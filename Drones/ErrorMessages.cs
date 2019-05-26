using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones
{
    public class ErrorMessages : Exception
    {
        const string message = "...";
        public ErrorMessages(string auxMessage, Exception inner):base(String.Format("{0} - {1}", message, auxMessage), inner)
        {
            this.HelpLink = "";
            this.Source = "";
        }
    }
}