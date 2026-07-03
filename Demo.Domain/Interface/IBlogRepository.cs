using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Interface
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBlogAsync(int id, Blog blog);
        Task<int> DeleteBlogAsync(int id);
    }
}
