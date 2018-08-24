using System.Web.Http;
using WebActivatorEx;
using Orders.Api;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Orders.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Orders Api");
                        c.IncludeXmlComments(GetXml());
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }

        protected static string GetXml()
        {
            return string.Format($"{System.AppDomain.CurrentDomain.BaseDirectory}\\bin\\Orders.Api.XML");
        }
    }
}
