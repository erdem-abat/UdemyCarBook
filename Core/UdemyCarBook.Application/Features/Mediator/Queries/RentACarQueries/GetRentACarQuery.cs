using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationID { get; set; }

        public GetRentACarQuery(int locationID, bool available)
        {
            LocationID = locationID;
            Available = available;
        }

        public bool Available { get; set; }

    }
}
