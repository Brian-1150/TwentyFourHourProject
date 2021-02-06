using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHourProject.Data;
using TwentyFourHourProject.Models;

namespace TwentyFourHourProject.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Author = _userId,
                Text = model.Text,
                PostId = model.PostId

            };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Comments.Add(entity);
                return ctx.SaveChanges() != 0;
            }

        }

        // Get comments by userid not needed
        public IEnumerable<CommentListItem> GetCommentsByPostId(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.PostId == postId)
                    .Select(
                    e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            Text = e.Text

                        }
                    );
                return query.ToArray();
            }

        }

    }
}
