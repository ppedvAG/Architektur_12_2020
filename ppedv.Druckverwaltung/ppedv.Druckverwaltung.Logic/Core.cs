using ppedv.Druckverwaltung.Model;
using ppedv.Druckverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Druckverwaltung.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo) //depenceny injection in here
        {
            Repository = repo;
        }

        public Druckauftrag GetLongestDruckauftrag()
        {
            return Repository.Query<Druckauftrag>().Where(x => x.Status == Druckstatus.Fertig)
                                                   .OrderBy(x => x.Ende - x.Start)
                                                   .FirstOrDefault();
        }


        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
