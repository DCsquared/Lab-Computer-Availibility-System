using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment1_CSC340
{
    class Computer
    {
        private string labID;
        public string labId
        {
            get { return labID; }
            set { labID = value; }
        }
        private string roomNum;
        public string roomNo
        {
            get { return roomNum; }
            set { roomNum = value; }
        }

        private string equip;
        public static int displayComputerStatus(int id, int labi)
        {
            return Computer.retrieveComputerStatus(id, labi);
        }

        //public void grabComputerStatus(int id, int stat, int labi)
        //{
        //    Computer.updateComputerStatus(id, stat, labi);
        //}
        public static int retrieveComputerStatus(int id, int labi)
        {
            int stats = 0;
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=cannon;database=cannon;port=3306;password=MSRBAE;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "Select status from computer where labID = @ls and ID = @i";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ls", labi);
                cmd.Parameters.AddWithValue("@i", id);
                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.Read())
                {
                    stats = Convert.ToInt32(myReader["status"].ToString());
                }
                myReader.Close();

                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return stats;
        }

        public static void updateComputerStatus(int id, int stat, int labi)
        {
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=cannon;database=cannon;port=3306;password=MSRBAE;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "Update computer set status = @s where labID = @ls and ID = @i"/*WHERE labID = @lab ORDER BY labID"*/;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", stat);
                cmd.Parameters.AddWithValue("@ls", labi);
                cmd.Parameters.AddWithValue("@i", id);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return;
        }

    }
}
