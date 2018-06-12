using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParqueo
{
    public partial class SuperUserForm : Form
    {
        public SuperUserForm()
        {
            InitializeComponent();
        }

        private void entrar_btn_Click(object sender, EventArgs e)
        {
            SuperUserLogin();
        }

        private void salir_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SuperUserLogin();
            }
        }

        public void SuperUserLogin()
        {
            if (Password_txt.Text == Program.SuperUserPass)
            {
                this.Hide();
                ConfiguracionSistemaForm form = new ConfiguracionSistemaForm();
                form.Show();
            }
            else
            {
                MessageBox.Show("Acceso negado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
