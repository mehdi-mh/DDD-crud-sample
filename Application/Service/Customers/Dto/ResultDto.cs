namespace Application.Service.Customers.Dto
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResultDTO<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
