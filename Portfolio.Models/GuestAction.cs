using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class GuestAction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime DateTime{ get; set; }

    }
}
