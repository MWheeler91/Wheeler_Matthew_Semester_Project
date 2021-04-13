using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wheeler_Matthew_Semester_Project
{
    public class ClientInformation
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomePage());
        }

        //Client Information
        //Client Information
        public int Client_ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        // Need to update data type for this in SQL server
        public string LastName { get; set; }
        //public string PhoneNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Employer { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhone { get; set; }
        public MedicalInformation MedicalInfo { get; set; }
        public ClientInformation(string firstname, string middleinitial, string lastname, string phone, string email, string address, string city, string state, string zip, string dateofbirth, string occupation, string employer,
        string emergencycontact, string emergencycontactrelationship, string emergencycontactphone, MedicalInformation clientMedicainfo)
        {
            this.FirstName = firstname;
            this.MiddleInitial = middleinitial;
            this.LastName = lastname;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.DateOfBirth = dateofbirth;
            this.Occupation = occupation;
            this.Employer = employer;
            this.EmergencyContact = emergencycontact;
            this.EmergencyContactRelationship = emergencycontactrelationship;
            this.EmergencyContactPhone = emergencycontactphone;
            this.MedicalInfo = clientMedicainfo;
        }

    }

}
