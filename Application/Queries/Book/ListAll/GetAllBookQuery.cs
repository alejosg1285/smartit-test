using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Book.ListAll;

public class GetAllBookQuery : IRequest<Result<List<GetAllBookDto>>>
{
}
