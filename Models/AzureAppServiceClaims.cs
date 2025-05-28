using System.Text;
using System.Text.Json;

namespace woodgroveapi.Models
{

    public class AzureAppServiceClaimsHeader
    {
        public string auth_typ { get; set; }
        public List<AzureAppServiceClaim> claims { get; set; }
        public string name_typ { get; set; }
        public string role_typ { get; set; }

        public static bool Authorize(HttpRequest req)
        {
            // List all properties on the request and log them  
            System.Diagnostics.Debug.WriteLine("--- HttpRequest Properties ---");
            System.Diagnostics.Debug.WriteLine($"Method: {req.Method}");
            System.Diagnostics.Debug.WriteLine($"Scheme: {req.Scheme}");
            System.Diagnostics.Debug.WriteLine($"Host: {req.Host}");
            System.Diagnostics.Debug.WriteLine($"Path: {req.Path}");
            System.Diagnostics.Debug.WriteLine($"QueryString: {req.QueryString}");
            System.Diagnostics.Debug.WriteLine($"Protocol: {req.Protocol}");

            // Log headers (excluding any sensitive information)  
            System.Diagnostics.Debug.WriteLine("--- Headers ---");
            foreach (var header in req.Headers)
            {
                System.Diagnostics.Debug.WriteLine($"{header.Key}: {(header.Key.ToLower().Contains("auth") ? "[REDACTED]" : string.Join(", ", header.Value.ToArray()))}");
            }

            // Log cookies count  
            System.Diagnostics.Debug.WriteLine($"Cookies Count: {req.Cookies.Count}");

            // Log form data if present (only keys for privacy)  
            if (req.HasFormContentType)
            {
                System.Diagnostics.Debug.WriteLine("--- Form Keys ---");
                foreach (var key in req.Form.Keys)
                {
                    System.Diagnostics.Debug.WriteLine(key);
                }
            }

            // For all language frameworks, App Service makes the claims in the incoming token   
            // available to your code by injecting them into the request headers.  
            // For more information, https://learn.microsoft.com/azure/app-service/configure-authentication-user-identities  
            if (req.Headers.TryGetValue("x-ms-client-principal", out var xMsClientPrincipal))
            {
                var json = Encoding.UTF8.GetString(Convert.FromBase64String(xMsClientPrincipal[0]!));
                AzureAppServiceClaimsHeader header = JsonSerializer.Deserialize<AzureAppServiceClaimsHeader>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

                AzureAppServiceClaim azp = header.claims.Find(x => x.typ == "azp")!;

                // Validate that the 'azp' claim contains the 99045fe1-7639-4a75-9d4a-577b6ca3810f value.   
                // This value ensures that the Microsoft Entra is the one who calls the API.   
                // For more information, https://learn.microsoft.com/azure/active-directory/develop/custom-extension-overview#protect-your-rest-api  
                return (azp != null) &&
                        azp.val == "99045fe1-7639-4a75-9d4a-577b6ca3810f";
            }

            return true;
        }
    }

    public class AzureAppServiceClaim
    {
        public string typ { get; set; }
        public string val { get; set; }
    }
}
