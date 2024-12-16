using Application.Core;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Persistence;

namespace Application.Commands.Book;

public class CreateBookCommandHandler(ApplicationDbContext context, IEmailService emailService) : IRequestHandler<CreateBookCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result<Unit>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Domain.Book book = request.BookRequest.fromRequest();
        _context.Books.Add(book);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to create the book");

        Domain.Contact contact = request.BookRequest.Contact.fromDto();
        contact.BookId = book.Id;
        _context.Contacts.Add(contact);

        List<Domain.Passenger> passengers = request.BookRequest.Passengers.Select(p => p.fromDto()).ToList();
        passengers.ForEach(passenger =>
        {
            passenger.BookId = book.Id;
            _context.Passengers.Add(passenger);
        });
        await _context.SaveChangesAsync();

        var bookedEmail = "Reserva realizada con exito en el hotel  del " + string.Format("{0:yyyy-MM-dd}", book.StartBook) + " al " + string.Format("{0:yyyy-MM-dd}", book.EndBook);

        MetadataEmail emailMetadata = new(book.Passengers.First().Email!, "Reserva realizada", bookedEmail);
        await _emailService.Send(emailMetadata);

        return Result<Unit>.Success(Unit.Value);
    }
}
