using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wheeler_Matthew_Semester_Project
{
    public partial class LookUpClient : Form
    {
        //List<PersonModel> people = new List<PersonModel>();

        public LookUpClient()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            HomePage HomePage = new HomePage();
            HomePage.Show();
        }



        private void clientLookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            LookUpClient lookUpClient = new LookUpClient();
            lookUpClient.Show();
        }

        private void newClientToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            NewClient newClient = new NewClient();
            newClient.Show();
        }

        private void lblOrthopedicPainWhere_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnViewNotes_Click(object sender, EventArgs e)
        {
            try
            {
                // transfer person to new form
                ClientNotes note = new ClientNotes(this, txtClientID.Text);
                note.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Must select a client name first!");
            }

        }
        public string ListBoxValue
        {
            get { return lbQueryReturn.SelectedItem.ToString(); }
        }
         
        private void btnSeachClient_Click(object sender, EventArgs e)
        {
            List<PersonModel> people = new List<PersonModel>();
            try
            {
                //sets culture info for title case
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                //converts the text search box to title case
                string Qtxtbox = myTI.ToTitleCase(txtClientQuery.Text);
                //sends the text box value to the sql query

                people = SQLiteDataAccess.LoadPeople(Qtxtbox);
                //MessageBox.Show(people.get(0));
                lbQueryReturn.DataSource = people; // shows people
                lbQueryReturn.DisplayMember = people.ToString(); // displays the person model's name
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("There are no clients with that last name!");
            }
        }


        private void lbQueryReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sets culture info for title case
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            // converts the text search box to title case
            string Qtxtbox = myTI.ToTitleCase(txtClientQuery.Text);

            // sends the selected item to the SQL class and returns the value to this string
            string FirstNameTxt = SQLiteDataAccess.FirstNameQuery(lbQueryReturn.SelectedItem);
            string MiddlenitialTxt = SQLiteDataAccess.MiddleInitialQuery(lbQueryReturn.SelectedItem);
            string LastNameTxt = SQLiteDataAccess.LastNameQuery(lbQueryReturn.SelectedItem);
            string Phonetxt = SQLiteDataAccess.PhoneQuery(lbQueryReturn.SelectedItem);
            string EmailTxt = SQLiteDataAccess.EmailQuery(lbQueryReturn.SelectedItem);
            string AddressTxt = SQLiteDataAccess.AddressQuery(lbQueryReturn.SelectedItem);
            string CityTxt = SQLiteDataAccess.CityQuery(lbQueryReturn.SelectedItem);
            string Statetxt = SQLiteDataAccess.StateQuery(lbQueryReturn.SelectedItem);
            string ZipTxt = SQLiteDataAccess.ZipQuery(lbQueryReturn.SelectedItem);
            string DateofBirth = SQLiteDataAccess.DateOfBirthQuery(lbQueryReturn.SelectedItem);
            string Occupationtxt = SQLiteDataAccess.OccupationQuery(lbQueryReturn.SelectedItem);
            string EmployerTxt = SQLiteDataAccess.EmployerQuery(lbQueryReturn.SelectedItem);
            string EmergencyContactTxt = SQLiteDataAccess.EmergencyContactQuery(lbQueryReturn.SelectedItem);
            string EmergencyContactRelationshipTxt = SQLiteDataAccess.EmergencyContactRelationshipQuery(lbQueryReturn.SelectedItem);
            string EmergencyContactPhoneTxt = SQLiteDataAccess.EmergencyContactPhone(lbQueryReturn.SelectedItem);
            string CurrentMedicationsTxt = SQLiteDataAccess.CurrentMedicationsQuery(lbQueryReturn.SelectedItem);
            string ChronicPainWhereTxt = SQLiteDataAccess.ChronicPainWhereQuery(lbQueryReturn.SelectedItem);
            string OrthopedicPainWheretxt = SQLiteDataAccess.OrthopedicPainWhereQuery(lbQueryReturn.SelectedItem);
            string AreasOfDiscomfortText = SQLiteDataAccess.AreasOfDiscomfortQuery(lbQueryReturn.SelectedItem);
            string Allegiestxt = SQLiteDataAccess.AllergiesWhatQuery(lbQueryReturn.SelectedItem);
            string ClientID = SQLiteDataAccess.ClientID(lbQueryReturn.SelectedItem);

            // sets the text box = to the above string
            txtFirstName.Text = myTI.ToTitleCase(FirstNameTxt);
            txtMiddleInitial.Text = myTI.ToTitleCase(MiddlenitialTxt);
            txtLastName.Text = myTI.ToTitleCase(LastNameTxt);
            try
            {
                txtPhone.Text = string.Format("{0:(###) ###-####}", Convert.ToInt64(Phonetxt));
            }
            catch (FormatException)
            {
                txtPhone.Text = Phonetxt;
            }
            txtEmail.Text = EmailTxt;
            txtAddress.Text = myTI.ToTitleCase(AddressTxt);
            txtCity.Text = myTI.ToTitleCase(CityTxt);
            txtState.Text = myTI.ToTitleCase(Statetxt);
            txtZip.Text = ZipTxt.ToString();
            datetimeDob.Text = DateofBirth;
            txtOccupation.Text = Occupationtxt;
            txtEmployer.Text = EmployerTxt;
            txtEmergencyContact.Text = EmergencyContactTxt;
            txtEmergencyContactRelationship.Text = EmergencyContactRelationshipTxt;
            try
            {
                txtEmergencyContactPhone.Text = string.Format("{0:(###) ###-####}", Convert.ToInt64(EmergencyContactPhoneTxt));
            }
            catch (FormatException)
            {
                txtEmergencyContactPhone.Text = EmergencyContactPhoneTxt;
            }
            txtCurrentMedications.Text = CurrentMedicationsTxt;
            txtChronicPain.Text = ChronicPainWhereTxt;
            txtOrthopedicPain.Text = OrthopedicPainWheretxt;
            txtAreaOfDiscomfort.Text = AreasOfDiscomfortText;
            txtAllergies.Text = Allegiestxt;
            txtClientID.Text = ClientID;

            // checkboxes
            int ChronicPain = SQLiteDataAccess.ChronicPainQuery(lbQueryReturn.SelectedItem);
            int OrthopedicPain = SQLiteDataAccess.OrthopedicPainQuery(lbQueryReturn.SelectedItem); 
            int Pregnant = SQLiteDataAccess.PregnantQuery(lbQueryReturn.SelectedItem);
            int PreferedPressureLight = SQLiteDataAccess.PreferedPressureLightQuery(lbQueryReturn.SelectedItem);
            int PreferedPressureMedium = SQLiteDataAccess.PreferedPressureMediumQuery(lbQueryReturn.SelectedItem);
            int PreferedPressureDeep = SQLiteDataAccess.PreferedPressureDeepQuery(lbQueryReturn.SelectedItem);
            int Allergies = SQLiteDataAccess.AllergiesQuery(lbQueryReturn.SelectedItem);
            int Cancer = SQLiteDataAccess.CancerQuery(lbQueryReturn.SelectedItem);
            int HeadacheMigrain = SQLiteDataAccess.HeadacheMigrainQuery(lbQueryReturn.SelectedItem);
            int Arthritis = SQLiteDataAccess.ArthritisQuery(lbQueryReturn.SelectedItem);
            int Diabetes = SQLiteDataAccess.DiabetesQuery(lbQueryReturn.SelectedItem);
            int JointReplacement = SQLiteDataAccess.JointReplacementQuery(lbQueryReturn.SelectedItem);
            int HighLowBloodPressure = SQLiteDataAccess.HighLowBloodPressureQuery(lbQueryReturn.SelectedItem); 
            int Neuropathy = SQLiteDataAccess.NeuropathyQuery(lbQueryReturn.SelectedItem); 
            int Fibromyalgia = SQLiteDataAccess.FibromyalgiaQuery(lbQueryReturn.SelectedItem);
            int Stroke = SQLiteDataAccess.StrokeQuery(lbQueryReturn.SelectedItem);
            int HeartAttack = SQLiteDataAccess.HeartAttackQuery(lbQueryReturn.SelectedItem);
            int KidneyDysfunction = SQLiteDataAccess.KidneyDysfunctionQuery(lbQueryReturn.SelectedItem);
            int BloodClots = SQLiteDataAccess.BloodClotsQuery(lbQueryReturn.SelectedItem);
            int Numbness = SQLiteDataAccess.NumbnessQuery(lbQueryReturn.SelectedItem);  
            int SprainsStrains = SQLiteDataAccess.SprainsStrainsQuery(lbQueryReturn.SelectedItem); 


            if (ChronicPain == 1)
            {
                cbChronicPainYes.Checked = true;
            }
            else
            {
                cbChronicPainYes.Checked = false;
            }

            if (OrthopedicPain == 1)
            {
                cbOrthopedicPainYes.Checked = true;
            }
            else
            {
                cbOrthopedicPainYes.Checked = false;
            }

            if (Pregnant == 1)
            {
                cbPregnant.Checked = true;
            }
            else
            {
                cbPregnant.Checked = false;
            }

            if (PreferedPressureLight == 1)
            {
                cbPreferredPressureLight.Checked = true;
            }
            else
            {
                cbPreferredPressureLight.Checked = false;
            }

            if (PreferedPressureMedium == 1)
            {
                cbPreferredPressureMedium.Checked = true;
            }
            else
            {
                cbPreferredPressureMedium.Checked = false;
            }

            if (PreferedPressureDeep == 1)
            {
                cbPreferredPressureDeep.Checked = true;
            }
            else
            {
                cbPreferredPressureDeep.Checked = false;
            }

            if (Allergies == 1)
            {
                cbAllergiesYes.Checked = true;
            }
            else
            {
                cbAllergiesYes.Checked = false;
            }

            if (Cancer == 1)
            {
                cbCancer.Checked = true;
            }
            else
            {
                cbCancer.Checked = false;
            }

            if (HeadacheMigrain == 1)
            {
                cbHeadacheMigraines.Checked = true;
            }
            else
            {
                cbHeadacheMigraines.Checked = false;
            }





            if (Arthritis == 1)
            {
                cbArthritis.Checked = true;
            }
            else
            {
                cbArthritis.Checked = false;
            }

            if (Diabetes == 1)
            {
                cbDiabetes.Checked = true;
            }
            else
            {
                cbDiabetes.Checked = false;
            }

            if (JointReplacement == 1)
            {
                cbJointReplacement.Checked = true;
            }
            else
            {
                cbJointReplacement.Checked = false;
            }

            if (HighLowBloodPressure == 1)
            {
                cbBloodPressure1.Checked = true;
            }
            else
            {
                cbBloodPressure1.Checked = false;
            }

            if (Neuropathy == 1)
            {
                cbNeuropathy1.Checked = true;
            }
            else
            {
                cbNeuropathy1.Checked = false;
            }

            if (Fibromyalgia == 1)
            {
                cbFibromyalgia.Checked = true;
            }
            else
            {
                cbFibromyalgia.Checked = false;
            }

            if (Stroke == 1)
            {
                cbStroke.Checked = true;
            }
            else
            {
                cbStroke.Checked = false;
            }

            if (HeartAttack == 1)
            {
                cbHeartAttack.Checked = true;
            }
            else
            {
                cbHeartAttack.Checked = false;
            }
            if (KidneyDysfunction == 1)
            {
                cbKidneyDysfunction.Checked = true;
            }
            else
            {
                cbKidneyDysfunction.Checked = false;
            }
            if (BloodClots == 1)
            {
                cbBloodClots.Checked = true;
            }
            else
            {
                cbBloodClots.Checked = false;
            }
            if (Numbness == 1)
            {
                cbNumbness1.Checked = true;
            }
            else
            {
                cbNumbness1.Checked = false;
            }
            if (SprainsStrains == 1)
            {
                cbSprainOrStrains1.Checked = true;
            }
            else
            {
                cbSprainOrStrains1.Checked = false;
            }

        }


    }
}
