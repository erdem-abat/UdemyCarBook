﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountByKmLowerThen1000Query : IRequest<GetCarCountByKmLowerThen1000QueryResult>
    {
    }
}