using System.Collections.Generic;

namespace ppedv.Druckverwaltung.Model
{
    public class Drucker : Entity
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public virtual ICollection<Druckauftrag> Auftrage { get; set; } = new HashSet<Druckauftrag>();
    }

}
