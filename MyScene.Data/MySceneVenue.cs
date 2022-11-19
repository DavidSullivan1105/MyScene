using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class MySceneVenue
    {
        [Key]
        public Guid Id { get; set; }
        public int VenueId { get; set; }

        public virtual MyScene MyVenue { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
