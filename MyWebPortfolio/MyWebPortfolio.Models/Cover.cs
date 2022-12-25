using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebPortfolio.Models {
    public class Cover {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";


    }
}
