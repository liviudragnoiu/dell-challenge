using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]        
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]        
        public string Category { get; set; }
    }
}
