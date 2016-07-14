using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeerTapHypermedia.DataAccess.Dtos;
using BeerTapHypermedia.Model;

namespace BeerTapHypermedia.ApiServices.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<KegDto, Keg>().ReverseMap();
            Mapper.CreateMap<OfficeKegDto, Office>().ReverseMap();
            Mapper.CreateMap<Office, OfficeDto>().ReverseMap();
        }
    }
}
