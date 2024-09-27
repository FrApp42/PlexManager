using Newtonsoft.Json;
using PlexAPI.Models.HttpRequest;
using PlexAPI.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;

namespace PlexAPI.Services
{
    internal class ApiRequest : IApiRequest
    {
        private HttpClient _httpClient = new HttpClient();

        public string URL { get; private set; } = string.Empty;
        public HttpMethod Method { get; private set; } = HttpMethod.Get;

        public Dictionary<string, string> RequestHeaders { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, string> ContentHeaders { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, string> QueryParams { get; private set; } = new Dictionary<string, string>();

        public object Body { get; private set; } = null;

        public ApiRequest()
        {

        }
        public ApiRequest(string url)
        {
            URL = url;
        }
        public ApiRequest(string url, HttpMethod httpMethod): this(url)
        {
            Method = httpMethod;
        }

        public ApiRequest AddHeader(string key, string value)
        {
            RequestHeaders.Add(key, value);
            return this;
        }

        public ApiRequest AddHeaders(Dictionary<string, string> headers)
        {
            foreach(KeyValuePair<string, string> header in headers)
            {
                RequestHeaders.Add(header.Key, header.Value);
            }
            return this;
        }

        public ApiRequest AddContentHeader(string key, string value)
        {
            ContentHeaders.Add(key, value);
            return this;
        }

        public ApiRequest AddContentHeaders(Dictionary<string, string> headers)
        {
            foreach(KeyValuePair<string, string> header in headers)
            {
                ContentHeaders.Add(header.Key, header.Value);
            }
            return this;
        }

        public ApiRequest AddQueryParam(string key, string value)
        {
            QueryParams.Add(key, value);
            return this;
        }

        public ApiRequest AddQueryParams(Dictionary<string, string> queryParams)
        {
            foreach(KeyValuePair<string, string> query in queryParams)
            {
                QueryParams.Add(query.Key, query.Value);
            }
            return this;
        }

        public ApiRequest AddPlexToken(string authToken)
        {
            RequestHeaders.Add("X-Plex-Token", authToken);
            return this;
        }

        public ApiRequest AcceptJson()
        {
            RequestHeaders.Add("Accept", "application/json");
            return this;
        }

        public ApiRequest AddJsonBody(object body) 
        {
            Body = body;
            return this;
        }

        public async Task<Result<T>> Run<T>()
        {
            StringBuilder builder = new StringBuilder(URL);
            string fullUrl = URL;

            if(fullUrl.EndsWith("/"))
                builder.Remove(fullUrl.Length - 1, 1);

            if(QueryParams.Count() > 0)
            {
                builder.Append("?");

                for(int i = 0; i < QueryParams.Count(); i++)
                {
                    KeyValuePair<string, string> query = QueryParams.ElementAt(i);
                    builder.Append($"{query.Key}={query.Value}");

                    if (!(i == QueryParams.Count() - 1))
                        builder.Append("&");
                }
            }
            

            HttpRequestMessage request = new HttpRequestMessage(Method, builder.ToString());
            for(int i = 0; i < RequestHeaders.Count; i++)
            {
                KeyValuePair<string, string> header = RequestHeaders.ElementAt(i);
                request.Headers.Add(header.Key, header.Value);
            }
            //foreach(KeyValuePair<string, string> header in RequestHeaders)
            //{
            //    request.Headers.Add(header.Key, header.Value);
            //}

            if(Body != null)
            {
                string json = JsonConvert.SerializeObject(Body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            Result<T> result = new Result<T>
            {
                StatusCode = (int)response.StatusCode
            };

            if(response.IsSuccessStatusCode)
            {
                string MediaType = response.Content?.Headers?.ContentType?.MediaType.ToLower();
                string ContentResponse = await response.Content?.ReadAsStringAsync();

                switch (true)
                {
                    case bool b when (MediaType.Contains("application/xml")):
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        StringReader reader = new StringReader(ContentResponse);
                        result.Value = (T)xmlSerializer.Deserialize(reader);
                        break;
                    case bool b when (MediaType.Contains("application/json")):
                        result.Value = JsonConvert.DeserializeObject<T>(ContentResponse);
                        break;
                    default:
                        result.Value = default(T);
                        break;
                }
            }
            return result;
        }
    }
}
