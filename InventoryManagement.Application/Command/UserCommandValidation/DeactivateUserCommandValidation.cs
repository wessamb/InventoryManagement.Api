using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Command.UserCommand;

namespace InventoryManagement.Application.Command.UserCommandValidation
{
    public class DeactivateUserCommandValidation: AbstractValidator<DeactivateUserCommand>
    {
        public DeactivateUserCommandValidation() { 
        RuleFor(x=>x.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
