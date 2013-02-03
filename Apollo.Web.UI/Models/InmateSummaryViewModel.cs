using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apollo.Web.UI.Models
{
    public class InmateSummaryViewModel
    {
        public int InmateID { get; set; }
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string DOB { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public Boolean IsInPopulation { get; set; }
        public string PropertyNumber { get; set; }
        public string Housing { get; set; }
        public string Classification { get; set; }

    }
}