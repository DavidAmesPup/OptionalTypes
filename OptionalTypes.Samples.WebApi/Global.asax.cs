using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using OptionalTypes.JsonConverters;

namespace OptionalTypes.Samples.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new OptionalConverter());

            // AreaRegistration.RegisterAllAreas();
            // WebApiConfig.Register(GlobalConfiguration.Configuration);
            // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // RouteConfig.RegisterRoutes(RouteTable.Routes);

            // GlobalConfiguration.Configure(WebApiConfig.Register);
            //  FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //  RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}