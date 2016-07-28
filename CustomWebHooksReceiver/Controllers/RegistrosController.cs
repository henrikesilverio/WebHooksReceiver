using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CustomWebHooksReceiver.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CustomWebHooksReceiver.Controllers
{
    [RoutePrefix("api/Registros")]
    public class RegistrosController : ApiController
    {
        [Route("InscreverSe")]
        [HttpPost]
        public Task<HttpResponseMessage> InscreverSe(DadosInscricao dadosInscricao)
        {
            HttpResponseMessage response;
            try
            {
                const string serviceUrl = "http://localhost:48720";
                var client = new RestClient(serviceUrl);
                var request = new RestRequest("api/webhooks/registrations", Method.POST);
                var json = JsonConvert.SerializeObject(dadosInscricao);
                request.AddParameter("text/json", json, ParameterType.RequestBody);
                request.AddCookie(".AspNet.ApplicationCookie",
                    "XkWqJ905SdpHj3Rv7GjuGOjrqyubnFNgME_D_k9TjTgXb8s-HIEKTGRVyqG-XAFqJrk4HQ-EootgFG11cCzbk_hFKDIintaSjkv5h6YnrQ0rT_lB7ZhnrCvVeZhC6J2M1rZUSnY_3TrN7mbn3Hc4cX9WfA9HxOhCisXuim7hgD2EEFyXik3sU99YGjuuOlIsugp_m5Bd_OD2fGJJ1lD6U-IMDsBPO_-l-uBr-JK5BrV3ALZeAPLef4JAQY2PhCYrXWVroM_7S6CHiaN-L6K0nGanzMQGWn5pA1KUpG8bMsHdpEYOO8yhlgakbGEyZyJal4MmrslCg76JhFCcSHh_8Io7SrbXLHMmW7_WUUbSg4KucSzHpX4rdAPUhIUiOuac0WKDgDVqhep4jLKMoN8SG5pgnPpqelTk7kJM2ZuqoKmGe8C72YW_gqquXqaVIqg79eXxAr01663uiLkdSIVcqrqaldWqPD1J3fwIdF-VzyqMIVNw7tugKCUANdcUFKrN");
                var ret = client.Execute(request);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("CancelarInscricao")]
        [HttpDelete]
        public Task<HttpResponseMessage> CancelarInscricao()
        {
            HttpResponseMessage response;
            try
            {
                const string serviceUrl = "http://localhost:48720";
                var client = new RestClient(serviceUrl);
                var request = new RestRequest("api/webhooks/registrations", Method.DELETE);
                request.AddCookie(".AspNet.ApplicationCookie",
                    "XkWqJ905SdpHj3Rv7GjuGOjrqyubnFNgME_D_k9TjTgXb8s-HIEKTGRVyqG-XAFqJrk4HQ-EootgFG11cCzbk_hFKDIintaSjkv5h6YnrQ0rT_lB7ZhnrCvVeZhC6J2M1rZUSnY_3TrN7mbn3Hc4cX9WfA9HxOhCisXuim7hgD2EEFyXik3sU99YGjuuOlIsugp_m5Bd_OD2fGJJ1lD6U-IMDsBPO_-l-uBr-JK5BrV3ALZeAPLef4JAQY2PhCYrXWVroM_7S6CHiaN-L6K0nGanzMQGWn5pA1KUpG8bMsHdpEYOO8yhlgakbGEyZyJal4MmrslCg76JhFCcSHh_8Io7SrbXLHMmW7_WUUbSg4KucSzHpX4rdAPUhIUiOuac0WKDgDVqhep4jLKMoN8SG5pgnPpqelTk7kJM2ZuqoKmGe8C72YW_gqquXqaVIqg79eXxAr01663uiLkdSIVcqrqaldWqPD1J3fwIdF-VzyqMIVNw7tugKCUANdcUFKrN");
                var ret = client.Execute(request);
                response = Request.CreateResponse(HttpStatusCode.OK);
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
