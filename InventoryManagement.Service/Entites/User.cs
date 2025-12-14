

using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Application.Entites
{
    public class User 
    {
        public int UserId { get; private set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public bool IsActive { get; private set; }

        public string PasswordHash { get; set; }



        private User() { }

        public User(string fullName, string phoneNumber, int roleId)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
        public void Activate()
        {
            IsActive = true;
        }

        public void UpdateDetails(string fullName, string phoneNumber, int roleId)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
        }
        public void ChangeRole(int newRoleId)
        {
            RoleId = newRoleId;
        }
        public void UpdatePhone(string newPhone)
        {
            PhoneNumber = newPhone;
        }
        public bool IsAdmin() => Role.RoleName == "Admin";
        public bool CanManageSales() => Role.RoleName == "Sales" || Role.RoleName == "Admin";
        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // التحقق عند تسجيل الدخول
        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

    }
}
