using LetsFly.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsFly.DataLayer.Interface
{
    public interface ICustomerData
    {
        Task<List<CustomerDo>> GetAllCustomers();
    }
}
