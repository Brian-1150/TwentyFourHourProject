using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHourProject.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Please limit reply to less than 100 characters.")]
        public string Text { get; set; }

    }
}
