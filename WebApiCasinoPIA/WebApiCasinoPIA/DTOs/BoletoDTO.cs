namespace WebApiCasinoPIA.DTOs
{
    public class BoletoDTO
    {
        public int Id { get; set; }

        public string NombreRifa { get; set; }

        public int? ParticipanteId { get; set; }

        public int? RifaId { get; set; }
    }
}
