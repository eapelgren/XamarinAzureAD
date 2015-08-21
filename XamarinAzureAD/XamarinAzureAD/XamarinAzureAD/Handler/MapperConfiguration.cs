﻿using System;
using System.Diagnostics;
using AutoMapper;
using DTOModel.Model;
using XamarinAzureAD.Model;

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
            AutoMapper.Mapper.CreateMap<NewsDTO, ObservableNews>().ConvertUsing<NewsConverter>();
        }

        private static void MapIUserDTO()
        {
            AutoMapper.Mapper.CreateMap<IUserDTO, ObservableUser>()
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