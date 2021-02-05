using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHourProject.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "500 Character Max Length")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "UserId")]
        public Guid Author { get; set; }

        public virtual List<Reply> Replies { get; set; } = new List<Reply>();

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; } // navigation


    }
}