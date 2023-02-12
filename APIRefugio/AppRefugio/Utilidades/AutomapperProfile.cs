using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AppRefugio.Migrations;
using AutoMapper;


namespace AppRefugio.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Animales, AnimalesDTO>();
            CreateMap<AnimalesCreacionDTO, Animales>();

            CreateMap<Veterinarios, VeterinarioDTO>();
            CreateMap<Veterinarios, VeterinariosDTOconAnimales>().ForMember(opciones => opciones.animalesDTOs, x => x.MapFrom(MapVeterinarioDTOconAnimalesDTO));
            CreateMap<VeterinarioCreacionDTO, Veterinarios>().ForMember(x => x.VeterinarioAnimales, opciones => opciones.MapFrom(MapVeterinariosAnimales));

            CreateMap<Adoptante, AdoptanteDTO>();
            CreateMap<AdoptanteCreacionDTO, Adoptante>();
            //CreateMap<Adoptante, AdoptantesListAnimalesDTO>();

            CreateMap<AnimalAdoptante, AnimalAdoptanteDTO>();
            CreateMap<AnimalAdoptanteCreacionDTO, AnimalAdoptante>().ForMember(opciones => opciones.AnimalesId, x => x.MapFrom(MapAdopciones));
        }

        private List<AnimalesDTO> MapVeterinarioDTOconAnimalesDTO(Veterinarios veterinarios, VeterinarioDTO veterinarioDTO)
        {
            var resultado = new List<AnimalesDTO>();

            if (veterinarios.VeterinarioAnimales == null)
            {
                return resultado;
            }

            foreach (var item in veterinarios.VeterinarioAnimales)
            {
                resultado.Add(new AnimalesDTO()
                {
                    Edad = item.Animales.Edad,
                    Nombre = item.Animales.Nombre,
                    Raza = item.Animales.Raza,
                    Especie = item.Animales.Especie,
                    Genero = item.Animales.Genero,
                    Id = item.Animales.Id,
                    Vacunas = item.Animales.Vacunas,
                    Descripcion = item.Animales.Descripcion,

                });

            }

            return resultado;
        }

        private List<VeterinariosAnimal> MapVeterinariosAnimales(VeterinarioCreacionDTO veterinarioCreacionDTO, Veterinarios veterinarios)
        {
            var resultado = new List<VeterinariosAnimal>();

            if (veterinarioCreacionDTO.AnimalesIds == null)
            {
                return resultado;
            }
            foreach (var animalesIds in veterinarioCreacionDTO.AnimalesIds)
            {
                resultado.Add(new VeterinariosAnimal()
                {
                    AnimalesId = animalesIds,
                });
            }
            return resultado;
        }

        private List<AnimalAdoptante> MapAdopciones(AnimalAdoptanteCreacionDTO animalAdoptanteCreacionDTO, AnimalAdoptante animalesAdoptante)
        {
            var lista = new List<AnimalAdoptante>();

            if (animalAdoptanteCreacionDTO.animalId == null)
            {
                return lista;
            }
            foreach (var AnimalesId in animalAdoptanteCreacionDTO.animalId)
            {
                lista.Add(new AnimalAdoptante()
                {
                    AnimalesId = AnimalesId, 
                });
            }
            return lista;
                        
        }


    }
}
