using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sdnugmeetinghtmlfragmentgenerator.Models
{
    public class HtmlFragmentCreateVM
    {
        public string HtmlFragment { get; set; }

        public DateTime MeetingDate { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerBio { get; set; }
        public string MeetingTopic { get; set; }
        public string MeetingTopicSummary { get; set; }
        public string RSVPFacebookLink { get; set; }
    }
}