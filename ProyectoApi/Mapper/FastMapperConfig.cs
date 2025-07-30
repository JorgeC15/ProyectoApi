using FastMapper;
using ProyectoApi.Data.Model;
using ProyectoApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi.Mapper
{
    public static class FastMapperConfig
    {
        public static void Inicializa()
        {
            TypeAdapterConfig<BookDTO, Book>
                .NewConfig()
                .IgnoreMember(dest => dest.Id);
                //.MapFrom(dest => dest.PublishDate, src => src.PublishDate.ToShortDateString());
        }
    }
}