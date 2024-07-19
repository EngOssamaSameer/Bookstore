using System.ComponentModel.DataAnnotations;

namespace BookStore.DTO
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Copies { get; set; }
    }
}
