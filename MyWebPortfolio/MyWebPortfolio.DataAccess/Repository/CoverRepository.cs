using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository {
    public class CoverRepository : Repository<Cover>, ICoverRepository {

        private readonly AppdDbContext _db;
        public CoverRepository(AppdDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Cover cover) {
            _db.Update(cover);
        }
    }
}
