using Demo.Domain.Entity;
using Demo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateblogentity = new Blog()
            {
                Id = request.Id,
                Title = request.Title,
                Content = request.Content,
                Author = request.Author
            };

            var updatedBlog = await _blogRepository.UpdateBlogAsync(request.Id, updateblogentity);
            return updatedBlog.Id;
        }
    }
}
