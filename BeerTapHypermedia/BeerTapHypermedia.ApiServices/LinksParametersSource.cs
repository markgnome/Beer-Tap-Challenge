namespace BeerTapHypermedia.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int officeId)
        {
            OfficeId = officeId;
        }

        public int OfficeId { get; private set; }
    }
}