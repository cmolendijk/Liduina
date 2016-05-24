using HangoverApp.DL.Models.Profile;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using HangoverApp.DL.Models;

namespace HangoverApp.Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("Users");
            builder.EntitySet<Button>("Buttons");
            builder.EntitySet<AidRequest>("AidRequests");
            builder.EntitySet<AidOffer>("AidOffers");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}