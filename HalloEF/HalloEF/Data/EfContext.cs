using HalloEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEF.Data
{
    class EfContext:DbContext
    {
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }
    }
}
