using Application.Interfaces.Contexts;
using Application.Service.Customers.Dto;

namespace Application.Service.Customers.Queries
{
    public class GetCustomersService : IGetCustomersService
    {
        private readonly IDatabaseContext _context;

        public GetCustomersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultGetCustomersDto Execute()
        {
            var users = _context.Customers.AsQueryable();

            var userList = users.Select(
                    p => new GetCustomersDto
                    {
                        Firstname = p.Firstname,
                        Lastname = p.Lastname,
                        BankAccountNumber = p.BankAccountNumber,
                        DateOfBirth = p.DateOfBirth,
                        Email = p.Email,
                        Id = p.Id,
                        PhoneNumber = p.PhoneNumber,
                    })
                .ToList();


            return new ResultGetCustomersDto()
            {
                Customers = userList,
                Rows = userList.Count()
            };
        }

        public ResultDTO<RequestGetCustomerDto?> Execute(int id)
        {
            try
            {
                var user = _context.Customers.FirstOrDefault(i => i.Id == id);
                if (user == null)
                {
                    return new ResultDTO<RequestGetCustomerDto?>
                    {
                        IsSuccess = false,
                        Message = "Customer not found"
                    };
                }
                else
                {
                    return new ResultDTO<RequestGetCustomerDto?>
                    {
                        Data = new RequestGetCustomerDto()
                        {
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            BankAccountNumber = user.BankAccountNumber,
                            DateOfBirth = user.DateOfBirth,
                            Email = user.Email,
                            Id = user.Id,
                            PhoneNumber = user.PhoneNumber,
                        },
                        IsSuccess = true,
                        Message = ""
                    };
                }
            }
            catch (Exception)
            {
                return new ResultDTO<RequestGetCustomerDto?>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Customer get error"
                };
            }
        }
    }
}