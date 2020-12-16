using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singelton
{
    class Program
    {
        static void Main(string[] args)
        {
            //var singel = new Singelton();
            //var singel2 = new Singelton();
            //var singel3 = new Singelton();
            Singelton.Instance.Hallo();
            Singelton.Instance.Hallo();
            Singelton.Instance.Hallo();
            Singelton.Instance.Hallo();
        }
    }

    public class Singelton
    {
        static Singelton _instance = null;
        public static Singelton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singelton();

                return _instance;
            }
        }

        private Singelton()
        { }

        public void Hallo() { }
    }
}
