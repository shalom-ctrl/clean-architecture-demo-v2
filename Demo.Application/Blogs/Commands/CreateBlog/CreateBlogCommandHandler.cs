using AutoMapper;
using Demo.Application.Blogs.Queries.GetBlogs;
using Demo.Domain.Entity;
using Demo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Title = request.Title,
                Content = request.Content,
                Author = request.Author
            };

            var result = await _blogRepository.CreateBlogAsync(blog);
            return _mapper.Map<BlogVm>(result);
        }
    }
}
