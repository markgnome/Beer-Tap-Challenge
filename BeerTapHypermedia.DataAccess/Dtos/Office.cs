using System.ComponentModel.DataAnnotations;
using IQ.DataPersistenceFramework.DAL;
using IQ.Framework.Entities;

namespace BeerTapHypermedia.DataAccess.Dtos
{
    public class Office : IIdentifiable<int>
    {
        /// <summary>
        /// Id of iQ Office
        /// </summary>
        [Key]
        [RowKey]
        public int Id { get; set; }
        /// <summary>
        /// Name 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Location field
        /// </summary>
        public int LocationId { get; set; }


        
    }
}
