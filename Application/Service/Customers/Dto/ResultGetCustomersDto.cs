namespace Application.Service.Customers.Dto
{
    public class ResultGetCustomersDto
    {
        public List<GetCustomersDto>? Customers { get; set; }
        public int Rows { get; set; }
    }
}
