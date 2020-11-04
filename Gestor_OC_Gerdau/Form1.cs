using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;


namespace Gestor_OC_Gerdau
{
    public partial class Frm_ppal : Form
    {
        WS_Gerdau.TipoObjGerdau[] mLista = null;
        string mPathPendientes = "";
        string mPathEnviados = "";

        public Frm_ppal()
        {
            InitializeComponent();
        }

        private void Btn_ObtenerDatos_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
        }

        private void ObtenerDatos()
        {
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            //System.Collections.Generic.List<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau> lLista = new System.Collections.Generic.List<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau> ();

            mLista = lPx.ObtenerDatosPorEnviar();
            //mLista = lPx.ObtenerDatosPorEnviar();

            Dtg.DataSource = mLista;


        }
        private string ObtenerUrlFtp()
        {
            string lServer = ConfigurationManager.AppSettings["FTP"];
            return lServer;
        }

        private void CargaArchivos_FTP(string iPathOrigen, string iNombreArchivo)
        {
            string larchivofinal = string.Concat(iPathOrigen); //, "\\",iNombreArchivo );
            string lServer = ObtenerUrlFtp();
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            WS_Gerdau.ArchivosGerdau lArchGerdau = new WS_Gerdau.ArchivosGerdau();

            //string lUrl = string.Concat("ftp://201.148.105.49:21//ArchivosCad//", iNombreArchivo);
            string lUrl = string.Concat(ObtenerUrlFtp(), iNombreArchivo);
            //string lUrl = string.Concat("ftp://200.54.224.157/Captura.png");
            Uri lUri = new Uri(lUrl);
            try
            {
                //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp.torresocaranza.cl//ArchivosCad//" + iNombreArchivo);
                lArchGerdau.Nombre = iNombreArchivo;
                lArchGerdau.Path = lUrl;
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(lUri);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("tocaranz", "klabe.99" );
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                //FileStream stream = File.OpenRead("C:\\MiArchivoASubir.xml");
                FileStream stream = File.OpenRead(string.Concat(larchivofinal, iNombreArchivo));
                //FileStream stream = File.OpenRead("D:\\Roberto Becerra\\TMP\\Captura.png");
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
                lArchGerdau.Estado = "20";
            }
            catch (Exception iex)
            {
                lArchGerdau.Obs = iex.Message .ToString () ;
                lArchGerdau.Estado = "21";
                TX_Estado.Text = string.Concat(TX_Estado.Text, Environment.NewLine, "----------------------------------------------------------------", Environment.NewLine, iex.ToString());
            }
            finally
            {               
                lPx.GrabarArchivoFTP(lArchGerdau);
            }
        }


        private void EnviarCorreo_de_Notificacion(DataRow ifila   )
        {
            int i = 0; string lEstado = ""; string lCuerpo = "";string lRes = "";
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            WS_Gerdau.ArchivosGerdau lArchGerdau = new WS_Gerdau.ArchivosGerdau();
            try
            {
                //primero revisamos los que fueron subido OK al FTP
                //lVista = new DataView(iTbl, "Estado=20", "", DataViewRowState.CurrentRows);
                //if (lVista.Count > 0)
                //{
                lArchGerdau.Nombre = ifila["Nombre"].ToString();
                    lCuerpo = string.Concat(" Hola Estimados: <br>  El presente correo es para informar el estado de las OC enviadas a Gerdau <br><br>");
                    lCuerpo = string.Concat(lCuerpo, " Los Siguientes archivos han sido cargados en el FTP de Gerdau. <BR> <BR>");
                    lCuerpo = string.Concat(lCuerpo, " <table align='center' border='1'  >   ");
                    lCuerpo = string.Concat(lCuerpo, "  <tr>  ");
                    lCuerpo = string.Concat(lCuerpo, "  <td align='center'>Nombre archivo</td>   <td align='center'>Path FTP</td> ");
                    lCuerpo = string.Concat(lCuerpo, "  <td align='center'>Fecha Carga FTP</td>   <td align='center'>Nro. OC </td>  </tr>");
                    lCuerpo = string.Concat(lCuerpo, "  <tr>  ");
                    lCuerpo = string.Concat(lCuerpo, "  <td style='font - family: Arial; font - size: small'>", ifila["Nombre"].ToString (), "</td>"  );
                    lCuerpo = string.Concat(lCuerpo, "  <td style='font - family: Arial; font - size: small'>", ifila["PathRemota"].ToString(), "</td>");
                    lCuerpo = string.Concat(lCuerpo, "  <td style='font - family: Arial; font - size: small'>", ifila["FechaCargaFTP"].ToString(), "</td>");
                    lCuerpo = string.Concat(lCuerpo, "  <td style='font - family: Arial; font - size: small'>", ifila["AdqOdNuRe"].ToString(), "</td>");
                    lCuerpo = string.Concat(lCuerpo, "  <BR> <BR>");

                    lRes = lPx.EnviarCorreoNotificacion("OC_GERDAU", lCuerpo, -700, "Notificacion por Envio de OC a Gerdau");
                    if (lRes.ToUpper().Equals("OK"))
                          lArchGerdau.Estado = "30";
                   else
                         lArchGerdau.Estado = "31";
                   


                lArchGerdau.Obs = lRes;
                //}

            }
            catch (Exception iex)
            {
                lArchGerdau.Obs = iex.Message.ToString();
                lArchGerdau.Estado = "31";
                TX_Estado.Text = string.Concat(TX_Estado.Text, Environment.NewLine,"----------------------------------------------------------------",Environment .NewLine , iex.ToString());
            }
            finally
            {
                lPx.GrabarArchivoEnvioMail(lArchGerdau);
            }

        }


        private void SubirArchivos()
        {
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();int i = 0;
            lDts = lPx.ObtenerArchivoPorSubir();
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    CargaArchivos_FTP(lTbl.Rows[i]["Path"].ToString(), lTbl.Rows[i]["Nombre"].ToString());

                }
            }
        }

        private void EnviaCorreoNotificacion_archivosEnFTP()
        {
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            lDts = lPx.ObtenerArchivosParaEnviarCorreoPorOC();
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    EnviarCorreo_de_Notificacion(lTbl.Rows[i]);
                }
            }
        }

        private void CrearArchivo( )
        {
            string lPath = mPathPendientes; // string.Concat (Application.StartupPath, "\\Archivos\\Pendientes\\");
            int i = 0; string lNombreArchivo = "";string lFecha = DateTime.Now.ToShortDateString ();
            string lHora = DateTime.Now.ToShortTimeString(); int j = 0;string lEstado = "";
            string lLinea = "";  List<string> lListaLineas = new List<string>() ;
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            WS_Gerdau.ArchivosGerdau lArchGerdau = new WS_Gerdau.ArchivosGerdau();

            lHora = lHora.Replace(":", "");
                for (i = 0; i < mLista.Length; i++)
                {
                try
                {
                    lListaLineas = new List<string>();
                    lArchGerdau.Nombre = string.Concat(  mLista[i].OC, "_", lFecha, "_", lHora, ".csv");
                    lArchGerdau.Path = lPath;
                    lArchGerdau.AdqOdNuRe = mLista[i].OC;
                    lArchGerdau.AdqOdNum = mLista[i].Correlativo;
                    lNombreArchivo = string.Concat(lPath, mLista[i].OC, "_", lFecha, "_", lHora, ".csv");
                    //Cabecera
                    lLinea = string.Concat(mLista[i].Tipo, "|", mLista[i].RutEmisor, "|", mLista[i].OC, "|", mLista[i].ClasePedido, "|", mLista[i].Moneda, "|", mLista[i].Contrato, "|", mLista[i].FechaPedido, "|", mLista[i].Usuario, "|", mLista[i].Vendedor, "|", mLista[i].CodigoDireccion, "|", mLista[i].DireccionEntrega, "|", mLista[i].Comuna, "|", mLista[i].Ciudad, "|", mLista[i].Incoterms, "|");
                    lListaLineas.Add(lLinea);
                    //Detalle
                    for (j = 0; j < mLista[i].Detalle.Length; j++)
                    {
                        lLinea = "";
                        lLinea = string.Concat(mLista[i].Detalle[j].Tipo, "|", mLista[i].RutEmisor, "|", mLista[i].OC, "|", mLista[i].Detalle[j].Posicion, "|", mLista[i].Detalle[j].Material, "|", mLista[i].Detalle[j].Descripcion, "|", mLista[i].Detalle[j].Almacen, "|", mLista[i].Detalle[j].FamiliaProducto, "|", mLista[i].Detalle[j].Cantidad, "|", mLista[i].Detalle[j].UnidadMedida, "|", mLista[i].Detalle[j].Precio, "|", mLista[i].Detalle[j].Monto, "|", mLista[i].Detalle[j].Descuento , "|", mLista[i].Detalle[j].FechaEstimadaEntrega, "|");
                        lListaLineas.Add(lLinea);
                    }
                    File.AppendAllLines(lNombreArchivo, lListaLineas);
                    //Creado OK
                    lEstado = "10";
                }
                catch (Exception iex)
                {
                    //Error al crear el Archivo
                    lEstado = "11";
                    lArchGerdau.Obs = iex.Message.ToString();
                    TX_Estado.Text = iex.ToString();
                }
                finally
                {
                    lArchGerdau.Estado = lEstado;
                    lPx.GrabarArchivo(lArchGerdau);
                }
            }
        
        }


        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int lFila = e.RowIndex;
            //WS_Gerdau.Detalle[] mListaDet = null;

            //WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            ////System.Collections.Generic.List<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau> lLista = new System.Collections.Generic.List<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau> ();

            //mListaDet = lPx.ObtenerDatosDetalle(Dtg.Rows [lFila ].Cells ["correlativo"].Value .ToString ());
           
            //this .dtg_det .DataSource = mListaDet;


        }

        private void Btn_CrearArchivo_Click(object sender, EventArgs e)
        {
            CrearArchivo();
        }

        private void Btn_subirArchivos_Click(object sender, EventArgs e)
        {
            SubirArchivos();
        }

        private void Btn_PruebasFTP_Click(object sender, EventArgs e)
        {
            EnviaCorreoNotificacion_archivosEnFTP();
        }

        private void Frm_ppal_Load(object sender, EventArgs e)
        {
             mPathPendientes =   ConfigurationManager.AppSettings["PathPendientes"];
            mPathEnviados = ConfigurationManager.AppSettings["PathEnviados"];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ObtenerDatos();
            //if (mLista.Length >0)
            //{
            //    CrearArchivo();
            //    SubirArchivos();
            //    EnviaCorreoNotificacion_archivosEnFTP();
            //    ObtenerDatos();
            //}
           
        }

        private void Btn_procesar_Click(object sender, EventArgs e)
        {
            if (mLista.Length > 0)
            {
                Lb_Msg.Text = ". . . Inicando Proceso . . . ";
                PB_Avance.Maximum = 5; PB_Avance.Minimum = 1; PB_Avance.Value = 1;
                PB_Avance.Visible = true;Lb_Msg.Visible = true;
                Lb_Msg.Refresh();PB_Avance.Refresh(); Application.DoEvents();

                Lb_Msg.Text = ". . .Creando Archivo  . . . "; PB_Avance.Value = PB_Avance.Value + 1;
                Lb_Msg.Refresh(); PB_Avance.Refresh(); Application.DoEvents();
                CrearArchivo();

                Lb_Msg.Text = ". . .Subiendo Archivo  . . . "; PB_Avance.Value = PB_Avance.Value + 1;
                Lb_Msg.Refresh(); PB_Avance.Refresh(); Application.DoEvents();
                SubirArchivos();

                Lb_Msg.Text = ". . .Enviando Correo de Notificación  . . . "; PB_Avance.Value = PB_Avance.Value + 1;
                Lb_Msg.Refresh(); PB_Avance.Refresh(); Application.DoEvents();
                EnviaCorreoNotificacion_archivosEnFTP();
                Lb_Msg.Text = ". . .Obteniendo Datos   . . . "; 
                Lb_Msg.Refresh(); PB_Avance.Refresh(); Application.DoEvents();
                ObtenerDatos();

                PB_Avance.Visible = false ; Lb_Msg.Visible = false ;

            }
        }
    }
}
