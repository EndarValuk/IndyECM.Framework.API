using System;
using Microsoft.AspNetCore.Builder;

namespace IndyECM.Framework.API.Features
{
  ///<summary>
  /// Defines a class that adds different features to applications pipeline
  ///</summary>
  public static class FeatureRegistryExtensions
  {
    ///<summary>
    /// Adds response timing feature to applications pipeline
    ///</summary>
    ///<param name="builder">Current applications pipeline</param>
    ///<returns>Modified applications pipeline</returns>
    public static IApplicationBuilder UseResponseTiming(this IApplicationBuilder builder)
    {
      if(builder == null)
      {
        throw new ArgumentNullException(nameof(builder));
      }
      return builder.UseMiddleware<ResponseTimingMiddleware>();
    }
  }
}