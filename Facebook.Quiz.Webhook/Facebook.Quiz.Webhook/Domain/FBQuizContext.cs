using System.Data.Entity;

namespace Facebook.Quiz.Webhook.Domain
{
    public class FBQuizContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}