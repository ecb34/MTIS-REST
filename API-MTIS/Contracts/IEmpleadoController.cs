// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Empleado.Models;


namespace API_MTIS.Empleado
{
    public interface IEmpleadoController
    {

        IHttpActionResult Post([FromBody] API_MTIS.Empleado.Models.Empleado empleado);
        IHttpActionResult Get([FromUri] string Nif);
        IHttpActionResult Put([FromBody] API_MTIS.Empleado.Models.Empleado empleado,[FromUri] string Nif);
        IHttpActionResult Delete([FromUri] string Nif);
    }
}
