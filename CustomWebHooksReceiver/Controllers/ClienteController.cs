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
                    "5hxbdSZhPkzpwHvO6GlFECAPX2X9N-ddHCGTOqbaLP_6riAmTu__yPA08Mg6f0jdTxy9pxvvxjb4_E9Lr-YwBWBt9cZ5bEBo1PuH9_S1opqNaXXWULFWs6oT8jfv2bFI7RTJhlErrj2kkrirOoQl41jfthq4jiKt32g8J7YwVMo9UbGHXOueojY2nAoQkInmSQavUiI3Pbea_WugkyjBa_JW2gaMDPWm44-xWmxChPjFrARP7SQ1r0ZbbiemuzyYhaDTzS3t8BnaDtD8BH207svyTEtYhGDHWOMwK_V_JVujkJlzBb_qaXMwacfsBhYzbLC5UroYyDktVCNJMveYt0b8kVvExgxYcGnmNcEN2s25Eep00jqwU0Ml16-D1AR_n1unt61WYEWdII30Ixx9JqavuyUAnbTiFQEjhuLYZ1iLbI-I2BWHjRBHnM9PoU8RnpmKKNJOEmzHJDH9_a2okgi4PfklQLAw3Z1pxnMrwvD7Ht8HxWdQYqZKcqhMeweq");
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
