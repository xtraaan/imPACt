using System;
using System.Collections.Generic;
using System.Text;

namespace imPACt
{
    public class EventApp
    {
        public int ImpactEventId { get; set; }

        public string EventName { get; set; }

        public string Sponsor { get; set; }

        public string PictureUrl { get; set; }

        public EventApp(int impactEventId, string eventName, string sponsor, string pictureUrl)
        {
            ImpactEventId = impactEventId;
            EventName = eventName;
            Sponsor = sponsor;
            PictureUrl = pictureUrl;
        }

        public EventApp()
        {
        }
    }
}
