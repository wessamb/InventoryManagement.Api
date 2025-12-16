using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Service
{
    public interface IUserService
    {
        Task ActivateAsync(int userId);
        Task DeactivateUserAsync(int userId);

        Task ChangeUserRoleAsync(int userId, int newRoleId);
    }
}
