﻿using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]

        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]

        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]

        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogCount")]

        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]

        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForDaily")]

        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]

        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForMonthly")]

        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByTransmissionIsAuto")]

        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var value = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandNameByMaxCar")]

        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogTitleByMaxBlogComment")]

        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var value = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByKmLowerThen1000")]

        public async Task<IActionResult> GetCarCountByKmLowerThen1000()
        {
            var value = await _mediator.Send(new GetCarCountByKmLowerThen1000Query());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelPetrolOrDiesel")]

        public async Task<IActionResult> GetCarCountByFuelPetrolOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelPetrolOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelElectric")]

        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }
    }
}
