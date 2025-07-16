// Models/UpdateRequest.cs
namespace myblog.Models
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string NewValue { get; set; } = string.Empty;
    }
    public class UpdateDateRequest
    {
        public int Id { get; set; }
        public DateTime NewDate { get; set; }
    }
}
