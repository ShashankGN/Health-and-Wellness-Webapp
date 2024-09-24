namespace Spoonacular.API.DTO.QueryParameter
{
    public class FoodItemsInput
    {
        public string Name { get; set; }
        public double GainedCalories { get; set; }
    }

    public class CalGaiedQueryData
    {
        public List<FoodItemsInput> FoodItems { get; set; }
        public double? TargetCalories { get; set; }
    }
}
