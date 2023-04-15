using Elasticsearch.Net;
using ElasticSearchDemo.Models;
using Nest;

public static class ElasticSearchExtensions
{
    public static void AddElasticsearch(
        this IServiceCollection services, IConfiguration configuration)
    {

        var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
                 .DefaultIndex("customer");
        

        var client = new ElasticClient(connectionSettings);

        services.AddSingleton<IElasticClient>(client);

        CreateIndex(client, "customer");
    }
 

    private async static void CreateIndex(IElasticClient client, string indexName)
    {
        Customer objCustomer = new Customer { id = Guid.NewGuid(), FirstName = "testing", LastName = "Lname" };
        var indexResponse = await client.IndexAsync(objCustomer, idx => idx.Index(indexName).OpType(OpType.Index));
    }
}
