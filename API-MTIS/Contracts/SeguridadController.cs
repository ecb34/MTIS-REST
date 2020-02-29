// Template: Base Controller (ApiControllerBase.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Seguridad.Models;
using API_MTIS.Utilidades.Models;

// Do not modify this file. This code was generated by AMF Server Scaffolder

namespace API_MTIS.Seguridad
{
    [RoutePrefix("seguridad")]
    public partial class SeguridadController : ApiController
    {


/// <summary>
		/// Validar un permiso - /seguridad
		/// </summary>
		/// <param name="sala"></param>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadGet</returns>
        [ResponseType(typeof(MultipleSeguridadGet))]
        [HttpGet]
        [Route("seguridad")]
        public virtual IHttpActionResult GetBase([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((ISeguridadController)this).Get(sala,nif,restkey);
                    }

/// <summary>
		/// Crear un permiso para que un usuario pueda acceder a una sala - /seguridad
		/// </summary>
		/// <param name="permiso"></param>
		/// <returns>Error</returns>
        [ResponseType(typeof(Error))]
        [HttpPost]
        [Route("seguridad")]
        public virtual IHttpActionResult PostBase([FromBody] API_MTIS.Seguridad.Models.Permiso permiso)
        {
            // Do not modify this code
                        return  ((ISeguridadController)this).Post(permiso);
                    }

/// <summary>
		/// Borrar un permiso - /seguridad
		/// </summary>
		/// <param name="sala"></param>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>Error</returns>
        [ResponseType(typeof(Error))]
        [HttpDelete]
        [Route("seguridad")]
        public virtual IHttpActionResult DeleteBase([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((ISeguridadController)this).Delete(sala,nif,restkey);
                    }

/// <summary>
		/// Obtener los niveles a los que puede acceder el empleado - /seguridad/{nif}
		/// </summary>
		/// <param name="Nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadNifGet</returns>
        [ResponseType(typeof(MultipleSeguridadNifGet))]
        [HttpGet]
        [Route("{nif}")]
        public virtual IHttpActionResult GetByNifBase([FromUri] string Nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((ISeguridadController)this).GetByNif(Nif,restkey);
                    }
    }
}
