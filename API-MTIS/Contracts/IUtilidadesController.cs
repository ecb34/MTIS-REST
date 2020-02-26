// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Utilidades.Models;


namespace API_MTIS.Utilidades
{
    public interface IUtilidadesController
    {

        IHttpActionResult Get([FromUri] string nif,[FromUri] string restkey);
        IHttpActionResult GetValidarNAFSS([FromUri] string nif,[FromUri] string restkey);
        IHttpActionResult GetValidarIBAN([FromUri] string nif,[FromUri] string restkey);
    }
}
