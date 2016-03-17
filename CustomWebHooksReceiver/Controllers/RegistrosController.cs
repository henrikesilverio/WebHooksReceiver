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
                    "5hxbdSZhPkzpwHvO6GlFECAPX2X9N-ddHCGTOqbaLP_6riAmTu__yPA08Mg6f0jdTxy9pxvvxjb4_E9Lr-YwBWBt9cZ5bEBo1PuH9_S1opqNaXXWULFWs6oT8jfv2bFI7RTJhlErrj2kkrirOoQl41jfthq4jiKt32g8J7YwVMo9UbGHXOueojY2nAoQkInmSQavUiI3Pbea_WugkyjBa_JW2gaMDPWm44-xWmxChPjFrARP7SQ1r0ZbbiemuzyYhaDTzS3t8BnaDtD8BH207svyTEtYhGDHWOMwK_V_JVujkJlzBb_qaXMwacfsBhYzbLC5UroYyDktVCNJMveYt0b8kVvExgxYcGnmNcEN2s25Eep00jqwU0Ml16-D1AR_n1unt61WYEWdII30Ixx9JqavuyUAnbTiFQEjhuLYZ1iLbI-I2BWHjRBHnM9PoU8RnpmKKNJOEmzHJDH9_a2okgi4PfklQLAw3Z1pxnMrwvD7Ht8HxWdQYqZKcqhMeweq");
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
                    "5hxbdSZhPkzpwHvO6GlFECAPX2X9N-ddHCGTOqbaLP_6riAmTu__yPA08Mg6f0jdTxy9pxvvxjb4_E9Lr-YwBWBt9cZ5bEBo1PuH9_S1opqNaXXWULFWs6oT8jfv2bFI7RTJhlErrj2kkrirOoQl41jfthq4jiKt32g8J7YwVMo9UbGHXOueojY2nAoQkInmSQavUiI3Pbea_WugkyjBa_JW2gaMDPWm44-xWmxChPjFrARP7SQ1r0ZbbiemuzyYhaDTzS3t8BnaDtD8BH207svyTEtYhGDHWOMwK_V_JVujkJlzBb_qaXMwacfsBhYzbLC5UroYyDktVCNJMveYt0b8kVvExgxYcGnmNcEN2s25Eep00jqwU0Ml16-D1AR_n1unt61WYEWdII30Ixx9JqavuyUAnbTiFQEjhuLYZ1iLbI-I2BWHjRBHnM9PoU8RnpmKKNJOEmzHJDH9_a2okgi4PfklQLAw3Z1pxnMrwvD7Ht8HxWdQYqZKcqhMeweq");
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
