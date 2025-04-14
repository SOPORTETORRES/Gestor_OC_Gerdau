using System;
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
    public partial class Frm_ProcesoPorLote : Form
    {
        public Frm_ProcesoPorLote()
        {
            InitializeComponent();
        }

        private void Btn_CargaDatos_Click(object sender, EventArgs e)
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = ""; DataTable lTblDetalle = new DataTable();

            try
            {
                lSql = " select distinct NroGuiaDEspacho, Lote   from EtiquetaAZA e , EtiquetaMP_Recepcionada er,DetalleRecepcion_MP dr , Recepcion_MP r    ";
                lSql = string.Concat(lSql, "  where not exists (select 1 from  CertificadosColadas c where e.lote=c.lote) ");
                //  and not exists (select 1 from  CertificadosColadas c1 where c1.lote=e.lote  union select 1 from CertificadosColadasCAP cap where cap.lote=e.lote)
                lSql = string.Concat(lSql, "  and  FechaInsert > '01/01/2023 00:00:01' and Procedencia not in ('CAP')  and len(e.lote)=10 ");
                //lSql = string.Concat(lSql, "  and  FechaInsert > '01/01/2023 00:00:01' and not exists (select 1 from  CertificadosColadas c1 where c1.lote=e.lote  union select 1 from CertificadosColadasCAP cap where cap.lote=e.lote) ");
                lSql = string.Concat(lSql, "  and er.Id_EtiquetaAZA =e.id  and er.Id_DR_MP =dr.Id   and  r.Id =dr.Id_Detalle_RMP  and e.id=e.id   ");
                lSql = string.Concat(lSql, " order by r.NroGuiaDEspacho desc");

                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblDetalle = lDts.Tables[0].Copy();
                    DTG_Resultado.DataSource = lTblDetalle; 
                }
            }
            catch (Exception iex)
            {

            }

        }

        private Boolean GDE_Fue_Enviada(string iNroGDE)
        {
            Boolean lRes = false;  string lSql = "";  DataTable lTbl = new DataTable();             DataSet lDts = new DataSet(); WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();

            lSql = String.Concat("select * from to_parametros where subtabla = 'Certificaciones_GDE' and par1='", iNroGDE,"'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                  lRes = true;
            
            return lRes;
        }

        private string PersisteGDE(string iNroGDE)
        {
            string  lRes = "";
            string lSql = ""; DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            string lFecha = string.Concat(DateTime.Now.ToShortDateString(), " ", DateTime.Now.ToShortTimeString());
            lSql = String.Concat(" insert into  to_parametros  (Subtabla,Descripcion, Par1, Par2 ) values('Certificaciones_GDE','', '", iNroGDE,"','", lFecha, "') ");
            lDts = lPx.ObtenerDatos(lSql);
             
            return lRes;
        }

        private void Enviar_Resumen_GDE(string iNroGDE)
        {
            string lMsg = ""; DataTable lTblDetalle = new System.Data.DataTable() ; string lSql = ""; int i = 0; DataTable lTbl = new DataTable();  //lDal As New ClsDatos
            DataSet lDts = new DataSet(); WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();

            //1.- Verificamos si ya se ha enviado la notificacion de la GDE
            if (GDE_Fue_Enviada(iNroGDE) == false)
            { 

            lSql = String.Concat("select *   from Recepcion_MP r  where NroGuiaDespacho =", iNroGDE);
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
            }


                if (lTbl.Rows.Count > 0)
            {
                lMsg = String.Concat(" Hola estimad@s   <br>  Se ha recepcionado la Guía de Materia Prima. <br>  Los datos son los siguinetes: <br>");
                lMsg = String.Concat(lMsg, "  No. Guía Despacho: ", lTbl.Rows[0]["NroGuiaDespacho"].ToString(), "   <br>  Fecha Guía Despacho: ", lTbl.Rows[0]["FechaGuiaDespacho"].ToString());
                lMsg = String.Concat(lMsg, "     <br> Kilos Guía Despacho:", lTbl.Rows [0]["KgsGD"].ToString(), " <br> <br> ");
                lMsg = String.Concat(lMsg, "  Detalle de la Guía de Despacho <br>  ");
                //lMsg = String.Concat(lMsg, " Codigo -  Producto -    Lote    -   Informe  -  Certificado  <br>  ");

                lMsg = String.Concat(lMsg, "  <br>  <table align='center' width='90%' border ='1'> ");

                lMsg = String.Concat(lMsg, " <tr>    <td>Código ;</td>             <td>Descripción</td>             <td>Peso paquete</td>             <td>Paquete</td>");
                lMsg = String.Concat(lMsg, " <td>Lote</td>     <td>Certificado</td>             <td>Informe</td>                 </tr>");


                lSql = String.Concat("select  codMaterial ,( select descripcion from materiaPrima mp  where mp.Codigo =dr.CodMaterial  ) Producto, e.PesoPaquete , Lote , e.Paquete , ");
                lSql = String.Concat(lSql, " ( select Url_Certificado  from CertificadosColadas c where c.lote =e.Lote )  Certificado, ");
                lSql = String.Concat(lSql, " ( select Url_Informe  from CertificadosColadas c where c.lote =e.Lote )  Informe ");
                lSql = String.Concat(lSql, "  from  DetalleRecepcion_MP dr  ,  EtiquetaMP_Recepcionada er , Recepcion_MP r   ,  EtiquetaAZA e ");
                lSql = String.Concat(lSql, "  where   r.Id =dr.Id_Detalle_RMP   and er.Id_DR_MP =dr.Id  and  	NroGuiaDespacho =", iNroGDE);
                lSql = String.Concat(lSql, "  and  er.Id_EtiquetaAZA =e.id  ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblDetalle = lDts.Tables[0].Copy();
                    for (i = 0; i<lTblDetalle.Rows.Count; i++)
                    {
                            // agregar el diametro -  calidad acero 
                        lMsg = String.Concat(lMsg, " <tr>    <td>", lTblDetalle.Rows[i]["CodMaterial"].ToString(), " </td>             <td>", lTblDetalle.Rows[i]["Producto"].ToString(), "</td>        ");
                        lMsg = String.Concat(lMsg, "       <td>", lTblDetalle.Rows[i]["PesoPaquete"].ToString(), "</td>             <td>", lTblDetalle.Rows[i]["Paquete"].ToString(), "</td> ");
                        lMsg = String.Concat(lMsg, "  <td>", lTblDetalle.Rows[i]["Lote"].ToString(), "</td>     <td>", lTblDetalle.Rows[i]["Certificado"].ToString(), "</td>         ");
                        lMsg = String.Concat(lMsg, "       <td>", lTblDetalle.Rows[i]["Informe"].ToString(), "</td>                 </tr>");
                    }                   
                }


                // Next
                lMsg = String.Concat(lMsg, "  </table>");
             }

            lMsg = String.Concat(lMsg, "  <br> <br>  No Responda a este correo, ya que ha sido generado de forma automática  <br> Buen día  ");
                System.Threading.Thread.Sleep(1000);
             string lTx=            lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lMsg, -2300, string.Concat ("Recepción de Materia prima según GDE: ",iNroGDE ));
                if (lTx.Equals ("OK"))
                    PersisteGDE(iNroGDE);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0; string lLote="";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();
            try
            {
                for (i = 0; i < DTG_Resultado.Rows.Count-1; i++)
                {
                    Lbl_Msg.Text = string.Concat (" Procesando el Lote  ", i, " de ", DTG_Resultado.Rows.Count - 1, " ==> ", lLote);
                    Lbl_Msg.Refresh();
                    this.Refresh();
                    lLote = DTG_Resultado.Rows[i].Cells["Lote"].Value.ToString();
                    // Insertamos en Tabla Lotes de MySql
                    lSql = string.Concat("select * from lotes  where  lote='", lLote, "'");
                    lTbl = lLot.CargarDatos(lSql);
                    if (lTbl.Rows.Count > 0)
                    {
                        lSql = string.Concat(" delete from lotes  where  lote='", lLote, "'");
                        lTbl = lLot.CargarDatos(lSql);
                    }
                    lLot.GrabarRegistro(lLote, 0);
                    lLot.ObtenerDatosCertificados_WB();
                    //Invovamos le web Browser y se preocesa el Lote.
                    this.ActualizaCetificados_Revisado(lLote);
                    DescargaPdfs_WB(lLote);
                }
                // recorremos la tabla y  enviamos  el detalle de las GDE recibidas
                //Enviar_Resumen_GDE
                    for (i = 0; i < DTG_Resultado.Rows.Count-1; i++)
                {
                    Lbl_Msg.Text = string.Concat(" Enviado notificación   ", i, " de ", DTG_Resultado.Rows.Count - 1, "  GDE==> ", lLote);
                    Lbl_Msg.Refresh();
                    this.Refresh();
                    lLote = DTG_Resultado.Rows[i].Cells["NroGuiaDespacho"].Value.ToString();
                    // Insertamos en Tabla Lotes de MySql
                    Enviar_Resumen_GDE(lLote);
                }
            }
            catch (Exception iex)
            {
            }
        }
        private string ObtenerColada(string iColada)
        {
            string lRes = "";

            lRes = iColada.Replace("{", "");
            //lRes = iColada.Replace("", "");

            return lRes.Trim();

        }


        private void DescargaPdfs_WB(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = ""; string lPathCertificados = "";
            string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = ""; string lTmp = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            //string lSql = string.Concat("  select * from CertificadosColadas  where  lote='", iLote, "'");
            ////lSql = string.Concat(lSql, " publicacionInforme is not  null  and estado is null ");
            //lDts = lPx.ObtenerDatos(lSql);
            //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            //{
            Frm_CertificacionViaje lDescargaPdf = new Frm_CertificacionViaje();
            try
                {

                lDescargaPdf.DescargaPdfs_WB(iLote);
                lNombreArc = string.Concat(iLote, "_C.pdf");
                lPathCertificados = ConfigurationManager.AppSettings["PathCertificados"].ToString();
                lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                if (File.Exists(lPathFin) == false)
                    MessageBox.Show(string.Concat("No se creo archivo :", lPathFin));
                else
                {
                    FileInfo lInfoArch = new FileInfo(lPathFin);
                    if ((lInfoArch.Length / 1000) < 50)
                        MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));
                }

                lNombreArc = string.Concat(iLote, "_I.pdf");
                lPathCertificados = ConfigurationManager.AppSettings["PathCertificados"].ToString();
                lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                if (File.Exists(lPathFin) == false)
                    MessageBox.Show(string.Concat("No se creo archivo :", lPathFin));
                else
                {
                    FileInfo lInfoArch = new FileInfo(lPathFin);
                    if ((lInfoArch.Length / 1000) < 50)
                        MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));
                }

                //lTbl = lDts.Tables[0].Copy();
                //MessageBox.Show(string.Concat("Comienza la descarga del certiticado:", iLote));

                //lPathCertificados = ConfigurationManager.AppSettings["PathCertificados"].ToString();

                //PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                //for (i = 0; i < lTbl.Rows.Count; i++)
                //    {
                //        // 1.- Certificado Url_Certificado
                //        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString().Replace("http", "https"));
                //        //url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString());
                //        lLote = lTbl.Rows[i]["lote"].ToString();



                //        lNombreArc = string.Concat(lLote, "_C.pdf");

                //        lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                //        //lLlave = lLot.ObtieneLlave(url);
                //        //url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);


                //        // revisamos si esta en el directorio de los certificados
                //        if (File.Exists(lPathFin) == false)
                //        {
                //            lDescargaPdf.DescargaPdfs_WB(iLote);

                //            cliente = new WebClient();
                //            //cliente.Headers.Add("ContentLength", "900000");
                //            cliente.DownloadFile(url, lPathFin);
                //            FileInfo lInfoArch = new FileInfo(lPathFin);
                //            if ((lInfoArch.Length / 1000) < 50)
                //                MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));

                //            //MessageBox.Show(string.Concat("Certificado descargado :", lPathFin));
                //        }
                //        System.Threading.Thread.Sleep(200);

                //        //2.- Informe
                //        lNombreArc = string.Concat(lLote, "_I.pdf");
                //        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Informe"].ToString().Replace("http", "https"));

                //        lPathFin = System.IO.Path.Combine(lPathCertificados, lNombreArc);
                //        //lLlave = lLot.ObtieneLlave(url);
                //        //url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);
                //        if (File.Exists(lPathFin) == false)
                //        {
                //            cliente = new WebClient();
                //            //cliente.Headers.Add("ContentLength", "900000");
                //            cliente.DownloadFile(url, lPathFin);
                //            FileInfo lInfoArch = new FileInfo(lPathFin);
                //            if ((lInfoArch.Length / 1000) < 50)
                //                MessageBox.Show(string.Concat("Parece que el archivo esta Malo:", lPathFin));

                //            //MessageBox.Show(string.Concat("Certificado descargado :", lPathFin));
                //        }
                //        //Persistimos los datos procesado 
                //        lSql = string.Concat("  Update  CertificadosColadas   set  estado='OK' where lote='", lLote, "'");
                //        lDts = lPx.ObtenerDatos(lSql);
                //}

            }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

          //  }

            //  MessageBox.Show("FIN");

        }

        private void ActualizaCetificados_Revisado(string iLote)
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
                                                if (lPartesColada.Length == 10)
                                                {
                                                    lLot.PesisteDatos(iLote, lPartesColada[6].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString(), lPartesColada[8].ToString());
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

                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
