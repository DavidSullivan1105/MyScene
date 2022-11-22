using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }
        [Required]
        public string BandName { get; set; }
        [Required]
        public Genre BandGenre { get; set; }
        [Required]
        //public List<string>? Albums { get; set; }
        public Guid OwnerId { get; set; }


    }

    public enum Genre { rock, jazz, hip_hop, country, dance}
}