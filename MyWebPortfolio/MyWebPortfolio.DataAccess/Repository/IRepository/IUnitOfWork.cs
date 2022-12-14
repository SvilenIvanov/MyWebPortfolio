using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository.IRepository {
    public interface IUnitOfWork {
        ICategoryRepository Category { get; }
        ICoverRepository Cover { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
