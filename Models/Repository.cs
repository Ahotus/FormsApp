namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });

            _products.Add(new Product { ProductId = 1, Name = "Samsung S5", Price = 2000, Image = "1.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "Samsung S6", Price = 3000, Image = "2.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Samsung S7", Price = 4000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, Name = "Samsung S8", Price = 5000, Image = "4.jpg", IsActive = true, CategoryId = 1 });
            
            _products.Add(new Product { ProductId = 5, Name = "Asus Zenbook", Price = 5000, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductId = 6, Name = "Macbook Pro", Price = 10000, Image = "6.jpg", IsActive = true, CategoryId = 2 });
        }
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}