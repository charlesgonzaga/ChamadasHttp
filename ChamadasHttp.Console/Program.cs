using ChamadasHttp.Console;

var callSContent = new CallsStringContent();
//var response = await callSContent.FromBodyPostAsync("https://localhost:5201/api/EndpointsStringContent/FromBodyPostAsync");
//var response = await callSContent.FromHeaderPostAsync("https://localhost:5201/api/EndpointsStringContent/FromHeaderPostAsync");
var response = await callSContent.FromQueryGetAsync("https://localhost:5201/api/EndpointsStringContent/FromQueryGetAsync");

var callFUEContent = new CallsEncodedContent();
//var response = await callFUEContent.FromBodyPostAsync("https://localhost:5201/api/EndpointsEncodedContent/FromBodyPostAsync");
//var response = await callFUEContent.FromHeaderPostAsync("https://localhost:5201/api/EndpointsEncodedContent/FromHeaderPostAsync");
//var response = await callFUEContent.FromHeaderSendAsync("https://localhost:5201/api/EndpointsEncodedContent/FromHeaderPostAsync");
//var response = await callFUEContent.FromQueryGetAsync("https://localhost:5201/api/EndpointsEncodedContent/FromQueryGetAsync");

if (!response.IsSuccessStatusCode)
    Console.WriteLine(response.StatusCode);
else
{
    //var resultContent = await response.Content.GetAsyncWithJson();
    var resultContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine(resultContent);
}

Console.ReadKey();
