using MyScene.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Models
{
    public class VenueEdit
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public int VenuePhone { get; set; }
        public Genre VenueGenre { get; set; }
        public bool Is21AndOver { get; set; }

    }
}
