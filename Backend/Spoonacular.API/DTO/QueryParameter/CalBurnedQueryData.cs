namespace Spoonacular.API.DTO.QueryParameter
{
    public class ActivityInput
    {
        public string Name { get; set; }
        public double BurntCalories { get; set; }
        public double HoursSpent { get; set; }
    }

    public class CalBurnedQueryData
    {
        public List<ActivityInput> Activities { get; set; }
        public double? TargetCalories { get; set; }
    }
}
