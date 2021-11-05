using Challenge4_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_ConsoleApp
{
    public class ProgramUI
    {
        protected readonly OutingRepository _outingRepo = new OutingRepository();

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
            Console.WriteLine("What would you like to do? \n" +
                "1: Display all outings \n" +
                "2: Add outings to the list \n" +
                "3: Show combined cost of outings");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    // display all outings
                    DisplayAllOutings();
                    break;
                case "2":
                    // add outings
                    AddOuting();
                    break;
                case "3":
                    // show combined cost of outings
                    ListCost();
                    break;
                default:
                    Console.WriteLine("That is not an accepted value. Please input a number from 1-3. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public void DisplayAllOutings()
        {
            Console.WriteLine("{0, -18} {1, -19} {2, -15} {3, -20} {4, -15}", "Event Type", "People Attended", "Date", "Cost Per Person", "Total Cost");
            foreach(Outing outing in _outingRepo.GetOutingDirectory())
            {
                string eventType = outing.TypeOfEvent.ToString();
                int peopleAttended = outing.NumAttended;
                string date = outing.Date.ToString("d");
                double personCost = outing.CostPerPerson;
                double totalCost = outing.TotalCost;
                Console.WriteLine("{0, -18} {1, -19} {2, -15} ${3, -19:N2} ${4, -14:N2}", eventType, peopleAttended, date, personCost, totalCost);
            }

            Console.WriteLine("\n" +
                "Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddOuting()
        {
            Outing outing = new Outing();
            bool checkType = true;
            while (checkType)
            {
                Console.WriteLine("What type of event was this outing? \n" +
                    "1: Golf \n" +
                    "2: Bowling \n" +
                    "3: Amusement Park \n" +
                    "4: Concert");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        outing.TypeOfEvent = EventType.Golf;
                        checkType = false;
                        break;
                    case "2":
                        outing.TypeOfEvent = EventType.Bowling;
                        checkType = false;
                        break;
                    case "3":
                        outing.TypeOfEvent = EventType.AmusementPark;
                        checkType = false;
                        break;
                    case "4":
                        outing.TypeOfEvent = EventType.Concert;
                        checkType = false;
                        break;
                    default:
                        Console.WriteLine("That was not an accepted value. Please try again. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

            bool validNum = false;
            while (!validNum)
            {
                Console.WriteLine("How many people attended this event?");
                string input = Console.ReadLine();
                Console.Clear();
                validNum = Int32.TryParse(input, out int peopleAttended);
                if (!validNum)
                {
                    Console.WriteLine("That was not a valid number. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    outing.NumAttended = peopleAttended;
                }
            }

            bool validDate = false;
            while (!validDate)
            {
                Console.WriteLine("What was the date of this event? (MM/DD/YYYY)");
                string input = Console.ReadLine();
                Console.Clear();
                validDate = DateTime.TryParse(input, out DateTime date);
                if (!validDate)
                {
                    Console.WriteLine("That was not a valid date. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    outing.Date = date;
                }
            }

            bool validDouble = false;
            while (!validDouble)
            {
                Console.WriteLine("What was the cost per person at this event? Do not include the dollar sign.");
                string input = Console.ReadLine();
                Console.Clear();
                validDouble = double.TryParse(input, out double personCost);
                if (!validDouble)
                {
                    Console.WriteLine("That is not a valid value. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    outing.CostPerPerson = personCost;
                }
            }

            string confirmInput = "0";
            while (confirmInput != "1" && confirmInput != "2")
            {
                Console.WriteLine($"Is this info correct? \n \n" +
                    $"Event type: {outing.TypeOfEvent} \n" +
                    $"Number of people attended: {outing.NumAttended} \n" +
                    $"Date: {outing.Date:d} \n" +
                    $"Cost per person: ${outing.CostPerPerson:N2} \n" +
                    $"Total cost for event: ${outing.TotalCost:N2}");
                Console.WriteLine(" \n" +
                    "1: Yes \n" +
                    "2: No");
                confirmInput = Console.ReadLine();
                Console.Clear();
                switch (confirmInput)
                {
                    case "1":
                        _outingRepo.AddOuting(outing);
                        Console.WriteLine("Adding this outing to the list. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Returning to the main menu. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("That was not an accepted value. Please try again. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        public void ListCost()
        {
            string input = "0";
            while(input != "1" && input != "2")
            {
                Console.WriteLine("Would you like to see the total cost for all outings, or outings of a specific type? \n" +
                    "1: All Outings \n" +
                    "2: Specific Type");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        double totalCost = 0;
                        List<Outing> allOutings = _outingRepo.GetOutingDirectory();
                        foreach(Outing outing in allOutings)
                        {
                            totalCost += outing.TotalCost;
                        }
                        Console.WriteLine($"The total cost of all outings is ${totalCost:N2} \n" +
                            $"Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        bool checkType = true;
                        while (checkType)
                        {
                            Console.WriteLine("Please select which type of event \n" +
                                "1: Golf \n" +
                                "2: Bowling \n" +
                                "3: Amusement Park \n" +
                                "4: Concert");
                            input = Console.ReadLine();
                            Console.Clear();
                            double totalCostType = 0;
                            switch (input)
                            {
                                case "1":
                                    List<Outing> golfOutings = new List<Outing>();
                                    foreach(Outing outing in _outingRepo.GetOutingDirectory())
                                    {
                                        if(outing.TypeOfEvent == EventType.Golf)
                                        {
                                            golfOutings.Add(outing);
                                        }
                                    }

                                    foreach(Outing outing in golfOutings)
                                    {
                                        totalCostType += outing.TotalCost;
                                    }

                                    Console.WriteLine($"The total cost of all golf outings is ${totalCostType:N2} \n" +
                                        $"Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    checkType = false;
                                    break;
                                case "2":
                                    List<Outing> bowlingOutings = new List<Outing>();
                                    foreach (Outing outing in _outingRepo.GetOutingDirectory())
                                    {
                                        if (outing.TypeOfEvent == EventType.Bowling)
                                        {
                                            bowlingOutings.Add(outing);
                                        }
                                    }

                                    foreach (Outing outing in bowlingOutings)
                                    {
                                        totalCostType += outing.TotalCost;
                                    }

                                    Console.WriteLine($"The total cost of all bowling outings is ${totalCostType:N2} \n" +
                                        $"Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    checkType = false;
                                    break;
                                case "3":
                                    List<Outing> amusementParkOutings = new List<Outing>();
                                    foreach (Outing outing in _outingRepo.GetOutingDirectory())
                                    {
                                        if (outing.TypeOfEvent == EventType.AmusementPark)
                                        {
                                            amusementParkOutings.Add(outing);
                                        }
                                    }

                                    foreach (Outing outing in amusementParkOutings)
                                    {
                                        totalCostType += outing.TotalCost;
                                    }

                                    Console.WriteLine($"The total cost of all amusement park outings is ${totalCostType:N2} \n" +
                                        $"Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    checkType = false;
                                    break;
                                case "4":
                                    List<Outing> concertOutings = new List<Outing>();
                                    foreach (Outing outing in _outingRepo.GetOutingDirectory())
                                    {
                                        if (outing.TypeOfEvent == EventType.Concert)
                                        {
                                            concertOutings.Add(outing);
                                        }
                                    }

                                    foreach (Outing outing in concertOutings)
                                    {
                                        totalCostType += outing.TotalCost;
                                    }

                                    Console.WriteLine($"The total cost of all concert outings is ${totalCostType:N2} \n" +
                                        $"Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    checkType = false;
                                    break;
                                default:
                                    Console.WriteLine("That was not an accepted value. Please input a value from 1-4 \n" +
                                        "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("That was not an accepted value. Please try again. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
