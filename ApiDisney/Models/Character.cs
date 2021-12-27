using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        [DataType(DataType.MultilineText)]
        public string Historia { get; set; }
       
    }
}
