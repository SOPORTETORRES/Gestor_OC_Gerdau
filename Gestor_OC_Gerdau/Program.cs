using Gestor_OC_Gerdau.Calidad;
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

            //Application.Run(new Frm_WBTmp());
            //Application.Run(new Frm_ppal());
            //Application.Run(new Pago.Frm_ActualizaArchivos_PDF());

            Application.Run(new Tools.Frm_CopiaDoc()); 

            Application.Run(new EnviosAutomaticos());
            //Application.Run(new Facturacion.Frm_VinculaGuiaFactura());
            Application.Run(new Calidad.Frm_ProcesoPorLote());
            Application.Run(new Calidad.Frm_RevisaColadas());
            

            // Application.Run(new Logistica.Frm_ProcesaGDE());
            //Application.Run(new Facturacion.Frm_RevisionSaldos());
            //Application.Run(new Calidad.Frm_SqlMysql());
            //Application.Run(new Calidad.Frm_WB());
             Application.Run(new FrmCambioPrecios());

            //Application.Run(new Frm_CreaMP());

            //     Application.Run(new Importar_NewCodigos());


            // Application.Run(new Produccion.Frm_IngresaDatos());

            //Application.Run(new Produccion.Frm_DescargarArchivos());

            //Application.Run(new Logistica.Frm_BodegaPT());
        }
    }
}
