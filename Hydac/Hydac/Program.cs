using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Registrering reg = new Registrering();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen");
                Console.ReadLine();
                Console.Clear();

                reg.Register();

                StreamWriter sw = new StreamWriter("Data.txt", true);
                sw.WriteLine($"{reg.Name} er checket ind d. {DateTime.Now}");

                sw.Close();

            }
        }
    }
}
