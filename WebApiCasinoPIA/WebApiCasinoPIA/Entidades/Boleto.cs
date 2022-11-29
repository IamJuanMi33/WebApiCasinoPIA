using System.ComponentModel.DataAnnotations;

namespace WebApiCasinoPIA.Entidades
{
    public class Boleto
    {
        [Required]
        public int Id { get; set; }

        public string NombreRifa { get; set; }

        public int ParticipanteId { get; set; }

        public int RifaId { get; set; }
    }
}
