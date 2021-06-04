using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialApl2.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MinLength(3,ErrorMessage ="La Descripcion es muy corta")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Costo { get; set; }
        public decimal Inventario { get; set; }
    }
}
