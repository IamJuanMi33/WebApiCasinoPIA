using System.ComponentModel.DataAnnotations;
using WebApiCasinoPIA.Validaciones;

namespace WebApiCasinoPIA.Entidades
{
    public class Participante
    {
        public int Id { get; set; }

        // Validación por defecto
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede contener hasta 50 caracteres")]

        // Validación personalizada
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede contener hasta 50 caracteres")]
        public string Apellido { get; set; }

        public Boleto Boleto { get; set; }

        public List<ParticipanteRifa> ParticipanteRifa { get; set; }

        public List<Premio> Premio { get; set; }
    }
}
