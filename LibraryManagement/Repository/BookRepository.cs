using LibraryManagement.dbcontext;
using LibraryManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
    public interface IBookRepository
    {
        public Task<List<Books>> GetBooksRepo();
        public Task<Books?> GetBookByIdRepo(int id);
        //public Task<bool> AddBookRepo(Books book);
        //public Task<bool> DeleteBookRepo(int id);
    }
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Books>> GetBooksRepo()
        {
          return await _context.LibraryBooks.ToListAsync();
        }
        public async Task<Books?> GetBookByIdRepo(int id)
        {
           var record =  await _context.LibraryBooks.FindAsync(id);
            
            if(record is not null)
            {
                return record;
            }
            return null;

        }
    }
}
