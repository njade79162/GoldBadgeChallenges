using Challenge3_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_ConsoleApp
{
    class ProgramUI
    {
        protected readonly BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            bool run = true;
            while (run)
            {
                MainMenu();
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("Hello Security Admin. What would you like to do? \n" +
                "1: Add a badge \n" +
                "2: Edit a badge \n" +
                "3: List all badges");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    // add a badge
                    NewBadge();
                    break;
                case "2":
                    // edit a badge
                    EditBadge();
                    break;
                case "3":
                    // list all badges
                    ListBadges();
                    break;
                default:
                    Console.WriteLine("That is not an accepted value. Please input a number from 1-3. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public void NewBadge()
        {
            bool validNum = false;
            int badgeNum = 0;
            while (!validNum)
            {
                Console.WriteLine("What is the number on the badge: ");
                string input = Console.ReadLine();
                Console.Clear();
                validNum = Int32.TryParse(input, out badgeNum);
                if (!validNum)
                {
                    Console.WriteLine("That is not a valid number. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            bool addDoors = true;
            List<string> doorList = new List<string>();
            while (addDoors)
            {
                Console.WriteLine("List a door that it needs access to: ");
                string doorInput = Console.ReadLine();
                Console.Clear();
                bool doorAlreadyAdded = false;
                foreach(string door in doorList)
                {
                    if(doorInput == door)
                    {
                        Console.WriteLine("This badge already has access to that door. Please try again. \n" +
                            "Press any key to continue...");
                        doorAlreadyAdded = true;
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                if (!doorAlreadyAdded)
                {
                    doorList.Add(doorInput);
                }

                string input = "1";
                while (input != "y" && input != "n")
                {
                    Console.WriteLine("Any other doors(y/n)?");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input)
                    {
                        case "y":
                            continue;
                        case "n":
                            Console.WriteLine("Giving this badge access to the specified doors. \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            addDoors = false;
                            break;
                        default:
                            Console.WriteLine("That was not an accepted value. Please enter either y or n. \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }

            Badge badge = new Badge(badgeNum, doorList);
            _badgeRepo.AddBadge(badge);
        }

        public void EditBadge()
        {
            bool validNum = false;
            int badgeNum = 0;
            while (!validNum)
            {
                Console.WriteLine("What is the badge number to update?");
                string input = Console.ReadLine();
                Console.Clear();
                validNum = Int32.TryParse(input, out badgeNum);
                if (!validNum)
                {
                    Console.WriteLine("That is not a valid number. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Badge badge = _badgeRepo.GetBadge(badgeNum);
            if (badge != null)
            {
                string input = "3";
                while (input != "1" && input != "2")
                {
                    Console.WriteLine($"{badgeNum} has access to the following doors: ");
                    foreach (string door in badge.DoorNames)
                    {
                        Console.WriteLine(door);
                    }
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do? \n" +
                        "1. Remove a door \n" +
                        "2. Add a door");
                    input = Console.ReadLine();
                    Console.Clear();
                    bool doorExists = false;
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorInput = Console.ReadLine();
                            Console.WriteLine();
                            foreach(string door in badge.DoorNames)
                            {
                                if(door == doorInput)
                                {
                                    doorExists = true;
                                }
                            }

                            if (!doorExists)
                            {
                                Console.WriteLine($"{badgeNum} already does not have access to that door. \n" +
                                    $"Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                List<string> newDoorList = badge.DoorNames;
                                newDoorList.Remove(doorInput);
                                Badge newBadge = new Badge(badgeNum, newDoorList);
                                _badgeRepo.UpdateBadge(badgeNum, newBadge);
                                Console.Clear();
                                break;
                            }
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            doorInput = Console.ReadLine();
                            foreach(string door in badge.DoorNames)
                            {
                                if(door == doorInput)
                                {
                                    doorExists = true;
                                }
                            }

                            if (doorExists)
                            {
                                Console.WriteLine($"{badgeNum} already has access to that door. \n" +
                                    $"Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                List<string> newDoorList = badge.DoorNames;
                                newDoorList.Add(doorInput);
                                Badge newBadge = new Badge(badgeNum, newDoorList);
                                _badgeRepo.UpdateBadge(badgeNum, newBadge);
                                Console.Clear();
                                break;
                            }
                        default:
                            Console.WriteLine("That was not an accepted value. Please try again. \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }

                Console.WriteLine($"{badgeNum} has access to the following doors: ");
                foreach (string door in badge.DoorNames)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"{badgeNum} is not a badge that exists. Please try again. \n" +
                    $"Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ListBadges()
        {
            Console.WriteLine("{0, -13} {1, -18}", "Badge #", "Door Access");
            foreach(KeyValuePair<int, List<string>> badge in _badgeRepo.GetBadgeDirectory())
            {
                string doorString = badge.Value[0];
                for(int i = 1; i < badge.Value.Count; i++)
                {
                    doorString = doorString + ", " + badge.Value[i];
                }
                Console.WriteLine("{0, -13} {1, -18}", badge.Key, doorString);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
