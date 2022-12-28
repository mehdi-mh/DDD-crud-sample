using Application.Service.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Customers.Commands.DeleteCustomer
{
    public interface IDeleteCustomerService
    {
        ResultDTO Execute(int id);

    }
}
