// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Utilidades.Models;

namespace API_MTIS.Utilidades
{
    public partial class UtilidadesController : IUtilidadesController
    {

/// <summary>
		/// valida el NIF de un empleado - /Utilidades/validarNIF
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNIFGet</returns>
        public IHttpActionResult Get([FromUri] string nif,[FromUri] string restkey)
        {
            // TODO: implement Get - route: Utilidades/validarNIF
			// var result = new MultipleUtilidadesValidarNIFGet();
			// return Ok(result);
			return Ok();
        }

/// <summary>
		/// valida el NAFSS de un empleado - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNAFSSGet</returns>
        public IHttpActionResult GetValidarNAFSS([FromUri] string nif,[FromUri] string restkey)
        {
            // TODO: implement GetValidarNAFSS - route: Utilidades/validarNAFSS
			// var result = new MultipleUtilidadesValidarNAFSSGet();
			// return Ok(result);
			return Ok();
        }

/// <summary>
		/// valida el IBAN de un empleado - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarIBANGet</returns>
        public IHttpActionResult GetValidarIBAN([FromUri] string nif,[FromUri] string restkey)
        {
            // TODO: implement GetValidarIBAN - route: Utilidades/validarIBAN
			// var result = new MultipleUtilidadesValidarIBANGet();
			// return Ok(result);
			return Ok();
        }

    }
}
