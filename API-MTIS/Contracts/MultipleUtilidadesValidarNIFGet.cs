// Template: Models (ApiModel.t4) version 4.0

// This code was generated by AMF Server Scaffolder

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace API_MTIS.Utilidades.Models
{
    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class MultipleUtilidadesValidarNIFGet
    {
        

        /// <summary>
        /// Resultado de la validación 
        /// </summary>

        public bool? Ipbool { get; set; }

        /// <summary>
        /// NIF vacío 
        /// </summary>

        public Error Error { get; set; }
    } // end class

} // end Models namespace

