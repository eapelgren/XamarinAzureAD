using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.Handler
{
    public static class MapperConfiguration
    {
        public static void Init()
        {
            Debug.WriteLine("Init Mapper");
            MapIUserDTO();
            MapINewsDTO();
        }

        private static void MapINewsDTO()
        {
            Mapper.CreateMap<NewsDTO, ObservableNews>().ConvertUsing<NewsConverter>();
        }

        private static void MapIUserDTO()
        {
            Mapper.CreateMap<IUserDTO, ObservableUser>()
                .ForMember(dest => dest.AuthorImageUri,
                    src => src.MapFrom(dto => new UriBuilder(dto.AuthorImageUri).Uri));
        }
    }

    internal class NewsConverter : ITypeConverter<NewsDTO, ObservableNews>
    {
        public ObservableNews Convert(ResolutionContext context)
        {
            throw new NotImplementedException("MAPPERCONFIG ERROR");

        }
    }
}