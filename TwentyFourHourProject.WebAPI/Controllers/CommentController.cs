using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHourProject.Data;
using TwentyFourHourProject.Models;
using TwentyFourHourProject.Services;

namespace TwentyFourHourProject.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            
            var commentService = new CommentService(userId);
            return commentService;
        }

        // getting all - make get by postId
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);

        }

        public IHttpActionResult GetCommentsByPostId(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Posts.Single(p => p.PostId == postId);
                var commentList = postEntity.Comments;

                return Ok(commentList);
            }
             
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var commentService = CreateCommentService();

            if (!commentService.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}
