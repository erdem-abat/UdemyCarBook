using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.PricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).ToList();
			return values;
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			/* Select * from(
             * Select Model, PricingID, Amount
             * From CarPricings
             * Inner Join Cars
             * On Cars.CarID = CarPricings.CarId
             * Inner Join Brands
             * On Brands.BrandID = Cars.BrandID
             * )
             * As SourceTable
             * Pivot(
             * Sum(Amount) For PricingID In([4],[3],[5])
             * ) as PivotTable;
             *   
             *    */

			var values = (from carPricing in _context.CarPricings
						  join car in _context.Cars on carPricing.CarID equals car.CarId
						  join brand in _context.Brands on car.BrandID equals brand.BrandID
						  group new { carPricing, brand, car } by new { brand.Name, car.Model, car.CoverImageUrl } into grouped
						  select new CarPricingViewModel
						  {
							  Brand = grouped.Key.Name,
							  Model = grouped.Key.Model,
							  CoverImageUrl = grouped.Key.CoverImageUrl,
							  Amounts = new List<decimal>
						{
							grouped.Sum(x => x.carPricing.PricingID == 4 ? x.carPricing.Amount : 0),
							grouped.Sum(x => x.carPricing.PricingID == 3 ? x.carPricing.Amount : 0),
							grouped.Sum(x => x.carPricing.PricingID == 5 ? x.carPricing.Amount : 0)
						}
						  }).ToList();
			
			return values;
		}
		//public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		//{
		//	List<CarPricingViewModel> values = new List<CarPricingViewModel>();
		//	using (var command = _context.Database.GetDbConnection().CreateCommand())
		//	{
		//		command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
		//		command.CommandType = System.Data.CommandType.Text;
		//		_context.Database.OpenConnection();
		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
		//				{
		//					Brand = reader["Name"].ToString(),
		//					Model = reader["Model"].ToString(),
		//					CoverImageUrl = reader["CoverImageUrl"].ToString(),
		//					Amounts = new List<decimal>
		//			{
		//				Convert.ToDecimal(reader["2"]),
		//				Convert.ToDecimal(reader["3"]),
		//				Convert.ToDecimal(reader["4"])
		//			}
		//				};
		//				values.Add(carPricingViewModel);
		//			}
		//		}
		//		_context.Database.CloseConnection();
		//		return values;
		//	}
		//}
	}
}
