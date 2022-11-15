using MyScene.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Models
{
    public class BandListItem
    {
        [Key]
        public int BandId { get; set; }
        [Required]
        public string BandName { get; set; }
        public Genre Genre { get; set; }


    }
}
