using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Pago
{
    public partial class Frm_ActualizaArchivos_PDF : Form
    {
        public Frm_ActualizaArchivos_PDF()
        {
            InitializeComponent();
        }


        private void IniciaProceso_PDF()
        {
            
            string lPath_Origen = ConfigurationManager.AppSettings["PathOrigen_PDF"].ToString(); 
            string lPathDest = ConfigurationManager.AppSettings["PathDestino_PDF"].ToString();
            Boolean lCopiar = false; string lArchivo = ""; string iNombreArchivo = "";

            try
            {
                Tx_PathOrigen.Text = lPath_Origen.ToString();
                Tx_PathDestino .Text = lPathDest.ToString();
                DirectoryInfo lFolder = new DirectoryInfo(lPath_Origen);

                Lbl_Msg.Text = string.Concat("Cargando Datos Inciales");this.Refresh(); Lbl_Msg.Refresh(); 
                foreach (var fi in lFolder.GetFiles())
                {
                    lPath_Origen = ConfigurationManager.AppSettings["PathOrigen_PDF"].ToString();
                    lPathDest = ConfigurationManager.AppSettings["PathDestino_PDF"].ToString();
                    iNombreArchivo = fi.Name.ToString();
                    lPathDest = Path.Combine(lPathDest, iNombreArchivo);
                    if (File.Exists(lPathDest) == false)
                    {
                        Lbl_Msg.Text = string.Concat("Procesando Archivo: ", iNombreArchivo ); this.Refresh(); Lbl_Msg.Refresh();

                        lPathDest = ConfigurationManager.AppSettings["PathDestino_PDF"].ToString();
                        DirectoryInfo lFolderDest = new DirectoryInfo(lPathDest);
                        foreach (var fi_Dest in lFolderDest.GetFiles())
                        {
                            if ((fi_Dest.Name.ToString().IndexOf(iNombreArchivo) == -1)) // &&  (lCopiar == false))  // NO EXISTE
                            {
                                lCopiar = true;
                                lArchivo = iNombreArchivo.ToString();
                            }
                            //else
                            //    lCopiar = false;

                        }

                        if ((lCopiar == true) || (lFolderDest.GetFiles().Count() == 0))
                        {
                            if (lArchivo.Length == 0)
                                lArchivo = iNombreArchivo;


                            Lbl_Msg.Text = string.Concat("Copiando Archivo: ", lArchivo); this.Refresh(); Lbl_Msg.Refresh();
                            lPath_Origen = Path.Combine(lPath_Origen, lArchivo);
                            lPathDest = Path.Combine(lPathDest, lArchivo);
                            if (File.Exists(lPathDest) == false)
                                File.Copy(lPath_Origen, lPathDest, true);
                        }
                    }

                    lCopiar = false;
                }
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
        }


            /// <summary>
            /// Este metodo  recibe como parametro el nombre del archivos que se va a copiar en destino, si el archivos ya existe No se copia
            /// </summary>
            /// <param name="iNombreArchivo"></param>
            private void Revisa_Archivo(string iNombreArchivo)
        {
            string lPathDest = ""; string lPathOrigen = ""; string lError = ""; 
            string lRes = ""; string lArchivo = "";
            string lPath_Archivos = ConfigurationManager.AppSettings["PathGDE"].ToString();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DirectoryInfo lFolder = new DirectoryInfo(lPath_Archivos);
            foreach (var fi in lFolder.GetFiles())
            {
                if ((fi.Name.ToString().IndexOf(iNombreArchivo) > -1) && (lRes != "OK"))
                {
                    //*******************************************
                    try
                    {
                        //lExtensionFile = ObtenerExtensionarchivo(fi.Name);
                        lArchivo = fi.Name.ToString(); // string.Concat(iNroGDE, ".", lExtensionFile);
                        lPathDest = @"Z:\Produccion\Archivos\GDE";
                        lError = "Antes IF";
                        if (Directory.Exists(lPathDest) == true)
                        {
                            lPathDest = Path.Combine(@"Z:\Produccion\Archivos\GDE\", lArchivo);
                            lPathOrigen = Path.Combine(@"D:\Guias de Despacho\Guias Torres Ocaranza\", lArchivo);
                            File.Copy(lPathOrigen, lPathDest, true);
                            lError = string.Concat("Finalizado, OK: ", lPathDest);
                        }
                    }
                    catch (Exception iEx)
                    {
                        lError = string.Concat("Error: ", iEx.Message.ToString());
                        MessageBox.Show(lError);
                    }
                }
            }
            // MessageBox.Show(" FIN ");
        }

        private void Btn_Inicia_Click(object sender, EventArgs e)
        {
            IniciaProceso_PDF();
        }

        private void Lbl_Msg_Click(object sender, EventArgs e)
        {

        }

        private void Frm_ActualizaArchivos_PDF_Load(object sender, EventArgs e)
        {
            Tx_PathOrigen.Text   = ConfigurationManager.AppSettings["PathOrigen_PDF"].ToString();
            Tx_PathDestino .Text = ConfigurationManager.AppSettings["PathDestino_PDF"].ToString();
        }
    }
}
