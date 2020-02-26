// Template: Client Proxy T4 Template (RAMLClient.t4) version 7.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RAML.Api.Core;
using Cliente.Empleado.Models;

namespace Cliente.Empleado
{
    public partial class Empleado
    {
        private readonly EmpleadoClient proxy;

        internal Empleado(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Crear un empleado - /empleado
		/// </summary>
		/// <param name="empleado"></param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoPostResponse> Post(Cliente.Empleado.Models.Empleado empleado)
        {

            var url = "/empleado";

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new ObjectContent(typeof(Cliente.Empleado.Models.Empleado), empleado, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Empleado.Models.EmpleadoPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Crear un empleado - /empleado
		/// </summary>
		/// <param name="request">Cliente.Empleado.Models.EmpleadoPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoPostResponse> Post(Cliente.Empleado.Models.EmpleadoPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/empleado";

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            if(request.Formatter == null)
                request.Formatter = new JsonMediaTypeFormatter();

			req.Content = new ObjectContent(typeof(Empleado), request.Content, request.Formatter);
	        var response = await proxy.Client.SendAsync(req);
            return new Cliente.Empleado.Models.EmpleadoPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    public partial class EmpleadoNif
    {
        private readonly EmpleadoClient proxy;

        internal EmpleadoNif(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Obtener todos los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="Nif"></param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifGetResponse> Get(string Nif)
        {

            var url = "/empleado/{nif}";
            url = url.Replace("{nif}", Uri.EscapeDataString(Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Empleado.Models.EmpleadoNifGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Obtener todos los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="request">Cliente.Empleado.Models.EmpleadoNifGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifGetResponse> Get(Cliente.Empleado.Models.EmpleadoNifGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/empleado/{nif}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.Nif == null)
				throw new InvalidOperationException("Uri Parameter Nif cannot be null");

            url = url.Replace("{nif}", Uri.EscapeDataString(request.UriParameters.Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
            return new Cliente.Empleado.Models.EmpleadoNifGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }


        /// <summary>
		/// Modificar los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="empleado"></param>
		/// <param name="Nif"></param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifPutResponse> Put(Cliente.Empleado.Models.Empleado empleado, string Nif)
        {

            var url = "/empleado/{nif}";
            url = url.Replace("{nif}", Uri.EscapeDataString(Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Put, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new ObjectContent(typeof(Cliente.Empleado.Models.Empleado), empleado, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Empleado.Models.EmpleadoNifPutResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Modificar los datos del empleado - /empleado/{nif}
		/// </summary>
		/// <param name="request">Cliente.Empleado.Models.EmpleadoNifPutRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifPutResponse> Put(Cliente.Empleado.Models.EmpleadoNifPutRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/empleado/{nif}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.Nif == null)
				throw new InvalidOperationException("Uri Parameter Nif cannot be null");

            url = url.Replace("{nif}", Uri.EscapeDataString(request.UriParameters.Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Put, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            if(request.Formatter == null)
                request.Formatter = new JsonMediaTypeFormatter();

			req.Content = new ObjectContent(typeof(Empleado), request.Content, request.Formatter);
	        var response = await proxy.Client.SendAsync(req);
            return new Cliente.Empleado.Models.EmpleadoNifPutResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }


        /// <summary>
		/// Borrar un empleado - /empleado/{nif}
		/// </summary>
		/// <param name="Nif"></param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifDeleteResponse> Delete(string Nif)
        {

            var url = "/empleado/{nif}";
            url = url.Replace("{nif}", Uri.EscapeDataString(Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Delete, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Empleado.Models.EmpleadoNifDeleteResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Borrar un empleado - /empleado/{nif}
		/// </summary>
		/// <param name="request">Cliente.Empleado.Models.EmpleadoNifDeleteRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Empleado.Models.EmpleadoNifDeleteResponse> Delete(Cliente.Empleado.Models.EmpleadoNifDeleteRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/empleado/{nif}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.Nif == null)
				throw new InvalidOperationException("Uri Parameter Nif cannot be null");

            url = url.Replace("{nif}", Uri.EscapeDataString(request.UriParameters.Nif.ToString()));

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Delete, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
            return new Cliente.Empleado.Models.EmpleadoNifDeleteResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    /// <summary>
    /// Main class for grouping root resources. Nested resources are defined as properties. The constructor can optionally receive an URL and HttpClient instance to override the default ones.
    /// </summary>
    public partial class EmpleadoClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "http://api.mtis/api/v1/";

        internal HttpClient Client { get { return client; } }




        public EmpleadoClient(string endpointUrl)
        {
            SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};

			if(string.IsNullOrWhiteSpace(endpointUrl))
                throw new ArgumentException("You must specify the endpoint URL", "endpointUrl");

			if (endpointUrl.Contains("{"))
			{
				var regex = new Regex(@"\{([^\}]+)\}");
				var matches = regex.Matches(endpointUrl);
				var parameters = new List<string>();
				foreach (Match match in matches)
				{
					parameters.Add(match.Groups[1].Value);
				}
				throw new InvalidOperationException("Please replace parameter/s " + string.Join(", ", parameters) + " in the URL before passing it to the constructor ");
			}

            if (!endpointUrl.EndsWith("/"))
                endpointUrl += "/";

            client = new HttpClient {BaseAddress = new Uri(endpointUrl)};
        }

        public EmpleadoClient(HttpClient httpClient)
        {
            if(httpClient.BaseAddress == null)
                throw new InvalidOperationException("You must set the BaseAddress property of the HttpClient instance");

            client = httpClient;

			SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};
        }

        

        public virtual Empleado Empleado
        {
            get { return new Empleado(this); }
        }
                

        public virtual EmpleadoNif EmpleadoNif
        {
            get { return new EmpleadoNif(this); }
        }
                


		public void AddDefaultRequestHeader(string name, string value)
		{
			client.DefaultRequestHeaders.Add(name, value);
		}

		public void AddDefaultRequestHeader(string name, IEnumerable<string> values)
		{
			client.DefaultRequestHeaders.Add(name, values);
		}

        // root methods



    }

} // end namespace









namespace Cliente.Empleado.Models
{
    public partial class  Error 
    {

        public int Codigo { get; set; }


        public string Mensaje { get; set; }


    } // end class

    public partial class  Empleado 
    {

        public string NIF { get; set; }


        public string Nombre { get; set; }


        public string Apellidos { get; set; }


        public string Poblacion { get; set; }


        public string Direccion { get; set; }


        public string Telefono { get; set; }


        public string Email { get; set; }


        public DateTime FechaNacimiento { get; set; }


        public string IBAN { get; set; }


        public string NSS { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Empleado, Error
    /// </summary>
    public partial class  MultipleEmpleadoNifGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleEmpleadoNifGet()
        {
            names.Add((HttpStatusCode)200, "Empleado");
            types.Add((HttpStatusCode)200, typeof(Empleado));
            names.Add((HttpStatusCode)404, "Error");
            types.Add((HttpStatusCode)404, typeof(Error));
        }

        /// <summary>
        /// Obtenido los datos correctamente 
        /// </summary>

        public Empleado Empleado { get; set; }


        /// <summary>
        /// No existe el NIF 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Uri Parameters for resource /empleado/{nif}
    /// </summary>
    public partial class  EmpleadoNifUriParameters 
    {

		[JsonProperty("nif")]
        public string Nif { get; set; }


    } // end class

    /// <summary>
    /// Request object for method Post of class Empleado
    /// </summary>
    public partial class EmpleadoPostRequest : ApiRequest
    {
        public EmpleadoPostRequest(Empleado Content = null, MediaTypeFormatter Formatter = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public Empleado Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class EmpleadoNif
    /// </summary>
    public partial class EmpleadoNifGetRequest : ApiRequest
    {
        public EmpleadoNifGetRequest(EmpleadoNifUriParameters UriParameters)
        {
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public EmpleadoNifUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Put of class EmpleadoNif
    /// </summary>
    public partial class EmpleadoNifPutRequest : ApiRequest
    {
        public EmpleadoNifPutRequest(EmpleadoNifUriParameters UriParameters, Empleado Content = null, MediaTypeFormatter Formatter = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public Empleado Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public EmpleadoNifUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Delete of class EmpleadoNif
    /// </summary>
    public partial class EmpleadoNifDeleteRequest : ApiRequest
    {
        public EmpleadoNifDeleteRequest(EmpleadoNifUriParameters UriParameters)
        {
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public EmpleadoNifUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Post of class Empleado
    /// </summary>

    public partial class EmpleadoPostResponse : ApiResponse
    {


	    private Error typedContent;
        /// <summary>
        /// Typed Response content
        /// </summary>
        public Error Content 
    	{
	        get
	        {
		        if (typedContent != null)
			        return typedContent;

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    typedContent = (Error)new XmlSerializer(typeof(Error)).Deserialize(xmlStream);
                }
                else
                {
                    var task =  Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync<Error>(Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync<Error>().ConfigureAwait(false);
		        
		            typedContent = task.GetAwaiter().GetResult();
                }
		        return typedContent;
	        }
	    }

		


    } // end class

    /// <summary>
    /// Response object for method Get of class EmpleadoNif
    /// </summary>

    public partial class EmpleadoNifGetResponse : ApiResponse
    {

	    private MultipleEmpleadoNifGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleEmpleadoNifGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleEmpleadoNifGet();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleEmpleadoNifGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Put of class EmpleadoNif
    /// </summary>

    public partial class EmpleadoNifPutResponse : ApiResponse
    {


	    private Error typedContent;
        /// <summary>
        /// Typed Response content
        /// </summary>
        public Error Content 
    	{
	        get
	        {
		        if (typedContent != null)
			        return typedContent;

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    typedContent = (Error)new XmlSerializer(typeof(Error)).Deserialize(xmlStream);
                }
                else
                {
                    var task =  Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync<Error>(Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync<Error>().ConfigureAwait(false);
		        
		            typedContent = task.GetAwaiter().GetResult();
                }
		        return typedContent;
	        }
	    }

		


    } // end class

    /// <summary>
    /// Response object for method Delete of class EmpleadoNif
    /// </summary>

    public partial class EmpleadoNifDeleteResponse : ApiResponse
    {


	    private Error typedContent;
        /// <summary>
        /// Typed Response content
        /// </summary>
        public Error Content 
    	{
	        get
	        {
		        if (typedContent != null)
			        return typedContent;

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    typedContent = (Error)new XmlSerializer(typeof(Error)).Deserialize(xmlStream);
                }
                else
                {
                    var task =  Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync<Error>(Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync<Error>().ConfigureAwait(false);
		        
		            typedContent = task.GetAwaiter().GetResult();
                }
		        return typedContent;
	        }
	    }

		


    } // end class


} // end Models namespace
