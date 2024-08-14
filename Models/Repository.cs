namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category{CategoryId=1, Name="Electronics"});
        }
        public static List<Product> Products
        {
            get { return _products; }
        }
        public static List<Category> Categories
        {
            get { return _categories; }
        }
    }
    
}