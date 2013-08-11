using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdnugmeetinghtmlfragmentgenerator.Models;

namespace sdnugmeetinghtmlfragmentgenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new HtmlFragmentCreateVM();
            vm.MeetingDate = Get3rdWednesdayOfCurrentMonth();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(HtmlFragmentCreateVM vm)
        {
            vm.HtmlFragment = HTMLEVENTFORMATTER;
            return View(vm);
        }

        public string GenerateEvent(HtmlFragmentCreateVM vm)
        {
            return "";
        }

        public DateTime Get3rdWednesdayOfCurrentMonth()
        {
            var thirdWednesday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
            while (thirdWednesday.DayOfWeek != DayOfWeek.Wednesday)
            {
                thirdWednesday = thirdWednesday.AddDays(1);
            }

            return thirdWednesday;
        }

        private const string HTMLEVENTFORMATTER = @"
            <div class=""post speaker-event"">
		        <h1 class=""title"">{0} - Meeting</h1>
		        <div class=""entry"">
			        <p><b>When:</b> {1} 6:00 PM - 8:00 PM</p>
			        <p><b>Speaker:</b> {2}</p>
			        <p><b>Speaker Bio:</b> {3}</p>
			        <p><b>Topic:</b> {4}</p>
			        <p><b>Summary:</b></p>
			        <p>
				        {5}
			        </p>
			        <p><b>Location:</b> <a href=""http://www.cohabitat.us/shreveport"">CoHabitat</a> - 610 Commerce St., Shreveport, LA <a href=""map.asp"" class=""more"">map</a></p>
			        <p><b>RSVP:</b> <a href=""{6}"">Click here</a><p>
		        </div>
		        <div class=""meta""> 
			        <p class=""links""> posted{7}</p> 
		        </div> 
	        </div>";
    }
}
