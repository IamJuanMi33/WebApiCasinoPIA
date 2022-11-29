namespace WebApiCasinoPIA.Entidades
{
    public class ParticipanteGanador
    {
        public int ParticipanteId;

        public int RifaId;

        public Participante Participante { get; set; }

        public Rifa Rifa { get; set; }

    }
}
