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
        public Frm_BodegaPT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PruebaIntegrar_BodegaPT();

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

        private void PruebaIntegrar_BodegaPT()
        {
            Px_BodegaPT.wsmovexiallSoapPortClient lPxMovEx = new Px_BodegaPT.wsmovexiallSoapPortClient();
            Px_BodegaPT.ExecuteRequest lObjEntradaMov = new Px_BodegaPT.ExecuteRequest();
            Px_BodegaPT.ExecuteResponse lResMovEx = new Px_BodegaPT.ExecuteResponse();
            Integracion_INET.Tipo_InvocaWS lResultado = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias lTipoEntradaEx = new Integracion_INET.MovExistencias();
            XmlSerializer lXmlSal = null; StringWriter strDataXml = new StringWriter(); string lEstadoProceso = "";
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            //WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.Cls_LN lLog = new Integracion_INET.Cls_LN();

            try
            {
                lObjEntradaMov.Intrasnporte = lLog.CreaXmlBodega_PT();
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

            }
            catch (Exception iex)
            {

            }
            finally
            {
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                lSql = string.Concat(lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                lSql = string.Concat(lSql, "','", lResultado.XML_Respuesta, "','", lResultado.URL_WS, "','Bodega_PT',", lTipoEntradaEx.ExistenciasAll.MOVNUMDOC);
                lSql = string.Concat(lSql, ",'", lEstadoProceso, "'");
                 lDAl.ListarAyudaSql(lSql);
            }


        }

    }
}
