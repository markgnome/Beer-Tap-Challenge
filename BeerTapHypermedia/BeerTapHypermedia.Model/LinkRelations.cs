namespace BeerTapHypermedia.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Office = "iq:Office";

        /// <summary>
        /// link relation to describe the Identity resouce
        /// </summary>
        public const string Keg = "iq:Keg";



        /// <summary>
        /// Action link for beer kegs
        /// </summary>
        public static class Kegs
        {
            /// <summary>
            /// Link to describe multiple kegs
            /// </summary>
            public const string Kurl = "iq:Kegs";
            /// <summary>
            /// action link to replace keg from office
            /// </summary>
            public const string ReplaceKeg = "iq:Replace";
            /// <summary>
            /// action link to change keg from office
            /// </summary>
            public const string ChangeKeg = "iq:Change";
            /// <summary>
            /// Get a pint of beer 
            /// </summary>
            public const string TapBeer = "iq:TapBeer";
        }

    }
}
