using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Data
{
    public class Artists
    {
        [Key]
        public int ArtistsId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [ForeignKey("BandId")]
        public int Bands { get; set; }
        public Guid UserId { get; set; }
    }
}
