using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_WB_Ver : Form
    {
        public Frm_WB_Ver()
        {
            InitializeComponent();
        }



        public void CargaTicket(string iLote)
        {
            string Url = string.Concat ("http://localhost/AZA/DatosColadaPorLote.php?lote=",iLote);
            Uri lURl = new Uri(Url);
            Wb.Url = lURl;
            // mTicket = iTicket;
            Wb.ScriptErrorsSuppressed = true;
            Wb.Navigate(lURl);
        }



    }
}
