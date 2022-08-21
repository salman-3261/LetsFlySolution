using Dapper;
using LetsFly.Business.Interface;
using LetsFly.BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIProject.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly ICustomerService _customerService;

        public ValuesController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        // GET api/values
        /// <summary>
        /// Get All the Values
        /// </summary>
        /// <remarks>
        /// Get All the String Values
        /// </remarks>
        /// <returns>All the String Values</returns>
        public async Task<IHttpActionResult> Get()
        {
            List<CustomerBo> customers;
            try 
            {
                customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch(Exception exception)
                {
                return InternalServerError();
            }
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            //return strings[id];
            return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            //strings.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
           // strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            //strings.RemoveAt(id);
        }
    }
}
