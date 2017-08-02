namespace SistemaParqueo
{
    partial class ScreenMonitorForm
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
            this.screenMonitor_timer = new System.Windows.Forms.Timer(this.components);
            this.MonitorTextToShow_lbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirTicketManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusDispositivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updateStatusOnDb_timer = new System.Windows.Forms.Timer(this.components);
            this.pulsoAbrirBrazo_timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // screenMonitor_timer
            // 
            this.screenMonitor_timer.Interval = 200;
            this.screenMonitor_timer.Tick += new System.EventHandler(this.screenMonitor_timer_Tick);
            // 
            // MonitorTextToShow_lbl
            // 
            this.MonitorTextToShow_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorTextToShow_lbl.AutoSize = true;
            this.MonitorTextToShow_lbl.BackColor = System.Drawing.Color.Transparent;
            this.MonitorTextToShow_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorTextToShow_lbl.ForeColor = System.Drawing.Color.White;
            this.MonitorTextToShow_lbl.Location = new System.Drawing.Point(85, 132);
            this.MonitorTextToShow_lbl.Name = "MonitorTextToShow_lbl";
            this.MonitorTextToShow_lbl.Size = new System.Drawing.Size(133, 31);
            this.MonitorTextToShow_lbl.TabIndex = 0;
            this.MonitorTextToShow_lbl.Text = "test label";
            this.MonitorTextToShow_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirTicketManualToolStripMenuItem,
            this.statusDispositivosToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menúToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menúToolStripMenuItem.Image = global::SistemaParqueo.Properties.Resources.menu;
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.menúToolStripMenuItem.Text = "MENÚ";
            // 
            // imprimirTicketManualToolStripMenuItem
            // 
            this.imprimirTicketManualToolStripMenuItem.Name = "imprimirTicketManualToolStripMenuItem";
            this.imprimirTicketManualToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.imprimirTicketManualToolStripMenuItem.Text = "Imprimir Ticket Manual";
            this.imprimirTicketManualToolStripMenuItem.Click += new System.EventHandler(this.imprimirTicketManualToolStripMenuItem_Click);
            // 
            // statusDispositivosToolStripMenuItem
            // 
            this.statusDispositivosToolStripMenuItem.Name = "statusDispositivosToolStripMenuItem";
            this.statusDispositivosToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.statusDispositivosToolStripMenuItem.Text = "STATUS DISPOSITIVOS ENTRADA";
            this.statusDispositivosToolStripMenuItem.Click += new System.EventHandler(this.statusDispositivosToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Image = global::SistemaParqueo.Properties.Resources.configure;
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.configuraciónToolStripMenuItem.Text = "CONFIGURACIÓN";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::SistemaParqueo.Properties.Resources.exit;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.salirToolStripMenuItem.Text = "SALIR";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-5, 253);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 10);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // updateStatusOnDb_timer
            // 
            this.updateStatusOnDb_timer.Interval = 500;
            this.updateStatusOnDb_timer.Tick += new System.EventHandler(this.updateStatusOnDb_timer_Tick);
            // 
            // pulsoAbrirBrazo_timer
            // 
            this.pulsoAbrirBrazo_timer.Interval = 500;
            this.pulsoAbrirBrazo_timer.Tick += new System.EventHandler(this.pulsoAbrirBrazo_timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScreenMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SistemaParqueo.Properties.Resources.dark_1867089_640;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(445, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MonitorTextToShow_lbl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenMonitorForm";
            this.Load += new System.EventHandler(this.ScreenMonitorForm_Load);
            this.Click += new System.EventHandler(this.ScreenMonitorForm_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer screenMonitor_timer;
        private System.Windows.Forms.Label MonitorTextToShow_lbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusDispositivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem imprimirTicketManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Timer updateStatusOnDb_timer;
        private System.Windows.Forms.Timer pulsoAbrirBrazo_timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}