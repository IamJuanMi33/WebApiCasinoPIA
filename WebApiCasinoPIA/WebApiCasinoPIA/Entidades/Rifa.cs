using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //[NotMapped]
        //public int Menor { get; set; }

        //[NotMapped]
        //public int Mayor { get; set; }

        //public List<ParticipanteRifa> ParticipanteRifa { get; set; }

        //// Validación por Modelo
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Nombre))
        //    {
        //        var primeraLetra = Nombre[0].ToString();

        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula",
        //                new String[] { nameof(Nombre) });
        //        }
        //    }

        //    if (Menor > Mayor)
        //    {
        //        yield return new ValidationResult("El valor de menor no puede ser mayor que el campo mayor",
        //            new String[] { nameof(Menor) });
        //    }
        //}
    }
}
