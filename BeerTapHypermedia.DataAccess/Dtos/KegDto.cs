using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class KegDto
    {
        [Key]
        public int? Id { get; set; }
        public decimal? Quantity { get; set; }
        public int? BrandId { get; set; }
    }
}
