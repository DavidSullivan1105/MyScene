using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class ArtistBand
    {
        [Key]
        public int ArtistId { get; set; }
        public int BandId { get; set; }

        public virtual Artist Artist { get; set; } 
        public virtual Band Band { get; set; } 
        
       
    }



}
