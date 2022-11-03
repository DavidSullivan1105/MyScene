using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class Venue
    {
        public int VenueID { get; set; }
        public String VenueName { get; set; }
        public String VenueAddress { get; set; }
        public int VenuePhone { get; set; }
        public bool Is21AndOver { get; set; }
        public VenueGenre VenueGenre { get; set; }


    }
    public enum VenueGenre { rock, jazz, hip_hop, country, dance}
}
