using Application.Service.Customers.Commands.AddCustomer;
using Application.Service.Customers.Commands.DeleteCustomer;
using Application.Service.Customers.Commands.EditCustomer;
using Application.Service.Customers.Dto;
using Application.Service.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IGetCustomersService _getCustomersService;
    private readonly IAddCustomerService _addCustomerService;
    private readonly IEditCustomerService _editCustomerService;
    private readonly IDeleteCustomerService _deleteCustomer;

    public CustomerController(IGetCustomersService getCustomersService, IAddCustomerService addCustomerService,
        IEditCustomerService editCustomerService, IDeleteCustomerService deleteCustomer)
    {
        _getCustomersService = getCustomersService;
        _addCustomerService = addCustomerService;
        _editCustomerService = editCustomerService;
        _deleteCustomer = deleteCustomer;
    }

    // [HttpGet("SayHello")]
    // public string SayHello()
    // {
    //     return "Hello";
    // }

    [HttpGet("get-customer/{id}")]
    public ResultDTO<RequestGetCustomerDto> GetCustomer(int id)
    {
        var result = _getCustomersService.Execute(id);
        return result;
    }

    [HttpGet("get-all-customers")]
    public ResultGetCustomersDto GetAllCustomers()
    {
        var result = _getCustomersService.Execute();
        return result;
    }

    [HttpPost("create-customer")]
    public ResultDTO<ResultAddCustomerDto> CreateCustomer(RequestAddCustomerDto request)
    {
        var result = _addCustomerService.Execute(request);
        return result;
    }

    [HttpPut("edit-customer")]
    public ResultDTO EditCustomer(RequestEditCustomerDto request)
    {
        var result = _editCustomerService.Execute(request);
        return result;
    }

    [HttpDelete("delete-customer/{id}")]
    public ResultDTO DeleteCustomer(int id)
    {
        var result = _deleteCustomer.Execute(id);
        return result;
    }
}