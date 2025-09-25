using System.Xml.Linq;

namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Employe[] employe = new Employe[]
            {
            new Employe { id = 1, name = "Anders Andersen" },
            new Employe { id = 2, name = "Birgitte Jensen" },
            new Employe { id = 3, name = "Carsten Nielsen" }
            };
            
            
        
            Console.WriteLine("Velkommen");
            Console.WriteLine("Tast 1 Check ind");
            Console.WriteLine("Tast 2 Check ud");
            
            int InOut = int.Parse(Console.ReadLine());
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
                    int id = int.Parse(Console.ReadLine());
                }
            }
            Console.ReadLine();
        }
    }
}
