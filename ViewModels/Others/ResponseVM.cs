namespace API.ViewModels.Others
{
    public class ResponseVM<T>
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
