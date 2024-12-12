using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste2CourseV2.Modèle
{
    public class Faire
    {
        private int id_course;
        private string date;

        public Faire(int id_course, int id_ingredient, string date)
        {
            this.id_course = id_course;
            this.date = date;
        }

        public int getFaireCourse() { return id_course; }
        public string getDate() { return date; }
    }
}
