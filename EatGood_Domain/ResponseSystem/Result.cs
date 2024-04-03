using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EatGood_Domain.ResponseSystem
{
    public class Result<T>
    {
        public T? Content { get; set; }
        public Error? Error { get; set; }
        public bool HasError => ErrorMessage != "";
        public string ErrorMessage { get; set; } = "";
        public string Message { get; set; } = "";
        public string RequestId { get; set; } = "";
        public bool IsSuccess { get; set; } = true;
        public DateTime RequestTime { get; set; } = DateTime.UtcNow;
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; } = 200;

        public Result()
        {
        }

        // Helper method to create a failed result
        public static Result<T> Fail(string errorMessage, int statusCode = 400)
        {
            return new Result<T>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode
            };
        }

        // Helper method to create a successful result
        public static Result<T> Success(T content, string message = "", int statusCode = 200)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Content = content,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
