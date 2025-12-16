using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Security;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
         
        }
        public async Task ActivateAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            user.Activate();
            await _userRepository.UpdateAsync(user);
        }
        public async Task  DeactivateUserAsync(int userId) {

            var user = await _userRepository.GetUserByIdAsync(userId);
            user.Deactivate();
            await _userRepository.UpdateAsync(user);
        }
        public async Task ChangeUserRoleAsync(int userId, int newRoleId) {
            var user = await _userRepository.GetUserByIdAsync(userId);
            user.ChangeRole(newRoleId);
            await _userRepository.UpdateAsync(user);
        }

 
    }
}
