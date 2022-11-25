using System.ComponentModel.DataAnnotations;

namespace WebApiCasinoPIA.DTOs
{
    public class RifaDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} solo puede contener hasta 25 caracteres")]
        public string Nombre { get; set; }
    }
}
