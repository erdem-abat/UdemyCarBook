using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWithTimePeriod();
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Model = x.Model,
				Brand = x.Brand,
				CoverImageUrl = x.CoverImageUrl,
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2]
			}).ToList();
		}
	}
}
