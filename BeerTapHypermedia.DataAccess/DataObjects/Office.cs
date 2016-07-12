using System.ComponentModel.DataAnnotations;
using IQ.DataPersistenceFramework.DAL;
using IQ.Framework.Entities;

namespace BeerTapHypermedia.DataAccess.DataObjects
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
        /// Entity Tenant Key
        /// </summary>
        [TenantKey]
        public int EntityId { get; set; }
        /// <summary>
        /// Name 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }


        
    }
}
