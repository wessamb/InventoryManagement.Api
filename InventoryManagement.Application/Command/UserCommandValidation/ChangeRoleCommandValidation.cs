using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Command.UserCommand;

namespace InventoryManagement.Application.Command.UserCommandValidation
{
    public class ChangeRoleCommandValidation: AbstractValidator<ChangeRoleCommand>
    {
        public ChangeRoleCommandValidation() 
        { 
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.NewRoleId)
     .InclusiveBetween(1, 3)
     .WithMessage("NewRoleId must be between 1 and 3");
        }
    }
}
