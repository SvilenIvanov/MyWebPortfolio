using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using MyWebPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository {
    public class ProductRepository : Repository<Product>, IProductRepository {

        private readonly AppdDbContext _db;
        public ProductRepository(AppdDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Product product) {
            var obj = _db.Products.FirstOrDefault(item => item.Id == product.Id);

            if (obj != null) {
                obj.Title = product.Title;
                obj.ISBN = product.ISBN;
                obj.Price = product.Price;
                obj.Price50 = product.Price50;
                obj.Price100 = product.Price100;
                obj.ListPrice = product.ListPrice;
                obj.Description = product.Description;
                obj.CategoryID = product.CategoryID;
                obj.Author = product.Author;
                obj.CoverID = product.CoverID;

                if (product.ImageURL != null) {
                    obj.ImageURL = product.ImageURL;
                }
            }
        }
    }
}
