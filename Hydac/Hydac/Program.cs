using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Hydac
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Registration reg = new Registration();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til HYDAC\n");
                Console.WriteLine("Tast ENTER for at checke ind eller checke ud");
                Console.ReadLine();
                Console.Clear();

                reg.getInOut();
                reg.getEmployeGuest();
                reg.validate();

                StreamWriter sw = new StreamWriter("Data.txt", true);
                sw.WriteLine($"{reg.name} du er tjekket {reg._inOut} d. {DateTime.Now}");

                sw.Close();

            }
        }
    }
}
