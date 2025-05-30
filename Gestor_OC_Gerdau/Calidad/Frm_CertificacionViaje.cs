﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_CertificacionViaje : Form
    {
        private string mViaje = "";
        private string mSoloVer = "";
        private string mDiametro = "";
        private string mIdEtiqueta = "";
        private string mIdObra = "";
        private DataTable mTblEtViaje = new DataTable();
        private DataTable mTblTotes = new DataTable();
        private DataTable mTblCC = new DataTable();

        public Frm_CertificacionViaje()
        {
            InitializeComponent();
        }

        public void ActualizaRegistros_V2()
        {
            Btn_ObtenerLotesV2_Click(null, null);
        }

            public  void ActualizaRegistros()
        {
            int i = 0;int j = 0; int lIdColada = 0; string lSql = ""; int iIdEtiquetaTO = 0;
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();




           if (Dtg_Datos.RowCount>0)
            { 
            //1.-  Verificacamos la Actualizar Certificados Paquete
            if (Dtg_Datos.Rows[0].Cells["Id"].Style.BackColor == Color.Yellow)
            {
                Btn_CP_Click(null, null);
            }
            // Fin 1.-
            // 2.- Buscamos los  lotes que faltan
            for (i = 0; i < Dtg_Datos.RowCount; i++)
            {
                if ((Dtg_Datos.Rows[i].Cells["EtiquetaVinc"].Value != null) && (Dtg_Datos.Rows[i].Cells["EtiquetaVinc"].Value.ToString().ToUpper().Equals("N")))
                {
                    if (Dtg_Datos.Rows[i].Cells["Lote"].Style.BackColor == Color.LightSalmon)
                    {
                        Lbl_Lote.Text = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();
                        Tx_lote.Text = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();
                        Btn_ActualizaLote_Click(null, null);
                    }
                }
                else
                {
                    if (Dtg_Datos.Rows[i].Cells["LoteAza"].Style.BackColor == Color.LightSalmon)
                    {
                        lIdColada = int.Parse(Dtg_Datos.Rows[i].Cells["IdColada"].Value.ToString());
                            iIdEtiquetaTO = int.Parse(Dtg_Datos.Rows[i].Cells["Id"].Value.ToString());

                            if (lIdColada == -1)
                            {
                                lSql = string.Concat(" select distinct Lote  from EtiquetasVinculadas v , EtiquetaAZA e where v.IdQR =e.id  and   IdEtiquetaTO =", iIdEtiquetaTO);
                                lDts = lPx.ObtenerDatos(lSql);
                                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                                {
                                    lTbl = lDts.Tables[0].Copy();
                                    for (j = 0; j < lTbl.Rows.Count; j++)
                                    {
                                        Lbl_Lote.Text = lTbl.Rows[j]["Lote"].ToString();
                                        Tx_lote.Text = lTbl.Rows[j]["Lote"].ToString();
                                        Btn_ActualizaLote_Click(null, null);
                                    }
                                }
                            }
                            else
                            {
                                Lbl_Lote.Text = Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString();
                                Tx_lote.Text = Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString();
                                Btn_ActualizaLote_Click(null, null);
                            }
                     
                    }
                }
            }
            }
        }

        private Boolean ExisteRegistro(string iDato, string iTipo)
        {
            DataView lVista = null; string lWhere = "";
           DataTable lTbl = new DataTable(); 
            Boolean lRes = false;  

            if (iTipo.ToUpper().Equals("E"))   //etiqeutaTO
            {
                if (mTblEtViaje.Rows.Count > 0)
                {
                    lWhere = string.Concat(" id=", iDato);
                    lVista = new DataView(mTblEtViaje, lWhere, "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        lRes = true;
                    else
                        lRes = false;
                }
                   
            }

            if (iTipo.ToUpper().Equals("L"))   //Lote 
            {
                lWhere = string.Concat(" lote='", iDato,"'");
                if (mTblTotes.Rows.Count > 0)
                {
                    lVista = new DataView(mTblTotes, lWhere, "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        lRes = true;
                    else
                        lRes = false;
                }            
            }

            if (iTipo.ToUpper().Equals("CC"))   //Lote 
            {
                lWhere = string.Concat(" Id='", iDato, "'");
                if (mTblCC.Rows.Count > 0)
                {
                    lVista = new DataView(mTblCC, lWhere, "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        lRes = true;
                    else
                        lRes = false;
                }
            }

            


            return lRes;
        }

        public void Inicialida(string iViaje, string iSoloVer)
        {
            mViaje = iViaje;
            mSoloVer = iSoloVer;
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();  
            lSql = String.Concat("  select  d.id  from viaje v , DetallePaquetesPieza d where d.IdViaje =v.id  and codigo='", iViaje,"' ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblEtViaje = lDts.Tables[0].Copy();
            }


            lSql = String.Concat("  select  d.id  from viaje v , DetallePaquetesPieza d , certificadosPaquete cc ");            lSql = String.Concat( lSql , " where d.IdViaje =v.id  and d.id=cc.IdPaquete  and codigo='", iViaje, "' and len(cc.lote)>0 ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblCC = lDts.Tables[0].Copy();
            }
            // 
            lSql = string.Concat(" select o.id   from Obras o , viaje v, it   where  v.idit=it.id and it.idobra=o.id and   v.codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mIdObra = lDts.Tables[0].Rows[0][0].ToString();

            }
            
        }

        public void ObtenerTblLotes(string iLotes)
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0; DataRow lFila = null;

            lTbl.Columns.Add("lote");
            string[] separatingStrings2 = { "," };
            
            string[] lpartes2 = iLotes.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
            if (lpartes2.Length > 0)
            {
                for (i = 0; i < lpartes2.Length; i++)
                {

                    lFila = lTbl.NewRow();
                    lFila["lote"] = lpartes2[i].ToString().Replace ("'","");
                    lTbl.Rows.Add(lFila);
                   
                }
                mTblTotes = lTbl.Copy();

            }

        }

        private string ObtenerUrl_CAP(string iLote )
        {
            string lRes = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0; string lIdDoc = "";
            string lPathInf = ""; string lPathCert = "";

            lSql = string.Concat(" select * from certificadoscoladasCap where lote='", iLote, "'  order  by IdDocumento  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 1)
                {
                    if (lTbl.Rows[0]["TipoDocumento"].ToString().ToUpper().Equals("INFORME"))
                        lPathInf = lTbl.Rows[0]["UrlDocumento"].ToString();

                    lIdDoc = lTbl.Rows[0]["IdDocumento"].ToString();
                    lSql = string.Concat(" select * from certificadoscoladasCap where lote='", iLote, "'   and IdDocumento like '%",lIdDoc, "%' and  TipoDocumento ='Certificado' ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTbl = lDts.Tables[0].Copy();
                        lPathCert =lTbl.Rows[0]["UrlDocumento"].ToString();
                    }
        
                }
            }

            lRes = string.Concat(lPathInf, "|", lPathCert);
            return lRes;
        }

        public void CargaDatos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();            string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lLotesPr = ""; string lLote = "";string lColadasCap = ""; string lUltimoLote = "";
            string[] separatingStrings = { "|" }; string[] lPartes = null;
            EnviosAutomaticos lEnv = new EnviosAutomaticos();
            lEnv.Desactivar_Timmer();
            if (Tx_Codigo.Text.Trim().Length > 4)
                mViaje = Tx_Codigo.Text;

            lSql = String.Concat("  SP_Consultas_WS  192,'", mViaje, "','','','',',','',''");
            Tx_Codigo.Text = mViaje;
            Btn_CorrigueEV.Enabled = false;

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows .Count ; i++)
                {
                    if (lTbl.Rows[i]["LoteAza"].ToString().Length > 0)
                        lLote = lTbl.Rows[i]["LoteAza"].ToString();
                    else
                        lLote = lTbl.Rows[i]["Lote"].ToString();


                    if (lEnv.EsLoteAza(lLote) == false)
                    {
                        lLote = lLote.Replace("00000", "");
                        lColadasCap = ObtenerUrl_CAP(lLote);
                        lPartes = lColadasCap.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                        if (lLote.ToString() != lUltimoLote)
                        {
                            //lColadasCap = ObtenerUrl_CAP(lLote);
                            //lPartes = lColadasCap.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                            if (lPartes.Length > 1)
                            {
                                lTbl.Rows[i]["UrlInforme"] = lPartes[0];
                                lTbl.Rows[i]["UrlCertificado"] = lPartes[1];
                                lUltimoLote = lLote;
                            }
                        }
                        else
                        {
                            if ((lPartes != null) && (lPartes.Length >0))
                            {
                                lTbl.Rows[i]["UrlInforme"] = lPartes[0];
                                lTbl.Rows[i]["UrlCertificado"] = lPartes[1];
                                lUltimoLote = lTbl.Rows[i]["Lote"].ToString();
                            }                            
                        }
                    }
                }

                    Dtg_Datos.DataSource = lTbl;

                //********************************
               


                //****************************************
                int iIdColada = 0;int iIdEtiquetaTO = 0;DataTable lTblLotes = new DataTable(); int j = 0;
                for (i = 0; i < Dtg_Datos.RowCount - 1; i++)
                {
                    if (Dtg_Datos.Rows[i].Cells["IdColada"].Value.ToString() != "")
                    {
                        iIdColada = int.Parse(Dtg_Datos.Rows[i].Cells["IdColada"].Value.ToString());
                        iIdEtiquetaTO = int.Parse(Dtg_Datos.Rows[i].Cells["Id"].Value.ToString());
                        //VErificamos si tiene una o varias coladas asociadas
                        if (iIdColada.ToString().Equals("-1"))
                        {
                            lSql = string.Concat(" select distinct Lote  from EtiquetasVinculadas v , EtiquetaAZA e where v.IdQR =e.id  and   IdEtiquetaTO =", iIdEtiquetaTO);
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTblLotes = lDts.Tables[0].Copy();
                                for (j = 0; j < lTblLotes.Rows.Count; j++)
                                {
                                    lLote = lTblLotes.Rows[j]["Lote"].ToString();
                                    if (lLotesPr.IndexOf(lLote) == -1)
                                    {
                                        lLotesPr = string.Concat(lLotesPr, "'", lLote, "',");
                                    }
                                }
                            }

                        }
                        else  //HAy solo una colada para la Etiqueta
                        {
                            if (Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString().Length > 0)
                                lLote = Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString();
                            else
                                lLote = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();

                            if (lLotesPr.IndexOf(lLote) == -1)
                            {
                                lLotesPr = string.Concat(lLotesPr, "'", lLote, "',");
                            }
                        }
                        //-------------------------------


                    }

                }
                if (lLotesPr.Trim().Length > 0)
                {
                    lLotesPr = lLotesPr.Substring(0, lLotesPr.Length - 1);
                    ObtenerTblLotes(lLotesPr);
                }
                for (i = 0; i < Dtg_Datos.RowCount - 1; i++)
                {

                    if (ExisteRegistro(Dtg_Datos.Rows[i].Cells["Id"].Value.ToString(), "E") == false)
                    Dtg_Datos.Rows[i].Cells["Id"].Style.BackColor = Color.LightSalmon;
                else
                    Dtg_Datos.Rows[i].Cells["Id"].Style.BackColor = Color.LightGreen;

                    if (ExisteRegistro(Dtg_Datos.Rows[i].Cells["Id"].Value.ToString(), "CC") == false)
                        Dtg_Datos.Rows[i].Cells["Id"].Style.BackColor = Color.Yellow  ;
                    else
                        Dtg_Datos.Rows[i].Cells["Id"].Style.BackColor = Color.LightGreen;

                    if (Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString().Length > 0)
                    {
                        if (ExisteRegistro(Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString(), "L") == false)
                            Dtg_Datos.Rows[i].Cells["LoteAza"].Style.BackColor = Color.LightSalmon;
                        else
                            Dtg_Datos.Rows[i].Cells["Lote"].Style.BackColor = Color.LightGreen;
                    }
                    else
                        if (ExisteRegistro(Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString(), "L") == false)
                        Dtg_Datos.Rows[i].Cells["Lote"].Style.BackColor = Color.LightSalmon;
                    else
                        Dtg_Datos.Rows[i].Cells["Lote"].Style.BackColor = Color.LightGreen;



                }
            }
        }

        private void DescargaPdfs_WB_PorViaje(string iCodigo )
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
            string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();string lPathCertificados = "";

            lPathCertificados = ConfigurationManager.AppSettings["PathCertificados"].ToString();

            string lSql = string.Concat(" select cc.*  from certificadospaquete cp ,   DetallePaquetesPieza d , viaje v , CertificadosColadas cc  ");
            lSql = string.Concat(lSql, " where d.idviaje =v.id  and  IdPaquete = d.id  and cc.lote =cp.lote  and  codigo='", iCodigo,"'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                try
                {
                    lTbl = lDts.Tables[0].Copy();

                    //PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString());
                        lLote = lTbl.Rows[i]["lote"].ToString();
                        lNombreArc = string.Concat(lLote, "_C.pdf");
                        lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                        lLlave = lLot.ObtieneLlave(url);
                        url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);

                        cliente = new WebClient();
                        cliente.DownloadFile(url, lPathFin);

                        System.Threading.Thread.Sleep(300);

                        //2.- Informe
                        lNombreArc = string.Concat(lLote, "_I.pdf");
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Informe"].ToString());
                        lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                        lLlave = lLot.ObtieneLlave(url);
                        url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);
                        cliente = new WebClient();
                        cliente.DownloadFile(url, lPathFin);

                        //Persistimos los datos procesado 
                        lSql = string.Concat("  Update  CertificadosColadas   set  estado='OK' where lote='", lLote, "'");
                        lDts = lPx.ObtenerDatos(lSql);
                  
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

            }

            //  MessageBox.Show("FIN");

        }



        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            CargaDatos( );
        }


        private void Btn_ActualizaLote_Click(object sender, EventArgs e)
        {
            string lLote = ""; EnviosAutomaticos lEnv = new EnviosAutomaticos();

            if (Tx_lote.Text.Trim().Length > 0)
                lLote = Tx_lote.Text;
            else
                lLote = Lbl_Lote.Text;

            if (lEnv.EsLoteAza(lLote) == true)
            {
                if (lLote.Trim().Length > 0)
                {
                   
                       ActualizaLote(lLote);
                    //MessageBox.Show(" Despues de ActualizaLote(lLote); Linea 393 ");
                Lbl_Lote.Text = "";
                CargaDatos();
                }
             
            }
            else
            {
                if (lLote.Trim().Length > 0)
                {

                    DescargaPdfs_WB_CAP(lLote);
                    Lbl_Lote.Text = "";
                    CargaDatos();
                }
            }
           
        }
        private void ActualizaLoteForzado(string iLote)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // 0.- Revisamos si esta en tabla certificadosColadas.
            lSql = string.Concat("select * from certificadosColadas  where  lote='", iLote, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count == 0))
            {
                //   Revisamos si esta en tabla Lotes de Mysql
                lSql = string.Concat("select * from lotes  where  lote='", iLote, "'");
                lTbl = lLot.CargarDatos(lSql);
                if (lTbl.Rows.Count > 0)
                {
                    lSql = string.Concat(" delete from lotes  where  lote='", iLote, "'");
                    lTbl = lLot.CargarDatos(lSql);
                }
                lLot.GrabarRegistro(iLote, 0);
                lLot.ObtenerDatosCertificados_WB();
                this.ActualizaCetificados_Revisado(iLote);
                DescargaPdfs_WB(iLote);
            }
            else
            {
                ActualizaCetificados(iLote);
                DescargaPdfs_WB(iLote);
            }


        }

        private void ActualizaLoteForzado_V2(string iLote)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // 0.- Revisamos si esta en tabla certificadosColadas.
            //lSql = string.Concat("select * from certificadosColadas  where  lote='", iLote, "'");
            //lDts = lPx.ObtenerDatos(lSql);
            //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count == 0))
            //{
                //   Revisamos si esta en tabla Lotes de Mysql
                lSql = string.Concat("select * from lotes  where  lote='", iLote, "'");
                lTbl = lLot.CargarDatos(lSql);
                if (lTbl.Rows.Count > 0)
                {
                    lSql = string.Concat(" delete from lotes  where  lote='", iLote, "'");
                    lTbl = lLot.CargarDatos(lSql);
                }
                lLot.GrabarRegistro(iLote, 0);
                lLot.ObtenerDatosCertificados_WB();
                this.ActualizaCetificados_Revisado(iLote);
                DescargaPdfs_WB(iLote);
            //}
            //else
            //{
            //    ActualizaCetificados(iLote);
            //    DescargaPdfs_WB(iLote);
            //}


        }


        private void ActualizaLote(string iLote)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // 0.- Revisamos si esta en tabla certificadosColadas.
            lSql = string.Concat("select * from certificadosColadas  where  lote='", iLote, "'");
            lDts = lPx.ObtenerDatos(lSql);

            //MessageBox.Show(lSql );

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count == 0))
            {
                //   Revisamos si esta en tabla Lotes de Mysql
                lSql = string.Concat("select * from lotes  where  lote='", iLote, "'");
                lTbl = lLot.CargarDatos (lSql);
                if (lTbl.Rows.Count > 0)
                {
                    lSql = string.Concat(" delete from lotes  where  lote='", iLote, "'");
                    lTbl = lLot.CargarDatos(lSql);
                }

                    lLot.GrabarRegistro(iLote, 0);
                    lLot.ObtenerDatosCertificados_WB();
                    ActualizaCetificados(iLote);
                //MessageBox.Show("ANtes deDescargaPdfs_WB ");
                    DescargaPdfs_WB(iLote);
                //MessageBox.Show("Despues  deDescargaPdfs_WB ");

            }
            else
            {
                ActualizaCetificados(iLote);
                DescargaPdfs_WB(iLote);
            }


        }
        private void DescargaPdfs_WB_CAP(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
      string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes(); string lLoteFinal = "";

            if (iLote.IndexOf("00000") > -1)
                lLoteFinal = iLote.Replace("00000", "");
            else
                lLoteFinal = iLote;

            string lSql = string.Concat("  select * from certificadoscoladasCap  where  lote='", lLoteFinal, "'");
            //lSql = string.Concat(lSql, " publicacionInforme is not  null  and estado is null ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                try
                {
                    lTbl = lDts.Tables[0].Copy();


                    //PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        if (i == 1)
                            i = lTbl.Rows.Count - 1;

                          url = System.IO.Path.Combine(lTbl.Rows[i]["UrlDocumento"].ToString());
                        lLote = string.Concat (lTbl.Rows[i]["lote"].ToString().Trim (),"_", lTbl.Rows[i]["IdDocumento"].ToString());
                        if (lTbl.Rows[i]["TipoDocumento"].ToString().ToUpper().Equals("INFORME"))
                                 lNombreArc = string.Concat(lLote.Trim (), "_I.pdf");

                        if (lTbl.Rows[i]["TipoDocumento"].ToString().ToUpper().Equals("CERTIFICADO"))
                            lNombreArc = string.Concat(lLote.Trim() , "_C.pdf");

                        lPathFin = System.IO.Path.Combine(@"C:\TMP\Calidad\Docs\CAP\", lNombreArc);

                        url = lTbl.Rows[i]["UrlDocumento"].ToString();
                        cliente = new WebClient();
                        cliente.DownloadFile(url, lPathFin);

                        System.Threading.Thread.Sleep(300);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

            }

            //  MessageBox.Show("FIN");

        }

        public void DescargaPdfs_WB(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";string lPathCertificados = "";
            string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";string lTmp = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            string lSql = string.Concat("  select * from CertificadosColadas  where  lote='",iLote ,"'" );
            //lSql = string.Concat(lSql, " publicacionInforme is not  null  and estado is null ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                try
                {
                    lTbl = lDts.Tables[0].Copy();
                    //MessageBox.Show(string.Concat("Comienza la descarga del certiticado:", iLote));

                    lPathCertificados = ConfigurationManager.AppSettings["PathCertificados"].ToString();

                    //PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString().Replace ("verifica","docs"));
                        lLote = lTbl.Rows[i]["lote"].ToString();
                    

                        
                        lNombreArc = string.Concat(lLote, "_C.pdf");
                   
                        lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                        //lLlave = lLot.ObtieneLlave(url);
                        //url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);


                        // revisamos si esta en el directorio de los certificados
                        if (File.Exists(lPathFin) == false)
                        {
                            cliente = new WebClient();
                            //cliente.Headers.Add("ContentLength", "900000");
                            cliente.DownloadFile(url, lPathFin);
                            System.Threading.Thread.Sleep(200);
                            // Obtenrmos el tamaño de una Archivo
                            FileInfo lInfoArch = new FileInfo(lPathFin);
                            if ((lInfoArch.Length / 1000) < 50 )
                                MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));
                        }
                        System.Threading.Thread.Sleep(200);

                            //2.- Informe
                            lNombreArc = string.Concat(lLote, "_I.pdf");
                            url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Informe"].ToString().Replace("verifica", "docs"));

                            lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                        //lLlave = lLot.ObtieneLlave(url);
                        //url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);
                        if (File.Exists(lPathFin) == false)
                        {
                            cliente = new WebClient();
                            //cliente.Headers.Add("ContentLength", "900000");
                            cliente.DownloadFile(url, lPathFin);
                            System.Threading.Thread.Sleep(200);
                            // Obtenrmos el tamaño de una Archivo
                            FileInfo lInfoArch = new FileInfo(lPathFin);
                            if ((lInfoArch.Length / 1000) < 50)
                                MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));
                        }

                        //cliente = new WebClient();
                        //    //cliente.Headers.Add("ContentLength", "0");
                        //    cliente.DownloadFile(url, lPathFin);
                       
                        //Persistimos los datos procesado 
                        lSql = string.Concat("  Update  CertificadosColadas   set  estado='OK' where lote='", lLote, "'");
                        lDts = lPx.ObtenerDatos(lSql);
                        }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

            }

            //  MessageBox.Show("FIN");

        }

        private string ObtenerColada(string iColada)
        {
            string lRes = "";

            lRes = iColada.Replace("{", "");
            //lRes = iColada.Replace("", "");

            return lRes.Trim (); 

        }
        private void ActualizaCetificados(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; int lCont = 0;int k = 0;
            string lSql = "";   string lDato = ""; string lColadaTmp = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes(); string lLoteColada = "";

            lSql = string.Concat(" select * from lotes where lote='", iLote, "'");
            lTbl = lLot.CargarDatos(lSql);
            if (lTbl.Rows.Count == 0)
            {
                //MessageBox.Show("No hay datos a procesar, Revisar", " Avisos Sistema");
            }
            else
            {
                string[] separatingStrings = { "}," };

                //MessageBox.Show( string .Concat ( " ActualizaCetificados    Linea 641  " , lSql , "   " ));

                //PB.Maximum = Dtg_Datos.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    //MessageBox.Show(string.Concat ("  Respuesta:  " , lTbl.Rows[i]["Respuesta"].ToString() ,"  "));

                    if (lTbl.Rows[i]["Respuesta"].ToString ().Length>5 )
                    {
                        if (iLote.Equals (lTbl.Rows[i]["lote"].ToString()))
                        {
                            lDato = lTbl.Rows[i]["Respuesta"].ToString();
                            if (lDato .IndexOf (iLote )>-1)
                            {
                                string[] lpartes = lDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                                if (lpartes.Length > 0)
                                {
                                    // Hay mas de un colada en la definicion
                                    for (lCont = 0; lCont < lpartes.Length; lCont++)
                                    {
                                        string[] separatingStrings2 = { ":{" };
                                        lDato = lpartes[lCont].ToString();
                                        string[] lpartes2 = lDato.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                        if (lpartes.Length > 0)
                                        {
                                            lLoteColada = ObtenerColada(lpartes2[0].ToString());
                                            if (lLoteColada.IndexOf(iLote) > -1)
                                            {
                                                string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                if (lPartesColada.Length == 5)
                                                {
                                                    lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                }
                                            }      
                                        }
                                    }
                                }
                                else
                                {
                                    // NO hay solo una Colada en la definicion

                                }

                            }
                            else
                             {
                                // Se debe verificar el caso de coladas madres e Hijas.
                                //"2613649302-03-04":{
                                // "Colada":"2613649302-03-04","Informe":"http://repositorio.idiem.cl/verifica/ej1vH8V1Yc",
                                //"Publicacion_Informe":"2021-03-30 15:07:45","Certificado":"http://repositorio.idiem.cl/verifica/1uxkMGWQme",
                                //"Publicacion_Certificado":"2021-03-30 18:23:59"}
                                // Colada solicitada: 2613649303  , Respuesta: "2613649302-03-04"
                                string[] separatingStrings2 = { ":{" };
                                string[] lpartes = lDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                                if (lpartes.Length > 0)
                                {
                                    for (lCont = 0; lCont < lpartes.Length; lCont++)
                                    {
                                        string[] lpartes2 = lpartes[lCont ].Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                        lLoteColada = ObtenerColada(lpartes2[0].ToString());
                                        if (lLoteColada.IndexOf("-") > -1)
                                        {
                                            string[] lPartesColada = (lLoteColada.Split(new Char[] { '-' }));
                                            for (k=0; k<lPartesColada .Length; k++)
                                            {
                                                if (k == 0)
                                                {
                                                    lColadaTmp = lPartesColada[k].ToString().Trim ();
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                          lPartesColada = (lpartes [lCont].ToString ().Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            k = lPartesColada.Length;
                                                        }
                                                    }
                                                }
                                                   
                                                else
                                                {
                                                    //lColadaTmp = lPartesColada[k].ToString();
                                                    lDato = lColadaTmp.Substring(0, lColadaTmp.Length - 2);
                                                    lColadaTmp = string.Concat(lDato, lPartesColada[k].ToString());
                                                    //lColadaTmp = lPartesColada[k].ToString();
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                        lPartesColada = (lpartes[lCont].ToString().Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            k = lPartesColada.Length;
                                                        }
                                                    }

                                                }


                                            }

                                        }
                                        else {
                                            if (lLoteColada.IndexOf(iLote) > -1)
                                            {
                                                string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                if (lPartesColada.Length == 5)
                                                {
                                                    lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                }
                                            }
                                            else   // para el caso de  261359560203
                                            {
                                                if (lLoteColada.Length == 14)
                                                {
                                                    lColadaTmp = lLoteColada.Substring(0, 11);
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                        string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lColadaTmp = lLoteColada.Substring(0, 9);
                                                        lColadaTmp = string.Concat(lColadaTmp, lLoteColada.Substring(11,2));
                                                        if (lColadaTmp.IndexOf(iLote) > -1)
                                                        {
                                                            string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                            if (lPartesColada.Length == 5)
                                                            {
                                                                lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                             



                                    }
                                    ////string[] separatingStrings2 = { ":{" };
                                    //lDato = lpartes[0].ToString();
                                    //lpartes = lDato.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                    //// Se debe persistir para poder informarlo via  Mail
                                    //lLot.PesisteColadasErroneas(iLote, lDato);
                                }

                              

                            }



                        }                      
                    }
                }
            }
        }


        private void ActualizaCetificados_Revisado (string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; int lCont = 0; int k = 0;
            string lSql = ""; string lDato = ""; string lColadaTmp = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes(); string lLoteColada = "";

            lSql = string.Concat(" select * from lotes where lote='", iLote, "'");
            lTbl = lLot.CargarDatos(lSql);
            if (lTbl.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos a procesar, Revisar", " Avisos Sistema");
            }
            else
            {
                string[] separatingStrings = { "}," };


                //PB.Maximum = Dtg_Datos.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    if (lTbl.Rows[i]["Respuesta"].ToString().Length > 5)
                    {
                        if (iLote.Equals(lTbl.Rows[i]["lote"].ToString()))
                        {
                            lDato = lTbl.Rows[i]["Respuesta"].ToString();
                            if (lDato.IndexOf(iLote) > -1)
                            {
                                string[] lpartes = lDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                                if (lpartes.Length > 0)
                                {
                                    // Hay mas de un colada en la definicion
                                    for (lCont = 0; lCont < lpartes.Length; lCont++)
                                    {
                                        string[] separatingStrings2 = { ":{" };
                                        lDato = lpartes[lCont].ToString();
                                        string[] lpartes2 = lDato.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                        if (lpartes.Length > 0)
                                        {
                                            lLoteColada = ObtenerColada(lpartes2[0].ToString());
                                            if (lLoteColada.IndexOf(iLote) > -1)
                                            {
                                                string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                if (lPartesColada.Length == 5)
                                                {
                                                    lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // NO hay solo una Colada en la definicion

                                }

                            }
                            else
                            {
                                // Se debe verificar el caso de coladas madres e Hijas.
                                //"2613649302-03-04":{
                                // "Colada":"2613649302-03-04","Informe":"http://repositorio.idiem.cl/verifica/ej1vH8V1Yc",
                                //"Publicacion_Informe":"2021-03-30 15:07:45","Certificado":"http://repositorio.idiem.cl/verifica/1uxkMGWQme",
                                //"Publicacion_Certificado":"2021-03-30 18:23:59"}
                                // Colada solicitada: 2613649303  , Respuesta: "2613649302-03-04"
                                string[] separatingStrings2 = { ":{" };
                                string[] lpartes = lDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                                if (lpartes.Length > 0)
                                {
                                    for (lCont = 0; lCont < lpartes.Length; lCont++)
                                    {
                                        string[] lpartes2 = lpartes[lCont].Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                        lLoteColada = ObtenerColada(lpartes2[0].ToString());
                                        if (lLoteColada.IndexOf("-") > -1)
                                        {
                                            string[] lPartesColada = (lLoteColada.Split(new Char[] { '-' }));
                                            for (k = 0; k < lPartesColada.Length; k++)
                                            {
                                                if (k == 0)
                                                {
                                                    lColadaTmp = lPartesColada[k].ToString();
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                        lPartesColada = (lpartes[lCont].ToString().Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            k = lPartesColada.Length;
                                                        }
                                                    }
                                                }

                                                else
                                                {
                                                    //lColadaTmp = lPartesColada[k].ToString();
                                                    lDato = lColadaTmp.Substring(0, lColadaTmp.Length - 2);
                                                    lColadaTmp = string.Concat(lDato, lPartesColada[k].ToString());
                                                    //lColadaTmp = lPartesColada[k].ToString();
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                        lPartesColada = (lpartes[lCont].ToString().Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            k = lPartesColada.Length;
                                                        }
                                                    }

                                                }


                                            }

                                        }
                                        else
                                        {
                                            if (lLoteColada.IndexOf(iLote) > -1)
                                            {
                                                string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                if (lPartesColada.Length == 5)
                                                {
                                                    lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                }
                                            }
                                            else   // para el caso de  261359560203
                                            {
                                                if (lLoteColada.Length == 14)
                                                {
                                                    lColadaTmp = lLoteColada.Substring(0, 11);
                                                    if (lColadaTmp.IndexOf(iLote) > -1)
                                                    {
                                                        string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                        if (lPartesColada.Length == 5)
                                                        {
                                                            lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lColadaTmp = lLoteColada.Substring(0, 9);
                                                        lColadaTmp = string.Concat(lColadaTmp, lLoteColada.Substring(11, 2));
                                                        if (lColadaTmp.IndexOf(iLote) > -1)
                                                        {
                                                            string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                                            if (lPartesColada.Length == 5)
                                                            {
                                                                lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }




                                    }
                                    ////string[] separatingStrings2 = { ":{" };
                                    //lDato = lpartes[0].ToString();
                                    //lpartes = lDato.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                                    //// Se debe persistir para poder informarlo via  Mail
                                    //lLot.PesisteColadasErroneas(iLote, lDato);
                                }



                            }



                        }
                    }
                }
            }
        }


        private void Dtg_Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex; string lLote = ""; string lEV = "";
            if (lIndex > -1)
            {
                if (Dtg_Datos .Columns .Count ==5)
                    lLote = Dtg_Datos.Rows[lIndex].Cells["lote"].Value.ToString();
                else
                          lLote = Dtg_Datos.Rows[lIndex].Cells["loteAza"].Value.ToString();

                if (lLote.ToString() == "")
                    lLote = Dtg_Datos.Rows[lIndex].Cells["lote"].Value.ToString();

                Lbl_Lote.Text = lLote;

                lEV = Dtg_Datos.Rows[lIndex].Cells["EtiquetaVinc"].Value.ToString();
                if (lEV.Equals("N"))
                {
                    mDiametro = Dtg_Datos.Rows[lIndex].Cells["Diametro"].Value.ToString();
                    mIdEtiqueta = Dtg_Datos.Rows[lIndex].Cells["Id"].Value.ToString();
                    Btn_CorrigueEV.Enabled = true;
                }
                else
                    Btn_CorrigueEV.Enabled = false;

                //Reparamos Etiquetas no vinculadas
                Lbl_IdPaquete.Text  = Dtg_Datos.Rows[lIndex].Cells["Id"].Value.ToString();
                Lbl_Diam .Text = Dtg_Datos.Rows[lIndex].Cells["Diametro"].Value.ToString();
                Lbl_Kgs .Text = Dtg_Datos.Rows[lIndex].Cells["KgsPaquete"].Value.ToString();
                Btn_ReparaET.Enabled = true;
            }
        }

        private void Frm_CertificacionViaje_Load(object sender, EventArgs e)
        {
            CargaDatos();
            if (mSoloVer == "N")
            {
                //ActualizaRegistros();
                ActualizaRegistros_V2();
                System.Threading.Thread.Sleep(1000);
                this.Close();
            }
                
        }

        private void Btn_lotesProblema_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // 0.- Revisamos si esta en tabla certificadosColadas.
            lSql = string.Concat("select   v.codigo It, d.Etiqueta , p.diametro,  lote  ,cp.fechaRegistro FechaRegistro ");
            lSql = string.Concat(lSql, "  	 from  CertificadosPaquete cp  , detallepaquetesPieza d, viaje v , piezas p ");
            lSql = string.Concat(lSql, "   where d.idviaje=v.id and d.id=cp.IdPaquete   and p.id=d.idpieza  and ");
            lSql = string.Concat(lSql, "   not exists (select * from certificadosColadas cc  where    cc.lote=cp.lote  )  ");
            lSql = string.Concat(lSql, "   and isnull((Select  1 from lotes l where l.lote=cp.lote) ,0)=1   ");
            lSql = string.Concat(lSql, "   and not  Codigo like '%IN-%' and cp.fechaRegistro>'01/03/2020 00:00:01'    ");
            lSql = string.Concat(lSql, "   order by 5 asc  " );
            lSql = string.Concat(lSql, "  ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                this.Dtg_Datos.DataSource = lTbl;
            }
        }

        private void Btn_ActualizaPorViaje_Click(object sender, EventArgs e)
        {
            DescargaPdfs_WB_PorViaje(Tx_Codigo.Text);
            new Clases.Cls_EnvioDoc().GeneraDocumentacionEnCarpeta(Tx_Codigo.Text);
            Revisa_ArchivosEnServidor(Tx_Codigo.Text, "");
            MessageBox.Show(" Proceso Finalizado ");
        }

        private void Btn_CP_Click(object sender, EventArgs e)
        {
           InsertaCertificadosPaquete();


        }

        private void InsertaCertificadosPaquete()
        {
            int i = 0;string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            string lLote = "";DataSet lDts = new DataSet();
            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                if (Dtg_Datos.Rows[i].Cells["Id"].Style.BackColor == Color.Yellow)
                {
                    lSql = string.Concat(" Select * from   certificadosPaquete where IdPaquete=", Dtg_Datos.Rows[i].Cells["Id"].Value.ToString());
                    lDts=lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count == 0))
                    {
                        lSql = " Insert into certificadosPaquete(lote, IdPaquete, fechaRegistro) values ('";
                        lLote = Dtg_Datos.Rows[i].Cells["LoteAZA"].Value.ToString();
                        if (lLote.Trim().Length == 0)
                            lLote = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();


                        lSql = string.Concat(lSql, lLote.ToString(), "',");
                        lSql = string.Concat(lSql, Dtg_Datos.Rows[i].Cells["Id"].Value.ToString(), ", getdate()) ");
                        lPx.ObtenerDatos(lSql);
                    }
                    else
                    {
                        if (lDts.Tables[0].Rows[0]["Lote"].ToString().Trim().Length == 0)
                        {
                            lSql = string.Concat (" delete  from   certificadosPaquete where idPaquete= ", Dtg_Datos.Rows[i].Cells["Id"].Value.ToString());
                            lDts = lPx.ObtenerDatos(lSql);

                            lSql = " Insert into certificadosPaquete(lote, IdPaquete, fechaRegistro) values ('";
                            lLote = Dtg_Datos.Rows[i].Cells["LoteAZA"].Value.ToString();
                            if (lLote.Trim().Length == 0)
                                lLote = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();


                            lSql = string.Concat(lSql, lLote.ToString(), "',");
                            lSql = string.Concat(lSql, Dtg_Datos.Rows[i].Cells["Id"].Value.ToString(), ", getdate()) ");
                            lPx.ObtenerDatos(lSql);
                        }

                    }
                   
                }

            }
            Inicialida(mViaje,mSoloVer  );
            CargaDatos();
        }

        private void Btn_CorrigueEV_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lPeso = "0";

            // de momento solo diametro 16 
            if (mDiametro.Equals("16"))
            {
                lSql = string.Concat (" select *   from CertificadosPaquete cp  where   cp.IdPaquete=", mIdEtiqueta) ;
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    if (lTbl.Rows[0]["Lote"].ToString().Trim().Length == 0)
                    {
                        lSql = string.Concat(" update  CertificadosPaquete  set Lote='2613049202'      where   IdPaquete=", mIdEtiqueta);
                        lDts = lPx.ObtenerDatos(lSql);
                        lSql = string.Concat("   select KgsPaquete  from DetallePaquetesPieza where id=", mIdEtiqueta);
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            lTbl = lDts.Tables[0].Copy();
                            lPeso = lTbl.Rows[0]["KgsPaquete"].ToString();
                            lSql = string.Concat(" insert into  EtiquetasVinculadas (IdEtiquetaTO ,IdQR , Tipo,KgsVinculados ,FechaRegistro ,IdMaquinaProduce ) ");
                            lSql = string.Concat(lSql, " values (",mIdEtiqueta,", 7699 ,'D',", lPeso,", getdate(),0)  ");
                            lDts = lPx.ObtenerDatos(lSql);
                        }
                    }
                }
             }
            Btn_CorrigueEV.Enabled = false;
        }

        private void Btn_ReparaET_Click(object sender, EventArgs e)
        {
            ReparaEtiquetaNOVincualda(Lbl_IdPaquete.Text, Lbl_Diam.Text, Lbl_Kgs.Text);
        }

        private void ReparaEtiquetaNOVincualda(string IdEtiquetaTO, string iDiametro, string iKgs)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lIdQr = ""; string lLote = ""; string idMaqProd = "";

            lSql = "select * from EtiquetaAZA where TipoEtiqueta ='D' and Obs='Para regularizacon de coladas por error de sistema' ";
            lSql = string.Concat(lSql, " and Diametro=", iDiametro);
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                lIdQr = lTbl.Rows[0]["Id"].ToString();
                lLote = lTbl.Rows[0]["Lote"].ToString();

                lSql = string.Concat("Select * from pieza_produccion where pie_etiqueta_Pieza=", IdEtiquetaTO);
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    idMaqProd = lTbl.Rows[0]["Pie_maquina"].ToString();
                }


                //Actualizamos el nuevo IdQr en las tablas de Produccion
                lSql = string.Concat(" Update pieza_produccion set Pie_etiqueta_colada=", lIdQr, "  where  pie_etiqueta_Pieza=", IdEtiquetaTO);
                lDts = lPx.ObtenerDatos(lSql);
                lSql = string.Concat(" Update Log_pieza_produccion set log_etiqueta_colada=", lIdQr, "  where  log_etiqueta_Pieza=", IdEtiquetaTO);
                lSql = string.Concat(lSql, " and Log_estado='O40'  and ISNUMERIC (log_etiqueta_colada)=1 ");
                lDts = lPx.ObtenerDatos(lSql);

                lSql = string.Concat(" Insert Into EtiquetasVinculadas ( IdEtiquetaTo, IdQr, Tipo,KgsVinculados,IdmaquinaProduce) ");
                lSql = string.Concat(lSql, " Values (", IdEtiquetaTO, ",", lIdQr, ",'P','", iKgs, "',", idMaqProd, ")");
                lDts = lPx.ObtenerDatos(lSql);

                //Verificamos si existe, 
                lSql = string.Concat(" Select  * from CertificadosPaquete where IdPaquete =", IdEtiquetaTO);
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lSql = string.Concat(" Update  CertificadosPaquete   set    lote='", lLote, "' where IdPaquete =", IdEtiquetaTO);
                }
                else
                {
                    lSql = string.Concat(" insert into  CertificadosPaquete ( lote , Idpaquete, fecharegistro ) values ('", lLote, "',", IdEtiquetaTO, ",Getdate())");
                }
                lDts = lPx.ObtenerDatos(lSql);
                CargaDatos();

            }
            else
                MessageBox.Show("NO hay Etiquetas para Reparar la Inconsistenacia", "Avisos Sistema");
        }

        private void Btn_VerLote_Click(object sender, EventArgs e)
        {
            Calidad.Frm_WB_Ver lForm = new Frm_WB_Ver(); string lTxLote = "";

            if (Tx_lote.Text.Trim().Length > 0)
                lTxLote = Tx_lote.Text;
            else
                lTxLote = Lbl_Lote.Text;


            lForm.CargaTicket(lTxLote);
            lForm.ShowDialog();
            //CargaTicket
        }

        private void Btn_RevisaHD_Click(object sender, EventArgs e)
        {
            Revisa_ArchivosEnServidor(Tx_Codigo.Text,"");
        }

        private Boolean ExisteArchivoEnServer(string iLote, string iSuc , string iPathSigla, string iCodigo, string iIdColada, string iIdEtiquetaTO)
        {
            Boolean lRes = false; EnviosAutomaticos lEnv = new EnviosAutomaticos(); 
            string lPathCalidad = ""; DataTable lTblLotes = new DataTable(); string lPathInfLote = "";
            string[] separators = { "-" }; string lPathCertLote = ""; DataSet lDts = new DataSet();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";int i = 0;
            DataTable lTblColadas = new DataTable();DataRow lFila = null; 

            lEnv.mGenerandoArchivo = true;

            lTblColadas.Columns.Add("Colada", Type.GetType("System.String"));
            //VErificamos si tiene una o varias coladas asociadas
            if (iIdColada.Equals("-1"))
            {
                lSql = string.Concat(" select distinct Lote  from EtiquetasVinculadas v , EtiquetaAZA e where v.IdQR =e.id  and   IdEtiquetaTO =", iIdEtiquetaTO);
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblLotes = lDts.Tables[0].Copy();
                    for (i = 0; i < lTblLotes.Rows.Count; i++)
                    {
                        lFila = lTblColadas.NewRow(); lFila["Colada"] = lTblLotes.Rows[i]["Lote"].ToString(); lTblColadas.Rows.Add(lFila);
                    }
                }

             }
            else  //HAy solo una colada para la Etiqueta
            {
                lFila = lTblColadas.NewRow(); lFila["Colada"] = iLote; lTblColadas.Rows.Add(lFila);
            }

            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
            for (i = 0; i < lTblColadas.Rows.Count; i++)
            {    
                if (lEnv.EsLoteAza(iLote) == true)
                {
                    lPathInfLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), string.Concat(lTblColadas.Rows [i]["Colada"].ToString (), "_I.pdf"));
                    lPathCertLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), string.Concat(lTblColadas.Rows[i]["Colada"].ToString(), "_C.pdf"));
                    if ((File.Exists(lPathInfLote) == true) && (File.Exists(lPathCertLote) == true))
                    {
                        lRes = true;
                    }
                    else
                    {
                        lRes = false;
                        i = lTblColadas.Rows.Count;
                    }
                }
                else
                {
                    DataView lVista = null; string lNomLoteInf = ""; string lNomLoteCert = ""; int lCont = 0;
                    lSql = string.Concat("  Select * from certificadosColadasCap where lote='", iLote, "' ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTblLotes = lDts.Tables[0].Copy();
                        lVista = new DataView(lTblLotes, "", "", DataViewRowState.CurrentRows);
                        if (lVista.Count > 0)
                        {
                            for (lCont = 0; lCont < lVista.Count; lCont++)
                            {
                                if (lVista[lCont]["TipoDocumento"].ToString().ToUpper().Equals("INFORME"))
                                    lNomLoteInf = string.Concat(iLote, "_", lVista[lCont]["IdDocumento"].ToString(), "_I.pdf");
                                else
                                    lNomLoteCert = string.Concat(iLote, "_", lVista[lCont]["IdDocumento"].ToString(), "_C.pdf");

                            }
                        }
                    }
                    lPathInfLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), lNomLoteInf);
                    lPathCertLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), lNomLoteCert);
                    if ((File.Exists(lPathInfLote) == true) && (File.Exists(lPathCertLote) == true))
                    {
                        lRes = true;
                    }
                    else
                    {
                        lRes = false;
                    }
                }
            }
            return lRes;
        }

        public  string   Revisa_ArchivosEnServidor(string iCodigo, string iObra)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;  string lRes = "S";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = ""; DataTable lTblDetalle = new DataTable();
            DataTable TblUC = new DataTable(); string lLote = ""; Boolean lPuedeSeguir = true;string lTmp = "";
            //MailMessage MMessage = new MailMessage();
            string lLotesEnviados = ""; 
            lSql = String.Concat("  SP_Consultas_WS  192,'", iCodigo, "','','','',',','',''");
            EnviosAutomaticos lEnv = new EnviosAutomaticos(); string lLog = "S";
            string lPathCalidad = ""; DataTable lTblLotes = new DataTable();
            Clases.Cls_EnvioDoc lDoc = new Clases.Cls_EnvioDoc();

            try
            {
                lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
                lEnv.mGenerandoArchivo = true;
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblDetalle = lDts.Tables[0].Copy();


                    lTx = "";
                    if (lTblDetalle.Rows.Count > 0)
                    {
                        for (i = 0; i < lTblDetalle.Rows.Count; i++)
                        {
                            if (lTblDetalle.Rows[i]["LoteAza"].ToString().Trim().Length > 0)
                                lLote = lTblDetalle.Rows[i]["LoteAza"].ToString();
                            else
                                lLote = lTblDetalle.Rows[i]["Lote"].ToString();
                            if (lEnv.VerificaLotePaquete(lLote, lTblDetalle.Rows[i]["Id"].ToString()) == "N")
                            {
                                lPuedeSeguir = false;
                                i = lTblDetalle.Rows.Count-1;
                                 lLog = string .Concat ("lEnv.VerificaLotePaquete=N - IdPaq=", lTblDetalle.Rows[i]["Id"].ToString(),Environment .NewLine);
                            }
                        }

                     if (lPuedeSeguir == true)
                        {

                            string lSuc = ""; string lPathCertificado = "";
                            string[] separators = { "-" }; string lPathInforme = "";
                            string[] lPartes = iCodigo.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            string lPathSigla = lPartes[0].ToString();

                            lSql = "  select distinct    s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s   ";
                            lSql = string.Concat(lSql, "    where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id   ");
                            lSql = string.Concat(lSql, " and  codigo='", iCodigo, "'");
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTbl = lDts.Tables[0].Copy();  // tabla con los lotes del viaje 
                                lSuc = string.Concat(lTbl.Rows[0]["Sucursal"].ToString(), "\\");
                                //lPathCalidad
                                lPathCertificado = Path.Combine(lPathCalidad, lSuc, lPathSigla, iCodigo.Replace("/", "_"), "CertificadoFabricacion.pdf");
                               lPathInforme = Path.Combine(lPathCalidad, lSuc, lPathSigla, iCodigo.Replace("/", "_"), "TrazabilidadColadas.pdf");
                               

                                if ((File.Exists(lPathCertificado) == true) && (File.Exists(lPathInforme) == true))
                                {
                                    //  Comenzamos a Iterar sobre el detalle de los Lotes Siempre deben haber 2  archivos 
                                    // Si la columna IdColada es -1 ==> pueden haber mas de una colada asociada y hay que procesarla
                                    for (i = 0; i < lTblDetalle.Rows.Count; i++)
                                    {
                                        if (lTblDetalle.Rows[i]["LoteAza"].ToString().Trim().Length > 0)
                                            lLote = string.Concat(lTblDetalle.Rows[i]["LoteAza"].ToString());//, "_");
                                        else
                                            lLote = string.Concat(lTblDetalle.Rows[i]["Lote"].ToString());//, "_");


                                        if (lLotesEnviados.IndexOf(lLote) == -1)
                                        {
                                                lTmp = lDoc.ExisteArchivoEnServer(lLote.Trim() , lSuc, lPathSigla, iCodigo, lTblDetalle.Rows[i]["idcolada"].ToString(), lTblDetalle.Rows[i]["id"].ToString());
                                            if (lTmp.Trim().Length == 0)
                                                lPuedeSeguir = true;
                                            else
                                                    lPuedeSeguir = false;


                                            if (lPuedeSeguir ==true )
                                            {
                                                lPuedeSeguir = true;
                                            }
                                            else
                                            {
                                                lPuedeSeguir = false;
                                                i = lTblDetalle.Rows.Count;
                                                lLog = string.Concat(lLog, " Revisa Archivos en Server: ", lTmp);
                                            }

                                           lLotesEnviados = string.Concat(lLotesEnviados, lLote, "-");
                                        }
                                    }


                                }
                                else
                                {
                                    lPuedeSeguir = false;
                                    lLog = string.Concat(lLog, " Archivo Generados NO Encontrados  ", lPathCertificado, " - ", lPathInforme, Environment.NewLine);
                                }



                                if (lPuedeSeguir == true)
                                {
                                    //persistimo el envio para no enviarlo nuevamente
                                    lSql = String.Concat("  Update viaje set mailCalidadEnviado=null where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                    Tx_Codigo.BackColor = Color.LightGreen;
  
                                }
                                else
                                {

                                    Tx_Codigo.BackColor = Color.LightSalmon;
                                    //MessageBox.Show(string.Concat("Detalle: ", lLog), "Avisos Sistema");
                                    lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                }
                            }
                        }
                        else
                        {
                            Tx_Codigo.BackColor = Color.LightSalmon;
                            //MessageBox.Show(string.Concat("Detalle: ", lLog), "Avisos Sistema");
                            //lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' where Codigo='", iCodigo, "' ");
                            //lDts = lPx.ObtenerDatos(lSql);
                        }
                    }
                }

                lRes = lLog;
            }
            catch (Exception iex)
            {
                MessageBox.Show(iex.Message.ToString(), "Avisos Sistema");
            }
            if ((lLog.Trim().Length > 0) && (lLog!="S"))
            {
                string lPath = String.Concat (  Application.StartupPath.ToString(), "\\LogEnvios.txt");
                lEnv.EscribeArchivoLog(lLog, lPath);
            }
            return lRes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string lPathFin = "";Calidad.Frm_WB lFrm = new Frm_WB(); string url = ""; string lNombreArc = "206878_I.pdf";
            DataSet lDts = new DataSet(); WebClient cliente = null;
            lPathFin = System.IO.Path.Combine(@"C:\TMP\Calidad\Docs\CAP", lNombreArc);

            //     < a href = "/cap/cake/ConsultaInformes/bajar/1826693/33863/32" > Ver </ a >
            //http://intranet.idiem.cl/cap/cake/ConsultaInformes/bajar/1826693/33863/32

            url = string.Concat("http://intranet.idiem.cl/cap/cake/ConsultaInformes/bajar/1826693/33863/32" );

            cliente = new WebClient();
            cliente.DownloadFile(url, lPathFin);
        }

        private void Btn_LoteForzado_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
     
            DataTable lTbl = new DataTable();
            DataSet lDts = new DataSet(); //DataTable lTbl = new DataTable();
            //ActualizaCetificados_Revisado();
            string lLote = ""; EnviosAutomaticos lEnv = new EnviosAutomaticos();

            if (Tx_lote.Text.Trim().Length > 0)
                lLote = Tx_lote.Text;
            else
                lLote = Lbl_Lote.Text;

            if (lEnv.EsLoteAza(lLote) == true)
            {
                if (lLote.Trim().Length > 0)
                {
                    ActualizaLoteForzado(lLote);
                    Lbl_Lote.Text = "";
                    //CargaDatos();
                }

            }else
             {
                lSql = String.Concat("  select  1 from  certificadoscoladasCap where lote='", lLote, "'");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count <2)) //Ya exsite 
                {
                    Frm_WB_CAP lFrm = new Frm_WB_CAP();
                    lFrm.IniciaForm(Tx_lote.Text, "", "");
                    lFrm.ShowDialog();
                    DescargaPdfs_WB_CAP(lLote);
                    Lbl_Lote.Text = "";
                    CargaDatos();
                }
              
                //System.Threading.Thread.Sleep(1000);

               
            }


        }

        private string ObtenerLoteProcesado(string iLote)
        {
            string lRes = "N";int i = 0;

            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                if  ((Dtg_Datos.Rows[i].Cells["LoteAza"].Value!=null ) && (Dtg_Datos.Rows[i].Cells["LoteAza"].Value.ToString().Equals(iLote)))
                {
                    if ((Dtg_Datos.Rows[i].Cells["UrlCertificado"].Value.ToString().Trim().Length > 0) && (Dtg_Datos.Rows[i].Cells["UrlInforme"].Value.ToString().Trim().Length > 0))
                        lRes = "S";
                    else
                        lRes = "N";
                }
            }


            return lRes;
        }


        private void Btn_ObtenerLotesV2_Click(object sender, EventArgs e)
        {
   
            int Cont = 0;string iLote = ""; string lLotes = ""; string lMsg = "";
            Lbl_Msg.Text = "";

            Btn_CP_Click(null, null);

            if (mTblTotes.Rows.Count > 0)
            {
                for (Cont = 0; Cont < mTblTotes.Rows.Count; Cont++)
                {
                    Lbl_Msg.Text = string .Concat ("Actualizando Lotes (",Cont , " de ", mTblTotes.Rows.Count.ToString ()) ;
                    Lbl_Msg.Refresh();                    this.Refresh();
                    iLote = mTblTotes.Rows[Cont]["Lote"].ToString();
                    Tx_lote.Text = iLote;
                    Lbl_Lote.Text = iLote;
                    // actualizamos tabla Mysql para buscar los lotes
                    //ActualizaLoteForzado_V2(iLote);

                     if (ObtenerLoteProcesado(iLote) == "N")
                    {
                        if (lLotes.IndexOf(iLote) == -1)
                        {
                            Btn_LoteForzado_Click(null, null);

                        }
                        lLotes = string.Concat(lLotes, " - ", iLote);
                        //DescargaPdfs_WB_PorViaje(Tx_Codigo.Text);
                    }
                }
            }
            // una vez que descargamos todos los lotes verificamos la informacion
            Lbl_Msg.Text = string.Concat(" Generando la documentacion " );
            Lbl_Msg.Refresh(); this.Refresh();
            new Clases.Cls_EnvioDoc().GeneraDocumentacionEnCarpeta(Tx_Codigo.Text);
            Lbl_Msg.Text = string.Concat(" Revisando consistencia de Información  ");
            Lbl_Msg.Refresh(); this.Refresh();
            lMsg = Revisa_ArchivosEnServidor(Tx_Codigo.Text, "");
            if (lMsg == "S")
            {
                Lbl_Msg.Text = string.Concat(" Copiando archivos al servidor central  ");
                Lbl_Msg.Refresh(); this.Refresh();
                CopiaAlServer(Tx_Codigo.Text);
                Lbl_Msg.Text = string.Concat("  Enviando correo al cliente con certificados ");
                Lbl_Msg.Refresh(); this.Refresh();
                EnviosAutomaticos lEnvio = new EnviosAutomaticos();
                lMsg = new EnviosAutomaticos().EnviaMail_Doc_Calidad_ZIP(Tx_Codigo.Text, mIdObra);
                if (lMsg.Trim().Length > 5)
                    Lbl_Msg.Text = lMsg;
                else
                {
                    new Clases.Cls_EnvioDoc().GeneraDocumentacionExtra_EnCarpeta(Tx_Codigo.Text);
                        Lbl_Msg.Text = string.Concat(" Finalizado OK.   ");
                }
                    

                Lbl_Msg.Refresh(); this.Refresh();
            }
            else
                Lbl_Msg.Text = lMsg;// string.Concat(" Error  al revisanr la información  ");
        }

        private void CopiaAlServer( string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lSucursal = ""; string lIt = "";

            lSql = string.Concat (" select s.nombre, codigo  from  viaje v, it, Sucursal s where v.idit=it.id and it.idsucursal=s.id and codigo='", iViaje,"'") ;
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count> 0))
            {
                lSucursal = lDts.Tables[0].Rows[0][0].ToString().ToUpper();
                lIt = lDts.Tables[0].Rows[0][1].ToString().ToUpper();

                // 1 Calama, 2 Bodega FE en Punta LC, 3 Santiago , 4 Concepción,5 Coronel
                // lPathLocal = @"C:\TMP\Calidad\Certificacion Automatica\SANTIAGO\";
                string lPathLocal = @"C:\TMP\Calidad\Certificacion Automatica\"; string lPathDirIT = ""; string lPathDirITServer = "";
                string lPathServer = @"R:\SANTIAGO\"; string lDir_IT = ""; string lPathFinal = "";
                string lPathFinalLoc = "";

                lPathLocal =string .Concat ("C:\\TMP\\Calidad\\Certificacion Automatica\\", lSucursal , "\\");
               // lPathServer = string .Concat ("R:\\", lSucursal, "\\");
        
            
                //lPathServer = @"R:\SANTIAGO\";
                //lPathLocal = @"C:\TMP\Calidad\Certificacion Automatica\SANTIAGO\";
                lPathLocal = string.Concat("C:\\TMP\\Calidad\\Certificacion Automatica\\", lSucursal, "\\");
                //@"\\192.168.1.193\One Drive\OneDrive - Torres Ocaranza Ltda\GeneracionDocumentosAutomatico
                lPathServer = string.Concat("\\192.168.1.191\\", lSucursal, "\\");
                //lPathServer = string.Concat(@"R:\", lSucursal, "\\");
                string[] separatingStrings2 = { "-" };
                string[] lpartes2 = iViaje.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);

                lDir_IT = lpartes2[0];
                lPathDirIT = Path.Combine(lPathLocal, lDir_IT);
                lPathDirITServer = Path.Combine(lPathServer, lDir_IT);
                lPathServer = Path.Combine(lPathServer, lDir_IT);
                lPathServer = string.Concat(lPathServer, "\\");

                //lPathServer = @"R:\SANTIAGO\5TO\";

                if (Directory.Exists(lPathServer) == false)
                    Directory.CreateDirectory(lPathServer);

          
                    ////lpartes2 = SubDir.Split(separatingStrings2, System.StringSplitOptions.RemoveEmptyEntries);
                    lPathFinal = Path.Combine(lPathDirITServer, iViaje .Replace("/","_"));
                    lPathFinalLoc = Path.Combine(lPathDirIT, iViaje.Replace("/", "_"));
                    DirectoryInfo di = new DirectoryInfo(lPathFinalLoc);

                    if (Directory.Exists(lPathFinal) == false)
                        Directory.CreateDirectory(lPathFinal);

                    lPathServer = lPathFinal;
                    lPathLocal = lPathFinalLoc;
                    foreach (var fi in di.GetFiles())
                    {
                        lPathFinal = Path.Combine(lPathServer, fi.ToString());
                        lPathFinalLoc = Path.Combine(lPathLocal, fi.ToString());
                        //if (File.Exists(lPathFinal) == false)
                            File.Copy(lPathFinalLoc, lPathFinal, true);
                    }
                }

                lSql = string.Concat(" update viaje set certificadosOK='S'   where  codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);

            }

        private void btn_GeneraProducciones_Click(object sender, EventArgs e)
        {
            int i = 0; DataTable lTbl = new DataTable(); string lSql = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();DataSet lDts = new DataSet();
            lSql = "   select top 1500 p.id IdPieza, d.id IdPaquete , p.idforma ,p.diametro ,    min(l.log_fecha) Corte ,max (l.log_fecha) Doblado ,  DATEDIFF (minute, min(l.log_fecha),max (l.log_fecha)) Tpo ,count(1)   ";
            lSql = string.Concat(lSql, " from piezas p, hojadespiece hd , viaje v , LOG_PIEZA_PRODUCCION l, detallepaquetesPieza d , Obras  o  ");
            lSql = string.Concat(lSql, "  where p.id_hd=hd.id and p.estado<>'00'  and d.idviaje=v.id  and p.fecha>getdate()-365  and o.id=hd.idObra ");
            lSql = string.Concat(lSql, "  and o.empresa='TO'  and  not exists ( select 1 from produccionPaquetes where  IdPaquete =d.id )  ");
            lSql = string.Concat(lSql, "  and idforma<>'1'  and v.nroguiaInet>0 and  LOG_ESTADO ='O40'and  l.LOG_ETIQUETA_PIEZA =d.id and p.id=d.IdPieza ");
            lSql = string.Concat(lSql, " group by  p.id, d.id , p.idforma ,p.diametro "); 
            lSql = string.Concat(lSql, "  having  count(1)=2  order by d.id  ");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {

                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lSql = " Insert into   produccionPaquetes  ( IdPieza, FechaCorte, FechaDoblado, IdPaquete,TiempoProduccion, idforma, diametro)";
                        lSql = string.Concat(lSql, " Values (", lTbl.Rows[i]["IdPieza"].ToString (),",'", lTbl.Rows[i]["Corte"].ToString());
                        lSql = string.Concat(lSql, "','" , lTbl.Rows[i]["Doblado"].ToString(), "',", lTbl.Rows[i]["IdPaquete"].ToString());
                        lSql = string.Concat(lSql, ",", lTbl.Rows[i]["Tpo"].ToString(), ",", lTbl.Rows[i]["idforma"].ToString());
                        lSql = string.Concat(lSql, ",", lTbl.Rows[i]["diametro"].ToString(), ")");
                        lPx.ObtenerDatos(lSql);

                    }
                }
            }

            
        }


        //}
    }

    
}
