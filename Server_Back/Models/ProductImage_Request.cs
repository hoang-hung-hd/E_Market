using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class ProductImage_Request
    {
        [Key]
        public int ProductId { set; get; }
        [Key]
        public int ImageId { set; get; }
    }
}
