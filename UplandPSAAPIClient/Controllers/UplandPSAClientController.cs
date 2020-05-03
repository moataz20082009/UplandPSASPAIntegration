using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace UplandPSAAPIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplandPSAClientController : ControllerBase
    {
        private class ApiClient
        {
            string baseUrl = "http://10.60.19.210/tenterprise/api/";
            string orgName = "TenroxR201";
            string token = "";
            string endPoint = "";
            string objectid = "";
            public ApiClient(HttpRequest request)
            {
                StringValues strValue = new StringValues();
                if (request.Headers.TryGetValue("ApiBaseUrl", out strValue))
                {
                    baseUrl = strValue.FirstOrDefault();
                }
                if (request.Headers.TryGetValue("orgname", out strValue))
                {
                    orgName = strValue.FirstOrDefault();
                }
                if (request.Headers.TryGetValue("token", out strValue))
                {
                    token = strValue.FirstOrDefault();
                }
                if (request.Headers.TryGetValue("endpoint", out strValue))
                {
                    endPoint = strValue.FirstOrDefault();
                }
                if (request.Headers.TryGetValue("objectid", out strValue))
                {
                    objectid = strValue.FirstOrDefault();
                }
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("OrgName", orgName);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                Url = $"{baseUrl.Trim('/')}/{endPoint}{(string.IsNullOrWhiteSpace(objectid) ? string.Empty : $"/{objectid}")}?{request.QueryString}";
                HttpClient = client;
            }
            private string Url { get; set; }
            private HttpClient HttpClient { get; set; }
            public Task<HttpResponseMessage> InvokeGet()
            {
                return HttpClient.GetAsync(Url);
            }
            public Task<HttpResponseMessage> InvokeDelete()
            {
                return HttpClient.DeleteAsync(Url);
            }
            public Task<HttpResponseMessage> InvokePost(object json)
            {
                string jsonString = JsonConvert.SerializeObject(json);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return HttpClient.PostAsync(Url, content);
            }
            public Task<HttpResponseMessage> InvokePut(object json)
            {
                string jsonString = JsonConvert.SerializeObject(json);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return HttpClient.PutAsync(Url, content);
            }
        }


        [HttpGet]
        public async Task<IActionResult> InvokeGetAsync()
        {
            ApiClient client = new ApiClient(Request);
            var response = await client.InvokeGet();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = new ContentResult() { Content = jsonResult, StatusCode = (int)response.StatusCode };
            if(response.IsSuccessStatusCode)
            {
                result.ContentType = "application/json";
            }
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> InvokeDeleteAsync()
        {
            ApiClient client = new ApiClient(Request);
            var response = await client.InvokeDelete();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = new ContentResult() { Content = jsonResult, StatusCode = (int)response.StatusCode };
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> InvokePostAsync([FromBody]object data)
        {
            ApiClient client = new ApiClient(Request);
            var response = await client.InvokePost(data);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = new ContentResult() { Content = jsonResult, StatusCode = (int)response.StatusCode };
            if (response.IsSuccessStatusCode)
            {
                result.ContentType = "application/json";
            }
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> InvokePutAsync([FromBody]object data)
        {
            ApiClient client = new ApiClient(Request);
            var response = await client.InvokePut(data);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = new ContentResult() { Content = jsonResult, StatusCode = (int)response.StatusCode };
            if (response.IsSuccessStatusCode)
            {
                result.ContentType = "application/json";
            }
            return result;
        }
    }
}