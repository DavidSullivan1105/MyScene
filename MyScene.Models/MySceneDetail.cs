using MyScenes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Models
{
    public class MySceneDetail
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public List<MySceneArtist> Artists { get; set; }
        [Required]
        public List<MySceneBand> Bands { get; set; }
        [Required]
        public List<MySceneVenue> Venues { get; set; }
    }
}
