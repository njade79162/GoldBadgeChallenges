using Challenge2_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_ConsoleApp
{
    public class ProgramUI
    {
        protected readonly ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            Claim claim1 = new Claim(1, "Description", ClaimType.Car, 20.00, new DateTime(2020, 07, 03), new DateTime(2020, 07, 05));
            Claim claim2 = new Claim(2, "Description 2", ClaimType.Home, 30.00, new DateTime(2021, 01, 01), DateTime.Now);
            _claimRepo.AddClaim(claim1);
            _claimRepo.AddClaim(claim2);

            bool run = true;
            while (run)
            {
                MainMenu();
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("Choose a menu item: \n" +
                "1: See all claims \n" +
                "2: Take care of next claim \n" +
                "3: Enter a new claim");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    // show all claims
                    ShowAllClaims();
                    break;
                case "2":
                    // show details of next claim and confirm whether or not to pull
                    NextClaim();
                    break;
                case "3":
                    // enter a new claim
                    AddNewClaim();
                    break;
                default:
                    Console.WriteLine("That was not a valid input. Please try again.");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public void ShowAllClaims()
        {
            Console.WriteLine("{0, -12} {1, -10} {2, -30} {3, -14:N2} {4, -19} {5, -16} {6, -12}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            foreach (Claim claim in _claimRepo.GetClaimDirectory())
            {
                int claimID = claim.ClaimID;
                string type = claim.ClaimType.ToString();
                string description = claim.Description;
                double amount = claim.ClaimAmount;
                string dateOfAccident = claim.DateOfIncident.ToString("d");
                string dateOfClaim = claim.DateOfClaim.ToString("d");
                bool isValid = claim.IsValid;
                Console.WriteLine("{0, -12} {1, -10} {2, -30} ${3, -13:N2} {4, -19} {5, -16} {6, -12}", claimID, type, description, amount, dateOfAccident, dateOfClaim, isValid);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public Claim NextClaim()
        {
            Claim claim = _claimRepo.GetNextClaim();
            if (claim != null)
            {
                Console.WriteLine($"Here are the details for the next claim to be handled: \n" +
                    $"ClaimID: {claim.ClaimID} \n" +
                    $"Type: {claim.ClaimType} \n" +
                    $"Description: {claim.Description} \n" +
                    $"Amount: ${claim.ClaimAmount:N2} \n" +
                    $"DateOfAccident: {claim.DateOfIncident:d} \n" +
                    $"DateOfClaim: {claim.DateOfClaim:d} \n" +
                    $"IsValid: {claim.IsValid}");
                Console.WriteLine();
                Console.WriteLine("Do you want to deal with this claim now (y/n)?");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "y":
                        Console.WriteLine("Pulling this claim off the top of the queue. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        return _claimRepo.DequeueClaim();
                    case "n":
                        Console.WriteLine("Returning to the main menu. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        return null;
                    default:
                        Console.WriteLine("That is not a valid input. Please try again. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        return null;
                }
            }
            return null;
        }

        public void AddNewClaim()
        {
            Claim claim = new Claim();
            string input;

            // claim ID
            bool validID = false;
            int ID;
            while (!validID)
            {
                Console.WriteLine("Enter the claim id: ");
                input = Console.ReadLine();
                Console.Clear();
                validID = Int32.TryParse(input, out ID);
                if (!validID)
                {
                    Console.WriteLine("That was not a valid number. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    claim.ClaimID = ID;
                }
            }

            // claim type
            bool validType = false;
            while (!validType)
            {
                Console.WriteLine("Select a claim type (1-3): \n" +
                    "1. Car \n" +
                    "2. Home \n" +
                    "3. Theft");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    switch (input)
                    {
                        case "1":
                        case "Car":
                            claim.ClaimType = ClaimType.Car;
                            validType = true;
                            break;
                        case "2":
                        case "Home":
                            claim.ClaimType = ClaimType.Home;
                            validType = true;
                            break;
                        case "3":
                        case "Theft":
                            claim.ClaimType = ClaimType.Theft;
                            validType = true;
                            break;
                        default:
                            Console.WriteLine("That is not a valid type. Please try again. \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // claim description
            Console.WriteLine("Enter a claim description: ");
            claim.Description = Console.ReadLine();
            Console.Clear();

            // amount of damage
            bool isDouble = false;
            double damageAmount;
            while (!isDouble)
            {
                Console.WriteLine("Amount of Damage: ");
                input = Console.ReadLine();
                Console.Clear();
                isDouble = double.TryParse(input, out damageAmount);
                if (!isDouble)
                {
                    Console.WriteLine("That is not a valid value. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    claim.ClaimAmount = damageAmount;
                }
            }

            // date of accident
            bool validDate = false;
            DateTime date;
            while (!validDate)
            {
                Console.WriteLine("Date of Accident (MM/DD/YYYY): ");
                input = Console.ReadLine();
                Console.Clear();
                validDate = DateTime.TryParse(input, out date);
                if (!validDate)
                {
                    Console.WriteLine("That was not a valid date. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    claim.DateOfIncident = date;
                }
            }

            // date of claim
            validDate = false;
            DateTime date2;
            while (!validDate)
            {
                Console.WriteLine("Date of Claim (MM/DD/YYYY): ");
                input = Console.ReadLine();
                Console.Clear();
                validDate = DateTime.TryParse(input, out date2);
                if (!validDate)
                {
                    Console.WriteLine("That was not a valid date. Please try again. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    claim.DateOfClaim = date2;
                }
            }

            input = "3";
            while (input != "1" && input != "2")
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID} \n" +
                    $"Claim Type: {claim.ClaimType} \n" +
                    $"Claim Description: {claim.Description} \n" +
                    $"Amount of Damage: {claim.ClaimAmount} \n" +
                    $"Date of Accident: {claim.DateOfIncident:d} \n" +
                    $"Date of Claim: {claim.DateOfClaim:d}");
                if (claim.IsValid)
                {
                    Console.WriteLine("This claim is valid.");
                }
                else
                {
                    Console.WriteLine("This claim is not valid.");
                }
                Console.WriteLine();
                Console.WriteLine("Add this claim to the queue? \n" +
                    "1: Yes \n" +
                    "2: No");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Adding this claim to the queue \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        _claimRepo.AddClaim(claim);
                        break;
                    case "2":
                        Console.WriteLine("Returning to the main menu. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("That is not a valid value. Please enter either 1 or 2. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
