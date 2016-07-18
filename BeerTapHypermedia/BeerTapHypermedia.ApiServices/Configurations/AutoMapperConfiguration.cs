using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.ApiServices.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Keg, KegModel>().ForMember(d => d.Brand, s => s.MapFrom(c => c.BrandId));
            Mapper.CreateMap<KegModel, Keg>().ForMember(d => d.BrandId, s => s.MapFrom(c => c.Brand));
            Mapper.CreateMap<Office, OfficeModel>().ForMember(d => d.Location, s => s.MapFrom(c => c.LocationId)).ReverseMap();
            Mapper.CreateMap<OfficeModel, Office>().ReverseMap();
        }
    }
}
