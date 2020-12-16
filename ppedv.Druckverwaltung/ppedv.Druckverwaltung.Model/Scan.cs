using System;
using System.Collections.Generic;

namespace ppedv.Druckverwaltung.Model
{
    public class Scan : Entity
    {
        public DateTime Datum { get; set; }
        public virtual Patient Patient { get; set; }
        public byte[] Daten { get; set; }
        public double Size { get; set; }
        public virtual ICollection<Druckauftrag> Druckauftrage { get; set; } = new HashSet<Druckauftrag>();
    }

}
