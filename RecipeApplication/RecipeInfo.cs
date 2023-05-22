using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    internal class RecipeInfo
    {
        public class Recipe
        {
            public delegate void RecipeExceedsCaloriesEventHandler();
            public event RecipeExceedsCaloriesEventHandler RecipeExceedsCalories;

            //variables used to save info and keep count
            public double factor;
            public String ingredient_name;
            public String unit_measure;
            public String description;
            public int ingredient_count;
            double quantity;
            int maxIngredients;
            public static int recipeCount;
            public static String recipeName;
            public int steps;
            public static double calorie;
            public static double caloriesTotal;
            public static String foodGroup;


            //Initialize Lists ...
            public List<String> ingredientNames = new List<String>();
            public List<String> ingredientUnits = new List<String>();
            public List<String> recipeNames = new List<String>();
            public List<int> maxIngredientCount = new List<int>();
            public List<double> ingredientQuantities = new List<double>();
            public List<String> stepsDescriptions = new List<String>();
            public List<String> ingredientName = new List<String>();
            public List<int> numIngredients = new List<int>();
            public List<int> numSteps = new List<int>();
            public List<double> calories = new List<double>();
            public List<String> foodGroups = new List<String>();
            public List<double> totalCalories = new List<double>();



            //method that gets the users input about ingredients and step descriptions for recipe ...
            public void RecipeDetails()
            {
                recipeCount = 0;
                caloriesTotal = 0;

                int ingredient_count = 0;
                int s = 0;
                steps = 0;
                maxIngredients = 0;

                Console.WriteLine("Enter Name of recipe : ");
                recipeName = Console.ReadLine();
                recipeNames.Insert(recipeCount, recipeName);

                Console.WriteLine("Enter Number of ingredients : ");
                maxIngredients = Int32.Parse(Console.ReadLine());
                maxIngredientCount.Insert(recipeCount, maxIngredients);


                // Loop to get ingredients ...
                while (ingredient_count < maxIngredients)
                {
                    Console.WriteLine("Enter name of ingredient " + (ingredient_count + 1) + ":");
                    ingredient_name = Console.ReadLine();
                    ingredientNames.Insert(ingredient_count, ingredient_name);

                    //error handling to prevent users from entering a value other than numeric. 
                    try
                    {
                        Console.WriteLine("Enter quantity of " + ingredient_name + " : 1, 2, 4, 6, 8, 10 :");
                        quantity = Double.Parse(Console.ReadLine());
                        ingredientQuantities.Insert(ingredient_count, quantity);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter Numeric values only ! ");
                        Console.WriteLine("Enter quantity of " + ingredient_name + ": ");
                        quantity = Double.Parse(Console.ReadLine());
                        ingredientQuantities.Insert(ingredient_count, quantity);
                    }

                    Console.WriteLine("Enter unit of measurement for " + ingredient_name + ": Single, Bunch, Tsp, Cup ");
                    unit_measure = Console.ReadLine();
                    ingredientUnits.Insert(ingredient_count, unit_measure);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("- A calorie is a unit of energy commonly used to measure the amount of energy in food and the energy expended through physical activity -");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter amount of calories for " + ingredient_name + ": ");
                    calorie = Double.Parse(Console.ReadLine());
                    calories.Insert(ingredient_count, calorie);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("- A food group is a category of foods that share similar nutritional properties -");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter the food group " + ingredient_name + " belongs to. (Fruit, Vegetables, Grains, Protein or Dairy) : ");
                    foodGroup = Console.ReadLine();
                    foodGroups.Insert(ingredient_count, foodGroup);

                    caloriesTotal += calorie;
                    ingredient_count++;
                }

                // Loop to get steps and descriptions ...
                Console.WriteLine("Enter number of steps : ");
                steps = Convert.ToInt32(Console.ReadLine());
                while (s < steps)
                {
                    Console.WriteLine("Enter description of step " + (s + 1));
                    description = Console.ReadLine();
                    stepsDescriptions.Insert(s, description);
                    s++;
                }
                recipeCount++;
            }











            //method to print the details of the recipe ...
            public void PrintDetails()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // Display all ingredients ...
                int i = 0;
                while (i < maxIngredients)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("Ingredient : " + (i + 1));
                    Console.WriteLine("- Name: " + ingredientNames[i]);
                    Console.WriteLine("- Quantity: " + ingredientQuantities[i]);
                    Console.WriteLine("- Unit of measurement: " + ingredientUnits[i]);
                    Console.WriteLine("- Food Group: " + foodGroups[i]);
                    Console.WriteLine("- Calories: " + calories[i]);
                    i++;
                }

                Console.WriteLine("");
                Console.WriteLine("Total Calories : " + caloriesTotal);
                Console.WriteLine("****************************");
                Console.WriteLine("");
                CheckRecipeCalories();

                Console.ForegroundColor = ConsoleColor.Green;

                //Display all steps ...
                int k = 0;
                while (k < steps)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("Description for step " + (k + 1) + ":");
                    Console.WriteLine(stepsDescriptions[k]);
                    k++;
                }

                Console.ForegroundColor = ConsoleColor.White;
            }








            //delegate to check calories ...
            public void CheckRecipeCalories()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (caloriesTotal > 300 && caloriesTotal < 500)
                {
                    Console.WriteLine("Total calories is over 300 !");
                }

                if (caloriesTotal > 500 && caloriesTotal < 1000)
                {
                    Console.WriteLine("Consuming a lot of calories on a regular basis can lead to weight gain, which can increase the risk of various health problems such as heart disease, diabetes, and certain cancers. Additionally, consuming a diet that is high in calories but low in nutrients can lead to nutrient deficiencies and other health problems. Therefore, it is generally recommended to consume a balanced diet and to limit the intake of high-calorie, low-nutrient foods.");
                }

                if (caloriesTotal > 1000)
                {
                    Console.WriteLine("Consuming over 1000 calories in a single meal may be excessive for many individuals, especially if this is a regular occurrence. Consuming a high number of calories in a single meal can lead to feelings of discomfort, bloating, and indigestion, and it can also contribute to weight gain over time if the excess calories are not burned off through physical activity.");
                }
            }











            //Dsiplays list of recipes and contents ...
            public void DisplayList()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                recipeNames.Sort();
                for (int r = 0; r < recipeCount; r++)
                {
                    Console.WriteLine(recipeNames[r]);
                }
                Console.ForegroundColor = ConsoleColor.White;

                String recipeNameInput;
                try
                {
                    Console.WriteLine("Enter the recipe you wish to display : ");
                    recipeNameInput = Console.ReadLine();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter name exactly as displayed !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter the recipe you wish to display : ");
                    recipeNameInput = Console.ReadLine();
                }
                if (recipeNames.Contains(recipeNameInput))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("****************************");
                    int recipeNameIndex = recipeNames.IndexOf(recipeNameInput);
                    Console.WriteLine("- Recipe Name: " + recipeNames[recipeNameIndex]);
                    Console.WriteLine();
                    int z = 0;
                    while (z < maxIngredientCount[recipeNameIndex])
                    {
                        Console.WriteLine("Ingredient : " + ingredientNames[z]);
                        Console.WriteLine("- Name: " + ingredientNames[z]);
                        Console.WriteLine("- Quantity: " + ingredientQuantities[z]);
                        Console.WriteLine("- Unit of measurement: " + ingredientUnits[z]);
                        Console.WriteLine("- Food Group: " + foodGroups[z]);
                        Console.WriteLine("- Calories: " + calories[z]);
                        z++;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Total Calories : " + caloriesTotal);
                Console.WriteLine("****************************");
                Console.WriteLine("");
                CheckRecipeCalories();
                Console.ForegroundColor = ConsoleColor.Green;
             
                //Display all steps ...
                int k = 0;
                while (k < steps)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("Description for step " + (k + 1) + ":");
                    Console.WriteLine(stepsDescriptions[k]);
                    k++;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }












            //method that scales the recipe ...
            public void ScaleRecipe()
            {
                Console.WriteLine("Enter the scaling factor:");
                factor = Double.Parse(Console.ReadLine());

                for (int i = 0; i < ingredientQuantities.Count; i++)
                {
                    double Scalevalue1 = ingredientQuantities[i];
                    ingredientQuantities[i] = Scalevalue1 * factor;
                }

                for (int i = 0; i < calories.Count; i++) 
                {
                    double Scalevalue2 = calories[i];
                    calories[i] = Scalevalue2 * factor;
                }
                caloriesTotal = caloriesTotal * factor;
                PrintDetails();
            }


            //method that clears the saved information...
            public void Clear()
            {
                Console.WriteLine("Are you sure you want to clear all recipes ? yes/no");
                String input = Console.ReadLine();
                input.ToLower();

                if (input == "yes")
                {
                    ingredientNames.Clear();
                    ingredientUnits.Clear();
                    ingredientQuantities.Clear();
                    stepsDescriptions.Clear();
                    calories.Clear();
                    foodGroups.Clear();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Recipe Cleared succesfully");
                    Console.ForegroundColor=ConsoleColor.White;
                }
                else
                {
                    PrintDetails();
                }
            }

            //method that resets all the saved values ...
            public void ResetQuantities()
            {
                ingredientUnits.Clear();
                ingredientQuantities.Clear();
                stepsDescriptions.Clear();
                calories.Clear();
                foodGroups.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe Reset succesfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    }