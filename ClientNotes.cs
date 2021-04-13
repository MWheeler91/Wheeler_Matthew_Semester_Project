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
    public partial class ClientNotes : Form
    {
        List<NoteModel> date = new List<NoteModel>();
        //public LookUpClient test;
        LookUpClient person;

        public string ClientID
        {
            get { return lblID.Text; }
        }

        public ClientNotes(LookUpClient person, string id)
        {
            // passes the highlighted person from the look-up client form
            this.person = person;
            InitializeComponent();
            lblID.Text = id;
        }
        private void ClientNotes_Load_1(object sender, EventArgs e)
        {
            // upon form load the name label is set to the name that was passed from the lookup client form
            lblID.Text = ClientID;
            lblName.Text = person.ListBoxValue;
            // sets that name to a variable so it can be passed for queries
            string clientName = lblName.Text;
            date = SQLiteDataAccess.LoadNoteQuery(ClientID);

            lbNoteQuery.DataSource = date; // shows people
            lbNoteQuery.DisplayMember = date.ToString(); // displays the person model's name
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int idnumber = Convert.ToInt32(lblID.Text);
            // saves the data in  the new note RTF to variable so it can be written to the database
            string saveNote = rtbNewNote.Text;
            // transfers the saveNote variable to be written
            SQLiteDataAccess.SaveNoteQuery(saveNote, idnumber);
            RefreshList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbNoteQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when the selected item in the listbox is changed it queries the database for the new selected date's notes
            string clientName = lblName.Text;
            string note = SQLiteDataAccess.ViewNote(lbNoteQuery.SelectedItem,  ClientID);
            rtbViewNote.Text = note;
        }
        private void RefreshList()
        {
            // upon form load the name label is set to the name that was passed from the lookup client form
            lblID.Text = ClientID;
            lblName.Text = person.ListBoxValue;
            // sets that name to a variable so it can be passed for queries
            string clientName = lblName.Text;
            date = SQLiteDataAccess.LoadNoteQuery(ClientID);

            lbNoteQuery.DataSource = date; // shows people
            lbNoteQuery.DisplayMember = date.ToString(); // displays the person model's name
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
