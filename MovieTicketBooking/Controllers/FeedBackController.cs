using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult Rating()
        {
            return View();
        }
    }
}