using System.Text.Json.Serialization;

namespace peace_kenya_api.Helpers
{
    public class Result<T>
    {
        [JsonPropertyName("success")]
        public bool IsSuccess
        {
            get { return Status == ResultStatus.Success; }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Data { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; } = null;

        [JsonIgnore]
        public ResultStatus Status { get; }

        private Result(ResultStatus status, T value = default, string error = null)
        {
            Status = status;
            Data = value;
            Error = error;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(ResultStatus.Success, value);
        }

        public static Result<T> NotFound(string error)
        {
            return new Result<T>(ResultStatus.NotFound, default, error);
        }

        public static Result<T> ValidationError(string error)
        {
            return new Result<T>(ResultStatus.ValidationError, default, error);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(ResultStatus.Failure, default, error);
        }
    }
}

