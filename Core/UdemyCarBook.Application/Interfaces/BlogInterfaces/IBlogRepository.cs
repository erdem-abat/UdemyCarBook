﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetLast3BlogsWithAuthors();
        List<Blog> GetAllBlogsWithAuthors();
        List<Blog> GetBlogByAuthorId(int id);
    }
}
