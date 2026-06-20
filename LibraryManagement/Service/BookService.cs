using LibraryManagement.Entity;
using LibraryManagement.Repository;

namespace LibraryManagement.Service
{
    public interface IBookService
    {
        //define book contracts
        public Task<List<Books>> GetBooks();
        public Task<Books?> GetBookById(int id);
        //public Task<bool> AddBook(Books book);
        //public Task<bool> DeleteBook(int id);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Books>> GetBooks()
        {
            var rec = await _repository.GetBooksRepo();
            if (rec.Count > 10)
            {
                return rec;
            }
            return new List<Books>();
        }

        public async Task<Books?> GetBookById(int id)
        {
            return await _repository.GetBookByIdRepo(id);
        }

    }
}
