using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste2CourseV2.Modèle
{
    public class Type_Ingredient
    {
        private int id_type;
        private string nom_type;

        public Type_Ingredient(int id_type, string nom_type)
        {
            this.id_type = id_type;
            this.nom_type = nom_type;
        }

        public int getIdType() { return id_type; }
        public string getNom_type() { return nom_type; }
    }
}
