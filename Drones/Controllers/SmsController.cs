using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio.Rest.Api.V2010.Account;
using Twilio;
using Twilio.Types;
using Twilio.TwiML;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;

namespace Drones.Controllers
{
    public class SmsController : Controller
    {
        // GET: Sms
        public ActionResult Index()
        {
            return View();
        }

        public void SendSms()
        { 
        }
    }
}