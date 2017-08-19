using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Quiz.Webhook.Domain;

namespace Facebook.Quiz.Webhook.Service
{
    public class AuthorService
    {
        private FBQuizContext Context { get; } = new FBQuizContext();

        public List<Author> GetAll()
        {
            return Context.Authors.ToList();
        }

        public Author GetById(long id)
        {
            return id <= 0
                ? null
                : Context.Authors.FirstOrDefault(x => x.Id == id);
        }

        public Author CreateAuthor (string fullName)
        {
            if (ExistsByName(fullName))
            {
                throw new InvalidOperationException("Author must have a unique name.");
            }

            var author = Context.Authors.Add(new Author
            {
                FullName = fullName
            });

            Context.SaveChanges();
            return author;
        }

        public Author UpdateAuthor (long id, string name)
        {
            var author = GetById(id);

            if (author == null || author.FullName == name)
            {
                throw new InvalidOperationException("Author must exist and update must difer.");
            }

            author.FullName = name;
            Context.SaveChanges();
            return author;
        }

        public void DeleteAuthor(long id)
        {
            var author = GetById(id);

            if (author == null)
            {
                throw new InvalidOperationException("Author must be not a null and update must difer from null.");
            }

            Context.Authors.Remove(author);
            Context.SaveChanges();
        }

        public bool ExistsByName(string name)
        {
            return string.IsNullOrEmpty(name) || Context.Authors.Any(s => s.FullName == name);
        }
    }
}