namespace Libraryservice.Models
{
    public class BookCategoryViewModel
    {
        public IList<Book>? Books { get; set; }
        public SearchTypes SearchTypes { get; set; }
        public string? SearchString { get; set; }
    }
}
