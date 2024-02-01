using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(int id);
        T GetById(int id);
        List<T> GetCommentsByBlogId(int id); //ek interface eklemeden bu işlem sağlandı normalde burada olmamalı!
        int GetCountCommentByBlog(int id); //ek interface eklemeden bu işlem sağlandı normalde burada olmamalı!
    }
}
