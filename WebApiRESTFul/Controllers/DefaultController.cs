using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiRESTFul.Controllers
{
    public class DefaultController : ApiController
    {


        [HttpGet]
        [Route("datahora/consulta")]
        public HttpResponseMessage GetDataHoraServidor()
        {
            try
            {
                var dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}
