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
using System.Xml.Serialization;

namespace Gestor_OC_Gerdau.Logistica
{
    public partial class Frm_BodegaPT : Form
    {
        public string mSucursal = "";
        public Frm_BodegaPT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PruebaIntegrar_BodegaPT();

        }

        private void query()
        {

        //            select codigo_inet, round(sum(kgspaquete), 0) Kg ,
        //(select sum(importeservicio) from ServiciosObra where o.id = IdObra and EsFacturable = 'S' ) Pr
        //    from DetallePaquetesPieza d, pieza_produccion, viaje v , it , Obras o
        //where d.id = pie_etiqueta_pieza and pie_avance = 100 and v.id = d.idviaje and v.idit = it.id
        //and PIE_FECHA_PRODUCCION > '23/12/2021 00:01'   and o.id = it.idobra--and d.id = 2444087
        //and it.IdSucursal = 4
        //group by codigo_inet, o.id

        }

        private void  PersisteEtiquetas ( DataTable iTbl , string iCodigo, int iMovNumDoc )
        {
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            DataView lVista = null; string lWhere = string .Concat ("Codigo='",iCodigo ,"'");
            int i = 0;
            try
            {
                lVista = new DataView(iTbl, lWhere, "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                {
                    for (i = 0; i < lVista.Count; i++)
                    {
                        lSql = string.Concat (" SP_CRUD_ETIQUETAS_PT ", lVista [i]["Id"].ToString (),",",iMovNumDoc.ToString ()) ;
                        lSql = string.Concat(lSql, ",'','','','','',1");
                        lDAl.ListarAyudaSql(lSql);
                    }
                }
            }
            catch (Exception iex)
            {

            }

        }

        private int Integrar_BodegaPT_TOSOL(string iGlosa, string iCodigo, string iKilos, string iPrecio)
        {
       
           Px_BedegaPT_Tosol.wsmovexiallSoapPortClient lPxMovEx = new Px_BedegaPT_Tosol.wsmovexiallSoapPortClient();
            Px_BedegaPT_Tosol.ExecuteRequest lObjEntradaMov = new Px_BedegaPT_Tosol.ExecuteRequest();
            Px_BedegaPT_Tosol.ExecuteResponse lResMovEx = new Px_BedegaPT_Tosol.ExecuteResponse();
            Integracion_INET.Tipo_InvocaWS lResultado = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias lTipoEntradaEx = new Integracion_INET.MovExistencias();
            XmlSerializer lXmlSal = null; StringWriter strDataXml = new StringWriter(); string lEstadoProceso = "";
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.Cls_LN lLog = new Integracion_INET.Cls_LN(); int lMovNumDoc = 0;

            try
            {
         
              lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "1", "105");
                       
                lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte.ToString();
                lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                lXmlSal = new XmlSerializer(lResMovEx.Outtansporte.GetType());
                lXmlSal.Serialize(strDataXml, lResMovEx.Outtansporte);
                lResultado.XML_Respuesta = strDataXml.ToString();
                //    iEstado.Text = iEstado.Text & vbCrLf & "Estado P1  :" & lResultado.XML_Respuesta.ToUpper.IndexOf("OK") : iEstado.Refresh()
                if (lResultado.XML_Respuesta.ToUpper().IndexOf("OK") > -1)
                    lEstadoProceso = "OK";
                else
                    lEstadoProceso = "ER";



                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&gt;", ">");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;gt;", ">");

                lMovNumDoc = ObtenerMovNumDoc(lResultado.XML_Respuesta);


            }
            catch (Exception iex)
            {

            }
            finally
            {
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                lSql = string.Concat(lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                lSql = string.Concat(lSql, "','", lResultado.XML_Respuesta, "','", lResultado.URL_WS, "','Bodega_PT',", lMovNumDoc);
                lSql = string.Concat(lSql, ",'", lEstadoProceso, "'");
                lDAl.ListarAyudaSql(lSql);
            }
            return lMovNumDoc;

        }


        private int   Integrar_BodegaPT(string iGlosa,  string iCodigo, string iKilos, string iPrecio  )
        {
            Px_BodegaPT.wsmovexiallSoapPortClient lPxMovEx = new Px_BodegaPT.wsmovexiallSoapPortClient();
            Px_BodegaPT.ExecuteRequest lObjEntradaMov = new Px_BodegaPT.ExecuteRequest();
            Px_BodegaPT.ExecuteResponse lResMovEx = new Px_BodegaPT.ExecuteResponse();
            Integracion_INET.Tipo_InvocaWS lResultado = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias lTipoEntradaEx = new Integracion_INET.MovExistencias();
            XmlSerializer lXmlSal = null; StringWriter strDataXml = new StringWriter(); string lEstadoProceso = "";
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.Cls_LN lLog = new Integracion_INET.Cls_LN(); int lMovNumDoc = 0;

            try
            {
                switch (mSucursal )
                {
                    case "4": //Santiago 
                              lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa,iCodigo,iKilos ,iPrecio ,"1","105"  );
                        break;
                    case "1": //Calama 
                        lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "2", "69");
                        break;
                    case "14": //Coronel
                        lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "3", "805");
                        break;
                    case "16": //Concepcion
                        lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "4", "405");
                        break;
                    default:
                        break;
                }

                
                // Calama
                //lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "2", "69");
                // Coronel
                // lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "3", "805");
                // Concepcion
                // lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT(iGlosa, iCodigo, iKilos, iPrecio, "4", "405");


                lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte.ToString ();
                lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                lXmlSal = new XmlSerializer(lResMovEx.Outtansporte.GetType());
                lXmlSal.Serialize(strDataXml, lResMovEx.Outtansporte);
                lResultado.XML_Respuesta = strDataXml.ToString();
                //    iEstado.Text = iEstado.Text & vbCrLf & "Estado P1  :" & lResultado.XML_Respuesta.ToUpper.IndexOf("OK") : iEstado.Refresh()
                if (lResultado.XML_Respuesta.ToUpper().IndexOf("OK") > -1)
                    lEstadoProceso = "OK";
                else
                    lEstadoProceso = "ER";

           

                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&gt;", ">");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;gt;", ">");

                lMovNumDoc = ObtenerMovNumDoc(lResultado.XML_Respuesta);

             
            }
            catch (Exception iex)
            {

            }
            finally
            {
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                lSql = string.Concat(lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                lSql = string.Concat(lSql, "','", lResultado.XML_Respuesta, "','", lResultado.URL_WS, "','Bodega_PT',", lMovNumDoc);
                lSql = string.Concat(lSql, ",'", lEstadoProceso, "'");
                 lDAl.ListarAyudaSql(lSql);
            }
            return lMovNumDoc;

        }

        private int ObtenerMovNumDoc(string iResp)
        {
            int lres = 0; int lInicio = -1; int lFin = -1; string lTx = "";int Largo = -1;

            lInicio = iResp.IndexOf("<MOVNUMDOC>")+11;
            if (lInicio > -1)
            {
                lFin = iResp.IndexOf("</MOVNUMDOC>");
                Largo = lFin - lInicio;
                lTx = iResp.Substring(lInicio, Largo);
            }

            if (lTx.Length > 1)
                lres = int.Parse(lTx);

            return lres;
        }


        private void Btn_CargaDatos_Click(object sender, EventArgs e)
        {
            
            CargaDatosParaGenerar_PT(mSucursal );

        }

        public void ProcesaDatos()
        {
            string lEmpresa = "TO";
            //mSucursal = Tx_IdSucursal.Text;
            Logistica.Frm_BodegaPT lForm = new Logistica.Frm_BodegaPT();
            lForm.CargaDatosParaGenerar_PT(mSucursal );
            this.Refresh();
            lForm.mSucursal = mSucursal;
            if (mSucursal == "7")
                lEmpresa = "TOSOL";
            lForm.ProcesaEnvio_Al_WS(lEmpresa);
            lForm.Close();

        }

        public void CargaDatosParaGenerar_PT(string isucursal )
        {
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); Cls_Sql lQuery = new Cls_Sql();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); DataTable lTbl = new DataTable();

            lSql = lQuery.ObtenerSql_Etiquetas("01/06/2022 00:00:01","", isucursal);
            lDts = lDAl.ListarAyudaSql(lSql);

            if (lDts.DataSet.Tables.Count > 0)
                lTbl = lDts.DataSet.Tables[0].Copy();

            dtg_datos.DataSource = lTbl;

        }


        public void IniciaProceso( )
        {
            string lEmpresa = "TO";
            CargaDatosParaGenerar_PT(mSucursal);

            if (mSucursal == "7")
                lEmpresa = "TOSOL";

            ProcesaEnvio_Al_WS(mSucursal);

        }


        public  string ProcesaEnvio_Al_WS(string iEmpresa )
        {
            string lRes = ""; DataTable lTbl = new DataTable(); DataView lVista = null;string lCodActual = "";
            string lCodProcesado = ""; DataTable lTblRes = new DataTable(); int i = 0; int k = 0; double lTotalKgs = 0;
            string lIT_Actual = "";string lIT_Procesada = ""; DataView lVista_Dos = null; int lCont = 0;
            DataRow lFila = null; Int64  lKgsInet = 0;


            lTblRes.Columns.Add("Codigo");
            lTblRes.Columns.Add("IT");
            lTblRes.Columns.Add("Kgs");
            lTblRes.Columns.Add("Pr");
            
            lTbl = (DataTable)dtg_datos.DataSource;
            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                lCodActual = lTbl.Rows[i]["Codigo_Inet"].ToString();
                if (lCodProcesado.IndexOf(lCodActual)==-1)  // el codigo actual no ha sido procesado
                {
                    lVista = new DataView(lTbl, string.Concat("Codigo_Inet='", lCodActual, "'"), "", DataViewRowState.CurrentRows);
                    for (k = 0; k < lVista.Count; k++)
                    {
                        lIT_Actual = lVista[k]["Codigo"].ToString();
                        if (lIT_Procesada.IndexOf(lIT_Actual) == -1)  // el codigo actual no ha sido procesado
                        {
                            lVista_Dos = new DataView(lTbl, string.Concat("Codigo_Inet='", lCodActual, "' and codigo='", lIT_Actual, "'"), "", DataViewRowState.CurrentRows);
                            for (lCont = 0; lCont < lVista_Dos.Count; lCont++)
                            {
                                lTotalKgs = double.Parse(lVista_Dos[lCont]["KgsPaquete"].ToString()) + lTotalKgs;
                            }
                            if (lTotalKgs > 0)
                            {
                                lIT_Procesada = string.Concat(lIT_Procesada, lIT_Actual, ",");
                                lFila = lTblRes.NewRow();
                                lFila["Codigo"] = lCodActual;
                                lFila["it"] = lIT_Actual;
                                lFila["Kgs"] = lTotalKgs+1;
                                lFila["Pr"] = lTbl.Rows[i]["Pr"].ToString(); ;
                                lTblRes.Rows.Add(lFila);
                                lTotalKgs = 0;
                               
                                lIT_Actual = "";
                            }
                            
                        }
                       
                        
                    }
                    lCodProcesado = string.Concat(lCodProcesado, lCodActual, ",");
                    lCodActual = "";
                    //lCodProcesado = string.Concat(lCodProcesado,  lCodActual, ",");
                    //lFila=lTblRes .NewRow ();
                    //lFila["Codigo"] = lCodActual;
                    //lFila["Kgs"] = lTotalKgs;
                    //lFila["Pr"] = lTbl.Rows[i]["Pr"].ToString(); ;
                    //lTblRes.Rows.Add(lFila);
                    //lTotalKgs = 0;
                    //lCodActual = "";
                }
            }
            // en la Tabla  lTblRes esta la información que se debe procesar
            // Recorremos la Tabla y fila por fila vamos integrando a INET
            Clases.Cls_Comun lCom = new Clases.Cls_Comun(); string lPrecio = "";  int lKgsFinal = 0; int lMovNumdoc = 0;
            for (i = 0; i < lTblRes.Rows.Count; i++)
            {
                lCodActual = lTblRes.Rows[i]["Codigo"].ToString();
                lKgsFinal = Redondea_double(lTblRes.Rows[i]["Kgs"].ToString());
                lPrecio = lTblRes.Rows[i]["Pr"].ToString();
                switch (iEmpresa)
                {
                    case "TO":
                        lMovNumdoc = Integrar_BodegaPT(string.Concat ("Integración Automatica: ", lTblRes.Rows[i]["IT"].ToString()), lCodActual, lKgsFinal.ToString(), lPrecio);
                        break;
                    case "TOSOL":
                        lMovNumdoc = Integrar_BodegaPT_TOSOL("Integración Automatica", lCodActual, lKgsFinal.ToString(), lPrecio);
                        break;

                }
                
                if (lMovNumdoc >0)
                    PersisteEtiquetas(lTbl, lTblRes.Rows[i]["IT"].ToString(), lMovNumdoc);

              lMovNumdoc = 0;
            }

                return lRes;
       }

        private int     Redondea_double(string lValor)
        {
            decimal   lres = 0; Boolean lSumar = false; int lTmp = 0; int lTmp2 = 0;
            string[] lPartes = (lValor.Split(new Char[] { ',' }));

            try
            {
                lres = decimal .Parse(lValor);
                lres = decimal.Round(lres );

            }
            catch (Exception iex)
            { }

            return int.Parse (lres.ToString ());
        }

        private int Redondea(string lValor)
        {
            int lres = 0; Boolean lSumar = false; int lTmp = 0; int lTmp2 = 0;
            string[] lPartes = (lValor.Split(new Char[] { ',' }));

            try
            {
                if (lPartes.Length == 2)
                {
                    lTmp = int.Parse(lPartes[1].ToString().Substring (0,1));
                    lTmp2 = int.Parse(lPartes[0].ToString());
                    if (lTmp > 5)
                        lSumar = true;

                    if (lSumar == true)
                        lres = lTmp2 + 1;
                    else
                        lres = lTmp2;

                }
                else
                    lres = int.Parse(lValor);

            }
            catch (Exception iex)
            { }

            return lres;
        }




        private void Btn_ObtenerObj_Click(object sender, EventArgs e)
        {
            string lEmpresa = "TO";
          
            if (mSucursal == "7")
                lEmpresa = "TOSOL";

            ProcesaEnvio_Al_WS(lEmpresa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Verificar(Tx_It.Text);
        }

        private void Verificar(string iViaje)
        {
            int lNroEtiquetas_BTP = 0; int lNroEtiquetas_Viaje = 0;
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts_BTP = new WsCrud.ListaDataSet();DataTable lTbl = new DataTable(); 
            WsCrud.ListaDataSet lDts_Total = new WsCrud.ListaDataSet();

            lSql = string.Concat(" SP_CRUD_ETIQUETAS_PT 0,0,'','",Tx_It .Text ,"', '','','',3");
            lDts_BTP= lDAl.ListarAyudaSql(lSql);
            if (lDts_BTP.DataSet.Tables.Count > 0)
            {
                lTbl = lDts_BTP.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                    lNroEtiquetas_BTP = int.Parse(lTbl.Rows[0][1].ToString());
            }
               

            lSql = string.Concat(" SP_CRUD_ETIQUETAS_PT 0,0,'','",Tx_It .Text ,"','', '','',4");
            lDts_Total = lDAl.ListarAyudaSql(lSql);
            if (lDts_Total.DataSet.Tables.Count > 0)
            {
                lTbl = lDts_Total.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                    lNroEtiquetas_Viaje = int.Parse(lTbl.Rows[0][1].ToString());
            }


            if (lNroEtiquetas_BTP == lNroEtiquetas_Viaje)
            {
                Lbl_Msg.Text = " OK ";
                Lbl_Msg.BackColor  = Color.LightGreen;
            }
            else
            {
                Lbl_Msg.Text = " Hay que Integrar saldo . . .  ";
                Lbl_Msg.BackColor = Color.LightSalmon ;
            }


        }

        private void Btn_IntegrarSaldo_Click(object sender, EventArgs e)
        {
            IntegaraSaldo(Tx_It.Text);
        }

        private void IntegaraSaldo (string iViaje)
        {
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts_BTP = new WsCrud.ListaDataSet(); DataTable lTbl = new DataTable();
            WsCrud.ListaDataSet lDts_Total = new WsCrud.ListaDataSet();

            lSql = string.Concat(" SP_CRUD_ETIQUETAS_PT 0,0,'','", Tx_It.Text, "', '','','',5");
            lDts_BTP = lDAl.ListarAyudaSql(lSql);
            if (lDts_BTP.DataSet.Tables.Count > 0)
            {
                lTbl = lDts_BTP.DataSet.Tables[0].Copy();
                dtg_datos.DataSource = lTbl;
            }
        }

        private void Btn_Redondea_Click(object sender, EventArgs e)
        {
            Lbl_Resultado.Text = Redondea_double(Tx_It.Text).ToString ();

        }

        private void Frm_BodegaPT_Load(object sender, EventArgs e)
        {
            ProcesaDatos();
            System.Threading.Thread.Sleep(500);
            this.Close(); 
        }
    }
}
