using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Biography
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string ImageAltText { get; set; }
        [Required]
        public string ImageFooter { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
