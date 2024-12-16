using Application.Core;
using Application.Models.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries.Book.ListAll;

public class GetAllBookQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllBookQuery, Result<List<GetAllBookDto>>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<List<GetAllBookDto>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Book> books = _context.Books.Include(h => h.HotelRoom.Hotel).Include(r => r.HotelRoom.Room).ToList();
        List<GetAllBookDto> list = books.Select(b => b.toDto()).ToList();

        return Result<List<GetAllBookDto>>.Success(list);
    }
}
