using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheeler_Matthew_Semester_Project
{
    public class MedicalInformation
    {

        //medical info
        public int Client_ID { get; set; }
        public string CurrentMedication { get; set; }
        public int ChronicPain { get; set; }
        public string ChronicPainWhere { get; set; }
        public int OrthopedicPain { get; set; }
        public string OrthopedicPainWhere { get; set; }
        public int Pregnant { get; set; }
        public int PeferredPressureLight { get; set; }
        public int PeferredPressureMedium { get; set; }
        public int PeferredPressureDeep { get; set; }
        public int Allergies { get; set; }
        public string AllergiesWhat { get; set; }
        public int Cancer { get; set; }
        public int HeadacheMigraine { get; set; }
        public int Arthritis { get; set; }
        public int Diabetes { get; set; }
        public int JointReplacement { get; set; }
        public int HighLowBloodPressure { get; set; }
        public int Neuropathy { get; set; }
        public int Fibromyalgia { get; set; }
        public int Stroke { get; set; }
        public int HeartAttack { get; set; }
        public int KidneyDysfunction { get; set; }
        public int BloodClots { get; set; }
        public int Numbness { get; set; }
        public int SprainsStrains { get; set; }
        public string AreasOfDiscomfort { get; set; }

        public MedicalInformation(string currentmedication, int chronicpain, string chronicpainwhere, int orthopedicpain, string orthopedicpainwhere, int pregnant, int preferredpressurelight, int preferredpressuremedium, int preferredpressuredeep,
            int allergies, string allergieswhat, int cancer, int headachemigraine, int arthritis, int diabetes, int jointreplacement, int highlowbloodpressure, int neuropathy, int fibromayalgia, int stroke, int heartattack, int kidneydysfunction,
            int bloodclots, int numbness, int sprainsstrains, string areasofdiscmfort)
        {
            this.CurrentMedication = currentmedication;
            this.ChronicPain = chronicpain;
            this.ChronicPainWhere = chronicpainwhere;
            this.OrthopedicPain = orthopedicpain;
            this.OrthopedicPainWhere = orthopedicpainwhere;
            this.Pregnant = pregnant;
            this.PeferredPressureLight = preferredpressurelight;
            this.PeferredPressureMedium = preferredpressuremedium;
            this.PeferredPressureDeep = preferredpressuredeep;
            this.Allergies = allergies;
            this.AllergiesWhat = allergieswhat;
            this.Cancer = cancer;
            this.HeadacheMigraine = headachemigraine;
            this.Arthritis = arthritis;
            this.Diabetes = diabetes;
            this.JointReplacement = jointreplacement;
            this.HighLowBloodPressure = highlowbloodpressure;
            this.Neuropathy = neuropathy;
            this.Fibromyalgia = fibromayalgia;
            this.Stroke = stroke;
            this.HeartAttack = heartattack;
            this.KidneyDysfunction = kidneydysfunction;
            this.BloodClots = bloodclots;
            this.Numbness = numbness;
            this.SprainsStrains = sprainsstrains;
            this.AreasOfDiscomfort = areasofdiscmfort;
        }
    }
}
