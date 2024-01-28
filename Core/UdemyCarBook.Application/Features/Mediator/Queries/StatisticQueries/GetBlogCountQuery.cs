using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
namespace UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetBlogCountQuery : IRequest<GetBlogCountQueryResult>
    {
    }
}
