using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var titelOLD = "Heute ist der " + DateTime.Now.ToString("dd.MM.yyyy") + " und es ist ein toller tag";
            var titelSF = string.Format("Heute ist der {0:dd.MM.yyyy} und es ist ein {1} toller Tag", DateTime.Now,1245);
            var titelSI = $"Heute ist der {DateTime.Now:dd.MM.yyyy} und es ist ein {12345} toller Tag";

            //string interpolation = $
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            textBox2.Text = json;

            BookResult bookResult = JsonConvert.DeserializeObject<BookResult>(json);

            dataGridView1.DataSource = bookResult.items.Select(x => x.volumeInfo).ToList();
        }
    }
}
