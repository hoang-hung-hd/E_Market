using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class ProductImage_Response
    {
        [Key]
        public int ProductId { set; get; }
        [Key]
        public int ImageId { set; get; }

        public Product_Response Product { set; get; }
        public Image_Response Image { set; get; }
    }
}
