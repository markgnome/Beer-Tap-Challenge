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
        /// 
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
    }
}
