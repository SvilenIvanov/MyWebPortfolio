using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository.IRepository {
    public interface IRepository<T> where T : class {

        public void Add(T entity);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        public T GetSingleOrDefault(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAll();
    }
}
