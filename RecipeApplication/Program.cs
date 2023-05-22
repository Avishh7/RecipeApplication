using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeApplication.RecipeInfo;

namespace RecipeApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating object of recipe class
            Recipe recipe = new Recipe();
            recipe.RecipeDetails();
            recipe.PrintDetails();

            //switch statement to scale, reset, clear array or exit application ...

            Console.WriteLine("\nEnter a command: add (to add new recipe), display (display list of recipes), scale, reset, clear, print or exit");
            string answer = Console.ReadLine();

            switch (answer.ToLower())
            {
                case "add":
                    recipe.RecipeDetails();
                    recipe.PrintDetails();
                    Console.WriteLine("Press (1) to display different recipes OR (2) to add new recipe: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        recipe.DisplayList();
                    }
                    if (input == 2)
                    {
                        goto case "add";
                    }
                    break;

                case "display":
                    recipe.DisplayList();
                    break;

                case "scale":
                    recipe.ScaleRecipe();
                    break;

                case "reset":
                    recipe.ResetQuantities();
                    recipe.RecipeDetails();
                    recipe.PrintDetails();
                    break;

                case "clear":
                    recipe.Clear();
                    Console.WriteLine("Recipe cleared.");
                    break;

                case "exit":
                    System.Environment.Exit(0);
                    break;

                case "print":
                    recipe.PrintDetails();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

