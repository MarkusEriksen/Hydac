using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Registrering
    {
        //variabler der 'get' men kun kan 'set' via Register()
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int InOut { get; private set; }
        public int EmployeGuest { get; private set; }


        public void Register() {
            Console.WriteLine("Tast 1 Check ind");
            Console.WriteLine("Tast 2 Check ud");
            InOut = int.Parse(Console.ReadLine());
            Console.Clear();

            if (InOut == 1)
            {
                Console.WriteLine("Tast 1 for Medarbejder");
                Console.WriteLine("Tast 2 for Gæst");

                int EmployeGuest = int.Parse(Console.ReadLine());
                Console.Clear();
                if (EmployeGuest == 1)
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
