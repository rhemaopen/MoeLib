﻿using System.Collections.Generic;
using System.Net.Http;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Web;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     HttpRequestMessageExtensions.
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        ///     Gets the trace entry.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MoeLib.Diagnostics.TraceEntry.</returns>
        public static TraceEntry GetTraceEntry(this HttpRequestMessage request)
        {
            IEnumerable<string> clientId = null;
            IEnumerable<string> deviceId = null;
            IEnumerable<string> requestId = null;
            IEnumerable<string> sourceIP = null;
            IEnumerable<string> sourceUserAgent = null;
            IEnumerable<string> sessionId = null;
            IEnumerable<string> userId = null;

            if (request?.Headers != null)
            {
                request.Headers.TryGetValues("X-JYM-CID", out clientId);
                request.Headers.TryGetValues("X-JYM-DID", out deviceId);
                request.Headers.TryGetValues("X-JYM-RID", out requestId);
                request.Headers.TryGetValues("X-JYM-IP", out sourceIP);
                request.Headers.TryGetValues("X-JYM-UA", out sourceUserAgent);
                request.Headers.TryGetValues("X-JYM-SID", out sessionId);
                request.Headers.TryGetValues("X-JYM-UID", out userId);
            }

            return new TraceEntry
            {
                ClientId = clientId?.Join(","),
                DeviceId = deviceId?.Join(","),
                RequestId = requestId?.Join(","),
                SessionId = sessionId?.Join(","),
                SourceIP = sourceIP != null ? sourceIP.Join(",") : request?.GetUserHostAddress(),
                SourceUserAgent = sourceUserAgent != null ? sourceUserAgent.Join(",") : request?.GetUserAgent(),
                UserId = userId?.Join(",")
            };
        }
    }
}