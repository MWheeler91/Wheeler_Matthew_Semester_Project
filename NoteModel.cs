using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheeler_Matthew_Semester_Project
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public string Date { get; set; }

        public NoteModel(string date)
        {
            this.Date = date;
        }
        public NoteModel()
        {

        }
        public override string ToString()
        {

            String objectdDesc = string.Format("{0}", Date);
            return objectdDesc;
        }
    }
}
