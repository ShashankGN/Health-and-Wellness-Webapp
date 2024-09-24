using System.ComponentModel.DataAnnotations;

namespace Spoonacular.API.Model
{
    public class Costomer
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public List<double> Mass { get; set; } 

        [Required]
        public List<double> Height { get; set; } 

        [Required]
        public List<DateTime> Date { get; set; } 

        [Required]
        public List<double> BMI { get; set; } 
    }

}
