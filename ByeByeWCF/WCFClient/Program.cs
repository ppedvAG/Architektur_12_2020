using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo WCF");

            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            
            var result =  client.Verdoppeln(17);
            Console.WriteLine(result);

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
