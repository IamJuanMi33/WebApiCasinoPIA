using System.ComponentModel.DataAnnotations;
using WebApiCasinoPIA.Validaciones;

namespace WebApiCasinoPIA.DTOs
{
    public class ParticipanteDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede contener hasta 50 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede contener hasta 50 caracteres")]
        [PrimeraLetraMayuscula]
        public string Apellido { get; set; }

    }
}
