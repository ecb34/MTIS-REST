// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            try
            {
                var pattern = new Regex("(\\d{1,8})([TRWAGMYFPDXBNJZSQVHLCKEtrwagmyfpdxbnjzsqvhlcke])");
                var matcher = pattern.Match(nif);

                if (matcher.Success)
                {
                    var letra = matcher.Groups[1];
                    var letras = "TRWAGMYFPDXBNJZSQVHLCKE";
                    int index = int.Parse(matcher.Groups[0].ToString());

                    index = index % 23;
                    var reference = letras.Substring(index, index + 1);

                    return Ok(new MultipleUtilidadesValidarNIFGet { Ipbool = reference.Equals(letra) });
                }
                return Ok(new MultipleUtilidadesValidarNIFGet { Ipbool = false });
            }
            catch (Exception)
            {
                return Ok(new MultipleUtilidadesValidarNIFGet { Error = new Error { Codigo = 404, Mensaje = "NIF Formato incorrecto" } });
            }
            
            
        }

/// <summary>
		/// valida el NAFSS de un empleado - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNAFSSGet</returns>
        public IHttpActionResult GetValidarNAFSS([FromUri] string nafss,[FromUri] string restkey)
        {
            try
            {
                var pattern = new Regex("(66|53|50|[0-4][0-9])-?\\d{8}-?\\d{2}");

                var matcher = pattern.Match(nafss);

                return Ok(new MultipleUtilidadesValidarNAFSSGet { Ipbool = matcher.Success });
            }
            catch (Exception)
            {
                return Ok(new MultipleUtilidadesValidarNIFGet { Error = new Error { Codigo = 404, Mensaje = "NAFSS Formato incorrecto" } });
            }
        }

/// <summary>
		/// valida el IBAN de un empleado - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="nif"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarIBANGet</returns>
        public IHttpActionResult GetValidarIBAN([FromUri] string iban,[FromUri] string restkey)
        {
            try
            {
                const int IBANNUMBER_MIN_SIZE = 15;
                const int IBANNUMBER_MAX_SIZE = 34;
                const Int64 IBANNUMBER_MAGIC_NUMBER = 97;

                var newAccountNumber = iban.Trim();

                if (newAccountNumber.Length < IBANNUMBER_MIN_SIZE || newAccountNumber.Length > IBANNUMBER_MAX_SIZE)
                {
                    return Ok(new MultipleUtilidadesValidarIBANGet { Ipbool = false });
                }

                // Move the four initial characters to the end of the string.
                newAccountNumber = newAccountNumber.Substring(4) + newAccountNumber.Substring(0, 4);

                // Replace each letter in the string with two digits, thereby expanding
                // the string, where A = 10, B = 11, ..., Z = 35.
                var numericAccountNumber = new StringBuilder();
                for (int i = 0; i < newAccountNumber.Length; i++)
                {
                    numericAccountNumber.Append(char.GetNumericValue(newAccountNumber[i]));
                }

                // Interpret the string as a decimal integer and compute the remainder
                // of that number on division by 97.
                /*var ibanNumber = new Int64();
                ibanNumber = numericAccountNumber.ToString();

                if (ibanNumber.mod(IBANNUMBER_MAGIC_NUMBER).intValue() == 1)
                {
                }*/
                return null;
            }catch (Exception)
            {
                return Ok(new MultipleUtilidadesValidarIBANGet { Error = new Error { Codigo = 404, Mensaje = "NAFSS Formato incorrecto" } });
            }
        }

    }
}
