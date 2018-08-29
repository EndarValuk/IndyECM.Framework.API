using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IndyECM.Framework.API.Interfaces
{
  ///<summary>
  /// Basic API middleware interface
  ///</summary>
  public interface IAmMiddleware
  {
    ///<summary>
    /// Executes operation and returns context to the next delegate/middleware in the pipeline
    ///</summary>
    ///<param name="context">Current HTTP context</param>
    ///<returns>.Net Task to complete</returns>
    Task InvokeAsync(HttpContext context);
  }
}