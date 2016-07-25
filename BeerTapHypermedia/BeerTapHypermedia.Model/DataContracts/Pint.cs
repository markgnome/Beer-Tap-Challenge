using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.Model.DataContracts
{
    /// <summary>
    /// Keg Entity Class
    /// </summary>
    public class Pint : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Volume
        /// </summary>
        public decimal Volume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int KegId { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public int KegId { get; set; }
        /// <summary>
        /// Office Id
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id => KegId;
    }
}
