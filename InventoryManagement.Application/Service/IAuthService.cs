using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;

namespace InventoryManagement.Application.Service
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string phone, string password);
        Task<User> RigisterAsync(string fullname, string phone, int RoleId, string Password);
    }
}
