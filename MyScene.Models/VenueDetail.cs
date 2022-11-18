using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Models
{
    public class VenueDetail
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        
        public string VenueAddress { get; set; }
        public int VenuePhone { get; set; }
        public bool Is21AndOver { get; set; }
    }
}
