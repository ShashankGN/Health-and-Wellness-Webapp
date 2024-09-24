namespace Spoonacular.API.DTO.QueryParameter
{
    public class SearchRecipesQueryParameter
    {
        public string Query { get; set; }
        public string? Cuisine {  get; set; }
        public string? ExcludeCuisine {  get; set; }
        public string? Diet { get; set; }
        public string? Type { get; set; }
        public string? Sort { get; set; }
        public double? MinCarbs {  get; set; }   
        public double? MaxCarbs { get; set; }
        public double? MinCalories {  get; set; }
        public double? MaxCalories { get; set; }
        public double? MinFat {  get; set; }
        public double? MaxFat { get; set; }
        public int Number { get; set; }
    }
}
