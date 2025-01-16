namespace Liste2CourseV2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            txtCourseName = new TextBox();
            dgvIngredient = new DataGridView();
            dgvCourses = new DataGridView();
            label3 = new Label();
            Ajouter = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIngredient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 77);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 4;
            label1.Text = "Liste d'ingrédients";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(588, 77);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 5;
            label2.Text = "Liste de courses";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(588, 112);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(100, 23);
            txtCourseName.TabIndex = 8;
            // 
            // dgvIngredient
            // 
            dgvIngredient.BackgroundColor = Color.Azure;
            dgvIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredient.Location = new Point(12, 140);
            dgvIngredient.Name = "dgvIngredient";
            dgvIngredient.RowTemplate.Height = 25;
            dgvIngredient.Size = new Size(312, 215);
            dgvIngredient.TabIndex = 9;
            // 
            // dgvCourses
            // 
            dgvCourses.BackgroundColor = Color.LightYellow;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(476, 141);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowTemplate.Height = 25;
            dgvCourses.Size = new Size(312, 215);
            dgvCourses.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(542, 115);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 11;
            label3.Text = "Nom :";
            // 
            // Ajouter
            // 
            Ajouter.Location = new Point(373, 192);
            Ajouter.Name = "Ajouter";
            Ajouter.Size = new Size(75, 23);
            Ajouter.TabIndex = 12;
            Ajouter.Text = "Ajouter";
            Ajouter.UseVisualStyleBackColor = true;
            Ajouter.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(373, 256);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Supprimer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(694, 112);
            button1.Name = "button1";
            button1.Size = new Size(26, 23);
            button1.TabIndex = 14;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(Ajouter);
            Controls.Add(label3);
            Controls.Add(dgvCourses);
            Controls.Add(dgvIngredient);
            Controls.Add(txtCourseName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dgvIngredient).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddIngredient_Click;
        private Button btnRemoveIngredient_Click;
        private Label label1;
        private Label label2;
        private TextBox txtCourseName;
        private DataGridView dgvIngredient;
        private DataGridView dgvCourses;
        private Label label3;
        private Button Ajouter;
        private Button button2;
        private Button button1;
    }
}