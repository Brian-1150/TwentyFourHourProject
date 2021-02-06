using System;
using System.Collections.Generic;
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

            };
            using (var ctx = new ApplicationDbContext())
            {
                
                ctx.Comments.Add(entity);

                //var post = ctx

                return ctx.SaveChanges() == 1;
            }

        }

        // Get comments by userid not needed
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.Author == _userId)
                    .Select(
                    e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId
                        }
                    ); 
                return query.ToArray();
            }

        }
        // MODIFY TO ADD COMMENT TO POST COMMENT LIST
        public IEnumerable<CommentListItem> A()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.Author == _userId)
                    .Select(
                    e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId
                        }
                    ); ; ;
                return query.ToArray();
            }

        }

    }
}
