using SistemaParqueo.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParqueo
{
    class Utilidades
    {
        public static bool ValidarForm(System.Windows.Forms.Control objForm, System.Windows.Forms.ErrorProvider error)
        {
            bool valor = true;
            foreach (System.Windows.Forms.Control obj in objForm.Controls)
            {
                //if (obj.Controls.Count > 0)
                //{
                //    valor = ValidarForm2(obj, error);
                //    continue;
                //}

                if (obj is Controles.textbox)
                {
                    textbox obj2 = (textbox)obj;
                    if (obj2.Validar)
                    {
                        if (string.IsNullOrEmpty(obj2.Text.Trim()))
                        {
                            valor = false;

                            error.SetError(obj, (string.IsNullOrEmpty(obj2.Text.Trim())) ? "Campo obligatorio" : "");
                        }
                    }
                }
            }
            return valor;
        }
        public static bool ValidarForm2(System.Windows.Forms.Control objForm, System.Windows.Forms.ErrorProvider error)
        {
            bool valor = true;
            foreach (System.Windows.Forms.Control obj in objForm.Controls)
            {
                if (obj.Controls.Count > 0)
                {
                    valor = ValidarForm2(obj, error);
                    continue;
                }

                if (obj is textbox)
                {
                    textbox obj2 = (textbox)obj;
                    if (obj2.Validar)
                    {
                        if (string.IsNullOrEmpty(obj2.Text.Trim()))
                        {
                            valor = false;

                            error.SetError(obj, (string.IsNullOrEmpty(obj2.Text.Trim())) ? "Campo obligatorio" : "");
                        }
                    }
                }
            }
            return valor;
        }
    }
}
