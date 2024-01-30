﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarId { get; set; }
        public int CarPricingID { get; set; }
        public string BrandName { get; set; }
        public decimal Amount { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
