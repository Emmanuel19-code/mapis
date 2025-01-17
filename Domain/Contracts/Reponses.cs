namespace mapis.Domain
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class CreatedResponse : BaseResponse
    {
        public bool Success { get; set; }
    }
    public class AdminLoginResponse : BaseResponse
    {
        public string? AccessToken { get; set; }
    }
    public class ApplicantsResponseInfo<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
    public class UpdateApplicantResponse : BaseResponse
    {
    }
    public class ApplyResponse : BaseResponse
    {
        public Guid? ApplicantId { get; set; }
    }
}
