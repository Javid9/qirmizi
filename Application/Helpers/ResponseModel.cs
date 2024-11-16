using System.Text.Json.Serialization;

namespace Application.Helpers
{
    public class ResponseModel<T>
    {
        public T Data { get; set; } = default!;
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
        public string? Message { get; set; }

        public static ResponseModel<T> Success(T data, int statusCode)
        {
            return new ResponseModel<T> { Data = data, IsSuccess = true, StatusCode = statusCode };
        }

        public static ResponseModel<T> Success(T data, string message, int statusCode)
        {
            return new ResponseModel<T> { Data = data, IsSuccess = true, Message = message, StatusCode = statusCode };
        }

        public static ResponseModel<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseModel<T> { Errors = errors, IsSuccess = false, StatusCode = statusCode };
        }

        public static ResponseModel<T> Fail(string error, int statusCode)
        {
            return new ResponseModel<T> { Errors = new List<string> { error }, IsSuccess = false, StatusCode = statusCode };
        }


    }
}
