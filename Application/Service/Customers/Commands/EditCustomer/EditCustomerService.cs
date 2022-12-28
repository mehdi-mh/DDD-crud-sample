using Application.Interfaces.Contexts;
using Application.Service.Customers.Dto;
using System.Text;

namespace Application.Service.Customers.Commands.EditCustomer
{
    public class EditCustomerService : IEditCustomerService
    {
        private readonly IDatabaseContext _context;

        public EditCustomerService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(RequestEditCustomerDto request)
        {
            try
            {
                var customer = _context.Customers.Find(request.Id);
                if (customer == null)
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "Customer not found"
                    };
                }

                var validator = new EditCustomerValidator(request);
                var results = validator.Validate(request);
                if (!results.IsValid)
                {
                    var sb = new StringBuilder();
                    foreach (var failure in results.Errors)
                    {
                        sb.Append(failure.ErrorMessage).Append(" , ");
                    }

                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = sb.ToString(),
                    };
                }

                customer.Firstname = request.Firstname;
                customer.Lastname = request.Lastname;
                customer.Email = request.Email;
                customer.PhoneNumber = request.PhoneNumber;
                customer.BankAccountNumber = request.BankAccountNumber;
                customer.DateOfBirth =request.DateOfBirth;

                _context.SaveChanges();
                return new ResultDTO()
                {
                    IsSuccess = true,
                    Message = "Customer edited successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "Customer edit error"
                };
            }
        }
    }
}