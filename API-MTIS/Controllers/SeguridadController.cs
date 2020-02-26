// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Seguridad.Models;

namespace API_MTIS.Seguridad
{
    public partial class SeguridadController : ISeguridadController
    {

/// <summary>
		/// Validar un permiso - /seguridad
		/// </summary>
		/// <param name="sala"></param>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadGet</returns>
        public IHttpActionResult Get([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey)
        {
            // TODO: implement Get - route: seguridad/seguridad
			// var result = new MultipleSeguridadGet();
			// return Ok(result);
			return Ok();
        }

/// <summary>
		/// Crear un permiso para que un usuario pueda acceder a una sala - /seguridad
		/// </summary>
		/// <param name="permiso"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Post([FromBody] API_MTIS.Seguridad.Models.Permiso permiso)
        {
            // TODO: implement Post - route: seguridad/seguridad
			// var result = new Error();
			// return Ok(result);
			return Ok();
        }

/// <summary>
		/// Borrar un permiso - /seguridad
		/// </summary>
		/// <param name="sala"></param>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Delete([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey)
        {
            // TODO: implement Delete - route: seguridad/seguridad
			// var result = new Error();
			// return Ok(result);
			return Ok();
        }

/// <summary>
		/// Obtener los niveles a los que puede acceder el empleado - /seguridad/{nif}
		/// </summary>
		/// <param name="Nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadNifGet</returns>
        public IHttpActionResult GetByNif([FromUri] string Nif,[FromUri] string restkey)
        {
            // TODO: implement GetByNif - route: seguridad/{nif}
			// var result = new MultipleSeguridadNifGet();
			// return Ok(result);
			return Ok();
        }

    }
}
