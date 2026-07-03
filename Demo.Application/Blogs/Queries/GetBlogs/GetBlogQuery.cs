using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Queries.GetBlogs
{
    public record GetBlogQuery : IRequest<List<BlogVm>>
    {
    }
}
