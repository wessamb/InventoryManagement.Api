using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Queries.UserQueries;

namespace InventoryManagement.Application.Queries.UserQueriesValidation
{
    public class GetUserByPhoneQueryValidation: AbstractValidator<GetUserByPhoneQuery>
    {
        public GetUserByPhoneQueryValidation() {
            RuleFor(p => p.phone).NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format");
        }
    }
}
