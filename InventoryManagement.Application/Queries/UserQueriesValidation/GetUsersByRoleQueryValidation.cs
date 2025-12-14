using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Queries.UserQueries;

namespace InventoryManagement.Application.Queries.UserQueriesValidation
{
    public class GetUsersByRoleQueryValidation: AbstractValidator<GetUsersByRoleQuery>
    {
        public GetUsersByRoleQueryValidation()
        {
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role must not be empty.")
                
                .WithMessage("Role must be either 'Admin', 'User', or 'Manager'.");

            RuleFor(x => x.PageNumber)
             .GreaterThan(0).WithMessage("Page number must be greater than 0.");
            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("Page size must not exceed 100.");
        }
    }
}
