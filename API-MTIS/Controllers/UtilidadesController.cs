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
                    var letra = matcher.Groups[2];
                    var letras = "TRWAGMYFPDXBNJZSQVHLCKE";
                    int index = int.Parse(matcher.Groups[1].ToString());

                    index = index % 23;
                    var reference = letras.Substring(index, 1);

                    return Ok(new MultipleUtilidadesValidarNIFGet { Ipbool = reference.Equals(letra.Value) });
                }
                return Ok(new MultipleUtilidadesValidarNIFGet { Ipbool = false});
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

                var bankAccount = iban.Trim();

                if (bankAccount.Length < IBANNUMBER_MIN_SIZE || bankAccount.Length > IBANNUMBER_MAX_SIZE)
                {
                    return Ok(new MultipleUtilidadesValidarIBANGet { Ipbool = false });
                }

                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return Ok(new MultipleUtilidadesValidarIBANGet {Ipbool = (checksum == 1) });
            }
            catch (Exception)
            {
                return Ok(new MultipleUtilidadesValidarIBANGet { Error = new Error { Codigo = 404, Mensaje = "IBAN Formato incorrecto" } });
            }
        }

    }
}
