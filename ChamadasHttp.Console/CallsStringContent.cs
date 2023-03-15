using System.Text;
using System.Text.Json;

namespace ChamadasHttp.Console;

public class CallsStringContent
{
    public async Task<HttpResponseMessage> FromBodyPostAsync(string endpoint)
    {
        var payload = new { username = "john", password = "doe" };
        var json = JsonSerializer.Serialize(payload);

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsync(endpoint, httpContent);

        return response;
    }

    public async Task<HttpResponseMessage> FromHeaderPostAsync(string endpoint)
    {
        var payload = new { username = "john", password = "doe" };

        using var httpClient = new HttpClient();

        var content = new StringContent(string.Empty);
        content.Headers.Add("username", payload.username);
        content.Headers.Add("password", payload.password);

        var response = await httpClient.PostAsync(endpoint, content);

        return response;
    }

    public async Task<HttpResponseMessage> FromQueryGetAsync(string endpoint)
    {
        var httpClient = new HttpClient();

        var payload = new { username = "john", password = "doe" };

        var queryString = new Dictionary<string, string>()
        {
            { "username", payload.username },
            { "password", payload.password }
        };

        var uriBuilder = new UriBuilder(endpoint)
        {
            Query = string.Join("&", queryString.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}"))
        };

        var response = await httpClient.GetAsync(uriBuilder.Uri);

        return response;
    }
}
