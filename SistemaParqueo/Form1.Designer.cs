namespace SistemaParqueo
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printerStatus_pic = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.estadoPapel_pic = new System.Windows.Forms.PictureBox();
            this.printerOnline_pic = new System.Windows.Forms.PictureBox();
            this.adamLectura_pic = new System.Windows.Forms.PictureBox();
            this.adamOnline_pic = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip_info = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printerAdamStatusRead_timer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.PulsoAbrirBrazoEntrada_timer = new System.Windows.Forms.Timer(this.components);
            this.iMPRESIÓNMANUALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printerStatus_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoPapel_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printerOnline_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamLectura_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamOnline_pic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.printerStatus_pic);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.estadoPapel_pic);
            this.panel1.Controls.Add(this.printerOnline_pic);
            this.panel1.Controls.Add(this.adamLectura_pic);
            this.panel1.Controls.Add(this.adamOnline_pic);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 317);
            this.panel1.TabIndex = 0;
            // 
            // printerStatus_pic
            // 
            this.printerStatus_pic.Image = global::SistemaParqueo.Properties.Resources.circle_error;
            this.printerStatus_pic.Location = new System.Drawing.Point(21, 208);
            this.printerStatus_pic.Name = "printerStatus_pic";
            this.printerStatus_pic.Size = new System.Drawing.Size(35, 35);
            this.printerStatus_pic.TabIndex = 10;
            this.printerStatus_pic.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Location = new System.Drawing.Point(67, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "PRINTER STATUS";
            // 
            // estadoPapel_pic
            // 
            this.estadoPapel_pic.Image = global::SistemaParqueo.Properties.Resources.circle_error;
            this.estadoPapel_pic.Location = new System.Drawing.Point(21, 259);
            this.estadoPapel_pic.Name = "estadoPapel_pic";
            this.estadoPapel_pic.Size = new System.Drawing.Size(35, 35);
            this.estadoPapel_pic.TabIndex = 8;
            this.estadoPapel_pic.TabStop = false;
            // 
            // printerOnline_pic
            // 
            this.printerOnline_pic.Image = global::SistemaParqueo.Properties.Resources.circle_error;
            this.printerOnline_pic.Location = new System.Drawing.Point(21, 151);
            this.printerOnline_pic.Name = "printerOnline_pic";
            this.printerOnline_pic.Size = new System.Drawing.Size(35, 35);
            this.printerOnline_pic.TabIndex = 7;
            this.printerOnline_pic.TabStop = false;
            // 
            // adamLectura_pic
            // 
            this.adamLectura_pic.Image = global::SistemaParqueo.Properties.Resources.circle_error;
            this.adamLectura_pic.Location = new System.Drawing.Point(21, 99);
            this.adamLectura_pic.Name = "adamLectura_pic";
            this.adamLectura_pic.Size = new System.Drawing.Size(35, 35);
            this.adamLectura_pic.TabIndex = 6;
            this.adamLectura_pic.TabStop = false;
            // 
            // adamOnline_pic
            // 
            this.adamOnline_pic.Image = global::SistemaParqueo.Properties.Resources.circle_error;
            this.adamOnline_pic.Location = new System.Drawing.Point(21, 48);
            this.adamOnline_pic.Name = "adamOnline_pic";
            this.adamOnline_pic.Size = new System.Drawing.Size(35, 35);
            this.adamOnline_pic.TabIndex = 5;
            this.adamOnline_pic.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(63, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ESTADO PAPEL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Location = new System.Drawing.Point(63, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "PRINTER CONEXION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ADAM LECTURA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ADAM STATUS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTATUS DISPOSITIVOS";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.iMPRESIÓNMANUALToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menúToolStripMenuItem.Text = "MENÚ";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.configuraciónToolStripMenuItem.Text = "CONFIGURACIÓN";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // printerAdamStatusRead_timer
            // 
            this.printerAdamStatusRead_timer.Interval = 300;
            this.printerAdamStatusRead_timer.Tick += new System.EventHandler(this.printerAdamStatusRead_timer_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(310, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 317);
            this.panel2.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            // 
            // PulsoAbrirBrazoEntrada_timer
            // 
            this.PulsoAbrirBrazoEntrada_timer.Interval = 200;
            this.PulsoAbrirBrazoEntrada_timer.Tick += new System.EventHandler(this.PulsoAbrirBrazoEntrada_timer_Tick);
            // 
            // iMPRESIÓNMANUALToolStripMenuItem
            // 
            this.iMPRESIÓNMANUALToolStripMenuItem.Name = "iMPRESIÓNMANUALToolStripMenuItem";
            this.iMPRESIÓNMANUALToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.iMPRESIÓNMANUALToolStripMenuItem.Text = "IMPRESIÓN MANUAL";
            this.iMPRESIÓNMANUALToolStripMenuItem.Click += new System.EventHandler(this.iMPRESIÓNMANUALToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 363);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 23);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 396);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ESTACION ENTRADA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printerStatus_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoPapel_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printerOnline_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamLectura_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamOnline_pic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox adamOnline_pic;
        private System.Windows.Forms.PictureBox adamLectura_pic;
        private System.Windows.Forms.ToolTip toolTip_info;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox printerStatus_pic;
        private System.Windows.Forms.PictureBox estadoPapel_pic;
        private System.Windows.Forms.PictureBox printerOnline_pic;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Timer printerAdamStatusRead_timer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer PulsoAbrirBrazoEntrada_timer;
        private System.Windows.Forms.ToolStripMenuItem iMPRESIÓNMANUALToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

