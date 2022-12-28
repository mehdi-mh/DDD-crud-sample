using Application.Service.Customers.Dto;

namespace Application.Service.Customers.Commands.EditCustomer
{
    public interface IEditCustomerService
    {
        ResultDTO Execute(RequestEditCustomerDto request);
    }
}