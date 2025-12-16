using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Security;

namespace InventoryManagement.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(JwtTokenGenerator jwt, IUserRepository userRepository)
        {
            _jwt = jwt;
            _userRepository = userRepository;
        }
        public async Task<string> LoginAsync(string phone, string password)
        {
            var user = await _userRepository.GetUserByPhoneAsync(phone);
            if (user == null || !user.CheckPassword(password))
            {
                throw new Exception("Invalid phone number or password.");
            }
            var token = _jwt.GenerateToken(user);
            return token;
        }

        public async Task<User> RigisterAsync(string fullname, string phone, int RoleId, string Password)
        {
            var exists = await _userRepository.GetUserByPhoneAsync(phone);
            if (exists != null)
                throw new Exception("This number is already used");
            var newUser = new User(fullname, phone, RoleId);

            newUser.SetPassword(Password);
            await _userRepository.AddAsync(newUser);
            return newUser;
        }
    }
}
