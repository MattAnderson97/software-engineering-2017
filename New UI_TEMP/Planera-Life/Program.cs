using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Planera_Life
{
    public delegate void SyncDelegate();
    public delegate void FileDelegate(DataTable Table);

    static class Program
    {        
        public static List<Query> Queries { get; set; }
        public static List<DataTable> Tables { get; set; }
        public static DataTable QueryResults;
        public static List<User> Users { get; set; }
        

        public static event SyncDelegate ChangeMade;
        public static event FileDelegate FileExport;
        private static SyncDelegate Handler;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Initialise properties
            Queries = new List<Query>();
        }

        public static void AddQuery(Query Query)
        {
            if(Queries==null)
            {
                Queries = new List<Query>();
            }

            Queries.Add(Query);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool isFemale { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        public User(string Name = "Admin")
        {
            this.Name = Name;
        }

        public void Set(string Name, string Email, DateTime DateOfBirth, bool isFemale, string Telephone, string Address)
        {
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.isFemale = isFemale;
            this.Telephone = Telephone;
            this.Address = Address;
        }
    }


    public class Query
    {
        public string Title { get; private set; }
        public string SQl { get; private set; }

        public Query(string Title, string SQL)
        {
            this.Title = Title;
            this.SQl = SQL;
        }

    }

    public class Session
    {
        public static string ConnectionString = "";

        public Session(string _ConnectionString = "")
        {
            if (ConnectionString != null)
            {
                ConnectionString = _ConnectionString;
            }
        }

        public DataTable ExecuteQuery(Query Query)
        {
            string SQL = Query.SQl;
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            OleDbCommand Command = new OleDbCommand(SQL);
            OleDbDataAdapter Adapter = new OleDbDataAdapter();
            DataTable Results = new DataTable();

            Connection.Open();

            Connection.Close();

            Adapter.Fill(Results);

            return Results;
        }
    }

    public class Table
    {
        public string Title { get; private set; }
        private int NumberOfColumns;
        public DataTable DataTable { get; private set; }

        public List<string[]> Rows { get; private set; }  = new List<string[]>();

        public Table(string Title, int NumberOfColumns)
        {
            this.Title = Title;
            this.NumberOfColumns = NumberOfColumns;
        }

        public void SetTitle(string Title)
        {
            this.Title = Title;
        }

        public void Set(DataTable Table)
        {
            DataTable = Table;

        }

        public string[,] GetRow(string[] Row)
        {
            string[,] _Row = new string[NumberOfColumns, Row.Count()];
            int Count = 0;

            foreach(string Field in Row)
            {
                _Row[NumberOfColumns, Count] = Field;
                Count += 1;
            }

            return _Row;
        }
    }
}
