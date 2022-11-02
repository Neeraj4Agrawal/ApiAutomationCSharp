using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace APIAutomation
{
    public class Code<T>
    {

        public ListOUserDTO GetUser(string endpoint)
        { 
            var user = new APIHelper<ListOUserDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOUserDTO content = user.GetContent<ListOUserDTO>(response);
            return content;
        }

        public CreateUserDIO CreateUser(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDIO>();
            var url = user.SetUrl(endpoint);
         //   var jsonReq= user.Serialize(payload);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            CreateUserDIO content = user.GetContent<CreateUserDIO>(response);
            return content;
        }
    }
}
