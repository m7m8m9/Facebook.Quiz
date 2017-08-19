using System;

namespace Facebook.Quiz.Webhook.Domain
{
    public class Post
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long ExternalId { get; set; }

        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}