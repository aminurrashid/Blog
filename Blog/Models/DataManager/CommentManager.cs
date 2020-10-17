using Blog.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DataManager
{
    public class CommentManager : ICommentRepository
    {
        readonly BlogContext _blogContext;
        public CommentManager(BlogContext context)
        {
            _blogContext = context;
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment dbEntity, Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
