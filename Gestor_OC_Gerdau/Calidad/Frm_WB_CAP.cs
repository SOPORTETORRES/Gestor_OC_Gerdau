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
    public partial class Frm_WB_CAP : Form
    {
        private string mLote = "";
        private string mDiametro = "";
        private string mUrl = "";
        public Frm_WB_CAP()
        {
            InitializeComponent();
        }

        private void Frm_WB_CAP_Load(object sender, EventArgs e)
        {
            WB.Navigate("http://intranet.idiem.cl/cap/cake/consulta_informes");
            Tx_lote.Text = mLote;
            Tx_diam.Text = mDiametro;
          //  IniciaProceso();
        }

        public void IniciaForm(string iLote, string iDiametro, string iUrl)
        {
            mLote = iLote;
            mDiametro = iDiametro;
            mUrl = iUrl;
        }


        private void IniciaProceso()
        {
            try
            {
                WB.Document.GetElementById("hornada").InnerText = mLote;
                WB.Document.GetElementById("diametro").InnerText = mDiametro;

                WB.Document.GetElementById("ConsultaInformesIndexForm").InvokeMember("submit");
            }
            catch (Exception iex)
            {
            }
        }

        private void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int i = 0;
            string lError = ""; String lTx = ""; string[] lPartes = null; string[] lPartes_2 = null;
            string[] stringSeparators = new string[] { "<TBODY>" };
            try
            {
                Boolean lProcesado = false;
                //string[] subs = s.Split(' ');
                HtmlElementCollection classButton = WB.Document.All;

                if (classButton.Count > 71)
                {
                    foreach (HtmlElement element in classButton)
                    {
                        if (lProcesado == false)
                        {
                            List<Char> lLista = new List<char>();
                            // if ((element.InnerHtml != null) && (element.InnerHtml.ToString().IndexOf("http://www.idiem.cl/intranet/") > 0))
                            if ((element.InnerHtml != null)) //&& (element.InnerHtml.ToString().IndexOf("http://localhost/") > 0))
                            {

                                if (element.InnerHtml.IndexOf("<TH>ID Documento</TH>") > 0)
                                {
                                    lTx = element.InnerHtml;
                                    lPartes = lTx.Split(stringSeparators, StringSplitOptions.None);
                                    stringSeparators = new string[] { "<TR" };
                                    if (lPartes.Length == 2)
                                    {
                                        lPartes_2 = lPartes[1].Split(stringSeparators, StringSplitOptions.None);
                                        for (i = 0; i < lPartes_2.Length; i++)
                                        {
                                            if (lPartes_2[i].Length > 5)
                                            {
                                                PersisteDatos(lPartes_2);
                                                i = lPartes_2[i].Length + 5;
                                            }

                                        }

                                    }
                                                           

                                    //lPartes_2 = lPartes[1].Split(stringSeparators, StringSplitOptions.None);

                                    //PersisteDatos(lPartes_2);
                                    //lPartes_2 = lPartes[3].Split(stringSeparators, StringSplitOptions.None);
                                    //PersisteDatos(lPartes_2);
                                    lProcesado = true;
                                }
                            }
                        }
                        //else
                        //{

                        //}
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    IniciaProceso();
                }
            }
            catch (Exception exc)
            {
                lError = exc.Message.ToString();
            }

            //this.Close();
        }
        private string LimpiaCaracteres(string iTx, Boolean iEsUrl)
        {
            string lRes = ""; string[] stringSeparators = new string[] { "</A>" };
            string[] lPartes = null; string lTmp = "";


            if (iEsUrl == false)
            {
                lRes = iTx.Replace(">", "");
                lRes = lRes.Replace("</", "");
                //lRes = lRes.Replace("/", "");
            }
            else
            {
                lPartes = iTx.Split(stringSeparators, StringSplitOptions.None);
                if (lPartes.Length > 1)
                {
                    lTmp = lPartes[0].ToString();
                    lRes = lTmp.Replace("class=text-center><A class=text-decoration-none href=", "");
                    lRes = lRes.Substring(2, lRes.Length - 7);
                    lRes = string.Concat("http://intranet.idiem.cl", lRes);


                    //("http://intranet.idiem.cl/cap/cake/ConsultaInformes/bajar/1826693/33863/32" );
                }



            }

            return lRes;
        }

        private int Val(string iValor)
        {
            int lRes = 0;
            try
            {
                lRes = int.Parse(iValor);
            }
            catch (Exception iEx)
            {
                lRes = 0;
            }
            return lRes;
        }

        private void CorrigePreIT()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lIdMov = "0"; string lIdPieza = "0"; string lKgsOK = "0";


            lSql = String.Concat("  select p.TotalKgs KgsOK , p1.TotalKgs Kgs_Err, IdMov , p1.id idPieza , p.id IdPiezaTipoB ,  ");
            lSql = String.Concat(lSql, "  (Select count(1) from DetallePaquetesPieza d where d.IdPieza=p1.id ) ");
            lSql = String.Concat(lSql, "  from  PiezasTipoB p, hojadespiece hd  , piezas  p1  where hd.id=p.id_hd ");
            lSql = String.Concat(lSql, " and hd.idobra=940 and  p1.IdPiezaTipoB =p.id     ");
            lSql = String.Concat(lSql, " and (Select count(1) from DetallePaquetesPieza d where d.IdPieza=p1.id )=1  and p.TotalKgs<>p1.TotalKgs  ");

            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    if ((lTbl.Rows.Count > 0))
                    {
                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            lIdMov = lTbl.Rows[i]["IdMov"].ToString();
                            lIdPieza = lTbl.Rows[i]["idPieza"].ToString();
                            lKgsOK = lTbl.Rows[i]["KgsOK"].ToString();

                            lSql = String.Concat("update movimientos set pesoasignado=", lKgsOK, " where id=", lIdMov);
                            lDts = lPx.ObtenerDatos(lSql);
                            lSql = String.Concat("update piezas set  totalKgs=", lKgsOK, " where id=", lIdPieza);
                            lDts = lPx.ObtenerDatos(lSql);
                            lSql = String.Concat(" update  detallepaquetespieza set kgspaquete=", lKgsOK, " where idpieza=", lIdPieza);
                            lDts = lPx.ObtenerDatos(lSql);

                        }




                    }
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void PersisteDatos(string[] iPartes)
        {
            int i = 0; string[] lPartes = null; DataRow lFila = null; int cont = 0; string lIdDoc = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";int lCont = 0;
            string[] stringSeparators = new string[] { "TD" }; string lUrlArchivo = "";
            DataTable lTbl = new DataTable(); DataView lVista = null;
            DataSet lDts = new DataSet(); //DataTable lTbl = new DataTable();


            try
            {
                lTbl.Columns.Add("IdDocumento", Type.GetType("System.String"));
                lTbl.Columns.Add("TipoDocumento", Type.GetType("System.String"));
                lTbl.Columns.Add("Lote", Type.GetType("System.String"));
                lTbl.Columns.Add("FechaProduccion", Type.GetType("System.String"));
                lTbl.Columns.Add("FechaFirma", Type.GetType("System.DateTime"));
                lTbl.Columns.Add("UrlArchivo", Type.GetType("System.String"));

                if (iPartes.Length > 0)
                {
                    for (i = 0; i < iPartes.Length; i++)
                    {
                        if ((iPartes[i].ToString().Length > 10) && (iPartes[i].ToString().IndexOf("No hay informes que coincidan") < 0))
                        {
                            lPartes = iPartes[i].Split(stringSeparators, StringSplitOptions.None);
                            lIdDoc = LimpiaCaracteres(lPartes[1], false);
                            if ((lIdDoc.ToString().Length > 4))
                            {
                                lSql = String.Concat("  select  1 from  certificadoscoladasCap where IdDocumento='", lIdDoc, "'");
                                lDts = lPx.ObtenerDatos(lSql);
                                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0)) //Ya exsite 
                                {

                                }
                                else  // Es Nuevo
                                {
                                    //if (lCont < 2)
                                    //{
                                    lFila = lTbl.NewRow();
                                    lFila["IdDocumento"] = lIdDoc;
                                    lFila["TipoDocumento"] = LimpiaCaracteres(lPartes[3], false); ;
                                    lFila["Lote"] = LimpiaCaracteres(lPartes[5], false);
                                    lFila["FechaProduccion"] = LimpiaCaracteres(lPartes[9], false);
                                    lFila["FechaFirma"] = LimpiaCaracteres(lPartes[11], false);
                                    lUrlArchivo = LimpiaCaracteres(lPartes[13], true);
                                    lFila["UrlArchivo"] = lUrlArchivo;
                                    lTbl.Rows.Add(lFila);





                                    //}

                                }
                                //   lFila = lTbl.NewRow();
                                //lFila["IdDocumento"] = lIdDoc;
                                //lFila["TipoDocumento"] = LimpiaCaracteres(lPartes[3], false); ;
                                //lFila["Lote"] = LimpiaCaracteres(lPartes[5], false);
                                //lFila["FechaProduccion"] = LimpiaCaracteres(lPartes[9], false);
                                //lFila["FechaFirma"] = LimpiaCaracteres(lPartes[11], false);
                                //lUrlArchivo = LimpiaCaracteres(lPartes[13], true);
                                //lFila["UrlArchivo"] = lUrlArchivo;
                                //lTbl.Rows.Add(lFila);
                                ////url = string.Concat("http://intranet.idiem.cl/cap/cake/ConsultaInformes/bajar/1826693/33863/32" );
                            }
                        }
                    }
                    lVista = new DataView(lTbl, "", "FechaFirma desc", DataViewRowState.CurrentRows);
                    if ((lVista.Count > 0)) // & (lCont < 2))
                    {
                        for (i = 0; i < lVista.Count; i++)
                        {
                            if (lCont < 2)
                            {
                                lSql = String.Concat("  Insert into certificadoscoladasCap (Lote, IdDocumento, TipoDocumento, FechaProduccion, ");
                                lSql = String.Concat(lSql, "  FechaFirma, UrlDocumento, Estado ) Values ('", LimpiaCaracteres(lVista[i]["lote"].ToString().Trim (), false), "','");
                                lSql = String.Concat(lSql, lVista[i]["IdDocumento"].ToString(), "','", LimpiaCaracteres(lVista[i]["TipoDocumento"].ToString(), false), "','", lVista[i]["FechaProduccion"].ToString().Substring (0,10), "','", lVista[i]["FechaFirma"].ToString().Substring(0, 10));
                                lSql = String.Concat(lSql, "','", lVista[i]["UrlArchivo"].ToString(), "','OK')");
                                lDts = lPx.ObtenerDatos(lSql);
                                lCont++;
                            }
                        }
                    }
                }
            }
            catch (Exception iEx)
            {
                throw iEx ;
            }

        }

        private void Btn_carga_Click(object sender, EventArgs e)
        {
            WB.Document.GetElementById("hornada").SetAttribute("value", Tx_lote.Text);
            WB.Document.GetElementById("diametro").SetAttribute("value", Tx_diam . Text);

            WB.Document.GetElementById("ConsultaInformesIndexForm").InvokeMember("submit");
        }
    }
}
