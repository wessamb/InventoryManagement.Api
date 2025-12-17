using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Execption
{
    public class ValidationException : AppException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException(Dictionary<string, string[]> errors)
            : base("Validation failed", 400)
        {
            Errors = errors;
        }

        public ValidationException(string message)
            : base(message, 400)
        {
            Errors = new Dictionary<string, string[]>();
        }
    }

}
