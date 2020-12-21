using FluentValidation;
using KitchenChallenge.Domain.Dishes;
using KitchenChallenge.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenChallenge.API.Validations
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Item must not be null");
            RuleFor(x => x.Description).NotNull().WithMessage("Item description must not be null");
            RuleFor(x => x.CookTime).Must(c => c > 0).WithMessage("Item CookTime must be greater than 0");
            RuleFor(x => x.Price).Must(c => c > 0).WithMessage("Item Price must be greater than 0");
        }
    }
}
