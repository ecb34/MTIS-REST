// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API_MTIS.Empleado.Models;
using API_MTIS.Utilidades.Models;

namespace API_MTIS.Empleado
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class EmpleadoController : IEmpleadoController
    {

/// <summary>
		/// Crear un empleado - /empleado
		/// </summary>
		/// <param name="empleado"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Post([FromBody] API_MTIS.Empleado.Models.Empleado empleado)
        {
            try
            {
                using (var dbContext = new DbContext())
                {
                    dbContext.Empleado.Add(empleado);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                var result = new Error
                {
                    Codigo = 400,
                    Mensaje = "Falta algun campo requerido"
                };
                return Ok(result);
            }
			return Ok(new Error{Codigo = 201, Mensaje = "Creado correctamente"});
        }

/// <summary>
		/// Obtener todos los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="nif"></param>
		/// <returns>MultipleEmpleadoNifGet</returns>
        public IHttpActionResult Get([FromUri] string nif)
        {
            using (var dbContext = new DbContext())
            {
                var empleado = dbContext.Empleado.FirstOrDefault(e => e.NIF == nif);
                if (empleado == null)
                {
                    return Ok(new Error { Codigo = 404, Mensaje = "Empleado no encontrado" });
                }
                else
                {
                    return Ok(empleado);
                }
            }
        }

/// <summary>
		/// Modificar los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="empleado"></param>
		/// <param name="nif"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Put([FromBody] API_MTIS.Empleado.Models.Empleado empleado,[FromUri] string nif)
        {
            try
            {
                using (var dbContext = new DbContext())
                {
                    var empleadoDB = dbContext.Empleado.FirstOrDefault(e => e.NIF == nif);
                    if (empleadoDB == null)
                    {
                        return Ok(new Error { Codigo = 404, Mensaje = "Error al actualizar, no existe el NIF" });
                    }
                    empleadoDB.NIF = empleado.NIF;
                    empleadoDB.Nombre = empleado.Nombre;
                    empleadoDB.Apellidos = empleado.Apellidos;
                    empleadoDB.Poblacion = empleado.Poblacion;
                    empleadoDB.Direccion = empleado.Direccion;
                    empleadoDB.Email = empleado.Email;
                    empleadoDB.FechaNacimiento = empleado.FechaNacimiento;
                    empleadoDB.IBAN = empleado.IBAN;
                    empleadoDB.NSS = empleado.NSS;
                    dbContext.Entry(empleadoDB).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Ok(new Error { Codigo = 404, Mensaje = "Error al actualizar, error en los datos" });
            }
			return Ok();
        }

/// <summary>
		/// Borrar un empleado - /empleado/{nif}
		/// </summary>
		/// <param name="nif"></param>
		/// <returns>Error</returns>
        public IHttpActionResult Delete([FromUri] string nif)
        {
            using(var dbContext = new DbContext())
            {
                var empleado = dbContext.Empleado.FirstOrDefault(e => e.NIF == nif);
                if(empleado == null)
                {
                    return Ok(new Error { Codigo = 404, Mensaje = "No existe el empleado con dicho NIF" });
                }
                else
                {
                    dbContext.Entry(empleado).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();
                    return Ok();
                }
            }
			
        }

    }
}
