using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Book.Detail;

public class DetailBookQuery : IRequest<Result<BookDetailResponseDto>>
{
    public int BookId { get; set; }
}
