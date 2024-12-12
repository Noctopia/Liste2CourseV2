using Liste2CourseV2.Modèle;
using Microsoft.VisualBasic.Devices;

namespace Liste2CourseV2
{
    public partial class Form1 : Form
    {
        private Repository repository;
        public Form1()
        {
            InitializeComponent();

            // Utilisation de SingletonDB pour la connexion
            SingletonDB dbManager = SingletonDB.GetInstance();
            repository = new Repository(dbManager);

            LoadIngredients();
            LoadCourses();
        }

        private void LoadIngredients()
        {
            // Récupère tous les ingrédients depuis le repository
            List<Ingredient> ingredients = repository.GetAllIngredients();
            dgvIngredient.Columns.Clear();
            dgvIngredient.Columns.Add("id", "Id");
            dgvIngredient.Columns.Add("nom", "Nom");
            dgvIngredient.Columns.Add("type", "Type");
            dgvIngredient.Columns[0].Visible = false;
            foreach (Ingredient ingredient in ingredients)
            {
                dgvIngredient.Rows.Add(ingredient.getId_ingredient(), ingredient.getNom_ingredient(), ingredient.getType().getNom_type());
            }
        }

        private void LoadCourses()
        {
            // Récupère toutes les courses depuis le repository
            List<Course> courses = repository.GetAllCourses();
            dgvCourses.DataSource = courses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvIngredient.SelectedRows.Count > 0 && !string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                // Récupère l'ID de l'ingrédient sélectionné
                DataGridViewRow selectedRow = dgvIngredient.SelectedRows[0];
                int ingredientId = (int)selectedRow.Cells["Id"].Value;

                // Récupère ou crée la course correspondante
                int courseId = GetOrCreateCourse(txtCourseName.Text);

                // Ajoute l'ingrédient à la course
                repository.AddIngredientToCourse(ingredientId, courseId);

                // Recharge les courses pour mettre à jour l'affichage
                LoadCourses();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                // Récupère l'ID de l'ingrédient et de la course depuis la ligne sélectionnée
                DataGridViewRow selectedRow = dgvCourses.SelectedRows[0];
                int ingredientId = (int)selectedRow.Cells["Id"].Value;
                int courseId = (int)selectedRow.Cells["CourseId"].Value;

                // Supprime l'ingrédient de la course
                repository.RemoveIngredientFromCourse(ingredientId, courseId);

                // Recharge les courses pour mettre à jour l'affichage
                LoadCourses();
            }

        }

        private int GetOrCreateCourse(string courseName)
        {
            // Récupère toutes les courses depuis le repository
            List<Course> courses = repository.GetAllCourses();

            // Cherche si une course avec le même nom existe déjà
            Course existingCourse = courses.Find(c => c.getNom_course().Equals(courseName));

            // Retourne l'ID de la course existante ou crée une nouvelle course si elle n'existe pas
            return existingCourse?.getCourse() ?? repository.CreateCourse(courseName);
        }
    }
}
