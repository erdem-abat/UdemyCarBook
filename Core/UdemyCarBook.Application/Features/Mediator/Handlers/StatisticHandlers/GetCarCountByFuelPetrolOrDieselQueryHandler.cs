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
    public class GetCarCountByFuelPetrolOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelPetrolOrDieselQuery, GetCarCountByFuelPetrolOrDieselQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByFuelPetrolOrDieselQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByFuelPetrolOrDieselQueryResult> Handle(GetCarCountByFuelPetrolOrDieselQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.GetCarCountByFuelPetrolOrDiesel();
            return new GetCarCountByFuelPetrolOrDieselQueryResult
            {
                CarCountByFuelPetrolOrDiesel = count
            };
        }
    }
}
