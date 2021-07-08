using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace gavl_api.Models
{
    public class ApiResponse
    {
        public bool success;
        public string httpmethod;
        public string url;
        public string querystring;
        
    }
    public class ErrorResponse : ApiResponse
    {   
        public ApiError error {get;set;}
    }
    public class DataResponse : ApiResponse
    {
        public IEnumerable<dynamic> data {get;set;} 
    }
    public class ApiError
    {
        public string code { get; set; }
        public string message {get; set;}
        public string url {get;set;}
    }
}