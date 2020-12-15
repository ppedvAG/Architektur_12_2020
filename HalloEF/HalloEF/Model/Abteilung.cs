using System.Collections.Generic;

namespace HalloEF.Model
{
    class Abteilung
    {
        public int Id { get; set; }
        public string Bezeichung { get; set; }
        public virtual ICollection<Mitarbeiter> Mitarbeiter { get; set; } = new HashSet<Mitarbeiter>();
    }
}
