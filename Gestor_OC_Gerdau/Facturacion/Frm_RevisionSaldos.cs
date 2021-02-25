using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using CommonLibrary;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace Gestor_OC_Gerdau.Facturacion
{
    public partial class Frm_RevisionSaldos : Form
    {
        private StringUtility su = new StringUtility();
        public Frm_RevisionSaldos()
        {
            InitializeComponent();
        }

        private void Btn_GeneraArchivoLC_Click(object sender, EventArgs e)
        {
            CargaInforme_LC("LCO");
        }

        private int Val(string iDato)
        {
            int lRes = 0; string[] separatingStrings = { "," }; string[] lPartes = null;
            lPartes = iDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (lPartes.Length > 0)
                    lRes = int.Parse(lPartes[0].ToString());

            }
            catch (Exception iEx)
            {

            }
            return lRes;
        }

        private void CargaInforme_LC(string iFiltro)
        {
            List<Models.LineaCredito> list = new List<Models.LineaCredito>();
            Models.LineaCredito lc = null; DataTable dt = new DataTable();
            bool add = false;
            string fechaHoy_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            List<string> listTest_RutBloqueo = obtenerListadoTest_RutBloqueo();

            try
            {
                string  valorUF = obtenerValorUF();
                // Utils lUtil = new Utils(); 
                 long lCoberturaSeg = 0;
                // Instancia del WS
                WsFacturacion.FacturacionSoapClient wsFacturacion = new WsFacturacion.FacturacionSoapClient();
                WsFacturacion.ListaDataSet lsDs = new WsFacturacion.ListaDataSet();
                String rutCompleto = "", rut = "", bloqueado = "N";
                Int64 valor1 = 0, valor2 = 0, valor3 = 0, valor4 = 0, totalLC = 0, totalLCO = 0, totalLCO_UF = 0, porcUtilizadoLC = 0, lMontoExc = 0;


                ////    EXEC SP_LINEA_CREDITO '','',0,'RBECERRA','FIN','','LCO','','','','',9
                dt = ObtenerDatosClientes();
                foreach (DataRow dataRow in dt.Rows)
                {
                    // WS
                    add = false;
                    bloqueado = ""; lMontoExc = 0;
                    valor1 = 0; valor2 = 0; valor3 = 0; totalLC = 0; totalLCO = 0; totalLCO_UF = 0; porcUtilizadoLC = 0;
                    totalLC = Convert.ToInt64(dataRow["monto_linea_aprobada"].ToString());
                    //rut = dataRow["rut"].ToString().Trim();
                    //rut = su.Left(rut, rut.Length - 1);
                    rutCompleto = dataRow["rut"].ToString().Trim();
                    rut = rutSinDigVer(rutCompleto);

                    //17 09 2019 Por solicitud de Mjevar ya no se debe verificar los bloqueos cada vez que se entre a la app
                    lsDs = wsFacturacion.ObtenerDatosLN_Cliente_V2(rut, 7);
                    if (lsDs.MensajeError.Equals(""))
                    {
                        if (lsDs.DataSet != null)
                        {
                            if (lsDs.DataSet.Tables.Count > 0)
                            {
                                if (lsDs.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    valor1 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][1].ToString());
                                    valor2 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][2].ToString());
                                    valor3 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][3].ToString());
                                    valor4 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][5].ToString());

                                    //Por Cambio de LN, se modifica la forma de calcular  la LC Ocupada
                                    //correo Danitza 21/08/2019
                                    //totalLCO = valor1 + valor2 + valor3;
                                    totalLCO = valor1 + valor3;
                                    lMontoExc = Int64.Parse(Cliente_con_Excecpcion(rutCompleto));

                                    bloqueado = dataRow["Lin_Bloqueado"].ToString().Trim();  // lsDs.DataSet.Tables[0].Rows[0][4].ToString(); // S/N
                                    // 2019-03-26 Monto linea credito ocupada
                                    valorUF = Val( valorUF.Replace(".","")).ToString ();
                                    totalLCO_UF = totalLCO / (Val(valorUF.Replace(".", "")));
                                }
                            }
                        }
                    }
                    // Logica del parametro: filtro
                    if (iFiltro.Equals("%"))
                        add = true;
                    else
                    {
                        //*************************************
                        // if (add==true )
                        switch (iFiltro)
                        {
                            case "LC":
                                add = totalLC > 0;
                                break;

                            case "LCO":
                                add = totalLCO > 0;
                                break;

                            case "LCE": //LInea credito con excepcion
                                add = lMontoExc > 0;
                                break;

                            case "LCB":  //Linea de credito Bloqueada
                                if (bloqueado == "S")
                                    add = true;
                                break;
                            case "LCN":  //Linea de credito NO Bloqueada
                                if (bloqueado == "N")
                                    add = true;
                                break;
                            default:
                                add = false;
                                break;
                        }
                        //**************************************
                    }
                    //
                    if (add)
                    {
                        lc = new Models.LineaCredito();
                        lc.Rut = rutCompleto;
                        lc.Cliente = dataRow["cliente"].ToString();
                        lc.Monto = totalLC; // Convert.ToInt64(dataRow["monto_linea_aprobada"].ToString());
                        if (!String.IsNullOrEmpty(dataRow["fecha_aprobacion_linea"].ToString()))
                            lc.Fecha_aprobacion = Convert.ToDateTime(dataRow["fecha_aprobacion_linea"].ToString());

                        if (bloqueado.Trim().Length == 0)
                            bloqueado = dataRow["Lin_bloqueado"].ToString();

                        lc.Bloqueo = bloqueado;
                        lCoberturaSeg = long.Parse(dataRow["CoberturaSeguro"].ToString());

                        // 2019-03-22 Fecha de alerta LC por coparse
                        if (!String.IsNullOrEmpty(dataRow["fecha_alcpc"].ToString()))
                            lc.Fecha_ALCPC = Convert.ToInt64(dataRow["fecha_alcpc"].ToString());
                        // 2019-03-26
                        lc.MontoTotalLCO_UF = totalLCO_UF;
                        // 2019-04-02
                        //1) Todo lo facturado (Pendiente de pago)
                        //2) Despachado (No facturado)
                        //3) Despachos programados (1 semana)
                        lc.F_PP = valor1 / Convert.ToInt32(valorUF);
                        lc.D_ProximaSem = valor2 / Convert.ToInt32(valorUF);
                        lc.D_SinFact = valor3 / Convert.ToInt32(valorUF);
                        lc.D_ProximaSem_Mas7 = valor4 / Convert.ToInt32(valorUF); // wsFacturacion.ObtenerTotalDespachoSiguienteSemana_V2(lc.Rut, "L",7);

                        if (lMontoExc > 0)
                        {
                            lc.Exepcionado = (Convert.ToInt32(lMontoExc)).ToString("#,##0");
                            
                        }
                        else
                        {
                            lc.Exepcionado = "";
                       
                        }

                        lc.Coberturaseguro = lCoberturaSeg;
                        lc.LC_Disponible = (lc.Monto - lc.MontoTotalLCO_UF).ToString("#,##0");


                        //lc.PathImg = lUtil.ObtenerSemaforo(lc.Monto, lc.MontoTotalLCO_UF, lTipo);   //"Content/Images/Verde.jpg";
                        list.Add(lc);
                    }
                }
                Dtg_Datos.DataSource = list;
            }
            catch (Exception exc)
            {

            }

        }


        public string  obtenerValorUF()
        {
            Models.ValorUF result = new Models.ValorUF();  DataTable dt = null;DateTime now = DateTime.Now;
            bool apiSBIF = true;
            string lSql = "";  
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            lSql = "  EXEC SP_LC_PARAMETRO 'LC_VALORUF','0','','','','',0,0,0,91 ";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lTbl = lDts.Tables[0].Copy();

            // Obtiene el ultimo valor de la UF obtenido desde la api de la SBIF
                if (lTbl != null)
                {
                    if (lTbl.Rows.Count > 0)
                    {
                        result.Valor = lTbl.Rows[0]["par_alf1"].ToString().Replace(".", "").Substring (0,5);
                        result.Fecha = lTbl.Rows[0]["par_alf2"].ToString();
                    }
                }
            
            // Si existe una fecha, verifica si no corresponde a la de hoy para realizar la actualizacion del valor
            if (result.Fecha != null)
            {
                if (result.Fecha == now.ToString("yyyy-MM-dd"))
                    apiSBIF = false;
            }
            //
            if (apiSBIF)
            {
                string fecha = now.ToString("yyyy") + "/" + now.ToString("MM") + "/dias/" + now.ToString("dd");
                string url = "https://api.sbif.cl/api-sbifv3/recursos_api/uf/" + fecha + "?apikey=682876d930756ca46f990955e5243e91184a8a4f&formato=xml";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(url);
                    XmlNodeList elemList = doc.GetElementsByTagName("Fecha");
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        result.Fecha = elemList[i].InnerText;
                    }
                    elemList = doc.GetElementsByTagName("Valor");
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        result.Valor = elemList[i].InnerText;
                    }
                }
                catch (Exception exc)
                {
                    result.ErrorMessage = exc.Message;
                }
            }
            return result.Valor ;
        }

        private  string Cliente_con_Excecpcion(string iRut)
        {
            string result = "0"; string lSql = ""; DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();

            lSql = " select isnull(sum(Det_Monto),0)  from LINEA_CREDITO_DETALLE where  DET_CONCEPTO =2 and  DET_MONTO >0    ";
            lSql = string.Concat(lSql, "  and det_rut='", iRut, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lTbl = lDts.Tables[0].Copy();

            
                if (lTbl != null)
                {
                    if (lTbl.Rows.Count > 0)
                    {
                        result = lTbl.Rows[0][0].ToString();
                    }
                }
            
            return result;
        }


        private  string rutSinDigVer(string rutCompleto)
        {
            string rut = rutCompleto.Trim();
            return su.Left(rut, rut.Length - 1);
        }

        private DataTable ObtenerDatosClientes()
        {
            string lSql = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();        DataTable lTbl = new DataTable();

            lSql = " EXEC SP_LINEA_CREDITO '','',0,'RBECERRA','FIN','','LCO','','','','',9  ";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lTbl = lDts.Tables[0].Copy();

            return lTbl;
        }

        private List<string> obtenerListadoTest_RutBloqueo()
        {
            string lSql = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); 
            DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();
            DataTable lTbl = new DataTable();

            lSql = " EXEC SP_LC_PARAMETRO 'LC_TEST_RUTBLOQUEO','','','','','',0,0,0,92 ";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                  lTbl = lDts.Tables[0].Copy();
            
            List<string> list = new List<string>();


                if (lTbl != null)
                {
                    if (lTbl.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in lTbl.Rows)
                        {
                            list.Add(dataRow["par_codint"].ToString());
                        }
                    }
                }
        
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lPathCOF = "";
            lPathCOF = string.Concat(ConfigurationManager.AppSettings["Path_ArchivoCOF"].ToString());

        }
    }
}
