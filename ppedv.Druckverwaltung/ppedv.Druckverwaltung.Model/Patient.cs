using System;
using System.Collections.Generic;

namespace ppedv.Druckverwaltung.Model
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public DateTime GetDatum { get; set; }
        public string Ort { get; set; }
        public virtual ICollection<Scan> Scans { get; set; } = new HashSet<Scan>();
    }

}
