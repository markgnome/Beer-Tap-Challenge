using IQ.Framework.Entities;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class Brand : IIdentifiable<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
