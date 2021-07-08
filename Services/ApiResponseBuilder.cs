using System;
using System.Collections.Generic;
using gavl_api.Models;
using Microsoft.AspNetCore.Http;

namespace gavl_api.Services
{
    public class ApiResponseBuilder
    {
        private bool _success;
        private string _httpMethod;
        private string _url;
        private string _queryString;
        private IEnumerable<dynamic> _data;
        private ApiError _error;
        public ApiResponseBuilder(HttpRequest request)
        {
            _httpMethod = request.Method.ToString();
            _url = request.Path.ToString();
            _queryString = request.QueryString.ToString();
        }
        public void AddData(IEnumerable<dynamic> data)
        {
            _success = true;
            _data = data;
        }
        public void AddError(ApiError error)
        {
            _success = false;
            _error = error;
        }
        public ApiResponse GenerateReponse()
        {
            if(_success)
                return new DataResponse{
                    success = _success,
                    httpmethod = _httpMethod,
                    url = _url,
                    querystring = _queryString,
                    data = _data
                };
            else 
                return new ErrorResponse{
                    success = _success,
                    httpmethod = _httpMethod,
                    url = _url,
                    querystring = _queryString,
                    error = _error
                };
        }
    }
}