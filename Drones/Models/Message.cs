using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Message
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public Customer Customer { get; set; }
        public void Select()
        {

        }
    }
}