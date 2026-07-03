using Demo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Unit>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            await _blogRepository.DeleteBlogAsync(request.Id);
            return Unit.Value;
        }
    }
}
