using System.ComponentModel.DataAnnotations;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class LocationDto 
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
