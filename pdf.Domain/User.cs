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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public User() 
        {
            Random rnd = new Random();
            Id = 0;
            Name = "User_" + (DateTimeOffset.UtcNow.ToUnixTimeSeconds()).ToString();
            Email = "default@gmail.com";
            Address = "Default default 1337";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
