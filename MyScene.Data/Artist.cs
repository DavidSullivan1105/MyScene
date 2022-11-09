using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class Artist
    {
        [Key]
        public int ArtistsId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public int ArtistPhone { get; set; }
        [Required]
        public string ArtistEmail { get; set; }
        public string Instrument { get; set; }
        [ForeignKey("BandId")]
        public List<string> Bands { get; set; }
        public Guid OwnerId { get; set; }
    }
}
