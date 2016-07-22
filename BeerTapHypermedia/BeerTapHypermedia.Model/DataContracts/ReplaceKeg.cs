using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.Model.DataContracts
{
    /// <summary>
    /// Keg Entity Class
    /// </summary>
    public class ReplaceKeg : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Keg ID 
        /// </summary>
        public int Id => KegId;

        /// <summary>
        /// Keg Brand of Beer
        /// </summary>
        public KegBrand Brand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int KegId { get; set; }
        /// <summary>
        /// Office Id
        /// </summary>
        public int OfficeId { get; set; }

    }
}
