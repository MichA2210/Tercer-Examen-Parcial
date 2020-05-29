namespace CursoCSharp_actividad3_WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Agregar = new System.Windows.Forms.Button();
            this.Borrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.TextBox();
            this.Apellido = new System.Windows.Forms.TextBox();
            this.Genero = new System.Windows.Forms.ComboBox();
            this.Modificar = new System.Windows.Forms.Button();
            this.AlumnosExistentes = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Materias = new System.Windows.Forms.ListBox();
            this.AgregarMateria = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Carrera = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(15, 493);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(75, 23);
            this.Agregar.TabIndex = 0;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Borrar
            // 
            this.Borrar.Location = new System.Drawing.Point(281, 493);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(75, 23);
            this.Borrar.TabIndex = 1;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseVisualStyleBackColor = true;
            this.Borrar.Click += new System.EventHandler(this.Borrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(75, 43);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Matricula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Genero";
            // 
            // Matricula
            // 
            this.Matricula.Location = new System.Drawing.Point(75, 6);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(100, 20);
            this.Matricula.TabIndex = 7;
            // 
            // Apellido
            // 
            this.Apellido.Location = new System.Drawing.Point(75, 83);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(100, 20);
            this.Apellido.TabIndex = 8;
            // 
            // Genero
            // 
            this.Genero.FormattingEnabled = true;
            this.Genero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.Genero.Location = new System.Drawing.Point(75, 123);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(121, 21);
            this.Genero.TabIndex = 9;
            this.Genero.Text = "Masculino";
            this.Genero.SelectedIndexChanged += new System.EventHandler(this.Genero_SelectedIndexChanged);
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(362, 493);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(75, 23);
            this.Modificar.TabIndex = 10;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // AlumnosExistentes
            // 
            this.AlumnosExistentes.FormattingEnabled = true;
            this.AlumnosExistentes.Location = new System.Drawing.Point(281, 26);
            this.AlumnosExistentes.Name = "AlumnosExistentes";
            this.AlumnosExistentes.Size = new System.Drawing.Size(234, 446);
            this.AlumnosExistentes.TabIndex = 19;
            this.AlumnosExistentes.DoubleClick += new System.EventHandler(this.AlumnosExistentes_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "AlumnosExistentes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Materias";
            // 
            // Materias
            // 
            this.Materias.FormattingEnabled = true;
            this.Materias.Location = new System.Drawing.Point(15, 303);
            this.Materias.Name = "Materias";
            this.Materias.Size = new System.Drawing.Size(160, 134);
            this.Materias.TabIndex = 23;
            this.Materias.DoubleClick += new System.EventHandler(this.Materias_DoubleClick);
            // 
            // AgregarMateria
            // 
            this.AgregarMateria.Location = new System.Drawing.Point(15, 443);
            this.AgregarMateria.Name = "AgregarMateria";
            this.AgregarMateria.Size = new System.Drawing.Size(100, 20);
            this.AgregarMateria.TabIndex = 24;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(121, 443);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(54, 23);
            this.btn1.TabIndex = 25;
            this.btn1.Text = "+";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Doble click para borrar materia";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 234);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Fecha de Nacimiento";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Carrera";
            // 
            // Carrera
            // 
            this.Carrera.Location = new System.Drawing.Point(75, 171);
            this.Carrera.Name = "Carrera";
            this.Carrera.Size = new System.Drawing.Size(100, 20);
            this.Carrera.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 522);
            this.Controls.Add(this.Carrera);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.AgregarMateria);
            this.Controls.Add(this.Materias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AlumnosExistentes);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Genero);
            this.Controls.Add(this.Apellido);
            this.Controls.Add(this.Matricula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.Agregar);
            this.Name = "Form1";
            this.Text = "Alumnos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Borrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Matricula;
        private System.Windows.Forms.TextBox Apellido;
        private System.Windows.Forms.ComboBox Genero;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.ListBox AlumnosExistentes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox Materias;
        private System.Windows.Forms.TextBox AgregarMateria;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Carrera;
    }
}

