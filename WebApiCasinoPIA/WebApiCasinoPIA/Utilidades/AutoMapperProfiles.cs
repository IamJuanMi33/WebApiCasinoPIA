using AutoMapper;
using WebApiCasinoPIA.DTOs;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ParticipanteDTO, Participante>();
            CreateMap<Participante, GetParticipanteDTO>();
            CreateMap<Participante, ParticipanteConRifaDTO>().
                ForMember(participanteDTO => participanteDTO.Rifas, opciones => opciones.MapFrom(MapParticipanteRifaDTO));
            CreateMap<RifaCreacionDTO, Rifa>()
                .ForMember(rifa => rifa.ParticipanteRifa, opciones => opciones.MapFrom(MapParticipanteRifa));
            CreateMap<Rifa, RifaDTO>();
            CreateMap<Rifa, RifaConParticipanteDTO>()
                .ForMember(rifaDTO => rifaDTO.Participantes, opciones => opciones.MapFrom(MapRifaParticipnteDTO));
            CreateMap<RifaPatchDTO, Rifa>().ReverseMap();
            CreateMap<PremioCreacionDTO, Premio>();
            CreateMap<Premio, PremioDTO>();
            CreateMap<BoletoCreacionDTO, Boleto>();
            CreateMap<Boleto, BoletoDTO>();
        }

        private List<RifaDTO> MapParticipanteRifaDTO(Participante participate, GetParticipanteDTO getParticipanteDTO)
        {
            var result = new List<RifaDTO>();

            if(participate.ParticipanteRifa == null) { return result; }

            foreach (var participanteRifa in participate.ParticipanteRifa)
            {
                result.Add(new RifaDTO()
                {
                    Id = participanteRifa.RifaId,
                    Nombre = participanteRifa.Rifa.Nombre
                });
            }

            return result;
        }

        private List<GetParticipanteDTO> MapRifaParticipnteDTO(Rifa rifa, RifaDTO rifaDTO)
        {
            var result = new List<GetParticipanteDTO>();

            if(rifa.ParticipanteRifa == null)
            {
                return result;
            }

            foreach (var participanterifa in rifa.ParticipanteRifa)
            {
                result.Add(new GetParticipanteDTO()
                {
                    Id = participanterifa.ParticipanteId,
                    Nombre = participanterifa.Participante.Nombre
                });
            }

            return result;
        }

        private List<ParticipanteRifa> MapParticipanteRifa(RifaCreacionDTO rifaCreacionDTO, Rifa rifa)
        {
            var result = new List<ParticipanteRifa>();

            if(rifaCreacionDTO.ParticipantesIds == null)
            {
                return result;
            }

            foreach(var participantesId in rifaCreacionDTO.ParticipantesIds)
            {
                result.Add(new ParticipanteRifa() { ParticipanteId = participantesId });
            }

            return result;
        }

        private List<GetBoletoDTO> MapBoletoDTORifa(Rifa rifa)
        {
            var result = new List<GetBoletoDTO>();

            if (rifa.Boletos == null)
            {
                return result;
            }

            foreach (var boletoRifa in rifa.Boletos)
            {
                result.Add(new GetBoletoDTO()
                {
                    Id = boletoRifa.Id,
                    NombreRifa = boletoRifa.NombreRifa
                });
            }

            return result;
        }
    }
}
