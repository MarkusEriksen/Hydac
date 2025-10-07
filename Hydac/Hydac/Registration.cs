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
            Console.WriteLine("Tast 1 for Check ind");
            Console.WriteLine("Tast 2 for Check ud");
            Console.WriteLine();
            Console.WriteLine("Tast ENTER for at bekræfte dit valg");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int inOut))
            {
                if (inOut == 1)
                {
                    this.inOut = true;
                }
                else if (inOut == 2)
                {
                    this.inOut = false;
                }
                else
                {
                    Console.WriteLine("Tast 1 eller 2!!!");
                }
            }
        }
   
        public void getEmployeGuest()
        {
            Console.Clear();

            Console.WriteLine("Tast 1 for Medarbejder");
            Console.WriteLine("Tast 2 for Gæst");
            Console.WriteLine();
            Console.WriteLine("Tast ENTER for at bekræfte dit valg");

            int employeGuest = int.Parse(Console.ReadLine());
            Console.Clear();

            if (employeGuest == 1)
            {
                this.employeGuest = true;
            }
            else if (employeGuest == 2)
            {
                this.employeGuest = false;
            }
            else
            {
                Console.WriteLine("Tast 1 eller 2!!!");
            }
            Console.Clear();
        }

        public void validate()
        {
            Console.Write("Tast medarbejder ID: ");
            id = int.Parse(Console.ReadLine());

            //For hver medarbejder(e) i employe arrayet tjekker vi om det indtastede id(id) == et defineret medarbejder id(e.id). Hvis ja så print navn. 
            foreach (Employe emp in Employe.employes)
            {
                if (emp.id == id)
                {
                    name = emp.name;
                    Console.WriteLine($"Velkommen til {name} du er tjekket {_inOut} d. {DateTime.Now}");
                    break;
                }
            }
            if (name == null)
            {
                Console.WriteLine("Ugyldigt medarbejder ID");
            }
            Console.ReadLine();

        }
    
    
    
    
    
    
    
    
    
    
    
    }
}
