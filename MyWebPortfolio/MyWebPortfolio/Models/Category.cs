using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace MyWebPortfolio.Models {
    public class Category {

        [Key]
        public int Id {get; set;}
        public int DisplayOrder {get; set;}
        public DateTime CreatedDateTime {get; set;} = DateTime.Now;
        [Required]
        public string Name { get; set; } = "";

        public override String ToString() {
            return String.Format("Id:{0} DisplayOrder:{1} CreatedDateTime:{2} Name:{3}"
                , Id.ToString(),DisplayOrder.ToString(), CreatedDateTime.ToString(), Name.ToString());
        }
    }
    

}
