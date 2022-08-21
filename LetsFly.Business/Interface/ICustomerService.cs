using LetsFly.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsFly.Business.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerBo>> GetAllCustomers();
    }
}
