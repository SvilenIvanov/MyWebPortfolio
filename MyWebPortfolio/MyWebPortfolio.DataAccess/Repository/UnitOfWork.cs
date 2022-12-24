using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppdDbContext _db;

        public UnitOfWork(AppdDbContext db) {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public void Save() {
            _db.SaveChanges();
        }
    }
}
