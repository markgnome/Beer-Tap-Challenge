using System.Web.Http;
using BeerTapHypermedia.ApiServices.Configurations;
using BeerTapHypermedia.WebApi.Infrastructure;

namespace BeerTapHypermedia.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BootStrapper.Initialize(GlobalConfiguration.Configuration);
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}