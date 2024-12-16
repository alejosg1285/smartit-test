using Application.Core;
using Application.Models.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries.Book.Detail;

public class DetailBookQueryHandler(ApplicationDbContext context) : IRequestHandler<DetailBookQuery, Result<BookDetailResponseDto>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<BookDetailResponseDto>> Handle(DetailBookQuery request, CancellationToken cancellationToken)
    {
        Domain.Book book = _context.Books
            .Include(h => h.HotelRoom.Hotel)
            .Include(r => r.HotelRoom.Room)
            .Include(c => c.Contact)
            .Include(p => p.Passengers)
            .FirstOrDefault(b => b.Id == request.BookId);
        if (book is null)
        {
            return null;
        }

        BookDetailResponseDto detail = book.toDetailDto();

        return Result<BookDetailResponseDto>.Success(detail);
    }
}
