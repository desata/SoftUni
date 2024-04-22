namespace Library.Models
{
    public class BookInfoViewModel
    {
        public BookInfoViewModel(int id, string imageUrl, string title, string author, decimal rating, string name)
        {
            id = Id;
            imageUrl = ImageUrl;
            title = Title;
            author = Author;
            rating = Rating;
            name = Category;
        }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }
        public string Category { get; set; }
    }
}
