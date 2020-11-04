using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_WB : Form
    {
        private string mLote = "";
        private string mTipo = "";
        private string mUrl = "";
        public Frm_WB()
        {
            InitializeComponent();
        }

        public void IniciaForm(string iLote, string iTipo, string iUrl)
        {
            mLote = iLote;
            mTipo = iTipo;
            mUrl = iUrl;
        }

        private void Frm_WB_Load(object sender, EventArgs e)
        {


            CargaTicket( );
        }

        public void CargaTicket( )
        {
            string Url = mUrl;
            Uri lURl = new Uri(Url);
            Wb.Url = lURl;
            // mTicket = iTicket;
            Wb.ScriptErrorsSuppressed = true;
            Wb.Navigate(lURl);
        }

        private string LimpiaTx(string iTx)
        {
            string lres = "";
            string[] lPartes = (iTx.Split(new Char[] { '"' }));
            if (lPartes.Length > 0)
            {
                lres = lPartes[1];
            }


            return lres;
        }
        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string lError = "";String lTx = "";int lInicio = 0;  int lFin = 0;
            string url = ""; string lPathFin = ""; string lNombreArc = "";
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
                            if  ((element.InnerHtml!=null) &&   (element.InnerHtml.ToString ().IndexOf ("http://www.idiem.cl/intranet/")>0))
                            {
                            // aqui se debe descargar los Docs.
                            lInicio = element.InnerHtml.ToString().IndexOf("<DIV class=download__pdf><IFRAME src=");
                            lFin  = element.InnerHtml.ToString().IndexOf("frameBorder=0></IFRAME>");
                            lTx = element.InnerHtml.ToString().Substring(lInicio, (lFin-lInicio ));
                            lInicio = lTx.IndexOf("rc=");
                            lTx = LimpiaTx(lTx.Substring(lInicio, lTx.Length-lInicio ));
                            //Se de
                             url = lTx;
                            //lPathFin = @"c:\Temp\mypdf2.pdf";
                            if (mTipo == "C")
                                lNombreArc = string.Concat(mLote, "_C.pdf");

                            if (mTipo == "I")
                                lNombreArc = string.Concat(mLote, "_I.pdf");

                            lPathFin = System.IO.Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                            WebClient cliente = new WebClient();
                            //cliente.DownloadFile(url, @"c:\Temp\mypdf.pdf");
                            cliente.DownloadFile(url, lPathFin);

                            lProcesado = true;

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
            this.Close();
        }
    }
}
