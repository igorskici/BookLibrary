using BookLibrary.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
     
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Book> GetAllBooksPagination([FromQuery] ParameterPagination ownerParameters)
        {
            var data = Helper.GetAllData(ownerParameters);
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var data = Helper.GetDataById(id);
            return Ok(data);
        }

        [HttpGet]
        public ActionResult<Book> GetBookChanges()
        {
            var data = Helper.GetBooksChanges();
            return Ok(data);
        }

        [HttpPost]
        public ActionResult<Book> EditBook([FromBody] Book book)
        {
            var data = Helper.EditBook(book);
            return Ok(data);
        }
    }
}
