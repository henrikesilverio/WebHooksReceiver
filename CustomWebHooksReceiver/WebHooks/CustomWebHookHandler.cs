using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using CustomWebHooksReceiver.Controllers;
using Microsoft.AspNet.WebHooks;
using WebApi.OutputCache.V2;

namespace CustomWebHooksReceiver.WebHooks
{
    public class CustomWebHookHandler : WebHookHandler
    {
        public CustomWebHookHandler()
        {
            this.Receiver = "custom";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            //Remove o cache
            var request = (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"]; ;
            var cache = GlobalConfiguration.Configuration.CacheOutputConfiguration().GetCacheOutputProvider(request);
            cache.RemoveStartsWith(
                GlobalConfiguration.Configuration.CacheOutputConfiguration()
                    .MakeBaseCachekey((ClienteController t) => t.PesquisarCliente()));

            // Get data from WebHook
            var data = context.GetDataOrDefault<CustomNotifications>();

            // Get data from each notification in this WebHook
            foreach (var notification in data.Notifications)
            {
                //var a = notification["P1"];
            }

            return Task.FromResult(true);
        }
    }
}