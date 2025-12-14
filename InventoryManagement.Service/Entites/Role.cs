using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; private set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();

        public Role() { }

        public Role(string roleName, string description = null)
        {
           
            RoleName = roleName;
            Description = description;
        }

        public void Rename(string newName)
        {
            RoleName = newName;
        }
    }
}
