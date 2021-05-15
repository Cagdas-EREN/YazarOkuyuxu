using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetById(Expression<Func<T, bool>> filter);
    }
}
