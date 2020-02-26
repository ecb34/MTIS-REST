// Template: Base Controller (ApiControllerBase.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Utilidades.Models;

// Do not modify this file. This code was generated by AMF Server Scaffolder

namespace API_MTIS.Utilidades
{
    [RoutePrefix("Utilidades")]
    public partial class UtilidadesController : ApiController
    {


/// <summary>
		/// valida el NIF de un empleado - /Utilidades/validarNIF
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNIFGet</returns>
        [ResponseType(typeof(MultipleUtilidadesValidarNIFGet))]
        [HttpGet]
        [Route("validarNIF")]
        public virtual IHttpActionResult GetBase([FromUri] string nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((IUtilidadesController)this).Get(nif,restkey);
                    }

/// <summary>
		/// valida el NAFSS de un empleado - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNAFSSGet</returns>
        [ResponseType(typeof(MultipleUtilidadesValidarNAFSSGet))]
        [HttpGet]
        [Route("validarNAFSS")]
        public virtual IHttpActionResult GetValidarNAFSSBase([FromUri] string nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((IUtilidadesController)this).GetValidarNAFSS(nif,restkey);
                    }

/// <summary>
		/// valida el IBAN de un empleado - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarIBANGet</returns>
        [ResponseType(typeof(MultipleUtilidadesValidarIBANGet))]
        [HttpGet]
        [Route("validarIBAN")]
        public virtual IHttpActionResult GetValidarIBANBase([FromUri] string nif,[FromUri] string restkey)
        {
            // Do not modify this code
                        return  ((IUtilidadesController)this).GetValidarIBAN(nif,restkey);
                    }
    }
}
