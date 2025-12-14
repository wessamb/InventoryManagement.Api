using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Queries.UserQueries;

namespace InventoryManagement.Application.Queries.UserQueriesValidation
{
    public class GetUserByIdQueryValidation:AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidation()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("UserId is required");
        }
    }
}
