using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.Responses
{
    public static class ApiResponseFactory
    {
        public static ApiResponse<T> Create<T>(
            int statusCode,
            string message,
            T data = default,
            List<string> errors = null)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = errors
            };
        }
    }

}