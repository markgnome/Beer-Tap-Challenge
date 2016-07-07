using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.Model
{
    /// <summary>
    /// Keg
    /// </summary>
    public class Keg : IStatefulResource<KegState>, IIdentifiable<string>, IStatefulKeg
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public KegState KegState { get; set; }
    }
}
