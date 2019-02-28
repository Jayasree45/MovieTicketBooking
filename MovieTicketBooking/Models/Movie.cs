using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBooking.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int movieid { get; set; }

        [StringLength(100,ErrorMessage ="max length should be 100")]
        public string moviename { get; set; }

        [DataType(DataType.Date)]
        public DateTime releasedate { get; set; }

        [StringLength(100, ErrorMessage = "max length should be 100")]
        public string description { get; set; }

        public byte image { get; set; }
    }
}