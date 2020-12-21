using FluentValidation;
using KitchenChallenge.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenChallenge.API.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Order must not be null");
            RuleFor(x => x.Items).Must(i => i.Count > 0).WithMessage("Order must have one or more Item");
            RuleForEach(x => x.Items).SetValidator(new ItemValidator()).When(x => x.Items.Count > 0);
        }
    }
}
