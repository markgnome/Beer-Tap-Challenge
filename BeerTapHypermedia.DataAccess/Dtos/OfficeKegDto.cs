using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IQ.DataPersistenceFramework.DAL;
using IQ.Framework.Entities;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class OfficeKegDto: OfficeDto 
    {
        public int OfficeId => Id;
        public int? KegId { get; set; }
        public decimal? Quantity { get; set; }
        public int? BrandId { get; set; }
        public virtual ICollection<KegDto> Kegs { get; set; }
    }
}
