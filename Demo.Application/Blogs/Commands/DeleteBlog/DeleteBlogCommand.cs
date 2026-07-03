using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
