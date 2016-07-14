using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({id})");

        public override string EntrypointRelation => LinkRelations.Office;
    }
}