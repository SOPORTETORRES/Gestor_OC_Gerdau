using Gestor_OC_Gerdau.Calidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Clases
{
    public class Cls_Lotes
    {
        private string mCnnMySql = "Database=cubigest;Data Source=localhost;User Id=root;Password=";
        //private string mCnnMySql = "Database=cubigest;Data Source=localhost;User Id=admin;Password=Heladera9696@";
        public DataTable CargarDatos(string lSql)
        {
            MySqlConnection cnn = new MySqlConnection(this.mCnnMySql);
            MySqlDataAdapter mda = new MySqlDataAdapter(lSql, cnn);
            DataSet ds = new DataSet(); DataTable lTbl = new DataTable();
            mda.Fill(ds, "MySql");
            if ((ds != null) && (ds.Tables.Count > 0))
                lTbl = ds.Tables[0].Copy();

            return lTbl;
        }

        public  string LimpiaTx(string iTx)
        {
            string lres = "";
            string[] lPartes = (iTx.Split(new Char[] { '"' }));
            if (lPartes.Length > 0)
            {
                lres = lPartes[1];
            }


            return lres;
        }

        public  string ObtieneLlave(string iTx)
        {
            string lres = "";
            string[] lPartes = (iTx.Split(new Char[] { '/' }));
            if (lPartes.Length > 0)
            {
                lres = lPartes[(lPartes.Length - 1)];
            }
            //http://repositorio.idiem.cl/verifica/hS7vdRrAd1

            return lres;
        }

        public  void PesisteDatos(string iLote, string iUrlCert, string iUrlInf, string iPubInf, string iPubCert)
        {
            string lLote = ""; string lUrlCert = ""; string lUrlInf = ""; string lPubInf = ""; string lPubCert = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();
            //{"2612489402":{"Colada":"2612489402"
            string[] lPartes = (iLote.Split(new Char[] { ':' }));
            if (lPartes.Length == 3)
            {
                lLote = LimpiaTx(lPartes[2].ToString());
            }
            else
                lLote = iLote;


            lPartes = (iUrlCert.Split(new Char[] { ':' }));
            //"Certificado":"http://repositorio.idiem.cl/verifica/hqlivHPuq8"
            if (lPartes.Length == 3)
            {
                lUrlCert = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString());
                lUrlCert = LimpiaTx(lUrlCert);
            }
            lPartes = (iUrlInf.Split(new Char[] { ':' }));
            //"Informe":"http://repositorio.idiem.cl/verifica/UzCpzlzsLb"
            if (lPartes.Length == 3)
            {
                lUrlInf = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString());
                lUrlInf = LimpiaTx(lUrlInf);
            }
            lPartes = (iPubInf.Split(new Char[] { ':' }));
            //"Publicacion_Informe":"2019-06-24 17:04:29"
            if (lPartes.Length == 4)
            {
                lPubInf = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString(), ":", lPartes[3].ToString());
                lPubInf = LimpiaTx(lPubInf);
            }
            lPartes = (iPubCert.Split(new Char[] { ':' }));
            //"Publicacion_Certificado":"2019-06-25 10:03:29"}}
            if (lPartes.Length == 4)
            {
                lPubCert = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString(), ":", lPartes[3].ToString().Substring(0, 2));
                lPubCert = LimpiaTx(lPubCert);
            }
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            string lSql = string.Concat(" Select 1 from CertificadosColadas where lote='", lLote, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0)) //&& (lDts.Tables[0].Rows.Count > 0))
            {
                if (lDts.Tables[0].Rows.Count == 0)
                {
                    lSql = string.Concat(" insert into CertificadosColadas (Lote,Url_Certificado, Url_Informe,PublicacionInforme, PublicacionCertificado , ObsDescarga , FechaInsert ) ");
                    lSql = string.Concat(lSql, " values ('", lLote, "','", lUrlCert, "','", lUrlInf, "','", lPubInf, "','", lPubCert, "','', getdate() )  select @@Identity ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lSql = string.Concat(" update  Lotes set Procesado='F' where lote='", lLote, "'");
                        lLot.CargarDatos(lSql);

                    }
                }
                else
                {
                    lSql = string.Concat("  Update  CertificadosColadas set Url_Certificado='", lUrlCert, "', Url_Informe='", lUrlInf, "',");
                    lSql = string.Concat(lSql, " PublicacionInforme='", lPubInf, "', PublicacionCertificado='", lPubCert, "'");
                    lSql = string.Concat(lSql, " Where lote='", lLote, "'");
                    //, PublicacionInforme, PublicacionCertificado ) ");
                    lDts = lPx.ObtenerDatos(lSql);
                    lSql = string.Concat(" update  Lotes set Procesado='F' where lote='", lLote, "'");
                    lLot.CargarDatos(lSql);
                }

            }

        }

        public  void ObtenerDatosCertificados_WB()
        {
            //DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
            //string lRes = ""; string lLote = ""; string url = "";
            Calidad.Frm_WB_Php lFrm = new Frm_WB_Php();

            try
            {

                WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
                DataSet lDts = new DataSet(); WebClient cliente = null;


                //url = "http://localhost/AZA/ObtenerDatos.php";

                lFrm.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem: " + ex.Message);

            }
            //  MessageBox.Show("FIN");

        }

        public string GrabarRegistro(string iLote, int idPaquete)
        {
            string lRes = "OK";
            string lSql = string.Concat(" Select 1 from Lotes where lote='", iLote, "'");
            DataTable lTbl = new DataTable();

            if (iLote.Trim().Length != 0)
            {
                lTbl = CargarDatos(lSql);
                if (lTbl.Rows.Count == 0)
                {  //en mySql
                    lSql = " insert into Lotes (Lote, Procesado, Fecha, Respuesta)";
                    lSql = string.Concat(lSql, " values ('", iLote, "','N',now(),'')");
                    lTbl = CargarDatos(lSql);

                }
            }

            return lRes;

        }
    }
}
