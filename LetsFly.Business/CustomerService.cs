using AutoMapper;
using LetsFly.Business.AutoMapper;
using LetsFly.Business.Interface;
using LetsFly.BusinessObject;
using LetsFly.DataLayer.Interface;
using LetsFly.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsFly.Business
{
    public class CustomerService : ICustomerService
    {

        readonly ICustomerData _customerData;
        readonly IMapper _mapper;

        public CustomerService(ICustomerData customerData) 
        {
            _customerData = customerData;
            _mapper = AutoMapperService.AutoMapperStart();
        }
        public async Task<List<CustomerBo>> GetAllCustomers() 
        {
            List<CustomerBo> customer;
            try
            {
                List<CustomerBo> customerList = _mapper.Map<List<CustomerDo>, List<CustomerBo>>(await _customerData.GetAllCustomers());
                return customerList;
            }
            catch (Exception exception)
            {
                exception.ToString();
                throw;
            }
        }
        

    }
}
