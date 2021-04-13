using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheeler_Matthew_Semester_Project
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public PersonModel(string fullname)
        {
            this.FullName = fullname; 
            //this.Id = Client_Id;
        }
        public override string ToString()
        {
            String objectdDesc = string.Format("{0}", FullName);
            return objectdDesc;
        }
    }
}

