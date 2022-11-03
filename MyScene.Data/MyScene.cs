using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class MyScene
    {
        public Guid UserId { get; set; }
        //[ForeignKey("ArtistsId")]
        public List<Artist> MyArtists { get; set; }
        //[ForeignKey("BandsId")]
        public List<int> MyBands { get; set; }
        //[ForeignKey("VenuesId")]
        public List<int> MyVenues { get; set; }
    }
}
