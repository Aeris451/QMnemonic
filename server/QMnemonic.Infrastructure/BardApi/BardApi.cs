
using System.Text;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Infrastructure.BardApi;


public class BardApi: IBardApiRepository
{

    public async Task<string> Generator(string content) 
    {
            string apiUrl = "http://localhost:5000/generate";

            string textToSend = "Wypisz mi przykłady uzycia tych znaków w języku japońskim, bez zdjęć: "+content;

            
            // Utwórz obiekt HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Utwórz obiekt HttpRequestMessage
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

                // Ustaw nagłówek "Content-Type"
                request.Content = new StringContent($"{{\"text\": \"{textToSend}\"}}", Encoding.UTF8, "application/json");

                // Wysłanie żądania POST z danymi JSON
                HttpResponseMessage response = await client.SendAsync(request);

                // Sprawdzenie, czy żądanie zakończyło się sukcesem
                if (response.IsSuccessStatusCode)
                {
                    // Odczytanie odpowiedzi z serwera
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Przetwarzanie odpowiedzi
                    return($"Odpowiedź z serwera: {responseData}");
                }
                else
                {
                    return($"Błąd HTTP: {response.StatusCode}");
                }
            }
    }
}


