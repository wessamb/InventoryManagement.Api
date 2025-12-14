using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Queries.UserQueries;

namespace InventoryManagement.Application.Queries.UserQueriesValidation
{
    public class GetAllUsersQueryValidation:AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersQueryValidation()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("Page size must not exceed 100.");

        }
    }
}
