using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace gavl_api.Models
{
    public class ApiResponse
    {
        public bool success;
        public string httpmethod;
        public string request;

        public ApiResponse(HttpRequest request)
        {
            httpmethod = request.Method.ToString();
            this.request = request.Path.ToString();
        }
        
    }
    public class ErrorResponse : ApiResponse
    {   
        public ErrorResponse(HttpRequest request): base(request)
        {
            success = false;
        }
        public ApiError error {get;set;}
    }
    public class DataResponse : ApiResponse
    {
        public DataResponse(HttpRequest request, IEnumerable<dynamic> dat): base(request)
        {
            success = true;
            data = dat;
        } 
        public IEnumerable<dynamic> data {get;set;} 
    }
    public class ApiError
    {
        public string code { get; set; }
        public string message {get; set;}
    }
}