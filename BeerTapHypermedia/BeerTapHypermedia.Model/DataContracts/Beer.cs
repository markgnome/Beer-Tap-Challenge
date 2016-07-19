using BeerTapHypermedia.Model.Enums;

namespace BeerTapHypermedia.Model.DataContracts
{
    /// <summary>
    /// Keg Entity Class
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Keg Id
        /// </summary>
        public int KegId { get; set; }

        /// <summary>
        /// Office Id
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public KegBrand Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Volume { get; set; }

    }
}
