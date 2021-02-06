using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHourProject.Models;
using TwentyFourHourProject.Data;
using TwentyFourHourProject.Services;

namespace TwentyFourHourProject.WebAPI.Controllers
{








































































































































//    [Authorize]
//    public class ReplyController : ApiController
//    {
//        //get all replies* prob not necessary
//        public IHttpActionResult Get()
//        {
//            ReplyService replyService = CreateReplyService();
//            var replies = replyService.GetReplies;
//            return Ok(replies);
//        }

//        //get reply by id or by comment
//        //public IHttpActionResult Get(int id)
//        //{
//        //    ReplyService replyService = CreateReplyService();
//        //    var reply = ReplyService.GetReplyBy
//        //}

//        public IHttpActionResult Post(ReplyCreate reply)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);
//            var service = CreateReplyService();

//            if (!service.CreateReply(reply))
//                return InternalServerError();

//            //var 
//            //if (!AddReplyToList(reply))
//            return Ok();
//        }
        
//        private ReplyService CreateReplyService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var replyService = new ReplyService(userId);
//            return replyService;
//        }
//    }
}
