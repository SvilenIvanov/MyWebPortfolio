﻿using Microsoft.EntityFrameworkCore;
using MyWebPortfolio.DataAccess.Data;
using MyWebPortfolio.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository {
    public class Repository<T> : IRepository<T> where T : class {

        private readonly AppdDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppdDbContext db) {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity) {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll() {

            IQueryable<T> query = dbSet.AsQueryable();
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter) {
            IQueryable<T> query = dbSet.AsQueryable();
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public T GetSingleOrDefault(Expression<Func<T, bool>> filter) {
            IQueryable<T> query = dbSet.AsQueryable();
            query.Where(filter);
            return query.SingleOrDefault();
        }

        public void Remove(T entity) {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) {
            dbSet.RemoveRange(entities);
        }
    }
}
