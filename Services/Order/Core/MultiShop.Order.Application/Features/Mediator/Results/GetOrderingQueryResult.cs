using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.Mediator.Results
{
    public class GetOrderingQueryResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
