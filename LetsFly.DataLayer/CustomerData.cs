using Dapper;
using LetsFly.DataLayer.Interface;
using LetsFly.DataObj;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsFly.DataLayer
{
    public class CustomerData : ICustomerData
    {
        public async Task<List<CustomerDo>> GetAllCustomers()
        {
            List<CustomerDo> customers;
            try
            {
                using (var connection = new SqlConnection("Server = .; Initial Catalog = LetsFly; Persist Security Info = False; MultipleActiveResultSets = False; Trusted_Connection = True; Connection Timeout = 30;"))
                {
                    customers = (await connection.QueryAsync<CustomerDo>("SELECT * FROM Customer")).ToList();
                }
                return customers;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}
