using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DTO
{
    public class OrderDTO
    {
        [Required]
        public string CstomerName { get; set; }
        public ICollection<BookInOrderDTO> Books { get; set; }
    }
}
