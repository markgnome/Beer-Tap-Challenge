using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerTapHypermedia.DataAccess.Entities
{
    public partial class Office
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column(Order = 0)]
        public int Id { get; set; }


        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }


        [Column(Order = 2)]
        [StringLength(200)]
        public string Description { get; set; }


        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationId { get; set; }
    }
}
