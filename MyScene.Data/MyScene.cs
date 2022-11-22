using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class MyScene
    {
        [Key]
        public Guid UserId { get; set; }
        
        public List<MySceneArtist> Artists { get; set; }
       
        public List<MySceneBand> Bands { get; set; }
        
        public List<MySceneVenue> Venues { get; set; }
    }
}
        
