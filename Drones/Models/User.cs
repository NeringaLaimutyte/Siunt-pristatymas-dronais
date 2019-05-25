using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }

        public User(int id, string name, string password, string email, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }
        public User()
        {

        }
        public void EndSession()
        {

        }
        public string CheckUserRole()
        {
            return Role;
        }
        public void ValidateData()
        {

        }
    }
}