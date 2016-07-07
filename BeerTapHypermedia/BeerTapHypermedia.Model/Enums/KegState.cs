namespace BeerTapHypermedia.Model.Enums
{

    /// <summary>
    /// Enumeration for the Keg
    /// </summary>
    public enum KegState
    {
        /// <summary>
        /// Keg is full and no need to replace
        /// </summary>
        Full,
        /// <summary>
        /// Keg is reduced but no need to replace 
        /// </summary>
        Reduced,
        /// <summary>
        /// Keg is almost empty and need to replace 
        /// </summary>
        Nearly,
        /// <summary>
        /// Keg is empty and must replace
        /// </summary>
        Empty

    }
}
