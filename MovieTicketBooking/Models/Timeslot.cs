using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieTicketBooking.Models
{
    public class Timeslot
    {
        [StringLength(100, ErrorMessage = "max length should be 100")]
        public string theatername { get; set; }

        [DataType(DataType.Date)]
        public DateTime showtime { get; set; }

        [DataType(DataType.Date)]
        public DateTime calendar { get; set; }
    }
}