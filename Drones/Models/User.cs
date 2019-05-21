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
        public void EndSession()
        {

        }
        public void CheckUserRole()
        {

        }
        public void ValidateData()
        {

        }
    }
}