using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverSurgery
{
    public partial class ApplicationMenu : Form
    {
        public ApplicationMenu()
        {
            InitializeComponent();
        }

        // Main Menu settings button click event.
        private void btnSettings_Click(object sender, EventArgs e)
        {
            // If the settings button is clicked the Create User panel will be displayed.
            pnlCreateUser.Visible = true;
        }

        #region pnlCreateUser
        // Create User panel back button click event.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // If the back button is clicked the Create User panel will be hidden.
            pnlCreateUser.Visible = false;
        }

        // Create user panel create button.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text != "" && tbxPassword.Text != "")
            {
                string userName = tbxUsername.Text;
                string password = tbxPassword.Text;
                LoginManager.GetLoginManagerInstance().CreateUser(userName, password);
                MessageBox.Show("Account Created!", "Done!");
                pnlCreateUser.Visible = false;
            }
            else
            {
                MessageBox.Show("Please enter a username and password.", "Error!");
            }
        }
        #endregion

        
    }
}
