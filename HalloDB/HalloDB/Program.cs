using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo DB");

            var conString = "Server=(localdb)\\mssqllocaldb;Database=HalloDb;Trusted_Connection=True;";

            using (var con = new SqlConnection(conString))
            {
                con.Open();
                Console.WriteLine("DB Verbindung ok");

                //var cmd = new SqlCommand();
                //cmd.Connection = con;

                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Personen";

                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var id = reader.GetInt32(reader.GetOrdinal("Id"));
                    var vName = reader.GetString(reader.GetOrdinal("Vorname"));
                    var nName = reader.GetString(reader.GetOrdinal("Nachname"));

                    Console.WriteLine($"{id} {vName} {nName}");
                }

            } //con.Dispose() => con.Close();
            

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
