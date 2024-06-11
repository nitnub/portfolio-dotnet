using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Biography
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }
        
        [Required]
        [DisplayName("Image Alt Text")]
        public string ImageAltText { get; set; }
        
        [Required]
        [DisplayName("Image Footer")]
        public string ImageFooter { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}
