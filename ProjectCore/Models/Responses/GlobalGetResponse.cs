namespace ProjectCore.Models.Responses
{
    public class GlobalGetResponse
    {
        public EnErrorCode ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object? ResponseObject { get; set; }
    }
}
