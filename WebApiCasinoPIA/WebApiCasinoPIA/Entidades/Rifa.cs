namespace WebApiCasinoPIA.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<ParticipanteRifa> ParticipanteRifa { get; set; }
    }
}
