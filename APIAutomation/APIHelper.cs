using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APIAutomation
{
    public class APIHelper<T>
    {
        public RestClient client;
        public RestRequest request;
        public string baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var client = new RestClient(url);
            return client;
        }

        public RestRequest CreatePostRequest(string payload)
        {
           var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");
            return request;
        }


        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        { 
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

        public string Serialize(dynamic content)
        { 
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
            return serializeObject;
        }
    }
}
