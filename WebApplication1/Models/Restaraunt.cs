using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class Restaraunt
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant Name")]
        [Required]
        public string Name { get; set; }
        public CuisineType Cuisine{get;set;}
    }
}