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
    public class OfficeKegModel : OfficeModel
    {
      
        /// <summary>
        /// Kegs in the office
        /// </summary>
        public IEnumerable<KegModel> Kegs { get; set; }
    }
}
