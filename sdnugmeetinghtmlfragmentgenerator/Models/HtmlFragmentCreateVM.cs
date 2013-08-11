using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sdnugmeetinghtmlfragmentgenerator.Models
{
    public class HtmlFragmentCreateVM
    {
        public string HtmlFragment { get; set; }

        [DisplayName("Meeting Date")]
        public DateTime MeetingDate { get; set; }

        [DisplayName("Speaker Name")]
        public string SpeakerName { get; set; }

        [DisplayName("Speaker Bio")]
        public string SpeakerBio { get; set; }

        [DisplayName("Meeting Topic")]
        public string MeetingTopic { get; set; }

        [DisplayName("Meeting Topic Summary")]
        public string MeetingTopicSummary { get; set; }

        [DisplayName("RSVP Facebook Link")]
        public string RSVPFacebookLink { get; set; }
    }
}