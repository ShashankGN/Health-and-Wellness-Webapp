namespace Spoonacular.API.DTO.ApiData
{
    public class SearchRecipesData
    {
        public int Offset { get; set; }
        public int Number { get; set; }
        public Result[] Results { get; set; }
        public int TotalResults { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }

    }
}



