using Gestor_OC_Gerdau.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Frm_ppal());
            //Application.Run(new EnviosAutomaticos());
            //Application.Run(new Facturacion.Frm_VinculaGuiaFactura());
            Application.Run(new Calidad.Frm_RevisaColadas());
            //Application.Run(new Calidad.Frm_SqlMysql());
            //Application.Run(new Calidad.Frm_WB());
            //Application.Run(new FrmCambioPrecios());

            //Application.Run(new Frm_CreaMP());
        }
    }
}
