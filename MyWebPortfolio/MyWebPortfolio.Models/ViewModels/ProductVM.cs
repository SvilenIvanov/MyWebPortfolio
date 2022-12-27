using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.Models.ViewModels {
    public class ProductVM {

        public Product product;
        public IEnumerable<SelectListItem> CategoryList {get; set;}
        public IEnumerable<SelectListItem> CoverList {get; set;}

        public ProductVM() {
            product = new Product();
        }

        public ProductVM(Product product, IEnumerable<SelectListItem> categoryList, IEnumerable<SelectListItem> coverList) {
            this.product = product;
            this.CategoryList = categoryList;
            this.CoverList = coverList;
        }
    }
}
