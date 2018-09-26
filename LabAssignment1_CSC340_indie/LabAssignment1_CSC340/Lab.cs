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

    
    class Lab //with a list
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

       public static List<Lab> retrieveLabStatus()
       // internal static List<Lab> retrieveLabStatus()
        {
            return displayLabStatus();
            //throw new NotImplementedException();
            
        }

        public string equipMents
        {
            get { return equip; }
            set { equip = value; }
        }

        private string time;
        public string times
        {
            get { return time; }
            set { time = value; }
        }

        public Lab(string i, string r, string e, string t)
        {
            labID = i;
            roomNo = r;
            equip = e;
            times = t;
        }

        /// <summary>
        /// Should probably call on three different Sql statements to get the
        /// data for lab objects
        /// </summary>
        /// <param name="lab"></param>
        

        internal static List<Lab> displayLabStatus()
        {
            List<Lab> eventList = new List<Lab>();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=cannon;database=cannon;port=3306;password=MSRBAE;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM lab ORDER BY labID"/*WHERE labID = @lab ORDER BY labID"*/;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
               // cmd.Parameters.AddWithValue("@lab", lab);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Lab newEvent = new Lab(row["labID"].ToString(), row["roomNo"].ToString(), row["equipMents"].ToString(), row["times"].ToString());
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }

        /// <summary>
        /// id, status, lab
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="j"></param>
        public static void getlabComputerStatus(int n, int m, int j)
        {
             Computer.updateComputerStatus(n, m, j);
        }

        /// <summary>
        /// id, lab
        /// </summary>
        /// <param name="n"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static int retreivelabComputerStatus(int n,  int j)
        {
           return Computer.retrieveComputerStatus(n, j);
        }
    }

}
