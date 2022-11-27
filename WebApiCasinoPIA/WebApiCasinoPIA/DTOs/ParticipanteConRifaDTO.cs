namespace WebApiCasinoPIA.DTOs
{
    public class ParticipanteConRifaDTO: GetParticipanteDTO
    {
        public List<RifaDTO> Rifas { get; set; }
    }
}
