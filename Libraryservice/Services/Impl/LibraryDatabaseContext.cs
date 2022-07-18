using Libraryservice.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Libraryservice.Services.Impl
{
    public class LibraryDatabaseContext : ILibraryDatabaseContextService
    {
        private IList<Book> _libraryDatabase;
        private readonly IOptions<DatabaseOptions> _databaseOptions;
        private readonly ILogger<LibraryDatabaseContext> _logger;
        public IList<Book> Books { get => _libraryDatabase; }
        public LibraryDatabaseContext(IOptions<DatabaseOptions> databaseOptions,
           ILogger<LibraryDatabaseContext> logger)
        {
            _databaseOptions = databaseOptions;
            _logger = logger;
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _libraryDatabase =
                       (List<Book>)JsonConvert.DeserializeObject(File.ReadAllText(_databaseOptions.Value.FileName), typeof(List<Book>));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Database load error.");
            }
        }
    }
}
