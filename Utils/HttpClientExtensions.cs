using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace BuilderAux_MVC.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue ContentType
            = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response) 
        {
            if(!response.IsSuccessStatusCode) { throw
                    new ApplicationException($"Algo de errdo aconteceu na chamada da API: {response.ReasonPhrase}");
            }
            var Content = response.Content;
            if (Content != null)
            {
                try
                {
                    var DataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonSerializer.Deserialize<T>(DataAsString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch
                {
                    throw new JsonException($"Json Vazio");
                }
            }
            return default(T);
            
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient HttpClient,
            string url,
            T Data)
        {
            var DataAsString = JsonSerializer.Serialize(Data);
            var Content = new StringContent(DataAsString);
            Content.Headers.ContentType = ContentType;
            return HttpClient.PostAsync(url, Content);
        }
        
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient HttpClient,
            string url,
            T Data)
        {
            var DataAsString = JsonSerializer.Serialize(Data);
            var Content = new StringContent(DataAsString);
            Content.Headers.ContentType = ContentType;
            return HttpClient.PutAsync(url, Content);
        }


    }
}
