using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
            Mapper.CreateMap<INewsDTO, ObservableNews>().ConvertUsing<NewsConverter>();    
        }

        private static void MapIUserDTO()
        {
            Mapper.CreateMap<IUserDTO, ObservableUser>()
                .ForMember(dest => dest.AuthorImageUri,
                    src => src.MapFrom(dto => new UriBuilder(dto.AuthorImageUri).Uri));

        }
        
    }

    internal class NewsConverter : ITypeConverter<INewsDTO, ObservableNews>
    {
        public ObservableNews Convert(ResolutionContext context)
        {
            var newsDTO = (INewsDTO) context.SourceValue;
            Debug.WriteLine("STARTING CONVERT OF INEWS DTO");
            Debug.WriteLine(newsDTO.Header);
            var os = new ObservableNews();

            if (string.IsNullOrEmpty(newsDTO.AuthorId) || string.IsNullOrWhiteSpace(newsDTO.AuthorId))
            {
                os.AuthorUser = new ObservableUser()
                {
                    DisplayName = "No User Set for News"
                };
            }
            else
            {
                Debug.WriteLine("TRYING TO Collect User with ID: " + newsDTO.AuthorId);
                var authorList = Resolver.Resolve<IUserProvider>().GetUsersAsyncTask(newsDTO.AuthorId).Result;
                var authorDTO = authorList.FirstOrDefault(); 
                Debug.WriteLine("collected User: " + authorList.FirstOrDefault().DisplayName);
                Debug.WriteLine("Doing nested Mapping");
                os.AuthorUser = new ObservableUser()
                {
                    AuthorImageUri = new UriBuilder(authorDTO.AuthorImageUri).Uri,
                    DisplayName = authorDTO.DisplayName,
                    GivenName = authorDTO.GivenName,
                    Id = authorDTO.Id,
                    Location = authorDTO.Location,
                    SurName = authorDTO.SurName,
                    TelephoneNumber = authorDTO.TelephoneNumber
                };
                Debug.WriteLine("OS.AuthorUser Set");
            }

            os.Header = newsDTO.Header;
            os.DatePosted = newsDTO.DatePosted;
            os.Description = newsDTO.Description;
            os.Id = newsDTO.Id;
            os.PictureUri = new UriBuilder(newsDTO.PictureUri).Uri;
            return os;
            
        }
    }
}
