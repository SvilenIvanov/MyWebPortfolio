using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPortfolio.Models
{
    public class ShoppingCart
    {
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        public Product ProductItem { get; set; }

        public ShoppingCart(int count, Product productItem)
        {
            Count = count;
            ProductItem = productItem;
        }
    }
}
