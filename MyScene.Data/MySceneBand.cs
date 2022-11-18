using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Data
{
    public class MySceneBand
    {
        [Key]
        public Guid UserId { get; set; }
        public int BandId { get; set; }

        public virtual MyScene MyBands  { get; set; }
        public virtual Band Band { get; set; }

    }
}
