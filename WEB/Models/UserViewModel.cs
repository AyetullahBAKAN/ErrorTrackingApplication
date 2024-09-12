using Core.DTOs;
using Core.Models;

namespace WEB.Models
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public List<UserRole> Roles { get; set; }   
    }
}
