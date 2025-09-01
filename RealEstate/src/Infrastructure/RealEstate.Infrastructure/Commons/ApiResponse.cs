using System.Net;

namespace RealEstate.Infrastructure.Commons
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; set; }
        public static ApiResponse Success(string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse
            {
                StatusCode = statusCode,
                Message = message,
            };

        }

        public static ApiResponse Success<T>(T data, string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            where T : class
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };

        }

        public static ApiResponse Fail(string reason, string message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResponse
            {
                StatusCode = statusCode,
                Message = message,
                Reason = reason
            };

        }

        public static ApiResponse Fail(IDictionary<string, IEnumerable<string>> errors, string reason, string message = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse
            {
                StatusCode = statusCode,
                Message = message,
                Reason = reason,
                Errors = errors

            };

        }

    }

    public class ApiResponse<T> : ApiResponse
        where T : class
    {
        public T Data { get; set; }
    }
}
