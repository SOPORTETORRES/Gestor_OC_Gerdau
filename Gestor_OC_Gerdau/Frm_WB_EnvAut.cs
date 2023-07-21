using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau
{
    public partial class Frm_WB_EnvAut : Form
    {
        public Frm_WB_EnvAut()
        {
            InitializeComponent();
        }

        public void CargaTicket()
        {
            string Url = "http://192.168.1.195:81/Frm_RevisaBloqueos.aspx";
            Uri lURl = new Uri(Url);
            Wb.Url = lURl;
            // mTicket = iTicket;
            Wb.ScriptErrorsSuppressed = true;
            Wb.Navigate(lURl);
        }

        private void Frm_WB_EnvAut_Load(object sender, EventArgs e)
        {
            CargaTicket();
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string lError = "";
            //String lTx = ""; int lInicio = 0; int lFin = 0;
            //string url = ""; string lPathFin = ""; string lNombreArc = "";
          
            try
            {
                Boolean lProcesado = false;
                HtmlElementCollection classButton = Wb.Document.All;
                foreach (HtmlElement element in classButton)
                {
                    if (lProcesado == false)
                    {
                        List<Char> lLista = new List<char>();
                        if ((element.InnerHtml != null) && (element.InnerHtml.ToString().IndexOf("Label1") > 0))
                        {
                            // aqui se debe descargar los Docs.
                          
                            lProcesado = true;
                            AppDomain.CurrentDomain.SetData("Res", "OK");
                            Thread.Sleep (3000);
                            this.Close();

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                lError = exc.Message.ToString();
            }
            //}

            //AppDomain.CurrentDomain.SetData("TblDatos", mTbl);
            //AppDomain.CurrentDomain.SetData("Ticket", mTicket);
            //AppDomain.CurrentDomain.SetData("Error", lError);
           
        }
    }
}
