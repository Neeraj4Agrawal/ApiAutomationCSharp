using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation
{
    internal class Class1
    {

        static void Main(string[] args)
        {//FIRST PROGRAM 
            /*       var restClient = new RestClient("https://reqres.in/");
                   var restRequest = new RestRequest("/api/users?page=2", Method.Get);
                   restRequest.AddHeader("Accept", "application/json");
                   restRequest.RequestFormat = DataFormat.Json;
                   RestResponse response = restClient.Execute(restRequest);
                   var content = response.Content;
                   var statusCode = response.StatusCode;
                   var hashcode = response.GetHashCode();
                   Console.WriteLine("status code is ----------- "+statusCode);
                   Console.WriteLine("content is ----------- " + content);
                   Console.WriteLine("hashcode is ----------- " + hashcode);
                   Console.ReadLine();*/

            // SECOND PROGRAM 
            /*     var data = new Code();
                 var response1 = data.GetUser();
                 Console.WriteLine("So here the hashcode values is --------" + response1.GetHashCode());
                 Console.WriteLine("So here the Page  values is --------" + response1.Page);
                 Assert.AreEqual(3, response1.Page);
                 Console.ReadLine();   */

            string payload = @"{
                               ""name"": ""morpheus"",
                               ""job"" : ""leader""
                                       }";

            var user = new APIHelper<CreateUserDIO>();
            var url = user.SetUrl("api/users");
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url,request);
            CreateUserDIO content = user.GetContent<CreateUserDIO>(response);
            Console.WriteLine("Name after hitting post request ---  "+content.Name);
            Console.WriteLine("Job after hitting post request ---  " + content.Job);
            Console.WriteLine("Hashcode after hitting post request ---  "+content.GetHashCode());
            Assert.AreEqual("morpheus", content.Name);
            Console.ReadLine();



        }   
    }
}
