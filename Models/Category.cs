namespace MovieAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string categoryname)
        {
            Id = id;
            CategoryName = categoryname;
        }
    }
}
