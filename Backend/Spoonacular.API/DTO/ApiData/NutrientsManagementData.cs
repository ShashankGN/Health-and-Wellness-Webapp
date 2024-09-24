namespace Spoonacular.API.DTO.ApiData
{
    public class NutrientsManagementData
    {
        public double? BMR { get; set; }
        public double? BMI { get; set; }
        public double? Calories { get; set; }
        public double? CarbsPerMeal { get; set; }
        public double? ProteinPerMeal { get; set; }
        public double? FatsPerMeal { get; set; }
        public double? FiberPerMeal { get; } = 8.3;
    }
}
