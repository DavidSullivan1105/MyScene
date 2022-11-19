using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Models
{
    public class ArtistCreate
    {
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public string ArtistEmail { get; set; }
        [Required]
        public int ArtistPhone { get; set; }
        [Required]
        public string Instrument { get; set; }
        [Required]
        public string Band { get; set; }

    }
}
