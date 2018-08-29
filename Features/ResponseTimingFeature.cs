using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using IndyECM.Framework.API.Interfaces;

namespace IndyECM.Framework.API.Features
{
  ///<summary>
  /// Defines a class that adds response timing feature
  ///</summary>
  public class ResponseTimingMiddleware : IAmMiddleware
  {
    ///<summary>
    /// Temporary holder for delegate/middleware
    ///</summary>
    private readonly RequestDelegate _next;

    ///<summary>
    /// Constructor
    ///</summary>
    ///<param name="next">Next delegate/middleware in the pipeline</param>
    public ResponseTimingMiddleware(RequestDelegate next)
    {
      if(next == null)
      {
        throw new ArgumentNullException(nameof(next));
      }
      _next = next;
    }

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context)
    {
      var sw = new Stopwatch();
      sw.Start();
      context.Response.OnStarting(state => {
        sw.Stop();
        context.Response.Headers.Append("X-Response-Time", $"{sw.ElapsedMilliseconds} ms");
        return Task.FromResult(0);
      }, context);
      // Call the next delegate/middleware in the pipeline
      await this._next(context);
    }
  }
}