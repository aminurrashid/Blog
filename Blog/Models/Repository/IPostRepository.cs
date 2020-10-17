using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Repository
{
    public interface IPostRepository : IDataRepository<Post>
    {
        IEnumerable<Post> GetAll(int limit, int offset);
        int GetAllCount();
        IEnumerable<Post> Search(string searchText, int limit = 10, int offset = 0);
    }
}
