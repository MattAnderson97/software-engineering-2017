using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planera_Life
{
    public partial class NewQueryDialogueBox: Form
    {
        private static SyncDelegate Handler;
        private static event SyncDelegate ChangeMade;

        public NewQueryDialogueBox()
        {
            InitializeComponent();
            
        }

        private void btn_QuerySave_Click(object sender, EventArgs e)
        {
            //Add query to main list
            Query Query = new Query(txt_QueryTitle.Text, txt_QueryText.Text);

            //Sync Changes and close
            Program.AddQuery(Query);
            this.Close();
        }

        private void btn_QueryCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sync()
        {


        }
    }
}
