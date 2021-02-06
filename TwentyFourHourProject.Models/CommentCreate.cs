using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHourProject.Models
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
    }
}
