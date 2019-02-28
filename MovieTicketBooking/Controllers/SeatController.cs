using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    public class SeatController : Controller
    {
        // GET: Seat
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult Ticket()
        {
            return View();
        }

    }
}