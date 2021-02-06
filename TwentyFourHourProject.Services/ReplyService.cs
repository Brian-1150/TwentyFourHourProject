using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHourProject.Data;
using TwentyFourHourProject.Models;

namespace TwentyFourHourProject.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public Comment _comment = new Comment();

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _userId,
                    Text = model.Text,
                    CommentId = model.CommentId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                
               // _comment.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

       
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Replies
                    .Where(e => e.Author == _userId)
                    .Select(
                    e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId
                        }
                    );
                return query.ToArray();
            }

        }

        //public ReplyDetail GetReplyByCommentId(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .
        //    }
        //}
    }
}
