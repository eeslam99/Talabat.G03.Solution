﻿
namespace Talabat.APIs.Errors
{
    public class ApiResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int? statusCode, string? message =null) 
        { 
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);

        
        
        }

        private string? GetDefaultMessageForStatusCode(int? statusCode)
        {
            return StatusCode switch
            {
                400 => "BadRequest",
                401 => "You are not Authorized",
                404 => "Resource Not Found",
                500 => "Internet Server Error",
                  _ => null,
            };
        }
    }
}
