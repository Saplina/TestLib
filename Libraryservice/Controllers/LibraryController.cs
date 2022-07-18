
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libraryservice.Models;
using Libraryservice.Services;

namespace Libraryservice.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LibraryController : Controller
    {
        private readonly ILabraryRepositoryService _libraryRepositoryService;

        public LibraryController(ILabraryRepositoryService libraryRepositoryService)
        {
            _libraryRepositoryService = libraryRepositoryService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index(SearchTypes searchType, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString) && searchString.Length >= 3)
                switch (searchType)
                {                   
                    case SearchTypes.Title:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByTitle(searchString) });
                    case SearchTypes.Category:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByCategory(searchString) });
                    case SearchTypes.Author:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByAuthor(searchString) });

                }

            return View(new BookCategoryViewModel { Books = new List<Book>() });
        }

        /// <summary>
        /// Получить список книг по наименованию
        /// </summary>
        /// <param name="title">Наименование книги</param>
        /// <returns></returns>
        [HttpGet("get/by-title")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByTitle([FromQuery] string title) =>
            Ok(_libraryRepositoryService.GetByTitle(title));

        /// <summary>
        /// Получить список книг по автору
        /// </summary>
        /// <param name="authorName">Автор</param>
        /// <returns></returns>
        [HttpGet("get/by-author")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByAuthor([FromQuery] string authorName) =>
            Ok(_libraryRepositoryService.GetByAuthor(authorName));

        /// <summary>
        /// Получить список книг по жанру
        /// </summary>
        /// <param name="category">Жанр</param>
        /// <returns></returns>
        [HttpGet("get/by-category")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByCategory([FromQuery] string category) =>
            Ok(_libraryRepositoryService.GetByCategory(category));

       

    }
}
