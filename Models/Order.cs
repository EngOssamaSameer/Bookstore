using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Order
    {
        public Order()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CstomerName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
