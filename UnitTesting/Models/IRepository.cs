namespace UnitTesting.Models
{
    public interface IRepository
    {
       public IEnumerable<Product> Products { get; }
        
       public void AddProduct(Product p);
    }
}

