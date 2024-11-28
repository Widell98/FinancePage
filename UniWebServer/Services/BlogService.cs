using UniWebServer.Data.Models;

namespace UniWebServer.Services
{
    public class BlogService
    {
        private List<BlogPost> posts = new();

        public List<BlogPost> GetPosts() => posts;

        public void AddPost(BlogPost post) => posts.Insert(0, post); // Nyaste först

        public void DeletePost(int postId)
        {
            var post = posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                posts.Remove(post);
            }
        }
    }
}
