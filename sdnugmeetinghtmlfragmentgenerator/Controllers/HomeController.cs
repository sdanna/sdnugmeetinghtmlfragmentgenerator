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
            vm.HtmlFragment = GenerateEvent(vm);
            return View(vm);
        }

        public string GenerateEvent(HtmlFragmentCreateVM vm)
        {
            return string.Format(HTMLEVENTFORMATTER,
                                 vm.MeetingDate.ToString("MMMM"),
                                 vm.MeetingDate.ToShortDateString(),
                                 vm.SpeakerName,
                                 vm.SpeakerBio,
                                 vm.MeetingTopic,
                                 vm.MeetingTopicSummary,
                                 CENTENARY_LOCATION,
                                 vm.RSVPFacebookLink,
                                 DateTime.Now.ToShortDateString());
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
		        <h1 class=""title"">{0} Meeting</h1>
		        <div class=""entry"">
			        <p><b>When:</b> {1} 6:00 PM - 8:00 PM</p>
			        <p><b>Speaker:</b> {2}</p>
			        <p><b>Speaker Bio:</b> {3}</p>
			        <p><b>Topic:</b> {4}</p>
			        <p><b>Summary:</b></p>
			        <p>
				        {5}
			        </p>
			        {6}
			        <p><b>RSVP:</b> <a href=""{7}"">Click here</a><p>
		        </div>
		        <div class=""meta""> 
			        <p class=""links""> posted {8} by Steven D'Anna</p> 
		        </div> 
	        </div><hr />";

        private const string COHAB_LOCATION = @"<p><b>Location:</b> <a href=""http://www.cohabitat.us/shreveport"">CoHabitat</a> - 610 Commerce St., Shreveport, LA  71101<a href=""map.asp"" class=""more"">map</a></p>";
        private const string CENTENARY_LOCATION = @"<p><b>Location:</b> <a href=""http://www.centenary.edu/campusmap"">Centenary College</a> Jackson Hall, Room 211 - 2911 Centenary Boulevard, Shreveport, LA  71104</p>";
    }
}
