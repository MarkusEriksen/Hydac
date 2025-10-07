using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Employe
    {
        public static Employe[] employes = 
            {
            new Employe { id = 1, name = "Anders Madsen" },
            new Employe { id = 2, name = "Birgitte Jensen" },
            new Employe { id = 3, name = "Carsten Nielsen" }
            };
        public int id;
        public string name;
        public bool IsCheckedIn; // Add this line
    }

    
}

