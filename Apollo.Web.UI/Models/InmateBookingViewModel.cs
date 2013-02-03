using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apollo.Web.UI.Models
{
    public class InmateBookingViewModel
    {
        public int InmateID { get; set; }
        public int BookingID { get; set; }
        public string FullName { get; set; }
        public string BookingDateString { get; set; }
        public DateTimeOffset BookingDate { get; set; }
        public string ReleaseDateString { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
    }
}