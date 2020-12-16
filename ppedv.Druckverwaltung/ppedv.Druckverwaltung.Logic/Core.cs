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
            var dbQuery =  Repository.Query<Druckauftrag>()
                                     .Where(x => x.Status == Druckstatus.Fertig)
                                     .ToList();

            var sortiert = dbQuery.OrderByDescending(x => x.Ende - x.Start).ThenBy(x=>x.Material);

            return sortiert.FirstOrDefault();

            //return Repository.Query<Druckauftrag>().Where(x => x.Status == Druckstatus.Fertig) 
            //                                       .ToList() //bis hier ist Linq-To-entities
            //            /*LINQ-to-Objects*/        .OrderBy(x => x.Ende - x.Start)
            //            /*LINQ-to-Objects*/        .FirstOrDefault();
        }


        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
