using MyScenes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Models
{
    public class VenueListItem
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        public string ?VenueName { get; set; }
        [Required]
        public string ?VenueAddress { get; set; }
        [Required]
        public int VenuePhone { get; set; }
        [Required]
        public bool Is21AndOver { get; set; }
        public Genre VenueGenre { get; set; }
    }
}
