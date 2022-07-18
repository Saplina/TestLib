using System.ComponentModel.DataAnnotations;

namespace Libraryservice.Models
{
    public enum SearchTypes
    {
        [Display (Name ="Искать по заголовку")]
        Title,
        [Display(Name = "Искать по автору")]
        Author,
        [Display(Name = "Искать по категории")]
        Category
    }
}
