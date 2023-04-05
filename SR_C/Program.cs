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
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Membuat Data");
                                        Console.WriteLine("2. Mencari Data");
                                        Console.WriteLine("3. Menghapus Data");
                                        Console.WriteLine("4. Update Data");
                                        Console.WriteLine("5. Keluar");
                                        Console.Write("\nEnter your choice (1-5): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA BARANG\n");
                                                    Console.WriteLine("Masukkan id_barang :");
                                                    string id_barang = Console.ReadLine();
                                                    Console.WriteLine("Masukkan nama_barang :");
                                                    string nama_barang = Console.ReadLine();
                                                    Console.WriteLine("Masukkan harga :");
                                                    string harga = Console.ReadLine();
                                                    Console.WriteLine("Masukkan stok :");
                                                    string stok = Console.ReadLine();
                                                    Console.WriteLine("Masukkan id_supplier :");
                                                    string id_supplier = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(id_barang, nama_barang, harga, stok, id_supplier, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk menambah data")''
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA WARUNG\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                }
                                                break;
                                            case '5':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid option");
                                                }
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Menggunakan User Tersebut\n");
                    Console.ResetColor();
                }
            }
        }

        public void baca(MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand("Select * From barang", con);
            DataSet ds = new DataSet();
            cmd.Fill(ds, "barang");
            DataTable dt = ds.Tables["barang"];

            foreach (DataRow roe in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine(row[col]);
                }
                Console.Write("\n");
            }

        }
        public void insert(string id_barang, string nama_barang, string harga, string stok, string id_supplier,
            MySqlConnection con)
        {

            string str;
            str = "insert into barang (id_barang,nama_barang,harga,stok,id_supplier)"
            + " values(@id_barang,@nama_barang,@harga,@stok,@id_supplier)";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new MySqlParameter("id_barang", id_barang));
            cmd.Parameters.Add(new MySqlParameter("nama_barang", nama_barang));
            cmd.Parameters.Add(new MySqlParameter("harga", harga));
            cmd.Parameters.Add(new MySqlParameter("stok", stok));
            cmd.Parameters.Add(new MySqlParameter("id_supplier", id_supplier));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }
    }
}