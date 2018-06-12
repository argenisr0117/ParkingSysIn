using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParqueo.Controles
{
    public partial class textbox : TextBox
    {
        public textbox()
        {
            InitializeComponent();
        }
        public bool Validar
        {
            set;
            get;
        }
        public textbox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
