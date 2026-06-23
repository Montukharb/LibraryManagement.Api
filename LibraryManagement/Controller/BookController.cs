using LibraryManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    //[Route("error")] //isme [controller] attribute nahi hai to route name fix ho gaya abhi class name se error/Error replace nahi hoga only /error fix rahe ga
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
