namespace MovieAPI.Models
{
    public class Movie
    {
        public int      Id          { get; set; }
        public string   Title       { get; set; }
        public int      CategoryId  { get; set; }
        public Movie(int id, string title, int categoryId)
        {
            Id = id;
            Title = title;
            CategoryId = categoryId;
        }
    }
}
