using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool isDeleted { get; set; }
        public User() 
        {
            Random rnd = new Random();
            Id = 0;
            UserName = "User_" + (DateTimeOffset.UtcNow.ToUnixTimeSeconds()).ToString();
            Name = "John";
            LastName = "Doe";
            Email = "default@gmail.com";
            Address = "Default default 1337";
            isDeleted = false;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
