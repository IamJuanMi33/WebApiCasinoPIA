using System.ComponentModel.DataAnnotations;

namespace WebApiCasinoPIA.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} solo puede contener hasta 25 caracteres")]
        public string Nombre { get; set; }

        public List<ParticipanteRifa> ParticipanteRifa { get; set; }
        public List<Premio> Premio { get; set; }

        //// Validación por Modelo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ParticipanteRifa.Count() > 54)
            {
                yield return new ValidationResult("El límite de participantes por rifa es de 54",
                    new String[] { nameof(Premio) });
            }
        }
    }
}
