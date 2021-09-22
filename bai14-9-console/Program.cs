using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bai14_9_console
{
    class Program
    {
        static String con = "Server=tcp:c1908g00.database.windows.net,1433;Initial Catalog=c1908gDB;Persist Security Info=False;User ID=c1908g;Password=1908g123@A;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
            String strTable = "select * from [NhiTestTable]";
            SqlConnection connect = new SqlConnection(con);
            SqlCommand cm = new SqlCommand(strTable, connect);
            try
            {
                Console.WriteLine("Hien thi thong tin tu Cloud Server");
                connect.Open();
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    Console.WriteLine("Ten {0},comment {1}", rd.GetValue(0).ToString(), rd.GetValue(1),
                     rd.GetValue(2).ToString());
                }
            }
            catch (Exception ex)
            {

            }
            insertdb();

            
        }
        static void insertdb()
        {
            String a;
            String b;
            Console.WriteLine("Nhap a:");
            a = Console.ReadLine();
            Console.WriteLine("Nhap a:");
            b = Console.ReadLine();
            String strTable = "insert into  [NhiTestTable] (LinhsComment, feelings) values (@aa, @bb)";
            SqlConnection connect = new SqlConnection(con);
            SqlCommand cm = new SqlCommand(strTable, connect);
            connect.Open();
            cm.Parameters.AddWithValue("@aa", a);
            cm.Parameters.AddWithValue("@aa", b);
            cm.ExecuteNonQuery();
            Console.WriteLine("Insert thanh cong");
        }
    }
}
