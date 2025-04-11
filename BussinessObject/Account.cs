
using System.ComponentModel.DataAnnotations;

namespace BussinessObject
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; } = 1;
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
