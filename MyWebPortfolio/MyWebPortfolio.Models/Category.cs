using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebPortfolio.Models {
    public class Category {
        private const int diplayOrderMinimumRange = 1;
        private const int diplayOrderMaximumRange = 250;

        [Key] // primary key
        public int Id {get; set;}
        [DisplayName("Display Order")] // changing the show name of the property
        [Range(diplayOrderMinimumRange, diplayOrderMaximumRange)]
        public int DisplayOrder {get; set;}
        [DisplayName("Created time")] // changing the show name of the property
        public DateTime CreatedDateTime {get; set;} = DateTime.Now;
        [Required] //db property
        public string Name { get; set; } = "";

        public override String ToString() {
            return String.Format("Id:{0} DisplayOrder:{1} CreatedDateTime:{2} Name:{3}"
                , Id.ToString(),DisplayOrder.ToString(), CreatedDateTime.ToString(), Name.ToString());
        }
    }
    

}
