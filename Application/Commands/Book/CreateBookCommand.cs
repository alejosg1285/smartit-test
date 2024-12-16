using Application.Core;
using Application.Models;
using MediatR;

namespace Application.Commands.Book;

public class CreateBookCommand : IRequest<Result<Unit>>
{
    public BookRequest? BookRequest { get; set; }
}
