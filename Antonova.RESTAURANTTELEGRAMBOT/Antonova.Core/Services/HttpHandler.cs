using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Antonova.Core.Services
{
    /// <summary>
    /// Http handler.
    /// </summary>
    public class HttpHandler
    {
        /// <summary>
        /// Send GET request.
        /// </summary>
        /// <param name="host">Host</param>
        /// <returns>string result</returns>
        public async Task<string> GetStringQuoteAsync(string host)
        {
            return await host
            .GetAsync()
            .ReceiveString();
        }
    }
}
