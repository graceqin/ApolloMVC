using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Apollo.Web.UI.Models;

namespace Apollo.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to Elkhart County Jail Management System";

            return View();
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult Bookings_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetInmateBookings().ToDataSourceResult(request));
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]

        public ActionResult BookingsFilterMenu_FullName()
        {
            return Json(GetInmateBookings().Select(e => e.FullName).Distinct(), JsonRequestBehavior.AllowGet);
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult BookingsFilterMenu_BookingDate()
        {
            return Json(GetInmateBookings().Select(e => e.BookingDate).Distinct(), JsonRequestBehavior.AllowGet);
        } 

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        private static IEnumerable<InmateBookingViewModel> GetInmateBookings()
        {
            var bookings = GetBookingRecords()
                .Select(b => new InmateBookingViewModel
                   {
                    InmateID = b.InmateID,
                    BookingID = b.BookingID,
                    FullName = b.FullName,
                    BookingDate = b.BookingDate,
                    ReleaseDate = b.ReleaseDate,
                    BookingDateString = b.BookingDate.ToString("MM/dd/yyyy HH:mm"),
                    ReleaseDateString = b.ReleaseDate.HasValue ? b.ReleaseDate.Value.ToString("MM/dd/yyyy HH:mm") : string.Empty
                });

            return bookings;
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        private static IEnumerable<BookingRecord> GetBookingRecords()
        {
            var bookings = new List<BookingRecord>() 
                {
                    new BookingRecord(){ InmateID = 100, BookingID = 1,  FullName= "Will Smith", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 101, BookingID = 2,  FullName= "Jennifer Lawrence", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 102, BookingID = 3,  FullName= "Nick Halon", BookingDate = DateTimeOffset.Now, ReleaseDate = null},
                    new BookingRecord(){ InmateID = 103, BookingID = 4,  FullName= "Mary Smith", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 104, BookingID = 5,  FullName= "Jessica Smith", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 105, BookingID = 6,  FullName= "Brian Smith", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 106, BookingID = 7,  FullName= "Aaron Downs", BookingDate = DateTimeOffset.Now, ReleaseDate = null},
                    new BookingRecord(){ InmateID = 107, BookingID = 8,  FullName= "John Downs", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 108, BookingID = 9,  FullName= "Mark White", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow},
                    new BookingRecord(){ InmateID = 109, BookingID = 10, FullName= "Jordan Payne", BookingDate = DateTimeOffset.Now, ReleaseDate = null},
                    new BookingRecord(){ InmateID = 110, BookingID = 11, FullName= "Alice Smith", BookingDate = DateTimeOffset.Now, ReleaseDate = null},
                    new BookingRecord(){ InmateID = 111, BookingID = 12, FullName= "Terisa Swollen", BookingDate = DateTimeOffset.Now, ReleaseDate = DateTimeOffset.UtcNow}
                };

            return bookings;
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        //public ActionResult InmateInfo_Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    return Json(GetInmateSummary().ToDataSourceResult(request));
        //}

        [Authorize]
        public ActionResult GetInmateSummary(int inmateId)
        {
            return PartialView("InmateSummary", GetInmateSummaryData(inmateId));
        }

        // ----------------------------------------------------------------------------------------------------
        public static InmateSummaryViewModel GetInmateSummaryData(int inmateId)
        {
            var inmateSummary = GetInmateBio().Where(i => i.InmateID == inmateId).Select(b => new InmateSummaryViewModel
            {
                InmateID = b.InmateID,
                SSN = b.SSN,
                FirstName = b.FirstName,
                MiddleName = b.MiddleName,
                LastName = b.LastName,
                Sex = b.Sex,
                Race = b.Race,
                DOB = b.DOB.HasValue ? b.DOB.Value.ToString("MM/dd/yyyy HH:mm") : string.Empty,
                Height = b.Height,
                Weight = b.Weight,
                IsInPopulation = false,
                PropertyNumber = "3512345",
                Housing =  "34A-02-210"
            }).FirstOrDefault();

            return inmateSummary;
        }

        // ----------------------------------------------------------------------------------------------------
        [Authorize]
        private static IEnumerable<InmateBiographical> GetInmateBio()
        {
            var inmates = new List<InmateBiographical>() 
                {
                    new InmateBiographical(){ InmateID = 100,  LastName= "Will", MiddleName = "Andy", FirstName="Smith", 
                        DOB = DateTimeOffset.Now, Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 101,  LastName= "Lawrence", MiddleName = "Ana", FirstName="Jennifer", 
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 102,  LastName= "Hallon", MiddleName = "Andy", FirstName="Nick", 
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 103,  LastName= "Smith", MiddleName = "May", FirstName="Mary", 
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 104,  LastName= "Smith", MiddleName = "May", FirstName="Jessica",
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 105,  LastName= "Smith", MiddleName = "Molly", FirstName="Brian", 
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 106,  LastName= "Downs", MiddleName = "floyd", FirstName="Aaron", 
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"},
                    new InmateBiographical(){ InmateID = 107,  LastName= "Downs", MiddleName = "May", FirstName="John",  
                        DOB = DateTimeOffset.Now},
                    new InmateBiographical(){ InmateID = 108,  LastName= "White", MiddleName = "Baron", FirstName="Mark",  
                        DOB = DateTimeOffset.Now, Height =@"5'4''", Weight = null},
                    new InmateBiographical(){ InmateID = 109, LastName= "Payne", MiddleName = "Jake", FirstName="Jordan",  
                        DOB = DateTimeOffset.Now, Height = null},
                    new InmateBiographical(){ InmateID = 110, LastName= "Smith", MiddleName = "Avery", FirstName="Alice", 
                        DOB = DateTimeOffset.Now, Height = null},
                    new InmateBiographical(){ InmateID = 111, LastName= "Weary", MiddleName = "Grety", FirstName="Terisa",  
                        DOB = DateTimeOffset.Now,  Height= @"5'10''", Weight ="168"}
                };

            return inmates;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
