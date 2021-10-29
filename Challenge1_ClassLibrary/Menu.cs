using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_ClassLibrary
{
    public class Menu
    {
        public int MealNumber;
        public string MealName;
        public string Description;
        public List<string> Ingredients;
        public double Price;

        public Menu()
        {

        }

        public Menu(int mealNum, string name, string desc, List<string> ingredients, double price)
        {
            MealNumber = mealNum;
            MealName = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
