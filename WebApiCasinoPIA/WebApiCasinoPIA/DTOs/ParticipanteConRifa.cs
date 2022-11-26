namespace WebApiCasinoPIA.DTOs
{
    public class ParticipanteConRifa: GetParticipanteDTO
    {
        public List<RifaDTO> Rifas { get; set; }
    }
}
