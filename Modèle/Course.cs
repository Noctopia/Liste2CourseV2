using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste2CourseV2.Modèle
{
    public class Course
    {
        private int id_course;
        private string nom_course;
        private List<Ingredient> ingredients;

        public Course(int id_course, string nom_course)
        {
            this.id_course = id_course;
            this.nom_course = nom_course;
        }

        public int getCourse() { return id_course; }
        public string getNom_course() { return nom_course; }
    }
}
