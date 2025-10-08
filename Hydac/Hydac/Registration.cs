using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hydac
{
    public class Registration
    {
        public int id;
        public string name;
        public bool inOut;
        public bool employeeGuest;
        public string _inOut => inOut ? "ind" : "ud";

        //Metode til at vælge check ind eller check ud
        public void GetInOut()
        {
            while (true)
            {
                Console.WriteLine("Tast 1 for Check ind");
                Console.WriteLine("Tast 2 for Check ud");
                Console.WriteLine();
                Console.WriteLine("Tast ENTER for at bekræfte dit valg");

                //Tjekker om input er tomt
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input må ikke være tomt. Prøv igen.");
                    continue;
                }
                //Forsøger at parse input til et tal
                if (int.TryParse(input, out int inOut))
                {
                    if (inOut == 1)
                    {
                        this.inOut = true;
                        break;
                    }
                    else if (inOut == 2)
                    {
                        this.inOut = false;
                        break;
                    }
                }
                Console.WriteLine("Tast 1 eller 2!!!");
            }
        }
        // Metode til at vælge om det er medarbejder eller gæst
        public void GetEmployeeGuest()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tast 1 for Medarbejder");
                Console.WriteLine("Tast 2 for Gæst");
                Console.WriteLine();
                Console.WriteLine("Tast ENTER for at bekræfte dit valg");

                string input = Console.ReadLine();
                // Tjekker om input er tomt
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input må ikke være tomt. Prøv igen.");
                    continue;
                }
                // Forsøger at parse input til et tal
                if (int.TryParse(input, out int employeeGuest))
                {
                    if (employeeGuest == 1)
                    {
                        this.employeeGuest = true;
                        break;
                    }
                    else if (employeeGuest == 2)
                    {
                        this.employeeGuest = false;
                        break;
                    }
                }
                Console.WriteLine("Tast 1 eller 2!!!");
            }
            Console.Clear();
        }

        // Metode til at validere medarbejderens ID og status
        public void Validate()
        {
            //Hvis gæst vælges gives nedenstående besked
            if (!employeeGuest)
            {
                Console.WriteLine("Gæstefunktion er ikke implementeret endnu.");
                Console.ReadLine();
                return;
            }

            // Loop indtil gyldigt medarbejder ID er indtastet
            while (true)
            {
                Console.Write("Tast medarbejder ID: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input må ikke være tomt. Prøv igen.");
                    continue;
                }
                if (int.TryParse(input, out id))
                {
                    break;
                }
                Console.WriteLine("Ugyldigt ID format. Prøv igen.");
            }

            // Tjekker om ID findes i listen af medarbejdere
            foreach (Employee emp in Employee.employes)
            {
                if (emp.id == id)
                {
                    name = emp.name;

                    // Check om medarbejderen allerede er checket ind eller checket ud
                    if (inOut && emp.IsCheckedIn)
                    {
                        Console.WriteLine($"Medarbejder {name} er allerede checket ind.");
                    }
                    else if (!inOut && !emp.IsCheckedIn)
                    {
                        Console.WriteLine($"Medarbejder {name} er allerede checket ud.");
                    }
                    else
                    {
                        // Opdater medarbejderens status til checket ind eller checket ud
                        emp.IsCheckedIn = inOut;
                        Console.WriteLine($"Velkommen til {name} du er tjekket {_inOut} d. {DateTime.Now}");
                    }
                    Console.ReadLine();
                    return;
                }
            }
            // Hvis ID ikke findes i listen
            Console.WriteLine("Ugyldigt medarbejder ID");
            Console.ReadLine();
        }

        // Add this method to support unit testing
        public bool TryCheckInOut(int employeeId, bool checkIn, out string employeeName)
        {
            employeeName = null;
            var emp = Employee.employes.FirstOrDefault(e => e.id == employeeId);
            if (emp == null)
                return false;

            employeeName = emp.name;

            if (checkIn)
            {
                if (emp.IsCheckedIn)
                    return false; // Already checked in
                emp.IsCheckedIn = true;
                return true;
            }
            else
            {
                if (!emp.IsCheckedIn)
                    return false; // Already checked out
                emp.IsCheckedIn = false;
                return true;
            }
        }
    }
}
