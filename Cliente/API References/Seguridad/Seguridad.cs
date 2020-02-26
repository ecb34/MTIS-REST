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
using Cliente.Seguridad.Models;

namespace Cliente.Seguridad
{
    public partial class Seguridad
    {
        private readonly SeguridadClient proxy;

        internal Seguridad(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Validar un permiso - /seguridad
		/// </summary>
		/// <param name="getseguridadquery">query properties</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadGetResponse> Get(Cliente.Seguridad.Models.GetSeguridadQuery getseguridadquery)
        {

            var url = "/seguridad";
            if(getseguridadquery != null)
            {
                url += "?";
                if(getseguridadquery.Sala != null)
					url += "&Sala=" + Uri.EscapeDataString(getseguridadquery.Sala);
                if(getseguridadquery.NIF != null)
					url += "&NIF=" + Uri.EscapeDataString(getseguridadquery.NIF);
                if(getseguridadquery.RestKey != null)
					url += "&restKey=" + Uri.EscapeDataString(getseguridadquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Seguridad.Models.SeguridadGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Validar un permiso - /seguridad
		/// </summary>
		/// <param name="request">Cliente.Seguridad.Models.SeguridadGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadGetResponse> Get(Cliente.Seguridad.Models.SeguridadGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/seguridad";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.Sala != null)
                    url += "&Sala=" + Uri.EscapeDataString(request.Query.Sala);
                if(request.Query.NIF != null)
                    url += "&NIF=" + Uri.EscapeDataString(request.Query.NIF);
                if(request.Query.RestKey != null)
                    url += "&restKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

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
            return new Cliente.Seguridad.Models.SeguridadGetResponse  
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
		/// Crear un permiso para que un usuario pueda acceder a una sala - /seguridad
		/// </summary>
		/// <param name="permiso"></param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadPostResponse> Post(Cliente.Seguridad.Models.Permiso permiso)
        {

            var url = "/seguridad";

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new ObjectContent(typeof(Cliente.Seguridad.Models.Permiso), permiso, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Seguridad.Models.SeguridadPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Crear un permiso para que un usuario pueda acceder a una sala - /seguridad
		/// </summary>
		/// <param name="request">Cliente.Seguridad.Models.SeguridadPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadPostResponse> Post(Cliente.Seguridad.Models.SeguridadPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/seguridad";

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

			req.Content = new ObjectContent(typeof(Permiso), request.Content, request.Formatter);
	        var response = await proxy.Client.SendAsync(req);
            return new Cliente.Seguridad.Models.SeguridadPostResponse  
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
		/// Borrar un permiso - /seguridad
		/// </summary>
		/// <param name="deleteseguridadquery">query properties</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadDeleteResponse> Delete(Cliente.Seguridad.Models.DeleteSeguridadQuery deleteseguridadquery)
        {

            var url = "/seguridad";
            if(deleteseguridadquery != null)
            {
                url += "?";
                if(deleteseguridadquery.Sala != null)
					url += "&Sala=" + Uri.EscapeDataString(deleteseguridadquery.Sala);
                if(deleteseguridadquery.NIF != null)
					url += "&NIF=" + Uri.EscapeDataString(deleteseguridadquery.NIF);
                if(deleteseguridadquery.RestKey != null)
					url += "&restKey=" + Uri.EscapeDataString(deleteseguridadquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Delete, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Seguridad.Models.SeguridadDeleteResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Borrar un permiso - /seguridad
		/// </summary>
		/// <param name="request">Cliente.Seguridad.Models.SeguridadDeleteRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadDeleteResponse> Delete(Cliente.Seguridad.Models.SeguridadDeleteRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/seguridad";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.Sala != null)
                    url += "&Sala=" + Uri.EscapeDataString(request.Query.Sala);
                if(request.Query.NIF != null)
                    url += "&NIF=" + Uri.EscapeDataString(request.Query.NIF);
                if(request.Query.RestKey != null)
                    url += "&restKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

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
            return new Cliente.Seguridad.Models.SeguridadDeleteResponse  
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

    public partial class SeguridadNif
    {
        private readonly SeguridadClient proxy;

        internal SeguridadNif(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Obtener los niveles a los que puede acceder el empleado - /seguridad/{nif}
		/// </summary>
		/// <param name="Nif"></param>
		/// <param name="getseguridadnifquery">query properties</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadNifGetResponse> Get(string Nif, Cliente.Seguridad.Models.GetSeguridadNifQuery getseguridadnifquery)
        {

            var url = "/seguridad/{nif}";
            url = url.Replace("{nif}", Uri.EscapeDataString(Nif.ToString()));
            if(getseguridadnifquery != null)
            {
                url += "?";
                if(getseguridadnifquery.RestKey != null)
					url += "&restKey=" + Uri.EscapeDataString(getseguridadnifquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new Cliente.Seguridad.Models.SeguridadNifGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Obtener los niveles a los que puede acceder el empleado - /seguridad/{nif}
		/// </summary>
		/// <param name="request">Cliente.Seguridad.Models.SeguridadNifGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<Cliente.Seguridad.Models.SeguridadNifGetResponse> Get(Cliente.Seguridad.Models.SeguridadNifGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/seguridad/{nif}";
			if(request.UriParameters == null)
				throw new InvalidOperationException("Uri Parameters cannot be null");               

			if(request.UriParameters.Nif == null)
				throw new InvalidOperationException("Uri Parameter Nif cannot be null");

            url = url.Replace("{nif}", Uri.EscapeDataString(request.UriParameters.Nif.ToString()));
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.RestKey != null)
                    url += "&restKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

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
            return new Cliente.Seguridad.Models.SeguridadNifGetResponse  
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
    public partial class SeguridadClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "http://api.mtis/api/v1/";

        internal HttpClient Client { get { return client; } }




        public SeguridadClient(string endpointUrl)
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

        public SeguridadClient(HttpClient httpClient)
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

        

        public virtual Seguridad Seguridad
        {
            get { return new Seguridad(this); }
        }
                

        public virtual SeguridadNif SeguridadNif
        {
            get { return new SeguridadNif(this); }
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









namespace Cliente.Seguridad.Models
{
    public partial class  Error 
    {

        public int Codigo { get; set; }


        public string Mensaje { get; set; }


    } // end class

    public partial class  Permiso 
    {

        public string Sala { get; set; }


        public string NIF { get; set; }


		[JsonProperty("restKey")]
        public string RestKey { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleSeguridadGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadGet()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Resultado de la validación 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// NIF o sala vacio 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipstring, Error
    /// </summary>
    public partial class  MultipleSeguridadNifGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadNifGet()
        {
            names.Add((HttpStatusCode)200, "Ipstring");
            types.Add((HttpStatusCode)200, typeof(IList<string>));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Niveles 
        /// </summary>

        public IList<string> Ipstring { get; set; }


        /// <summary>
        /// No existe el NIF 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    public partial class  GetSeguridadQuery 
    {

        public string Sala { get; set; }


        public string NIF { get; set; }


		[JsonProperty("restKey")]
        public string RestKey { get; set; }


    } // end class

    public partial class  DeleteSeguridadQuery 
    {

        public string Sala { get; set; }


        public string NIF { get; set; }


		[JsonProperty("restKey")]
        public string RestKey { get; set; }


    } // end class

    public partial class  GetSeguridadNifQuery 
    {

		[JsonProperty("restKey")]
        public string RestKey { get; set; }


    } // end class

    /// <summary>
    /// Uri Parameters for resource /seguridad/{nif}
    /// </summary>
    public partial class  SeguridadNifUriParameters 
    {

		[JsonProperty("nif")]
        public string Nif { get; set; }


    } // end class

    /// <summary>
    /// Request object for method Get of class Seguridad
    /// </summary>
    public partial class SeguridadGetRequest : ApiRequest
    {
        public SeguridadGetRequest(GetSeguridadQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetSeguridadQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Post of class Seguridad
    /// </summary>
    public partial class SeguridadPostRequest : ApiRequest
    {
        public SeguridadPostRequest(Permiso Content = null, MediaTypeFormatter Formatter = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public Permiso Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Delete of class Seguridad
    /// </summary>
    public partial class SeguridadDeleteRequest : ApiRequest
    {
        public SeguridadDeleteRequest(DeleteSeguridadQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public DeleteSeguridadQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class SeguridadNif
    /// </summary>
    public partial class SeguridadNifGetRequest : ApiRequest
    {
        public SeguridadNifGetRequest(SeguridadNifUriParameters UriParameters, GetSeguridadNifQuery Query = null)
        {
            this.Query = Query;
            this.UriParameters = UriParameters;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetSeguridadNifQuery Query { get; set; }

        /// <summary>
        /// Request Uri Parameters
        /// </summary>
        public SeguridadNifUriParameters UriParameters { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Get of class Seguridad
    /// </summary>

    public partial class SeguridadGetResponse : ApiResponse
    {

	    private MultipleSeguridadGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadGet();

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
            return MultipleSeguridadGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Post of class Seguridad
    /// </summary>

    public partial class SeguridadPostResponse : ApiResponse
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
    /// Response object for method Delete of class Seguridad
    /// </summary>

    public partial class SeguridadDeleteResponse : ApiResponse
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
    /// Response object for method Get of class SeguridadNif
    /// </summary>

    public partial class SeguridadNifGetResponse : ApiResponse
    {

	    private MultipleSeguridadNifGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadNifGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadNifGet();

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
            return MultipleSeguridadNifGet.GetSchema(statusCode);
        }      

    } // end class


} // end Models namespace
