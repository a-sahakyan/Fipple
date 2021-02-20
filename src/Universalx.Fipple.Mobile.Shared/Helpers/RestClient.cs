using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Universalx.Fipple.Mobile.Shared.Helpers
{
    public class RestClient
    {
        private readonly HttpClient HttpClient;
        private readonly string BaseAddress;

        public RestClient(string baseAddress)
        {
            BaseAddress = baseAddress;
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            HttpClient = new HttpClient(httpClientHandler);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestModel)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url), "URL is missing");
            }

            if (requestModel is null)
            {
                throw new ArgumentNullException(nameof(requestModel), "Request model is missing");
            }

            string content = JsonConvert.SerializeObject(requestModel);
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            HttpContent httpContent = new ByteArrayContent(buffer);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, string.Concat(BaseAddress, url));
            message.Content = httpContent;

            HttpResponseMessage responseMessage = await HttpClient.SendAsync(message);
            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"{responseMessage.StatusCode} {responseContent}");
            }

            TResponse response = JsonConvert.DeserializeObject<TResponse>(responseContent);
            return response;
        }
    }
}
