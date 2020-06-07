// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_MTIS.Seguridad.Models;
using API_MTIS.Utilidades.Models;

namespace API_MTIS.Seguridad
{
    public partial class SeguridadController : ISeguridadController
    {

        private bool CheckRestKey(string key)
        {
            using(var dbContext = new DbContext())
            {
                var dbKey = dbContext.RestKey.SingleOrDefault(k => k.Key == key);

                return dbKey != null;
            }
        }
/// <summary>
		/// Validar un permiso - /seguridad
		/// </summary>
		/// <param name="sala"></param>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadGet</returns>
        public IHttpActionResult Get([FromUri] string sala,[FromUri] string nif,[FromUri] string restkey)
        {
            if (CheckRestKey(restkey))
            {
                try
                {
                    using(var dbContext = new DbContext())
                    {
                        var result = dbContext.Permiso.Count(p => p.NIF == nif && p.Sala == sala) > 0;

                        return Ok(new MultipleSeguridadGet {Ipbool = result});
                    }
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.BadRequest, new MultipleSeguridadGet { Error = new Error { Codigo = 404, Mensaje = "Datos erroneos" } });
                }
                  
            }
            return Content(HttpStatusCode.Forbidden, new MultipleSeguridadGet { Error = new Error { Codigo = 404, Mensaje = "RestKey errónea" } });

        }

/// <summary>
		/// Crear un permiso para que un usuario pueda acceder a una sala - /seguridad
		/// </summary>
		/// <param name="permiso"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Post([FromBody] API_MTIS.Seguridad.Models.Permiso body)
        {
            if (CheckRestKey(body.RestKey))
            {
                try
                {
                    var permiso = new API_MTIS.Models.Permiso
                    {
                        NIF = body.NIF,
                        Sala = body.Sala
                    };

                    using (var dbContext = new DbContext())
                    {
                        dbContext.Permiso.Add(permiso);
                        dbContext.SaveChanges();
                    }
                    return Ok();
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.BadRequest, new Error { Codigo = 400, Mensaje = "Sala o NIF inválidos" });
                }
            }
            return Content(HttpStatusCode.Forbidden, new Error { Codigo = 404, Mensaje = "RestKey inválido" });
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
            if (CheckRestKey(restkey))
            {
                try
                {

                    using (var dbContext = new DbContext())
                    {
                        var permiso = dbContext.Permiso.FirstOrDefault(p => p.NIF == nif && p.Sala == sala);
                        if(permiso == null)
                        {
                            return Content(HttpStatusCode.NotFound, new Error { Codigo = 404, Mensaje = "Permiso no existe" });
                        }
                        dbContext.Entry(permiso).State = System.Data.Entity.EntityState.Deleted;
                        dbContext.SaveChanges();
                    }
                    return Ok(new Error() {Codigo = 201, Mensaje = "Permiso eliminado"});
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.BadRequest, new Error { Codigo = 400, Mensaje = "Error en los parámetros enviados" });
                }
            }
            return Content(HttpStatusCode.Forbidden, new Error { Codigo = 400, Mensaje = "Rest Key inválida" });
        }

        /// <summary>
        /// Obtener los niveles a los que puede acceder el empleado - /seguridad/{nif}
        /// </summary>
        /// <param name="Nif"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleSeguridadNifGet</returns>
        public IHttpActionResult GetByNif([FromUri] string Nif,[FromUri] string restkey)
        {
            if (CheckRestKey(restkey))
            {
                try
                {
                    using(var dbContext = new DbContext())
                    {
                        var salas = dbContext.Permiso.Where(p => p.NIF == Nif).Select(p => p.Sala).ToList();
                        return Ok(new MultipleSeguridadNifGet { Ipstring = salas });
                    }
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.BadRequest, new Error { Codigo = 400, Mensaje = "NIF inválido" });
                }
            }
            return Content(HttpStatusCode.Forbidden, new Error { Codigo = 400, Mensaje = "Rest Key inválida" });
        }

    }
}
