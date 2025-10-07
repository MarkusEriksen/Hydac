using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter et nyt Registration-objekt, som håndterer check ind og check ud
            Registration reg = new Registration();
            //Programmet kører indtil det stoppes manuelt
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til HYDAC\n");
                Console.WriteLine("Tast ENTER for at checke ind eller checke ud");
                Console.ReadLine();
                Console.Clear();

                //Kalder metoder i Registration-klassen
                reg.GetInOut();
                reg.GetEmployeeGuest();
                reg.Validate();

                // Åbner en StreamWriter, skriver en linje og lukker ned igen
                StreamWriter sw = new StreamWriter("Data.txt", true);
                sw.WriteLine($"{reg.name} du er tjekket {reg._inOut} d. {DateTime.Now}");
                sw.Close();

            }
        }
    }
}
