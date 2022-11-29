﻿using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.DTOs
{
    public class PremioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public int? RifaId { get; set; }
        public int? ParticipanteId { get; set; }
        public Rifa Rifa { get; set; }
        public Participante Participante { get; set; }
    }
}
