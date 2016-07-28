using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CustomWebHooksReceiver.Models;
using RestSharp;
using WebApi.OutputCache.V2;

namespace CustomWebHooksReceiver.Controllers
{
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        [Route("PesquisarCliente")]
        [HttpGet]
        [CacheOutput(ServerTimeSpan = int.MaxValue)]
        public Task<HttpResponseMessage> PesquisarCliente()
        {
            HttpResponseMessage response;
            try
            {
                const string serviceUrl = "http://localhost:48720";
                var client = new RestClient(serviceUrl);
                var request = new RestRequest("api/Cliente/ConsultaClientes", Method.GET);
                request.AddCookie(".AspNet.ApplicationCookie",
                    "XkWqJ905SdpHj3Rv7GjuGOjrqyubnFNgME_D_k9TjTgXb8s-HIEKTGRVyqG-XAFqJrk4HQ-EootgFG11cCzbk_hFKDIintaSjkv5h6YnrQ0rT_lB7ZhnrCvVeZhC6J2M1rZUSnY_3TrN7mbn3Hc4cX9WfA9HxOhCisXuim7hgD2EEFyXik3sU99YGjuuOlIsugp_m5Bd_OD2fGJJ1lD6U-IMDsBPO_-l-uBr-JK5BrV3ALZeAPLef4JAQY2PhCYrXWVroM_7S6CHiaN-L6K0nGanzMQGWn5pA1KUpG8bMsHdpEYOO8yhlgakbGEyZyJal4MmrslCg76JhFCcSHh_8Io7SrbXLHMmW7_WUUbSg4KucSzHpX4rdAPUhIUiOuac0WKDgDVqhep4jLKMoN8SG5pgnPpqelTk7kJM2ZuqoKmGe8C72YW_gqquXqaVIqg79eXxAr01663uiLkdSIVcqrqaldWqPD1J3fwIdF-VzyqMIVNw7tugKCUANdcUFKrN");
                var ret = client.Execute<List<ClienteModel>>(request);
                response = Request.CreateResponse(HttpStatusCode.OK, ret.Data);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
