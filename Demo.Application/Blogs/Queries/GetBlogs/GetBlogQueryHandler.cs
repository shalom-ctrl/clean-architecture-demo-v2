using AutoMapper;
using Demo.Domain.Interface;
using MediatR;

namespace Demo.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
           var result = await _blogRepository.GetAllBlogsAsync();
           //var resultlist =  result.Select(x => new BlogVm
           // {
           //     Id = x.Id,
           //     Title = x.Title,
           //     Content = x.Content,
           //     Author = x.Author
           // }).ToList();

            var resultlist = _mapper.Map<List<BlogVm>>(result);

            return resultlist;
        }
    }
}
