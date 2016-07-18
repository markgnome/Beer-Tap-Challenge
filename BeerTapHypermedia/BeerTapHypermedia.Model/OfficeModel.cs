using System.Collections.Generic;
using System.Runtime.InteropServices;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class OfficeModel : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the Office
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Office Id 
        /// </summary>
        public int OfficeId => Id;

        /// <summary>
        /// Name for the Office
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location of Office
        /// </summary>
        public OfficeLocation Location { get; set; }

        /// <summary>
        /// Description for the Office
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Kegs in the office
        /// </summary>
        public IEnumerable<KegModel> Kegs { get; set; }
    }
}
