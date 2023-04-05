using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SR_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.WriteLine("Masukkan Server :");
                    string server = Console.ReadLine();
                    Console.WriteLine("Masukkan User ID :");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password :");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database Tujuan :");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk terhubung ke database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                MySqlConnection conn;
                                string connectionString;
                                connectionString = @"SERVER=Mysql@127.0.0.1:3306" + server + ";DATABASE=database_warung" +
                                db + ";UserID=SARAS" + user + ";PASSWORD=1234" + pass + ";Port=3306";

                                conn = new MySqlConnection(connectionString);
                                conn.Open();
                                Console.Clear();
                                while (true)

                            }
                    }

                }
            }
        }
    }
}
