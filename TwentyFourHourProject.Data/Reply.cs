﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHourProject.Data
{
    public class Reply
    {

        [Key]
        public int ReplyId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }


        //Navigation Property
        public virtual Comment Comment { get; set; } //virtual means it can be overwritten

        [Required]
        public Guid Author { get; set; }

        [Required]
        public string Text { get; set; }

        //Might need to add the datetime offset utc later



    }
}
