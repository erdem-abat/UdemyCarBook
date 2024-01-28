using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var data = _context.Comments
            .GroupBy(x => x.BlogID)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .FirstOrDefault();
            var value = _context.Blogs.Where(x => x.BlogID == data).Select(x => x.Title).FirstOrDefault();
            return value;
        }

        public string GetBrandNameByMaxCar()
        {
            //both works
            /*SELECT top 1 BrandID,Count(*) AS c   FROM Cars  GROUP BY BrandID order by Count(*) desc */
            //var data = _context.Cars
            //.GroupBy(car => car.BrandID)
            //.OrderByDescending(group => group.Count())
            //.Select(group => group.Key)
            //.FirstOrDefault();
            //var value = _context.Brands.Where(x => x.BrandID == data).Select(x => x.Name).FirstOrDefault();
            //return value;

            var values = _context.Cars.GroupBy(x => x.BrandID).Select(y => new
            {
                BrandID = y.Key,
                Count = y.Count()
            }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x=>x.BrandID == values.BrandID).Select(y=>y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 4).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 5).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 3).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var carId = _context.CarPricings.Where(x => x.PricingID == 4).OrderByDescending(x => x.Amount).Select(x => x.CarID).FirstOrDefault();
            var value = _context.Cars.Include(x => x.Brand).Where(x => x.CarId == carId).Select(x => x.Model + x.Brand.Name).FirstOrDefault();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var carId = _context.CarPricings.Where(x => x.PricingID == 4).OrderBy(x => x.Amount).Select(x => x.CarID).FirstOrDefault();
            var value = _context.Cars.Include(x => x.Brand).Where(x => x.CarId == carId).Select(x => x.Model + x.Brand.Name).FirstOrDefault();
            return value;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Electric").Count();
            return value;
        }

        public int GetCarCountByFuelPetrolOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Petrol" || x.Fuel == "Diesel").Count();
            return value;
        }

        public int GetCarCountByKmLowerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Auto").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
