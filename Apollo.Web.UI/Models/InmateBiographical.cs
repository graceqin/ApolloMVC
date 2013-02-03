using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apollo.Web.UI.Models
{
    public class InmateBiographical
    {
        public int InmateID { get; set; }
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public DateTimeOffset? DOB { get; set; }
        public string BirthOfPlace { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}