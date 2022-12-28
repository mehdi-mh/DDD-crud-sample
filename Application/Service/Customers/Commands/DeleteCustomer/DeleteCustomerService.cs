using Application.Interfaces.Contexts;
using Application.Service.Customers.Dto;

namespace Application.Service.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerService:IDeleteCustomerService
    {
        private readonly IDatabaseContext _context;

        public DeleteCustomerService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(int id)
        {

            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "Customer not found"
                    };
                }

                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return new ResultDTO()
                {
                    IsSuccess = true,
                    Message = "Customer deleted successfully"
                };
            }
            catch (Exception)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "Customer deletion error"
                };
            }
        }
    }
}
