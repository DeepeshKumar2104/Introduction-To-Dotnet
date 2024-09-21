
namespace CodefirstApproach.Reposit
{
    public class StudentRepository : IProduct
    {
        public List<Product> GetAllProduct() {
            return DataSource();
        }

        public Product GetAllProductbyId(int id) { return DataSource().Where(x => x.ProductId == id).FirstOrDefault(); }

        private List<Product> DataSource()
        {
            return new List<Product> {
            new Product { ProductId = 1, ProductName = "Laptop",
                          Price = 799.99m, StockQuantity = 50,
                          Category = "Electronics", Supplier = "Tech World" },
            new Product { ProductId = 2, ProductName = "Smartphone",
                          Price = 499.99m, StockQuantity = 120,
                          Category = "Electronics",
                          Supplier = "Mobile Solutions" },
            new Product { ProductId = 3, ProductName = "Office Chair",
                          Price = 89.99m, StockQuantity = 75,
                          Category = "Furniture", Supplier = "Furniture Hub" },
            new Product { ProductId = 4, ProductName = "Bluetooth Speaker",
                          Price = 29.99m, StockQuantity = 200,
                          Category = "Electronics", Supplier = "Sound Gear" },
            new Product { ProductId = 5, ProductName = "Water Bottle",
                          Price = 9.99m, StockQuantity = 300,
                          Category = "Home Essentials",
                          Supplier = "Daily Needs" }
        };
        }
    }
}
