using ppedv.Druckverwaltung.Logic;
using ppedv.Druckverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Druckverwaltung.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Druckerverwaltung v0.1 ***");

            var core = new Core();

            foreach (var p in core.Repository.GetAll<Patient>())
            {
                Console.WriteLine($"{p.Name}");
            }

            Console.WriteLine($"Der Längste: {core.GetLongestDruckauftrag().Material}");

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
