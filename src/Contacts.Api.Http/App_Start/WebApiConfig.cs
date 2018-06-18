using Contacts.Interface;
using Contacts.Repository;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Unity.WebApi;

namespace Contacts.Api.Http
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container
                .RegisterType<IContactRepository, ContactRepository>();
            config.DependencyResolver = new UnityDependencyResolver(container);


            config.MapHttpAttributeRoutes();            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
                        
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;            
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Services.Replace(typeof(IExceptionHandler), new ProblemResponse());
        }
    }
}
