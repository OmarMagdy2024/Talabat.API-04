namespace Talabat.API.Errors
{
    public class ExceptionError:APIResponse
    {
        public string? Details { get; set; }
        public ExceptionError(int statuscode,string? message=null,string details=null):base(statuscode,message)
        {
            Details = details;
        }
    }
}
