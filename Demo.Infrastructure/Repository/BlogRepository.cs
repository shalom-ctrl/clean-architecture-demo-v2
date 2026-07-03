using Demo.Domain.Entity;
using Demo.Domain.Interface;
using Demo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            return await _dbContext.Blogs
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> UpdateBlogAsync(int id, Blog blog)
        {
            int rowsAffected = await _dbContext.Blogs
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, blog.Title)
                    .SetProperty(b => b.Content, blog.Content)
                    .SetProperty(b => b.Author, blog.Author)
                );

            if (rowsAffected == 0)
            {
                return null;
            }

            return await _dbContext.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
