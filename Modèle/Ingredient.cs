using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste2CourseV2.Modèle
{
    public class Ingredient
    {
        private int id_ingredient;
        private string nom_ingredient;
        private Type_Ingredient type;

        public Ingredient(int id_ingredient, string nom_ingredient, Type_Ingredient type)
        {
            this.id_ingredient = id_ingredient;
            this.nom_ingredient = nom_ingredient;
            this.type = type;
        }

        public int getId_ingredient() { return id_ingredient; }
        public string getNom_ingredient() { return nom_ingredient; }
        public Type_Ingredient getType() { return type; }
    }
}
