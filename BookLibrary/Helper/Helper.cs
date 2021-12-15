using BookLibrary.Pagination;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookLibrary
{
    public static class Helper
    {
        public static PagedList<Book> GetAllData(ParameterPagination ownerParameters)
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory() + $"\\Data\\BooksData.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            IEnumerable<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Book>>(JSON);
            books = books.AsQueryable();


            return PagedList<Book>.ToPagedList(books.OrderBy(on => on.id),
                 ownerParameters.PageNumber,
                 ownerParameters.PageSize);
        }

        public static IEnumerable<Book> GetDataById(int id)
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory() + $"\\Data\\BooksData.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            IEnumerable<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Book>>(JSON).Where(i => i.id == id);


            return books;
        }

        public static IEnumerable<BooksChanges> GetBooksChanges()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory() + $"\\Data\\BookChanges.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            IEnumerable<BooksChanges> books = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<BooksChanges>>(JSON);


            return books;
        }
    }
}
