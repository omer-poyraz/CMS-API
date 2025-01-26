namespace Entities.Response
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Result { get; set; }

        public static ApiResponse<T> Success(
            T result,
            string message = Messages.Success.Retrieved,
            int statusCode = 200
        )
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = statusCode,
                Result = result,
            };
        }

        public static ApiResponse<T> Error(
            string message = Messages.Error.ServerError,
            int statusCode = 400
        )
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = statusCode,
                Result = default,
            };
        }
    }
}
