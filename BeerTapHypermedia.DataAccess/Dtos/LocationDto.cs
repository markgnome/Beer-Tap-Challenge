using System.ComponentModel.DataAnnotations;
using IQ.Framework.Entities;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class LocationDto : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
