using System.Data.Entity;

namespace Facebook.Quiz.Webhook.Domain
{
    public class Author
    {
        public long Id { get; set; }
        public long ExternalId { get; set; }

        public string FullName { get; set; }
    }
}