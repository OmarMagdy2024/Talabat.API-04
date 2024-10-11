
namespace Talabat.API.Errors
{
    public class APIResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }

        public APIResponse(int status,string? message=null)
        {
            Status = status;
            Message = message??GetDefaultMessage(status);
        }

        private string? GetDefaultMessage(int status)
        {
            return status switch
            {
                400 => "Bad Request",
                401 => "Un Authrized",
                404 => "Not Found",
                500 => "Server Error",
                _ => null,
            };
        }
    }
}
