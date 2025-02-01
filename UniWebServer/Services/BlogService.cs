using Microsoft.EntityFrameworkCore;
using UniWebServer.Data;
using UniWebServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWeb.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace UniWebServer.Services
{
    public class BlogService
    {
        private IDbContextFactory<AppDbContext> _dbContextFactory;

        public BlogService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<BlogPost>> GetPostsAsync()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Blog.OrderByDescending(p => p.Date).ToListAsync();
            }
        }

        public void AddPost(BlogPost post)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Blog.Add(post);
                context.SaveChanges();
            }
        }

        public async Task DeletePostAsync(int postId)
        {         
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var post = await context.Blog.FindAsync(postId);
                if (post != null)
                {
                    context.Blog.Remove(post);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
