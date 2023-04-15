using Nest;
using Elasticsearch.Net;
using ElasticSearchDemo.Models;

namespace ElasticSearchDemo.Services
{
    public class Customer : ICustomer
    {


        private readonly IElasticClient _client;

        public Customer(IElasticClient client)
        {
            //
            _client = client;
        }

        public async Task<string> AddCustomer(CustomerDTO objCustomer)
        {

            ElasticSearchDemo.Models.Customer objNewCustomer = new ElasticSearchDemo.Models.Customer
            {
                id = Guid.NewGuid(),
                FirstName = objCustomer.FirstName,
                LastName = objCustomer.LastName
            };
            var indexResponse = await _client.IndexAsync(objNewCustomer, idx => idx.Index("customer").OpType(OpType.Index));
            return indexResponse.IsValid ? Convert.ToString(indexResponse.Id) : "Unable to add the item";

        }

        public async Task<dynamic> GetAllCustomers()
        {
            var searchResponse = await _client.SearchAsync<dynamic>(s => s.Index("customer").Query(q => q.MatchAll()));
            return searchResponse.IsValid ? searchResponse.Documents.ToList() : default;

        }

        public async Task<dynamic> GetCustomerByID(string id)
        {
            var searchResponse = _client.Search<ElasticSearchDemo.Models.Customer>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.id)
                        .Query(id)
                    )
                )
            );
            return searchResponse.IsValid ? searchResponse.Documents.ToList().FirstOrDefault() : default;
        }

        public async Task<dynamic> UpdateDocument(Guid id, CustomerDTO objCustomer)
        {
            var objupdatedCustomer = new ElasticSearchDemo.Models.Customer { id = id, };
            var response = _client.Update(DocumentPath<ElasticSearchDemo.Models.Customer>
                .Id(id),
                u => u
                    .Index("customer")
                    .DocAsUpsert(true)
                    .Doc(objupdatedCustomer));
            return response.IsValid;
        }


        public async Task<dynamic> DeleteRecord(string id)
        {
            var searchResponse = _client.Delete<ElasticSearchDemo.Models.Customer>(id);
            return searchResponse.IsValid;
        }

    }
}