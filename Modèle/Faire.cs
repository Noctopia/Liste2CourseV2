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
        private int id_ingredient;
        private DateTime date;
        private int quantity;

        public Faire(int id_course, int id_ingredient, DateTime date, int quantity)
        {
            this.id_course = id_course;
            this.id_ingredient = id_ingredient;
            this.date = date;
            this.quantity = quantity;
        }

        public int getFaireCourse() { return id_course; }
        public int getIdingredient() {  return id_ingredient; }
        public DateTime getDate() { return date; }
        public int getQuantity() { return quantity; }
    }
}
