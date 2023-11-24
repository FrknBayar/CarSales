namespace Car.Services.Models
{
    public class ResponseModel<T> where T : class
    {
        public T Response { get; set; }

        public List<MessageModel> Messages { get; set; } = new();
    }
}
