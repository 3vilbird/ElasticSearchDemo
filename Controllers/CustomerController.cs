using ElasticSearchDemo.Models;
using ElasticSearchDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _customer;


        public CustomerController(ICustomer customer)
        {
            _customer = customer;

        }
        [HttpGet(Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var res = await _customer.GetAllCustomers();
            return Ok(res);
        }

        [HttpGet(Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerByID(string id)
        {
            var res = await _customer.GetCustomerByID(id);
            return Ok(res);
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO objCustomer)
        {
            var res = await _customer.AddCustomer(objCustomer);
            return Ok(res);
        }

        [HttpPut(Name = "UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerDTO objCustomer)
        {
            var res = await _customer.UpdateDocument(id, objCustomer);
            return Ok(res);
        }



        [HttpDelete(Name = "DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(string id)
        {
            var res = await _customer.DeleteRecord(id);
            return Ok(res);
        }


    }
}