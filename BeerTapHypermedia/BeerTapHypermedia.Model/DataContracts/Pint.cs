using BeerTapHypermedia.Model.Enums;

namespace BeerTapHypermedia.Model.DataContracts
{
    /// <summary>
    /// Keg Entity Class
    /// </summary>
    public class Pint
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
        public int Volume { get; set; }

    }
}
