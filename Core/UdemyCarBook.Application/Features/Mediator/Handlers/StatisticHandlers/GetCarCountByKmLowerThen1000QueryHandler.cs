using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByKmLowerThen1000QueryHandler : IRequestHandler<GetCarCountByKmLowerThen1000Query, GetCarCountByKmLowerThen1000QueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByKmLowerThen1000QueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByKmLowerThen1000QueryResult> Handle(GetCarCountByKmLowerThen1000Query request, CancellationToken cancellationToken)
        {
            var count = _repository.GetCarCountByKmLowerThen1000();
            return new GetCarCountByKmLowerThen1000QueryResult
            {
                CarCountByKmLowerThen1000 = count
            };
        }
    }
}
