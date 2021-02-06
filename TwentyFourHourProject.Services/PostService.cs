using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHourProject.Data;
using TwentyFourHourProject.Models;

namespace TwentyFourHourProject.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Author = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

            public IEnumerable<PostListItem> GetPosts()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Posts
                            .Where(e => e.Author == _userId)
                            .Select(
                                e =>
                                    new PostListItem
                                    {
                                        PostId = e.PostId,
                                        Title = e.Title,
                                        //CreatedUtc = e.CreatedUtc
                                    }
                            );

                    return query.ToArray();
                }
            }
        }
    }
