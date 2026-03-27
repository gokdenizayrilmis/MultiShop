using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handl(CreateOrderDetailCommand handler) 
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount = handler.ProductAmount,
                ProductId = handler.ProductId,
                ProductName = handler.ProductName,
                ProductPrice = handler.ProductPrice,
                ProductTotalPrice = handler.ProductTotalPrice,
                OrderingId = handler.OrderingId,
            });
        }



    }
}
