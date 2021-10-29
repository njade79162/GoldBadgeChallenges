using Challenge1_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_ConsoleApp
{
    public class ProgramUI
    {
        protected readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            bool run = true;
            while (run)
            {
                run = RunMenu();
            }
        }

        public bool RunMenu()
        {
            Console.WriteLine("What would you like to do? \n" +
                "1: Add an item to the menu \n" +
                "2: Delete an item from the menu \n" +
                "3: See all items on the menu \n" +
                "4: Exit");
            string userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // add item
                    AddMenuItem();
                    break;
                case "2":
                    // delete item
                    RemoveMenuItem();
                    break;
                case "3":
                    // see all
                    ListAllItems();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                default:
                    Console.WriteLine("Please enter in a valid number between 1 and 4. \n" +
                            "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return true;
            }
            return ContinueCheck();
        }

        private void AddMenuItem()
        {
            Menu item = new Menu();

            Console.WriteLine("Adding a new menu item... \n" +
                "Please enter the name of this menu item: ");
            item.MealName = Console.ReadLine();
            Console.Clear();

            bool isNum = false;
            while (!isNum)
            {
                Console.WriteLine("Please enter a meal number for this menu item: ");
                string mealNumInput = Console.ReadLine();
                isNum = Int32.TryParse(mealNumInput, out int mealNumInt);
                if (!isNum)
                {
                    Console.WriteLine("That is not a valid number. Please input a number. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    item.MealNumber = mealNumInt;
                }
            }
            Console.Clear();

            Console.WriteLine("Please enter a description for this menu item: ");
            item.Description = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter the ingredients for this menu item: ");
            bool inputIngredients = true;
            List<string> ingredients = new List<string>();
            while (inputIngredients)
            {
                Console.WriteLine("Please input an ingredient: ");
                ingredients.Add(Console.ReadLine());
                Console.Clear();
                string input = "3";
                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Would you like to input another ingredient? \n" +
                        "1: Yes \n" +
                        "2: No");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            break;
                        case "2":
                            inputIngredients = false;
                            break;
                        default:
                            Console.WriteLine("Please input either 1 or 2. \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
            item.Ingredients = ingredients;

            Console.WriteLine("Please enter a price for this menu item: ");
            bool isPrice = false;
            while (!isPrice)
            {
                string priceInput = Console.ReadLine();
                Console.Clear();
                isPrice = double.TryParse(priceInput, out double priceInputDouble);
                if (!isPrice)
                {
                    Console.WriteLine("Please enter a valid number for the price. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    item.Price = priceInputDouble;
                }
            }


            string confirmInput = "3";
            while (confirmInput != "1" && confirmInput != "2")
            {
                _menuRepo.PrintItem(item);
                Console.WriteLine($"\n" +
                    $"Is this correct? \n" +
                    $"1: Yes \n" +
                    $"2: No");
                confirmInput = Console.ReadLine();
                Console.Clear();
                switch (confirmInput)
                {
                    case "1":
                        Console.WriteLine("Adding this item to the menu... \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        _menuRepo.AddMenuItem(item);
                        break;
                    case "2":
                        Console.WriteLine("Aborting... \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please input either 1 or 2 \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private void RemoveMenuItem()
        {
            bool isNum = false;
            while (!isNum)
            {
                Console.WriteLine("Please input the number corresponding to the menu item you would like to remove: \n");
                int count = 1;
                foreach (Menu item in _menuRepo.GetAllItems())
                {
                    Console.WriteLine($"{count}:");
                    Console.WriteLine($"Name: {item.MealName} \n");
                    count++;
                }
                string input = Console.ReadLine();
                Console.Clear();
                isNum = Int32.TryParse(input, out int intInput);
                if (!isNum)
                {
                    Console.WriteLine("Please enter a valid number \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    if (intInput > _menuRepo.GetAllItems().Count)
                    {
                        Console.WriteLine("Please enter one of the numbers listed \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        isNum = false;
                        Console.Clear();
                    }
                    else
                    {
                        bool confirmInput = false;
                        while (!confirmInput)
                        {
                            _menuRepo.PrintItem(_menuRepo.GetAllItems()[intInput - 1]);
                            Console.WriteLine("Delete this item? \n" +
                                "1: Yes \n" +
                                "2: No");
                            input = Console.ReadLine();
                            Console.Clear();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("Deleting this item. \n" +
                                        "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    _menuRepo.DeleteItem(_menuRepo.GetAllItems()[intInput - 1]);
                                    confirmInput = true;
                                    break;
                                case "2":
                                    Console.WriteLine("Aborting... \n" +
                                        "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    confirmInput = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter either 1 or 2 \n" +
                                        "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public void ListAllItems()
        {
            foreach(Menu item in _menuRepo.GetAllItems())
            {
                _menuRepo.PrintItem(item);
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public bool ContinueCheck()
        {
            string input = "3";
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Would you like to continue editing the menu? \n" +
                    "1: Yes \n" +
                    "2: No");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        return true;
                    case "2":
                        Console.WriteLine("Exiting the program \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        return false;
                    default:
                        Console.WriteLine("Please enter either 1 or 2 \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            Console.WriteLine("Something went wrong. Exiting the program \n" +
                "Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }
}
