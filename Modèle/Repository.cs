using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste2CourseV2.Modèle
{
    public class Repository
    {
        private readonly SingletonDB dbManager;

        public Repository(SingletonDB dbManager)
        {
            this.dbManager = dbManager;
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string query = "SELECT ingredient.id_ingredient, ingredient.nom_ingredient, ingredient.id_type, type_ingredient.nom_type FROM ingredient INNER JOIN type_ingredient on type_ingredient.id_type = ingredient.id_type;";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Type_Ingredient type = new Type_Ingredient(reader.GetInt32(2), reader.GetString("nom_ingredient"));
                        Ingredient ingredient = new Ingredient(reader.GetInt32("id_ingredient"), reader.GetString("nom_ingredient"), type);
                        ingredients.Add(ingredient);
                    }
                connection.Close();
            }

            return ingredients;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT id_course, nom_course FROM course;";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Course course = new Course(reader.GetInt32("id_course"), reader.GetString("nom_course"));
                        courses.Add(course);
                    }
            }

            return courses;
        }

        public List<Ingredient> GetAllIngredientsFromCourse(int idCourse)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string query = "SELECT faire.id_ingredient, ingredient.nom_ingredient, type_ingredient.nom_type, type_ingredient.id_type, faire.quantite " +
                "faire.id_course, faire.dateDuJour FROM faire " +
                "INNER JOIN course ON faire.id_course = course.id_course INNER JOIN ingredient ON faire.id_ingredient = ingredient.id_ingredient " +
                "INNER JOIN type_ingredient ON ingredient.id_type = type_ingredient.id_type " +
                "WHERE faire.id_course = @id_course";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_course", idCourse);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Type_Ingredient type = new Type_Ingredient(reader.GetInt32(3), reader.GetString(2));
                    Faire faire = new Faire(reader.GetInt32(5), reader.GetInt32(0), reader.GetDateTime(6), reader.GetInt32(4));
                    Ingredient ingredient = new Ingredient(reader.GetInt32(0), reader.GetString(1), type, faire);
                    ingredients.Add(ingredient);
                }
                connection.Close();
            }

            return ingredients;
        }

        public int CreateCourse(string courseName)
        {
            string query = "INSERT INTO course (nom_course) VALUES (@nom_course); SELECT LAST_INSERT_ID();";

            using (MySqlConnection connection = dbManager.GetDBConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nom_course", courseName);
                    int courseId = Convert.ToInt32(command.ExecuteScalar());
                    return courseId;
            }
        }

        public void AddIngredientToCourse(int ingredientId, int courseId)
        {
            string query = "INSERT INTO faire (dateDuJour, id_course, id_ingredient) VALUES (NOW(), @id_course, @id_ingredient);";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_course", courseId);
                    command.Parameters.AddWithValue("@id_ingredient", ingredientId);
                    command.ExecuteNonQuery();
            }
        }

        public void RemoveIngredientFromCourse(int ingredientId, int courseId)
        {
            string query = "DELETE FROM faire WHERE id_course = @id_course AND id_ingredient = @id_ingredient;";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_course", courseId);
                    command.Parameters.AddWithValue("@id_ingredient", ingredientId);
                    command.ExecuteNonQuery();
            }
        }

        public void IncreaseQuantity(int ingredientId, int courseId)
        {
            string query = "UPDATE faire SET quantite = quantite + 1 WHERE faire.id_course = @id_course AND id_ingredient = @id_ingredient";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_course", courseId);
                command.Parameters.AddWithValue("@id_ingredient", ingredientId);
                command.ExecuteNonQuery();
            }
        }

        public void DecreaseQuantity(int ingredientId, int courseId)
        {
            string query = "UPDATE faire SET quantite = quantite - 1 WHERE faire.id_course = @id_course AND id_ingredient = @id_ingredient";

            using (MySqlConnection connection = new MySqlConnection("server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_course", courseId);
                command.Parameters.AddWithValue("@id_ingredient", ingredientId);
                command.ExecuteNonQuery();
            }
        }
    }
}
