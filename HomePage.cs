using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wheeler_Matthew_Semester_Project
{

    
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void newClientButton_Click(object sender, EventArgs e)
        {
            Hide();
            NewClient newClient = new NewClient();
            newClient.Show();
        }

        private void clientLookUpButton_Click(object sender, EventArgs e)
        {
            Hide();
            LookUpClient lookUpClient = new LookUpClient();
            lookUpClient.Show();
        }
    }
}
