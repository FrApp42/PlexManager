using PlexAPI.Models.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexAPI.Services.Interfaces
{
    internal class IApiRequest
    {
        public string URL { get; private set; }
        public HttpMethod Method { get; private set; }
        public Dictionary<string, string> RequestHeaders { get; private set; }
        public Dictionary<string, string> ContentHeaders { get; private set; }
        public Dictionary<string, string> QueryParams { get; private set; }
        public object Body { get; private set; }
    }
}
