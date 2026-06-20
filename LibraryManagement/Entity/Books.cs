using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Entity
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        public int PublisherId { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}
