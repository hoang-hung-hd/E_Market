using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageName { set; get; }

        [Required]
        public string Path { set; get; }

        public ICollection<ProductModel> Products { get; set; }

    }
}
