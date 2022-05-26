namespace UnitTesting.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository _simpleRepository = new SimpleRepository();
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public static SimpleRepository simpleRepository => _simpleRepository;

        private SimpleRepository()
        {
            var init = new[]
            {
                new Product{Name = "Sasha", Price = 234.34M},
                new Product{Name = "Canonade", Price = 234.34M},
                new Product{Name = "Diffraction", Price = 234.34M},
                new Product{Name = "Dog", Price = 254.34M},
                new Product{Name = "breeding", Price = 254.364M},
                new Product{Name = "Homeling", Price = 234.34M},
                new Product{Name = "Ingush", Price = 237.34M},
                new Product{Name = "Liver", Price = 834.4M},
                new Product{Name = "substituated", Price = 134.344M},
                new Product{Name = "There's", Price = 34.34M},
                new Product{Name = "woman", Price = 23.3M},
            };
            foreach (var p in init)
            {
                AddProduct(p);
            }
        }

        public IEnumerable<Product> Products => _products.Values;
        public void AddProduct(Product product) => _products.Add(product.Name,product);
    }
}

