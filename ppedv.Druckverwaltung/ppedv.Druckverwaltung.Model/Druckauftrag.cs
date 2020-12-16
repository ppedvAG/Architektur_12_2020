using System;

namespace ppedv.Druckverwaltung.Model
{
    public class Druckauftrag : Entity
    {
        public virtual Scan Scan { get; set; }
        public string Material { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public Druckstatus Status { get; set; }
        public virtual Drucker Drucker { get; set; }
    }

    public enum Druckstatus
    {
        Geplant,
        ImDruck,
        Fertig,
        Fehler
    }
}
