using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Application.Command.UserCommand;

namespace InventoryManagement.Application.Command.UserCommandValidation
{
    public class RegisterUserCommandValidation: AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidation() { 
        RuleFor(x => x.fullname).NotEmpty().WithMessage("Full Name is required")
                .MaximumLength(100).WithMessage("Full Name must not exceed 100 characters");
            RuleFor(x => x.phone).NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[0-9]\d{1,14}$").WithMessage("Phone number is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role is required");
                
        }
    }
}
