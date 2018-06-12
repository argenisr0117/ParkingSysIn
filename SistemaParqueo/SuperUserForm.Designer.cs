namespace SistemaParqueo
{
    partial class SuperUserForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.salir_btn = new System.Windows.Forms.Button();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.Usuario_txt = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.entrar_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "SUPER USER LOGIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "___________________________________________";
            // 
            // salir_btn
            // 
            this.salir_btn.BackColor = System.Drawing.SystemColors.Info;
            this.salir_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.salir_btn.FlatAppearance.BorderSize = 2;
            this.salir_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.salir_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir_btn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.salir_btn.Image = global::SistemaParqueo.Properties.Resources.exit;
            this.salir_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salir_btn.Location = new System.Drawing.Point(172, 188);
            this.salir_btn.Name = "salir_btn";
            this.salir_btn.Size = new System.Drawing.Size(72, 63);
            this.salir_btn.TabIndex = 21;
            this.salir_btn.Text = "SALIR";
            this.salir_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salir_btn.UseVisualStyleBackColor = false;
            this.salir_btn.Click += new System.EventHandler(this.salir_btn_Click);
            // 
            // Password_txt
            // 
            this.Password_txt.BackColor = System.Drawing.SystemColors.Info;
            this.Password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txt.Location = new System.Drawing.Point(78, 129);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(186, 24);
            this.Password_txt.TabIndex = 19;
            this.Password_txt.UseSystemPasswordChar = true;
            this.Password_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_txt_KeyDown);
            // 
            // Usuario_txt
            // 
            this.Usuario_txt.BackColor = System.Drawing.SystemColors.Info;
            this.Usuario_txt.Enabled = false;
            this.Usuario_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario_txt.Location = new System.Drawing.Point(78, 79);
            this.Usuario_txt.Multiline = true;
            this.Usuario_txt.Name = "Usuario_txt";
            this.Usuario_txt.Size = new System.Drawing.Size(186, 34);
            this.Usuario_txt.TabIndex = 18;
            this.Usuario_txt.Text = "Superuser";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaParqueo.Properties.Resources.key;
            this.pictureBox2.Location = new System.Drawing.Point(21, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaParqueo.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(21, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // entrar_btn
            // 
            this.entrar_btn.BackColor = System.Drawing.SystemColors.Info;
            this.entrar_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.entrar_btn.FlatAppearance.BorderSize = 2;
            this.entrar_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.entrar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entrar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrar_btn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.entrar_btn.Image = global::SistemaParqueo.Properties.Resources.forward;
            this.entrar_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.entrar_btn.Location = new System.Drawing.Point(41, 188);
            this.entrar_btn.Name = "entrar_btn";
            this.entrar_btn.Size = new System.Drawing.Size(72, 63);
            this.entrar_btn.TabIndex = 20;
            this.entrar_btn.Text = "ENTRAR";
            this.entrar_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.entrar_btn.UseVisualStyleBackColor = false;
            this.entrar_btn.Click += new System.EventHandler(this.entrar_btn_Click);
            // 
            // SuperUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.salir_btn);
            this.Controls.Add(this.entrar_btn);
            this.Controls.Add(this.Password_txt);
            this.Controls.Add(this.Usuario_txt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button salir_btn;
        private System.Windows.Forms.Button entrar_btn;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.TextBox Usuario_txt;
    }
}