namespace MovieAPI.Models
{
    public class MovieList
    {
        public List<Movie> Movies { get; set; }
        public List<Category> Categories { get; set; }

        public MovieList()
        {
            Categories = new List<Category>()
            {
                new Category(1,"Action"),
                new Category(2,"Comedy"),
                new Category(3,"Sci-Fi"),
                new Category(4,"Drama")
            };
            Movies = new List<Movie>()
            {
                new Movie(0,"Bladerunner",3),
                new Movie(1,"Superbad",2),
                new Movie(2,"John Wick",1),
                new Movie(3,"Planes, Trains, and Automobiles",2),
                new Movie(4,"Dear John",4)
            };
        }
    }
}
