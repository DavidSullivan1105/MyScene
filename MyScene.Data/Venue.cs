using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Data
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }
        [Required]
        public String VenueName { get; set; }
        [Required]
        public String VenueAddress { get; set; }
        [Required]
        public int VenuePhone { get; set; }
        [Required]
        public bool Is21AndOver { get; set; }

        public VenueGenre VenueGenre { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

    }
    public enum VenueGenre { rock, jazz, hip_hop, country, dance}
}
