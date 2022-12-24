using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository {
    public class CategoryRepository : Repository<Category>, ICategoryRepository {

        private readonly AppdDbContext _db;
        public CategoryRepository(AppdDbContext db) : base(db) {
            _db = db;
            
        }
        public void Save() {
            _db.SaveChanges();
        }

        public void Update(Category category) {
            _db.Update(category);
        }
    }
}
