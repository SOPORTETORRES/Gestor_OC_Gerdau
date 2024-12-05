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

namespace Gestor_OC_Gerdau.Tools
{
    public partial class Frm_CopiaDoc : Form
    {
        public Frm_CopiaDoc()
        {
            InitializeComponent();
        }

        private void Btn_RevisaInfo_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }


        private void CargaDatos()
        {
            string rutaDirectorio = @"C:\TMP\Calidad\Docs"; DataTable lTbl = new DataTable();
            DataRow lFila = null; string lLote = "";

            lTbl.Columns.Add("Lote");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            lTbl.Columns.Add("Kgs");
            // Verificar si el directorio existe
            if (Directory.Exists(rutaDirectorio))
            {
                // Obtener todos los archivos en el directorio
                string[] archivos = Directory.GetFiles(rutaDirectorio);

                // Mostrar la lista de archivos
                //Console.WriteLine("Archivos en el directorio:");
                foreach (string archivo in archivos)
                {
                    FileInfo lInfoArch = new FileInfo(archivo);
                    if (((lInfoArch.Length/1000) < 50) && (lInfoArch.LastWriteTime.Year >=2024  ))
                    {

                        lFila = lTbl.NewRow();
                        lFila["Lote"] = archivo;
                        lFila["Kgs"] = (lInfoArch.Length / 1000);
                        lTbl.Rows.Add(lFila);
                    }

                }
                Dtg_Resultado.DataSource = lTbl;

            }
        }

        DataTable ObtenerViajesAsociados(string iLote)
        {
            DataSet   lDts=  new DataSet ();string lSql = "";
            Gestor_OC_Gerdau.WS_TO.Ws_ToSoapClient lPx = new Gestor_OC_Gerdau.WS_TO.Ws_ToSoapClient();
            lSql = "select distinct v.codigo , MailCalidadEnviado , FechaMailCalidad   ";
            lSql = string.Concat(lSql, " from  detallepaquetesPieza d , viaje v, etiquetasVinculadas ev , etiquetaAza e  ");
            lSql = string.Concat(lSql, " where d.idviaje=v.id  and idQr=e.id and IdetiquetaTO=d.id      ");
            lSql = string.Concat(lSql, "   and lote in ('", iLote, "')  "); //   and MailCalidadEnviado <>'S'   ");
            lDts=lPx.ObtenerDatos(lSql);
            return lDts.Tables[0].Copy(); ;
        }

        private void ProcesaLote()
        {
            int i = 0;string lPath = "";DataTable lViajes = new DataTable();string lLote = "";
            Gestor_OC_Gerdau.WS_TO.Ws_ToSoapClient lPx = new Gestor_OC_Gerdau.WS_TO.Ws_ToSoapClient();
            int k = 0;

            for (i = 0; i < Dtg_Resultado.Rows.Count; i++)
            {
                // eliminar Archivo fisico del directorio   C:\TMP\Calidad\Docs
                lPath = Dtg_Resultado.Rows[i].Cells["Lote"].Value.ToString();
                if (File.Exists(lPath) == true)
                    File.Delete(lPath);

                lLote = lPath.Substring(20, 10);
                //Eliminamos los registros de la Tabla Certificados Coladas
                lLote = string.Concat( "  Delete from certificadoscoladas  where lote='", lLote,"'");
                lPx.ObtenerDatos(lLote);

                // Buscar los viaje  asociados a las Coladas con problemas y dejarlos como NO procesados y/o enviados 
                lLote = lPath.Substring(20, 10);
                lViajes = ObtenerViajesAsociados(lLote);
                for (k = 0; k < lViajes.Rows .Count; k++)
                {
                    if (lViajes.Rows[k]["MailCalidadEnviado"].ToString() != "E")
                    {
                        lLote = string.Concat("  update viaje set  MailCalidadEnviado='E'  where codigo='", lViajes.Rows[k]["Codigo"].ToString(), "'");
                        lPx.ObtenerDatos(lLote);
                    }                        
                }
            }                           
            // Descargar las coladas (con problemas) de  Idiem
            // Re procesar los viajes 

        }

        private void Btn_Procesar_Click(object sender, EventArgs e)
        {
            ProcesaLote();
        }
    }
}
