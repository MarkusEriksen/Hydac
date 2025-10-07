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
    internal class Registration
    {
        public int id;
        public string name;
        public bool inOut;
        public bool employeGuest;
        public string _inOut => inOut ? "ind" : "ud";


        public void getInOut()
        {
            while (true)
            {
                Console.WriteLine("Tast 1 for Check ind");
                Console.WriteLine("Tast 2 for Check ud");
                Console.WriteLine();
                Console.WriteLine("Tast ENTER for at bekræfte dit valg");

                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input må ikke være tomt. Prøv igen.");
                    continue;
                }
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
   
        public void getEmployeGuest()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tast 1 for Medarbejder");
                Console.WriteLine("Tast 2 for Gæst");
                Console.WriteLine();
                Console.WriteLine("Tast ENTER for at bekræfte dit valg");

                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input må ikke være tomt. Prøv igen.");
                    continue;
                }
                if (int.TryParse(input, out int employeGuest))
                {
                    if (employeGuest == 1)
                    {
                        this.employeGuest = true;
                        break;
                    }
                    else if (employeGuest == 2)
                    {
                        this.employeGuest = false;
                        break;
                    }
                }
                Console.WriteLine("Tast 1 eller 2!!!");
            }
            Console.Clear();
        }

        public void validate()
        {
            if (!employeGuest)
            {
                Console.WriteLine("Gæstefunktion er ikke implementeret endnu.");
                Console.ReadLine();
                return;
            }

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

            foreach (Employe emp in Employe.employes)
            {
                if (emp.id == id)
                {
                    name = emp.name;

                    // Check om medarbejderen allerede er checket ind
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
                        emp.IsCheckedIn = inOut;
                        Console.WriteLine($"Velkommen til {name} du er tjekket {_inOut} d. {DateTime.Now}");
                    }
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("Ugyldigt medarbejder ID");
            Console.ReadLine();
        }
    
    
    
    
    
    
    
    
    
    
    
    }
}
