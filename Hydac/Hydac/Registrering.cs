using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hydac
{
    internal class Registrering
    {
        //variabler der 'get' men kun kan 'set' via Register()
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InOut { get; set; }
        public bool EmployeGuest { get; set; }



        public void Register()
        {
            Console.WriteLine("Tast 1 Check ind");
            Console.WriteLine("Tast 2 Check ud");
            int inOut = int.Parse(Console.ReadLine());
            if (inOut == 1)
            {
                InOut = true;
            }
            else if (inOut == 2)
            {
                InOut = false;
            }
            else
            {
                Console.WriteLine("Tast 1 eller 2!!!");
            }

            Console.Clear();

            if (InOut == true)
            {
                Console.WriteLine("Tast 1 for Medarbejder");
                Console.WriteLine("Tast 2 for Gæst");

                int employeGuest = int.Parse(Console.ReadLine());
                Console.Clear();

                if (employeGuest == 1)
                {
                    EmployeGuest = true;
                }
                else if (employeGuest == 2)
                {
                    EmployeGuest = false;
                }
                else
                {
                    Console.WriteLine("Tast 1 eller 2!!!");
                }
                Console.Clear();

                if (EmployeGuest = true)
                {
                    Console.Write("Tast medarbejder ID: ");
                    Id = int.Parse(Console.ReadLine());

                    //For hver medarbejder(e) i employe arrayet tjekker vi om det indtastede id(id) == et defineret medarbejder id(e.id). Hvis ja så print navn. 
                    foreach (Employe emp in Employe.employes)
                    {
                        if (emp.id == Id)
                        {
                            Name = emp.name;
                            Console.WriteLine($"Velkommen til {emp.name} du er tjekket ind d. {DateTime.Now}");
                            Console.ReadLine();
                            return;
                            
                        }
                    }
                    Console.WriteLine("Ugyldigt medarbejder ID");
                    Console.ReadLine();

                }

            }
        }
    }
}
