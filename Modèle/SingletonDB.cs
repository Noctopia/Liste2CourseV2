using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Liste2CourseV2.Modèle
{
    public class SingletonDB
    {
        private static SingletonDB instance = null;
        private static readonly string connectionString = "server=localhost;Port=3306; database=Liste2Courses;uid=root;pwd=\"\";";
        private MySqlConnection connection;

        // Constructeur privé
        private SingletonDB()
        {
            connection = new MySqlConnection(connectionString);
        }

        // Méthode pour récupérer l'instance unique
        public static SingletonDB GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonDB();
            }
            return instance;
        }

        // Méthode pour obtenir la connexion à la base de données
        public MySqlConnection GetDBConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        }

        // Méthode pour fermer explicitement la connexion
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
