using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_ClassLibrary
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuDirectory = new List<Menu>();

        public bool AddMenuItem(Menu item)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(item);
            return _menuDirectory.Count > startingCount;
        }

        public Menu GetItemByName(string name)
        {
            foreach (Menu item in _menuDirectory)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public void PrintItem(Menu item)
        {
            Console.WriteLine($"Item #{item.MealNumber} \n" +
                $"Name: {item.MealName} \n" +
                $"Description: {item.Description} \n" +
                $"Ingredients: \n");
            foreach (string ingredient in item.Ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine($"\n" +
                $"Price: ${item.Price}");
        }

        public bool DeleteItem(Menu item)
        {
            return _menuDirectory.Remove(item);
        }

        public List<Menu> GetAllItems()
        {
            List<Menu> menuItems = _menuDirectory;
            return menuItems;
        }
    }
}
