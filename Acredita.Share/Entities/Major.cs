using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acredita.Share.Entities
{
    public class Major
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Carrera")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Duración")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public int duration { get; set; }
        public bool Active { get; set; }
    }
}
