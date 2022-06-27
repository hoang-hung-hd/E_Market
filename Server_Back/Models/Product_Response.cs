using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class Product_Response
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 characters")]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Description must be 3 to 250 characters")]
        public string Description { set; get; }

        [Required]
        public double Price { set; get; }

        public DateTime Created { set; get; }

        public Category_Response Category { get; set; }
        public ICollection<Image_Response> Images { get; set; }
    }
}
