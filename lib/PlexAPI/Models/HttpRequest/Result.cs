using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexAPI.Models.HttpRequest
{
    internal class Result<T>
    {
        public int StatusCode { get; set; }

        public T Value { get; set; } = default(T);

    }
}
