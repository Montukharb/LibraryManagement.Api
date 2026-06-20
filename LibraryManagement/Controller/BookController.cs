using LibraryManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
         
        }
        //get method used for access all table data as a list or single record
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _bookService.GetBooks();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _bookService.GetBookById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}
