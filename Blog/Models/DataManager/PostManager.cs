using Blog.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DataManager
{
    public class PostManager : IPostRepository
    {
        readonly BlogContext _blogContext;
        public PostManager(BlogContext context)
        {
            _blogContext = context;
        }

        public void Add(Post entity)
        {
            _blogContext.Posts.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Delete(Post entity)
        {
            _blogContext.Posts.Remove(entity);
            _blogContext.SaveChanges();
        }

        public Post Get(long id)
        {
            return _blogContext.Posts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _blogContext.Posts.ToList();
        }

        public IEnumerable<Post> GetAll(int limit, int offset)
        {
            try
            {
                return _blogContext.Posts.Include(x => x.User).Include(x => x.Comments).Skip(offset).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                return new List<Post>();
            }
        }

        public int GetAllCount()
        {
            return _blogContext.Posts.Count();
        }

        public IEnumerable<Post> Search(string searchText, int limit = 10, int offset = 0)
        {
            try
            {
                return _blogContext.Posts.Include(x => x.User).Include(x => x.Comments).AsEnumerable().Where(x => x.Content.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).Skip(offset).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                return new List<Post>();
            }
        }

        public void Update(Post dbEntity, Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
