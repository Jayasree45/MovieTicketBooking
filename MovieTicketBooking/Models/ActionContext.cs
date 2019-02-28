using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieTicketBooking.Models
{
    public class ActionContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ActionContext() : base("name=ActionContext")
        {
        }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Action> Actions { get; set; }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Horror> Horrors { get; set; }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Comedy> Comedies { get; set; }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Family> Families { get; set; }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Adventure> Adventures { get; set; }

        public System.Data.Entity.DbSet<MovieTicketBooking.Models.Payment> Payments { get; set; }
    }
}
