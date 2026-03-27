using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repoistory;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repoistory)
        {
            _repoistory = repoistory;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repoistory.GetByIdAsync(request.OrderingId);
            value.OrderDate = request.OrderDate;
            value.TotalPrice = request.TotalPrice;
            value.OrderDetails = value.OrderDetails;
            value.OrderingId = request.OrderingId;
            await _repoistory.UpdateAsync(value);
        }
    }
}
