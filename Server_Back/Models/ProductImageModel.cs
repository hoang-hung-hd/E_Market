using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class ProductImageModel
    {
        [Key]
        public int ProductId { set; get; }
        [Key]
        public int ImageId { set; get; }

        public ProductModel Product { set; get; }
        public ImageModel Image { set; get; }
    }
}
