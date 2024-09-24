using Spoonacular.API.Data;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;
using Spoonacular.API.Model;

namespace Spoonacular.API.Services
{
    public class CustomerNutrientsManagementService
    {
        CostomerDbContext _context;
        public CustomerNutrientsManagementService(CostomerDbContext context)
        {
            _context = context;
        }

        public void NutrientsDbManager(NutrientsManagementData managementdata, NutrientsManagementQueryData querydata)
        {
            var result= _context.customers.FirstOrDefault(x=>x.Id==querydata.Id);
            if (result == null) 
            {
                var obj = new Costomer()
                {
                    Id = querydata.Id,
                    Age = (int)querydata.Age,
                    Mass=[(double)querydata.Weight],
                    Height = [(double)querydata.Height],
                    Date = [DateTime.UtcNow],
                    BMI = [(double)managementdata.BMI]
                };
                _context.customers.Add(obj);
            }
            else
            {
                result.Mass.Add((double)querydata.Weight);
                result.Height.Add((double)querydata.Height);
                result.Date.Add(DateTime.UtcNow);
                result.BMI.Add((double)managementdata.BMI);
            }
            _context.SaveChanges();

        }

        public static NutrientsManagementData NutrientsCalculation(NutrientsManagementQueryData input)
        {
            var output = new NutrientsManagementData();

            output.BMI = input.Weight / Math.Pow((double)(input.Height / 100), 2);

            // Calculate BMR based on Gender
            if (input.Gender?.ToLower() == "male")
            {
                output.BMR = 88.362 + (13.397 * input.Weight) + (4.799 * input.Height) - (5.677 * input.Age);
            }
            else if (input.Gender?.ToLower() == "female")
            {
                output.BMR = 447.593 + (9.247 * input.Weight) + (3.098 * input.Height) - (4.330 * input.Age);
            }
            else
            {
                throw new ArgumentException("Invalid gender specified.");
            }

            // Apply Activity Level Multiplier to BMR
            if (input.Activeness == "Sedentary") { output.BMR *= 1.2; }
            else if (input.Activeness == "Lightly active") { output.BMR *= 1.375; }
            else if (input.Activeness == "Moderately active") { output.BMR *= 1.55; }
            else if (input.Activeness == "Very active") { output.BMR *= 1.725; }
            else if (input.Activeness == "Extra active") { output.BMR *= 1.9; }
            else
            {
                throw new ArgumentException("Invalid activity level specified.");
            }

            // Total Meal Calories
            output.Calories = output.BMR/3;

            // Macronutrient Distribution Per Meal (assuming 3 meals per day)
            output.CarbsPerMeal = ((output.Calories * 0.50) / 4) / 3; 
            output.ProteinPerMeal = ((output.Calories * 0.20) / 4) / 3; 
            output.FatsPerMeal = ((output.Calories * 0.30) / 9) / 3;

            return output;
        }
    }
}
