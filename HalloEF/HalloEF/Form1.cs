using HalloEF.Data;
using HalloEF.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HalloEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EfContext context = new EfContext();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            var query = context.Mitarbeiter.Where(x => x.Name.StartsWith("F") &&
                                                       x.GebDatum.Month > 2)
                                           .OrderBy(x => x.Abteilungen.Sum(y => y.Bezeichung.Length));

            Debug.WriteLine(query.ToString());

            dataGridView1.DataSource = query.ToList();
        }

        private void SpeichernButton_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void DemoButton_Click(object sender, EventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichung = "Holz" };
            var abt2 = new Abteilung() { Bezeichung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Beruf = "Macht dinge",
                    GebDatum = DateTime.Now.AddYears(-50).AddDays(i * 17),
                    Name = $"Fred #{i:000}"
                };

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                context.Mitarbeiter.Add(m);
            }
            context.SaveChanges();
        }
    }
}
