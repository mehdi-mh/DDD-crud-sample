using Application.Service.Customers.Dto;

namespace Application.Service.Customers.Commands.AddCustomer
{
    public interface IAddCustomerService
    {
        ResultDTO<ResultAddCustomerDto> Execute(RequestAddCustomerDto request);

    }
}
