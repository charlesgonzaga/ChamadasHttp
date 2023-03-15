namespace ChamadasHttp.Console;

public class CallsEncodedContent
{
    public async Task<HttpResponseMessage> FromBodyPostAsync(string endpoint)
    {
        var payload = new Dictionary<string, string>
        {
            { "username", "john" },
            { "password", "doe" }
        };

        using var httpClient = new HttpClient();
        var content = new FormUrlEncodedContent(payload);
        
        var response = await httpClient.PostAsync(endpoint, content);

        return response;
    }

    public async Task<HttpResponseMessage> FromHeaderPostAsync(string endpoint)
    {
        var payload = new Dictionary<string, string>
        {
            { "username", "john" },
            { "password", "doe" }
        };

        using var httpClient = new HttpClient();

        var content = new FormUrlEncodedContent(new Dictionary<string, string>());
        content.Headers.Add("username", payload["username"]);
        content.Headers.Add("password", payload["password"]);

        var response = await httpClient.PostAsync(endpoint, content);

        return response;

        // Outra forma de fazer a requisição
        //
        //var payload = new Dictionary<string, string>
        //{
        //    { "username", "john" },
        //    { "password", "doe" }
        //};

        //using var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Add("username", payload["username"]);
        //httpClient.DefaultRequestHeaders.Add("password", payload["password"]);

        //var response = await httpClient.PostAsync(endpoint, null);

        //return response;
    }

    public async Task<HttpResponseMessage> FromHeaderSendAsync(string endpoint)
    {
        var payload = new Dictionary<string, string>
        {
            { "username", "john" },
            { "password", "doe" }
        };

        using var httpClient = new HttpClient();

        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Add("username", payload["username"]);
        request.Headers.Add("password", payload["password"]);

        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        return response;
    }

    public async Task<HttpResponseMessage> FromQueryGetAsync(string endpoint)
    {
        var payload = new Dictionary<string, string>
        {
            { "username", "john" },
            { "password", "doe" }
        };

        using var httpClient = new HttpClient();

        var uriBuilder = new UriBuilder(endpoint)
        {
            Query = string.Join("&", payload.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}"))
        };

        var response = await httpClient.GetAsync(uriBuilder.Uri);

        return response;
    }
}
