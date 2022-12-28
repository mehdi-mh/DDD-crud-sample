using Application.Service.Customers.Dto;

namespace Application.Service.Customers.Queries
{
    public interface IGetCustomersService
    {
        ResultGetCustomersDto Execute();
        ResultDTO<RequestGetCustomerDto?> Execute(int id);
    }
}
