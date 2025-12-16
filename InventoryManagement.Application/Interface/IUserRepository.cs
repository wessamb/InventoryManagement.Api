using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Queries.UserQueries;

namespace InventoryManagement.Application.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int getUserById);   
            Task<User> GetUserByPhoneAsync(string getUserByPhone);

        Task<IEnumerable<User>> GetAllUsersAsync(int PageNumber = 1, int PageSize = 10);

        Task<IEnumerable<User>> GetAllUsersByRolesAsync(int RoleId, int PageNumber = 1, int PageSize = 10);

        Task UpdateAsync(User user);

        Task AddAsync(User user);









    }
}
