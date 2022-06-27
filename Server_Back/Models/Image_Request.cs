using System.ComponentModel.DataAnnotations;

namespace Server_Back.Models
{
    public class Image_Request
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageName { set; get; }

        [Required]
        public string Path { set; get; }
    }
}
