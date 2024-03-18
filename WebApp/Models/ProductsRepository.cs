namespace WebApp.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99},
            new Product { ProductId = 2, CategoryId = 1, Name = "Cola", Quantity = 300, Price = 2.99},
            new Product { ProductId = 3, CategoryId = 2, Name = "White Bread", Quantity = 200, Price = 0.99},
            new Product { ProductId = 4, CategoryId = 2, Name = "Cinnamon Rols", Quantity = 150, Price = 1.50},

        };

        public static void AddProduct(Product product)
        {
            var MaxId = _products.Max(x => x.ProductId);
            product.ProductId = MaxId + 1;
            _products.Add(product);
        }

        public static List<Product> GetProducts() => _products;

        public static Product? GetProductById(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                return new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                };
            }

            return null;
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if(product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
