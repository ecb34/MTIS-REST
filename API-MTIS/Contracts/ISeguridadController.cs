// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Seguridad.Models;


namespace API_MTIS.Seguridad
{
    public interface ISeguridadController
    {

        IHttpActionResult Get([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey);
        IHttpActionResult Post([FromBody] API_MTIS.Seguridad.Models.Permiso permiso);
        IHttpActionResult Delete([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey);
        IHttpActionResult GetByNif([FromUri] string Nif,[FromUri] string restkey);
    }
}
