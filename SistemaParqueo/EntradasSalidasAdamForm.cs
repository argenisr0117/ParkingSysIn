using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech.Adam;

namespace SistemaParqueo
{
    public partial class EntradasSalidasAdamForm : Form
    {
        
        AdamDevice adam_func = new AdamDevice();

        public EntradasSalidasAdamForm()
        {
            InitializeComponent();
            
        }

        private void EntradasSalidasAdamForm_Load(object sender, EventArgs e)
        {
           
            timer1.Enabled = true;
            timer1_Tick(1, e);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
       
            if (Program.PushButton)
            {
                input1Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input1Adam_pic, "ON");
            }
            else
            {
                input1Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input1Adam_pic, "OFF");
            }

            if (Program.LoopTicketEntrada)
            {
                input2Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input2Adam_pic, "ON");
            }
            else
            {
                input2Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input2Adam_pic, "OFF");
            }

            if (Program.LoopBrazoEntrada)
            {
                input3Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input3Adam_pic, "ON");
            }
            else
            {
                input3Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input3Adam_pic, "OFF");
            }

            if (Program.AdamInput4)
            {
                input4Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input4Adam_pic, "ON");
            }
            else
            {
                input4Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input4Adam_pic, "OFF");
            }

            if (Program.AdamInput5)
            {
                input5Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input5Adam_pic, "ON");
            }
            else
            {
                input5Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input5Adam_pic, "OFF");
            }

            if (Program.AdamInput6)
            {
                input6Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(input6Adam_pic, "ON");
            }
            else
            {
                input6Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(input6Adam_pic, "OFF");
            }

            

            if (Program.AbrirBrazoEntrada)
            {
                output1Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output1Adam_pic, "ON");
            }
            else
            {
                output1Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output1Adam_pic, "OFF");
            }

            if (Program.AdamOutput2)
            {
                output2Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output2Adam_pic, "ON");
            }
            else
            {
                output2Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output2Adam_pic, "OFF");
            }

            if (Program.AdamOutput3)
            {
                output3Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output3Adam_pic, "ON");
            }
            else
            {
                output3Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output3Adam_pic, "OFF");
            }

            if (Program.AdamOutput4)
            {
                output4Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output4Adam_pic, "ON");
            }
            else
            {
                output4Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output4Adam_pic, "OFF");
            }

            if (Program.AdamOutput5)
            {
                output5Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output5Adam_pic, "ON");
            }
            else
            {
                output5Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output5Adam_pic, "OFF");
            }

            if (Program.AdamOutput6)
            {
                output6Adam_pic.Image = Properties.Resources.circle_ok;
                EntradaSalida_tooltip.SetToolTip(output6Adam_pic, "ON");
            }
            else
            {
                output6Adam_pic.Image = Properties.Resources.circle_error;
                EntradaSalida_tooltip.SetToolTip(output6Adam_pic, "OFF");
            }

            timer1.Enabled = true;
        }

        private void output1Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AbrirBrazoEntrada)
            {
                adam_func.AdamWrite(Program.adam6060, 17, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 17, true);
            }
        }

        private void output2Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AdamOutput2)
            {
                adam_func.AdamWrite(Program.adam6060, 18, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 18, true);
            }
        }

        private void output3Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AdamOutput3)
            {
                adam_func.AdamWrite(Program.adam6060, 19, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 19, true);
            }
        }

        private void output4Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AdamOutput4)
            {
                adam_func.AdamWrite(Program.adam6060, 20, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 20, true);
            }
        }

        private void output5Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AdamOutput5)
            {
                adam_func.AdamWrite(Program.adam6060, 21, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 21, true);
            }
        }

        private void output6Adam_pic_Click(object sender, EventArgs e)
        {
            if (Program.AdamOutput6)
            {
                adam_func.AdamWrite(Program.adam6060, 22, false);
            }
            else
            {
                adam_func.AdamWrite(Program.adam6060, 22, true);
            }
        }

       
    }
}
