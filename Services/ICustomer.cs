using ElasticSearchDemo.Models;

namespace ElasticSearchDemo.Services
{
    public interface ICustomer
    {

        public Task<dynamic> GetAllCustomers();
        public Task<string> AddCustomer(CustomerDTO objCustomer);
        public Task<dynamic> GetCustomerByID(string id);
        public Task<dynamic> DeleteRecord(string id);
        public Task<dynamic> UpdateDocument(Guid id, CustomerDTO objCustomer);

    }
}