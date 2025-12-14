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
using InventoryManagement.Application.Exceptions;
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
        private readonly JwtTokenGenerator _jwt;
        public UserRepository(AppDbContext context,ILogger<UserRepository> logger,JwtTokenGenerator jwt)
        {
            _context = context;
            _logger = logger;
            _jwt = jwt;
        }

        public async Task<string> ActivateUserAsync(int activateUser)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.UserId == activateUser);
            if (user == null)
            {
                _logger.LogWarning("Activation failed. User with ID {UserId} not found.", activateUser);
                throw new Exception("User not found");
            }
            user.Activate();
            await _context.SaveChangesAsync();
            _logger.LogInformation("USER Activated Successfully ");
            return "change stats User to Activate";
        }

        public async Task<string> ChangeRoleAsync(int UserId, int NewRoleId)
        {
            var Change = await _context.Users.FirstOrDefaultAsync(u => u.UserId == UserId);
            if (Change == null)
            {
                _logger.LogWarning("USER Not Found ");
                return "User not found";
            }
            Change.ChangeRole(NewRoleId);

            await _context.SaveChangesAsync();
            _logger.LogInformation("User role changed successfully ");
            return "User role changed successfully";
        }

        public async Task<string> DeactivateUserAsync(int deactivateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == deactivateUser);
            if (user == null)
            {
                _logger.LogWarning("USER Not Found ");
                throw new Exception("User not found");
            }
            user.Deactivate();
            await _context.SaveChangesAsync();
            _logger.LogInformation("USER Deactivated Successfully ");
            return "change stats User to Deactivate ";
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

        public async Task<string> LoginAsync(string phone, string password)
        {
            var user = await _context.Users.Include(x => x.Role)
      .FirstOrDefaultAsync(x => x.PhoneNumber == phone);

            if (user == null)
            {
                _logger.LogInformation("USER Not Found ");
                throw new NotFoundException("User not found");
            }
            if (!user.CheckPassword(password))
            {
                _logger.LogWarning("Invalid password ");
                throw new Exception("Invalid password");
            }

            return _jwt.GenerateToken(user);
        }

        public async Task<User> RigisterAsync(string fullname, string phone, int RoleId, string Password)
        {
            // 1. فحص إذا الرقم موجود مسبقًا
            var exists = await _context.Users
                .AnyAsync(x => x.PhoneNumber == phone);

            if (exists)
                throw new Exception("This number is already used");

            // 2. إنشاء المستخدم الجديد
            var newUser = new User(fullname,phone, RoleId);

            newUser.SetPassword(Password);

            // 3. إضافة المستخدم
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // 4. إرجاع المستخدم
            return newUser;
        }
    }
}
