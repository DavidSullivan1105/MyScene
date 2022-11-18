using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Data
{
    public class MySceneArtist
    {
        [Key]
        public Guid UserId { get; set; }
        public int ArtistId { get; set; }


        public virtual MyScene MyArtists { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
