using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Video
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Tool Tip")]
        public string ToolTip { get; set; }

        [Required]
        public string URL { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
    }
}
