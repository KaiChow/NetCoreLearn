using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebEmployee
{
    public interface IHttpActionResult
    {
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
}
