using System.Text;
using Application.Interfaces.Contexts;
using Application.Service.Customers.Dto;
using Domain.Entities;
using FluentValidation.Results;

namespace Application.Service.Customers.Commands.AddCustomer
{
    public class AddCustomerService : IAddCustomerService
    {
        private readonly IDatabaseContext _context;

        public AddCustomerService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<ResultAddCustomerDto> Execute(RequestAddCustomerDto request)
        {
            try
            {
                var validator = new AddCustomerValidator(request);
                ValidationResult results = validator.Validate(request);
                if (!results.IsValid)
                {
                    var sb = new StringBuilder();
                    foreach (var failure in results.Errors)
                    {
                        sb.Append(failure.ErrorMessage).Append(" , ");
                    }

                    return new ResultDTO<ResultAddCustomerDto>()
                    {
                        Data = new ResultAddCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = sb.ToString(),
                    };
                }

                var customer = new Customer()
                {
                    BankAccountNumber = request.BankAccountNumber,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return new ResultDTO<ResultAddCustomerDto>()
                {
                    Data = new ResultAddCustomerDto()
                    {
                        CustomerId = customer.Id
                    },
                    IsSuccess = true,
                    Message = "Customer Created Successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultDTO<ResultAddCustomerDto>()
                {
                    Data = new ResultAddCustomerDto()
                    {
                        CustomerId = 0,
                    },
                    IsSuccess = false,
                    Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                };
            }
        }
    }
}