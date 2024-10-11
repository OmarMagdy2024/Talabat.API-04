namespace Talabat.API.Errors
{
    public class ValidationError:APIResponse
    {
        public ICollection<string> Errors { get; set; }
        public ValidationError():base(400)
        {
            Errors = new List<string>();
        }


    }
}
