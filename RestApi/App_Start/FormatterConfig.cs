using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace RestApi
{
    public class FormatterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Remove support for XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Add support for Json Patch Media Type
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            //Format Json Output as Indented CamelCase
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
