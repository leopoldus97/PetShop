using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity.AuthModels
{
    public class User
    {
        public User(long id, string name, string password)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
        }
        public long Id { get; }
        public string Username { get; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
