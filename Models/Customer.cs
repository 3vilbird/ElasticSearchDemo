namespace ElasticSearchDemo.Models
{
    public class Customer
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}