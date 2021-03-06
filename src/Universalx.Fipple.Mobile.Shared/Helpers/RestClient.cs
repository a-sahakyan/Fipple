using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Universalx.Fipple.Mobile.Models;

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
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClient = new HttpClient(httpClientHandler);
        }

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string url, NameValueCollection queryParams = null)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url), "URL is missing");
            }

            if(queryParams != null)
            {
                AddQueryParams(ref url, queryParams);
            }

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, string.Concat(BaseAddress, url));
            HttpResponseMessage responseMessage = await HttpClient.SendAsync(message);
            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            ApiResponse<TResponse> response = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseContent);
            return response;
        }

        private void AddQueryParams(ref string url, NameValueCollection queryParams)
        {
            var uriBuilder = new UriBuilder(url);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (string name in queryParams.Keys)
            {
                query[name] = queryParams[name];
            }

            uriBuilder.Query = query.ToString();
            url = string.Concat(uriBuilder.Path, uriBuilder.Query);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest requestModel)
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

            ApiResponse<TResponse> response = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseContent);
            return response;
        }
    }
}
