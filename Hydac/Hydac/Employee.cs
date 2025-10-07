using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Employee
    {
        //Array med alle medarbejdere i systemet
        public static Employee[] employes = 
            {
            new Employee { id = 1, name = "Anders Madsen" },
            new Employee { id = 2, name = "Birgitte Jensen" },
            new Employee { id = 3, name = "Carsten Nielsen" }
            };
       
        //Felter til at gemme medarbejderens unikke ID og navn
        public int id;
        public string name;
        //Bool der fortæller om medarbejderen er checket ind eller checket ud
        public bool IsCheckedIn;
    }

    
}

