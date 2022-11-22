using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Models
{
    public class ArtistDetail
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int ArtistPhone { get; set; }
        public string ArtistEmail { get; set; }
        public List<string> Bands { get; set; }
        public string Instrument { get; set; }


    }
}
