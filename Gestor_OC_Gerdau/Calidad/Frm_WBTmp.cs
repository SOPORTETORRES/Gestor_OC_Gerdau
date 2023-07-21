using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_WBTmp : Form
    {
        WebClient wc = new WebClient();
        public Frm_WBTmp()
        {
            InitializeComponent();
        }

        private void Frm_WBTmp_Load(object sender, EventArgs e)
        {

        }

        public  void CargaUrl(string iurl)
        {
            //Wb = new WebBrowser();
            //Wb.Navigate(iurl);

            //Uri lURl = new Uri(iurl);
            //Wb.Url = lURl;
            //// mTicket = iTicket;
            //Wb.ScriptErrorsSuppressed = true;
            //Wb.Navigate(lURl);

        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri lUrl = new Uri(Tx_url.Text);
            wc.DownloadFileAsync(lUrl, "Archivo1.pdf");
        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Descarga completetada");
        }
    }
}
