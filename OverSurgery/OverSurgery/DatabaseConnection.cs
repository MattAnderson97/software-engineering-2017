using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class DatabaseConnection
    {
        #region ATTRIBUTES
        private string connectionStr;

        // The SqlCconnection object used to store the connection to
        // the database.
        System.Data.SqlClient.SqlConnection connectionToDB;

        // The DataAdapter object used to open a table of the 
        // database.
        private System.Data.SqlClient.SqlDataAdapter dataAdapter;
        #endregion

        #region METHODS

        /// <summary>
        /// Open the connection.
        /// </summary>
        public void openConnection()
        {
            // Create the connection to the database as an instance of 
            // System.Data.SqlClient.SqlConnection.
            connectionToDB = new System.Data.SqlClient.SqlConnection(connectionStr);

            // Opens the connection
            connectionToDB.Open();
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void closeConnection()
        {
            // Closes the connection to the database.
            connectionToDB.Close();
        }
        #endregion

        #region CONSTRUCTORS
        public DatabaseConnection(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }
        #endregion
    }
}
