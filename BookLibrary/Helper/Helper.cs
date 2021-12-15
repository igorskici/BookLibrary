using BookLibrary.Pagination;
using Newtonsoft.Json.Linq;
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

        public static List<Book> EditBook(Book bookForChange)
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory() + $"\\Data\\BooksData.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            List<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(JSON);
            var book = books.Where(i => i.id == bookForChange.id).ToList();

            book[0] = bookForChange;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
            string serBook = Newtonsoft.Json.JsonConvert.SerializeObject(books[0], Newtonsoft.Json.Formatting.Indented);

            string founderMinus1 = output.Remove(output.Length - 1, 1);

            //Add to Json 
            File.WriteAllText(folderDetails, founderMinus1 + "," + serBook + "]");

            //should remove book[0] from json file....

            return books;
        }
    }
}
