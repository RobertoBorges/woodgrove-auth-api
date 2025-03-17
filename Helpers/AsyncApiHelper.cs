using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace woodgroveapi.Helpers
{
    public static class AsyncApiHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Performs a "fire and forget" POST request to an API endpoint without waiting for the response
        /// </summary>
        /// <typeparam name="T">The type of the payload to send</typeparam>
        /// <param name="endpoint">The API endpoint URL</param>
        /// <param name="payload">The data to send</param>
        /// <param name="logger">Logger for error handling</param>
        public static void FireAndForgetPost<T>(string endpoint, T payload, ILogger logger)
        {
            // Start task but don't await it
            Task.Run(async () =>
            {
                try
                {
                    var jsonContent = new StringContent(
                        JsonSerializer.Serialize(payload), 
                        Encoding.UTF8, 
                        "application/json");
                    
                    // Send the request and explicitly don't await the response
                    var response = await _httpClient.PostAsync(endpoint, jsonContent);
                    
                    // Optional: Log the status code without processing the response content
                    if (!response.IsSuccessStatusCode)
                    {
                        logger.LogWarning("Fire-and-forget POST to {Endpoint} failed with status code {StatusCode}",
                            endpoint, response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception but don't propagate it
                    logger.LogError(ex, "Error in fire-and-forget POST to {Endpoint}", endpoint);
                }
            });
        }
    }
}
