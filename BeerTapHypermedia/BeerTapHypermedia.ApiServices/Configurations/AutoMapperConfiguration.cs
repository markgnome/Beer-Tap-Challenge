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
            Mapper.CreateMap<KegDto, Keg>().ForMember(d => d.Brand, s => s.MapFrom(c => c.BrandId));
            Mapper.CreateMap<Keg, KegDto>().ForMember(d => d.BrandId, s => s.MapFrom(c => c.Brand));
            Mapper.CreateMap<OfficeKegDto, Office>().ForMember(d => d.Location, s => s.MapFrom(c => c.LocationId)).ReverseMap();
            Mapper.CreateMap<Office, OfficeDto>().ReverseMap();
        }
    }
}
