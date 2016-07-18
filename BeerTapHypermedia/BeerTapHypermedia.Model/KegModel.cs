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
    /// Keg Entity Class
    /// </summary>
    public class KegModel :  IIdentifiable<int>, IStatefulKeg, IStatefulResource<KegState>
    {
        /// <summary>
        /// Default Full Quantity of a Keg
        /// </summary>
        public const decimal FullQuantity = 2000; // in ml = 5 gallons

        /// <summary>
        /// Identification
        /// </summary>
        public int KegId => Id;

        /// <summary>
        /// Keg Identifier from backend
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Keg State 
        /// </summary>
        public KegState KegState {
            get
            {
                if(Quantity == 0) { return KegState.Empty; }
                if(Quantity == FullQuantity) { return KegState.Full;}
                if (Quantity < FullQuantity && Quantity > (FullQuantity/4))
                {
                    return KegState.Reduced;
                }
                return KegState.Nearly;
            }
        }

        /// <summary>
        /// Default is 5 gl = 2000 ml
        /// </summary>
        public decimal Quantity { get; set; } 

        /// <summary>
        /// Keg Brand of Beer
        /// </summary>
        public KegBrand Brand { get; set; }
        /// <summary>
        /// Office 
        /// </summary>
        public int OfficeId { get; set; }

    }
}
