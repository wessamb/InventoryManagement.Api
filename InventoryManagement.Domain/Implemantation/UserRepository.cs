using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Common;
using InventoryManagement.Application.Entites;

using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Queries.UserQueries;
using InventoryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Infrastructure.Implemantation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserRepository> _logger;
       
        public UserRepository(AppDbContext context,ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        
        }

     

        public async Task AddAsync(User user)
        {
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

    

        

        public async Task<IEnumerable<User>> GetAllUsersAsync(int PageNumber = 1, int PageSize = 10)
        {
            var users = await _context.Users.Include(x => x.Role).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            _logger.LogInformation("Retrieved {UserCount} users from the database.", users.Count);
            if (!users.Any())
                _logger.LogWarning("No users found for page {PageNumber}.", PageNumber);
            return users;
        }

        public async Task<IEnumerable<User>> GetAllUsersByRolesAsync(int RoleId, int PageNumber = 1, int PageSize = 10)
        {
            var query = _context.Users
                 .Include(x => x.Role)
                 .Where(x => x.RoleId == RoleId)
                 .OrderBy(x => x.FullName);
            var users = await query.ApplyPagination(PageNumber, PageSize).ToListAsync();
            if (!users.Any())
                _logger.LogWarning("No users found with RoleId: {RoleId}", RoleId);


            _logger.LogInformation("Retrieved {UserCount} users with RoleId: {RoleId}", users.Count, RoleId);
            return users;
        }

        public async Task<User> GetUserByIdAsync(int getUserById)
        {
            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.UserId == getUserById);
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserID} not found.", getUserById);
                throw new Exception("User Not Found");
            }
            _logger.LogInformation("User with ID {UserID} retrieved successfully.", getUserById);
            return user;
        }

        public async Task<User> GetUserByPhoneAsync(string getUserByPhone)
        {
            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber == getUserByPhone);
            if (user == null)
            {
                _logger.LogWarning("this number does not except");
                return null;
            }
            _logger.LogInformation($"this number is {getUserByPhone} ");
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            
          _context.Users.Update(user);
          await  _context.SaveChangesAsync();
        }


    }
}
