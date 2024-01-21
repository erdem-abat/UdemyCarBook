using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carrepository;

        public GetCarWithBrandQueryHandler(ICarRepository carrepository)
        {
            _carrepository = carrepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carrepository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Brand.Name,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}