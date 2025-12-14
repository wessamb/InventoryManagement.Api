using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Command.UserCommand;

namespace InventoryManagement.Application.Command.UserCommandValidation
{
    public class LoginCommandValidation: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation() { 
        RuleFor(p=>p.phone).NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+?[0-9]\d{1,14}$").WithMessage("Invalid phone number format");
            RuleFor(p => p.password).NotEmpty().WithMessage("Password is required");

        }
    }
}
