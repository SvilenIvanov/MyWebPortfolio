﻿using MyWebPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.DataAccess.Repository.IRepository {
    public interface ICategoryRepository : IRepository<Category>{

        public void Update(Category category);
        public void Save();
    }
}
