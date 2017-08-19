using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Quiz.Webhook.Domain;
using Microsoft.Ajax.Utilities;

namespace Facebook.Quiz.Webhook.Service
{
    public class PostService
    {
        private FBQuizContext Context { get; } = new FBQuizContext();

        public List<Post> GetAll()
        {
            return Context.Posts.ToList();
        }

        public Post GetById(long id)
        {
            return id <= 0
                ? null
                : Context.Posts.FirstOrDefault(x => x.Id == id);
        }

        public Post AddPost ( string text, Author auth )
        {
            if (text.IsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("Post must not be null/whitespace!");
            }

            var post = Context.Posts.Add(new Post
            {
                AuthorId = auth.Id,
                Text = text,
                CreatedDateTime = DateTime.Now
            });

            Context.SaveChanges();
            return post;
        }

        public Post UpdatePost(long id, string text)
        {
            var post = GetById(id);

            if (post == null || post.Text == text)
            {
                throw new InvalidOperationException("Author must exist and update text must difer!");
            }

            post.Text = text;
            Context.SaveChanges();
            return post;
        }

        public void DeletePost(long id)
        {
            var post = GetById(id);

            if (post == null)
            {
                throw new InvalidOperationException("Post msut exist/difer from null!");
            }

            Context.Posts.Remove(post);
            Context.SaveChanges();
        }
    }
}