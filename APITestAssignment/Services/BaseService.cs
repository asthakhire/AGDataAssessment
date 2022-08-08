using APITestAssignment.Configurations;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace APITestAssignment
{
    public class BaseService
    {
        public string TestUri;
        public System.Net.Http.HttpClient _httpClient { get; set; }

        public BaseService()
        {
            this.TestUri = TestConfig.TestUri;
            _httpClient = new System.Net.Http.HttpClient();
        }
        public async Task<HttpResponseMessage> Post(string requestUrl, HttpContent content)
        {
            var responseMessage = await _httpClient.PostAsync(requestUrl, content);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> Get(string requestUrl)
        {
            var responseMessage = await _httpClient.GetAsync(requestUrl);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> Put(string requestUrl, HttpContent content)
        {

            var responseMessage = await _httpClient.PutAsync(requestUrl, content);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> Delete(string requestUrl)
        {
            var responseMessage = await _httpClient.DeleteAsync(requestUrl);
            return responseMessage;
        }
    }
}
