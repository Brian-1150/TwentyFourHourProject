using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHourProject.Data
{ 
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }
        [Required]
        public Guid Author { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}