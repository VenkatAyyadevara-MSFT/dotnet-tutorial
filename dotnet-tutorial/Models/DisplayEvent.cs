using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office365.OutlookServices;

namespace dotnet_tutorial.Models
{
    public class DisplayEvent
    {
        public string Subject { get; set; }
        public string Organizer { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LocationDisplayName { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCoordinates { get; set; }
        
        public DisplayEvent(string subject, string start, string end, Location location, Recipient organizer)
        {
            this.Subject = subject;
            this.Organizer = BuildOrganizerString(organizer);
            this.Start = DateTime.Parse(start);
            this.End = DateTime.Parse(end);
            this.LocationDisplayName = location.DisplayName ?? "null";
            this.LocationAddress = BuildAddressString(location.Address);
            this.LocationCoordinates = BuildCoordinatesString(location.Coordinates);
        }

        public String BuildOrganizerString(Recipient organizer)
        {
            return String.Format("{0} <{1}>",    
                organizer.EmailAddress.Name ?? "<No Name>",
                organizer.EmailAddress.Address
                );
        }

        public String BuildAddressString(PhysicalAddress address)
        {
            if (address == null)
            {
                return "null";
            }
            else {
                return String.Format("{0}, {1}, {2}, {3}", 
                    address.Street == "" ? "<No Street>" : address.Street, 
                    address.City == "" ? "<No City>" : address.City, 
                    address.State == "" ? "<No State>" : address.State,
                    address.CountryOrRegion == "" ? "<No Country Or Region>" : address.CountryOrRegion
                    );
            }
        }

        public String BuildCoordinatesString(GeoCoordinates coordinates)
        {
            if (coordinates == null)
            {
                return "null";
            }
            else
            {
                return String.Format("{0}, {1}", coordinates.Latitude, coordinates.Longitude);
            }
        }
    }
}