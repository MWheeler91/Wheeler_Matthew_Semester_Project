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
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewClient_Load(object sender, EventArgs e)
        {
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            HomePage HomePage = new HomePage();
            HomePage.Show();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            NewClient newClient = new NewClient();
            newClient.Show();
        }

        private void clientLookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            LookUpClient lookUpClient = new LookUpClient();
            lookUpClient.Show();
        }

        private void txtEmergencyContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmergencyContactRelationship_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            int outputValue = 0;
            bool isNumber = false;
            isNumber = int.TryParse(txtZip.Text, out outputValue);
            try
            {
                if (String.IsNullOrEmpty(txtFirstName.Text))
                {
                    errorMsg += "First name field cannnot be empty!\n";
                }
                if (String.IsNullOrEmpty(txtLastName.Text))
                {
                    errorMsg += "Last name field cannnot be empty!\n";
                }
                if (String.IsNullOrEmpty(txtPhone.Text))
                {
                    errorMsg += "Phone field cannnot be empty\n";
                }
                if (String.IsNullOrEmpty(txtEmail.Text))
                {
                    errorMsg += "Email field cannnot be empty\n";
                }
                if (!String.IsNullOrEmpty(txtZip.Text) && !isNumber)
                {
                    //MessageBox.Show("Zip code must be a number");
                    errorMsg += "Zip code must be a number\n";
                }
                if (!String.IsNullOrEmpty(txtZip.Text) && txtZip.Text.Length != 5 && txtZip.Text.Length != 0)
                {
                    //MessageBox.Show("Zip code must be 5 digits long");
                    errorMsg += "Zip code must be 5 digits long\n";
                }
                if (errorMsg != "")
                {
                    MessageBox.Show(errorMsg);
                }
                else
                {
                    MedicalInformation clientmed = new MedicalInformation(txtCurrentMedications.Text,
                        Convert.ToInt32(cbChronicPainYes.Checked),
                        txtChronicPain.Text,
                        Convert.ToInt32(cbOrthopedicPainYes.Checked),
                        txtOrthopedicPain.Text,
                        Convert.ToInt32(cbPregnant.Checked),
                        Convert.ToInt32(cbPreferredPressureLight.Checked),
                        Convert.ToInt32(cbPreferredPressureMedium.Checked),
                        Convert.ToInt32(cbPreferredPressureDeep.Checked),
                        Convert.ToInt32(cbAllergiesYes.Checked),
                        txtAllergies.Text,
                        Convert.ToInt32(cbCancer.Checked),
                        Convert.ToInt32(cbHeadacheMigraines.Checked),
                        Convert.ToInt32(cbArthritis.Checked),
                        Convert.ToInt32(cbDiabetes.Checked),
                        Convert.ToInt32(cbJointReplacement.Checked),
                        Convert.ToInt32(cbBloodPressure.Checked),
                        Convert.ToInt32(cbNeuropathy.Checked),
                        Convert.ToInt32(cbFibromyalgia.Checked),
                        Convert.ToInt32(cbStroke.Checked),
                        Convert.ToInt32(cbHeartAttack.Checked),
                        Convert.ToInt32(cbKidneyDysfunction.Checked),
                        Convert.ToInt32(cbBloodClots.Checked),
                        Convert.ToInt32(cbNumbness.Checked),
                        Convert.ToInt32(cbSprainOrStrains.Checked),
                        txtAreaOfDiscomfort.Text);

                    ClientInformation client = new ClientInformation(
                        txtFirstName.Text,
                        txtMiddleInitial.Text,
                        txtLastName.Text,
                        txtPhone.Text,
                        txtEmail.Text,
                        txtAddress.Text,
                        txtCity.Text,
                        txtState.Text,
                        txtZip.Text,
                        datetimeDob.Text,
                        txtOccupation.Text,
                        txtEmployer.Text,
                        txtEmergencyContact.Text,
                        txtEmergencyContactRelationship.Text,
                        txtEmergencyContactPhone.Text, clientmed);

                    // sends the objects to the SavePerson SQL write query
                    SQLiteDataAccess.SavePerson(clientmed, client);

                    MessageBox.Show("Client added");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Broke! Blame the Developer!");
            }




        }
    }
}
