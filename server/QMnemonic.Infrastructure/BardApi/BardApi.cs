
using System.Text;
using QMnemonic.Domain.Repositories;
using Newtonsoft.Json;


namespace QMnemonic.Infrastructure.BardApi;


public class BardApi : IBardApiRepository
{

    public async Task<string> Generator(string prompt, string content, string key)
    {
        string apiUrl = "http://localhost:5000/generate";


        var data = new
        {
            prompt = prompt,
            content = content,
            key = key
        };
        
        string jsonSend = JsonConvert.SerializeObject(data);


        using (HttpClient client = new HttpClient())
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            request.Content = new StringContent(jsonSend, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();

                return ($"Odpowiedź z serwera: {responseData}");
            }
            else
            {
                return ($"Błąd HTTP: {response.StatusCode}");
            }
        }
    }
}


