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

namespace Gestor_OC_Gerdau.Logistica
{
    public partial class Frm_ProcesaGDE : Form
    {
        public Frm_ProcesaGDE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        public void CargaDatos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            lSql = "  select convert(date,a.atefchdoc)  atefchdoc ,  (Select Par1 from   to_parametros where subtabla ='TiposGuiaINET' and par2= doccod ), ";
            lSql = String.Concat(lSql, "   (select Count(1) from  GuiasRecibidas g  where g.Doccod=a.doccod and NroGuiaInet=a.atenum   ), ");
            lSql = String.Concat(lSql, "  * from   Tocaranza.dbo.ateclien a where a.atefchdoc> '01/06/2022' and doccod between 300 and 400   ");
            lSql = String.Concat(lSql, "   and    not exists  ( select 1 from  GuiasRecibidas where  NroGuiaInet=a.atenum ) ");
            lSql = String.Concat(lSql, "  Order by   a.atenum ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lSql = " Insert into GuiasRecibidas (NroGuiaInet,FechaProceso,NombreArchivo, Estado, FechaGuiaInet, DocCod) Values (";
                    lSql = String.Concat(lSql, lTbl.Rows[i]["atenum"].ToString(), ",Getdate(),'','I','", lTbl.Rows[i]["atefchdoc"].ToString());
                    lSql = String.Concat(lSql, "',", lTbl.Rows[i]["doccod"].ToString(), ")");
                    lPx.ObtenerDatos(lSql);
                }

            }



            lSql = "  select *      from GuiasRecibidas  where Estado ='I'  and FechaGuiaInet >'01/06/2022 00:00:01' order by nroGuiaInet desc ";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lTbl = lDts.Tables[0].Copy();


            Dtg_Datos.DataSource = lTbl;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ProcesaDatos();
        }

        public void ProcesaDatos()
        {
            int i = 0;
            if (Tx_NroGuia.Text.Trim().Length > 0)
            {
                Lbl_Msg.Text = String.Concat("... procesando Guía: ", Tx_NroGuia.Text);
                Lbl_Msg.Refresh(); this.Refresh();
                Revisa_GDE(Tx_NroGuia.Text);
            }
            else
            {
                for (i = 0; i < Dtg_Datos.Rows.Count; i++)
                {
                    Lbl_Msg.Text = String.Concat("... procesando Guía: ", Dtg_Datos.Rows[i].Cells["NroGuiaINET"].Value.ToString());
                    Lbl_Msg.Refresh(); this.Refresh();
                    Revisa_GDE(Dtg_Datos.Rows[i].Cells["NroGuiaINET"].Value.ToString());

                }
            }

            Tx_Msg.Text = ".  .  .   Enviando Correo a Clientes  .  .  . ";
            Tx_Msg.Refresh();
            this.Refresh();
           
            EnviosAutomaticos lFrm = new EnviosAutomaticos();
            lFrm.mGenerandoArchivo = false;
            lFrm.Envia_Guias_Pendientes_Entrega_Camion();
            lFrm.Close();

        }

        private string ObtenerExtensionarchivo(string iArchivo)
        {
            string lRes = "";
            string[] split = iArchivo.Split(new Char[] { '.' });

            if (split.Length > 1)
                lRes = split[1].ToString();

            return lRes;
        }

        private void Revisa_GDE(string iNroGDE)
        {
            string lPathDest = ""; string lPathOrigen = ""; string lError = "";string lExtensionFile = "";
            string lRes = ""; string  lArchivo = ""; DateTime  FechaArchivo  ; string lsql = "";
            string lPath_GDE = ConfigurationManager.AppSettings["PathGDE"].ToString();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DirectoryInfo lFolder = new DirectoryInfo(lPath_GDE);
            foreach (var fi in lFolder.GetFiles())
            {
                if ((fi.Name.ToString ().IndexOf (iNroGDE )>-1) && (lRes!="OK" )) 
                {
                    //*******************************************
                    try
                    {
                        lExtensionFile = ObtenerExtensionarchivo(fi.Name);
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
                   
                    //******************************************************
                    lArchivo = Path.Combine(lPath_GDE, fi.Name.ToString());
                    FechaArchivo = File.GetCreationTime(lArchivo);
                    lArchivo= string .Concat ("~/Archivos/GDE/", fi.Name.ToString());
                    lRes = string.Concat("Path Archivo: ", lArchivo, "   Fecha Archivo:", FechaArchivo.ToLongDateString());
                    lsql = String.Concat(" Update  GuiasRecibidas set Estado ='F' , NombreArchivo='", lArchivo, "',fechaGuiaFirmada='", FechaArchivo, "'");
                    lsql = String.Concat(lsql, " where NroGuiaInet=", iNroGDE);
                    lPx.ObtenerDatos(lsql);
                    Tx_Msg.Text = lsql;
                   // MessageBox .Show (string.Concat (" Actualizado en BD: Guia:", iNroGDE),"Avisos sistema" );
                  //  MessageBox.Show(string.Concat(" Actualizado en BD: Guia:", iNroGDE , "  " , lRes), "Avisos sistema");

                }
            }
           // MessageBox.Show(" FIN ");
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_CopiaGuia_Click(object sender, EventArgs e)
        {
            string lPathDest = "";string lPathOrigen = ""; string lError = "";
;
            try
            {
                lPathDest = @"Z:\Produccion\Archivos\GDE";
                lError = "Antes IF";
                if (Directory.Exists(lPathDest) == true)
                {
                    lPathDest = @"Z:\Produccion\Archivos\GDE\9544.pdf";
                    lPathOrigen = @"D:\Guias de Despacho\Guias Torres Ocaranza\9544.pdf";
                    File.Copy(lPathOrigen, lPathDest, true);
                    lError = "Finalizado, OK";
                }
            }
            catch (Exception iEx)
            {
                lError = string.Concat ("Error: ",iEx .Message .ToString() );
            }
            MessageBox.Show(lError);
        }
    }
}
