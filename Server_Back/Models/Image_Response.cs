using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class Image_Response
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageName { set; get; }

        [Required]
        public string Path { set; get; }

        public ICollection<Product_Response> Products { get; set; }

    }
}
