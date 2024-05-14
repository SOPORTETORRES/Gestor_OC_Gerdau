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
    public partial class Frm_WB_Php : Form
    {
        public Frm_WB_Php()
        {
            InitializeComponent();
        }


        public void CargaTicket()
        {
            string Url = "http://localhost/AZA/ObtenerDatos.php";
            Uri lURl = new Uri(Url);
            Wb.Url = lURl;
            // mTicket = iTicket;
            Wb.ScriptErrorsSuppressed = true;
            Wb.Navigate(lURl);
        }

        private void Frm_WB_Php_Load(object sender, EventArgs e)
        {
            CargaTicket();
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string lError = "";   int lInicio = 0; 
           
            //HtmlDocument doc = this.WB.Document;
            //doc.GetElementById("tickerLookUp").SetAttribute("Value", "Gec");
            //if (mTbl.Rows.Count == 0)
            //{
            try
            {
                Boolean lProcesado = false;
                HtmlElementCollection classButton = Wb.Document.All;
                foreach (HtmlElement element in classButton)
                {
                    if (lProcesado == false)
                    {
                        List<Char> lLista = new List<char>();
                       // if ((element.InnerHtml != null) && (element.InnerHtml.ToString().IndexOf("http://www.idiem.cl/intranet/") > 0))
                            if ((element.InnerHtml != null) ) //&& (element.InnerHtml.ToString().IndexOf("http://localhost/") > 0))
                            {
                            // aqui se debe descargar los Docs.
                            lInicio = element.InnerHtml.ToString().IndexOf("Registro Grabado OK");
                            //lFin = element.InnerHtml.ToString().IndexOf("frameBorder=0></IFRAME>");
                            //lTx = element.InnerHtml.ToString().Substring(lInicio, (lFin - lInicio));
                            ////lInicio = lTx.IndexOf("rc=");

                            if (lInicio > -1)
                            {
                                lProcesado = true;
                                this.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                lError = exc.Message.ToString();
            }

            this.Close();
        }
    }
    

}
