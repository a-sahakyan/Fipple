using Newtonsoft.Json;
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
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, string.Concat(BaseAddress, url));

            string content = JsonConvert.SerializeObject(requestModel);
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            HttpContent httpContent = new ByteArrayContent(buffer);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
            message.Content = httpContent;

            HttpResponseMessage responseMessage = await HttpClient.SendAsync(message);
            string responseContent = await responseMessage.Content.ReadAsStringAsync();
            TResponse response = JsonConvert.DeserializeObject<TResponse>(responseContent);

            return response;
        }
    }
}
