using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_RevisaColadas : Form
    {
        
        private string mViaje = "";
        public Frm_RevisaColadas()
        {
            InitializeComponent();
        }




        private void CargaBmd()
        {
            string lSql = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();
            DataTable lTbl = new DataTable();

            lSql = "  select * from sucursal ";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Cmb_Suc.DataSource = lTbl;
                Cmb_Suc.ValueMember = "Id";
                Cmb_Suc.DisplayMember = "Nombre";
            }

            DataTable lTbl2 = new DataTable(); DataRow lFila = null;
            lTbl2.Columns.Add("Estado", Type.GetType("System.String"));
            lTbl2.Columns.Add("Key", Type.GetType("System.String"));

            lFila = lTbl2.NewRow(); lFila["Estado"] = "Finalizada"; lFila["Key"] = "S"; lTbl2.Rows.Add(lFila);
            lFila = lTbl2.NewRow(); lFila["Estado"] = "En Curso"; lFila["Key"] = "P"; lTbl2.Rows.Add(lFila);
            lFila = lTbl2.NewRow(); lFila["Estado"] = "Pendiente"; lFila["Key"] = "N"; lTbl2.Rows.Add(lFila);

            Cmb_Estado.DataSource = lTbl2;
            Cmb_Estado.ValueMember = "Key";
            Cmb_Estado.DisplayMember = "Estado"; 


        }

        private void CargaViajes()
        {
            DataSet lDts = new DataSet(); WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataTable lTbl = new DataTable(); int i = 0; int lKgsCert = 0; int lKgsProd = 0; int lDif = 0;
            lDts = lPx.ObtenerViajesCerificar_PorSucursal("14");
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                //        Dim lVista As New DataView(lTbl, "KgsCertificados>0 ", "KgsCertificados desc", DataViewRowState.CurrentRows)
                //GridView1.DataSource = lVista
                Dtg_Datos.DataSource = lTbl;
            }

            for (i = 0; i < Dtg_Datos.Rows.Count - 1; i++)
            {

                lKgsCert = Val(Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString());
                lKgsProd = Val(Dtg_Datos.Rows[i].Cells["KgsProducidos"].Value.ToString());

                lDif = lKgsProd - lKgsCert;



                if (lDif < 3)
                    Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightYellow;

                if (lDif > 2)
                    Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightSalmon;


                if (lDif == 0)
                    Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightGreen;

            }



        }



        private void ObtenerRegistrosColadasCetificados()
        {
            string lRes = "OK"; int i = 0;Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();
            string lSql = string.Concat(" Select * from Lotes where procesado='S' order by id DESC ");
            DataTable lTbl = new DataTable();
            lTbl = lLot.CargarDatos(lSql);
            //if (lTbl.Rows.Count == 0)
            Dtg_Datos.DataSource = lTbl;
            Dtg_Datos.Columns["id"].Width = 50;
            Dtg_Datos.Columns["Lote"].Width = 70;
            Dtg_Datos.Columns["Procesado"].Width = 50;
            Dtg_Datos.Columns["fecha"].Width = 70;
            Dtg_Datos.Columns["Respuesta"].Width = 750;

            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                Dtg_Datos.Rows[i].Height = 50;

            }


        }

        private void ObtenerdatosPorViaje(string iViaje, string iTipoColada)
        {
            string lSql = "";
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            if (iTipoColada.ToUpper().Equals("S"))
                lSql = string.Concat(" SP_Consultas_ActaEntrega 14,'", iViaje, "','','','',',','',''");
            else
                lSql = string.Concat(" SP_Consultas_ActaEntrega 10,'", iViaje, "','','','',',','',''");


         //lSql = "  select lote NroColada, 1 Id from lote_no_encontrado   where  actualizado is null ";
  
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                PB.Maximum = lDts.Tables[0].Rows.Count; PB.Minimum = 0; PB.Value = 0;
                for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                {
                    lLot.GrabarRegistro(lDts.Tables[0].Rows[i]["NroColada"].ToString(), int.Parse(lDts.Tables[0].Rows[i]["id"].ToString()));
                    if (PB.Value < PB.Maximum)
                        PB.Value = PB.Value + 1;
                    else
                        PB.Value = PB.Value - 1;

                }
            }
        }


        private void Btn_CargaTablaMySql_Click(object sender, EventArgs e)
        {
            //string lSql = " SP_Consultas_ActaEntrega 10,'AVO-367/1','','','',',','',''";
            //WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0;
            //DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();

            //lDts = lPx.ObtenerDatos(lSql);
            //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            //{
            //    for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
            //    {
            //        GrabarRegistro(lDts.Tables[0].Rows[i]["NroColada"].ToString (), int.Parse (lDts.Tables[0].Rows[i]["id"].ToString ()));
            //    }


            //}


        }

        private void ActualizaCetificados()
        {
            DataTable lTbl = new DataTable(); int i = 0; int lCont = 0;
            string lSql = ""; string lRes = ""; string lDato = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // string[] separatingStrings = { "}," };

            if (Dtg_Datos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos a procesar, Revisar", " Avisos Sistema");
            }
            else
            {
                string[] separatingStrings = { "}," };


                PB.Maximum = Dtg_Datos.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                for (i = 0; i < Dtg_Datos.Rows.Count; i++)
                {
                    if (Dtg_Datos.Rows[i].Cells["Respuesta"].Value != null)
                    {
                        lDato = Dtg_Datos.Rows[i].Cells["Respuesta"].Value.ToString();
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
                                    string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                    if (lPartesColada.Length == 5)
                                    {
                                        lLot.PesisteDatos(lPartesColada[0].ToString(), lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                        if (PB.Value < PB.Maximum)
                                            PB.Value = PB.Value + 1;
                                        else
                                            PB.Value = PB.Value - 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // hay solo una Colada en la definicion

                        }
                    }

                }
            }

        }

        private void DescargaPdfs()
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
            string lRes = ""; string lLote = ""; string url = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();

            string lSql = string.Concat("  select top 2 * from CertificadosColadas  where  ");
            lSql = string.Concat(lSql, " publicacionInforme is not  null  and estado is null ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                try
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        //url = @"http://repositorio.idiem.cl/docs/6JNoJJvfK8"; http://repositorio.idiem.cl/verifica/hS7vdRrAd1
                        //url = @"http://repositorio.idiem.cl/docs/hS7vdRrAd1";


                        //url = System.IO.Path.Combine(  lTbl.Rows[i]["Url_Certificado"].ToString());
                        url = lTbl.Rows[i]["Url_Certificado"].ToString().Replace("verifica", "docs");

                        //lTbl.Rows[i]["Url_Certificado"].ToString();

                        lLote = lTbl.Rows[i]["lote"].ToString();
                        //lPathFin = @"c:\Temp\mypdf2.pdf";
                        lPathFin = System.IO.Path.Combine(@"c:\Temp\", string.Concat(lLote, "_C.pdf"));
                        WebClient cliente = new WebClient();
                        //cliente.DownloadFile(url, @"c:\Temp\mypdf.pdf");
                        cliente.DownloadFile(url, lPathFin);

                    }


                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Problem: " + ex.Message);

                }

            }

        }





        private void DescargaPdfs_WB()
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
            string lRes = ""; string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            string lSql = string.Concat("  select top 100 * from CertificadosColadas  where estado is null  ");
            //lSql = string.Concat(lSql, " publicacionInforme is not  null  and estado is null ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                try
                {
                    lTbl = lDts.Tables[0].Copy();

                    PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString());
                        lLote = lTbl.Rows[i]["lote"].ToString();
                        lNombreArc = string.Concat(lLote, "_C.pdf");
                        lPathFin = System.IO.Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                        lLlave = lLot. ObtieneLlave(url);
                        url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);

                        cliente = new WebClient();
                        cliente.DownloadFile(url, lPathFin);

                        System.Threading.Thread.Sleep(300);

                        //2.- Informe
                        lNombreArc = string.Concat(lLote, "_I.pdf");
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Informe"].ToString());
                        lPathFin = System.IO.Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                        lLlave = lLot.ObtieneLlave(url);
                        url = string.Concat("http://www.idiem.cl/intranet/modulos/firma/archivo.php?doc_key=", lLlave);
                        cliente = new WebClient();
                        cliente.DownloadFile(url, lPathFin);

                        //Persistimos los datos procesado 
                        lSql = string.Concat("  Update  CertificadosColadas   set  estado='OK' where lote='", lLote, "'");
                        lDts = lPx.ObtenerDatos(lSql);
                        if (PB.Value < PB.Maximum)
                            PB.Value = PB.Value + 1;
                        else
                            PB.Value = PB.Value - 1;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

            }

            //  MessageBox.Show("FIN");

        }

        private void GeneraCarpeta_()
        {
            string lSql = ""; string lLotesProc = ""; DataTable lTblEt = new DataTable(); int i = 0; int lCont = 0;
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lPathSigla = ""; string lPathIni = "";
            string lNombreArc = "";

            DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();
            string lViaje = ""; string lViajesProcesados = ""; DataTable lTbl = new DataTable();
            DataView lVista = null; string lPathArchivo = @"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\\";
            string lPathDest = ""; DataTable lTblViajes = new DataTable(); DataView lVista2 = null;
            string lSucursal = "Calama";

            lPathArchivo = @"C:\TMP\Calidad\Calama\";
            lPathIni = @"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\";
            lSql = String.Concat(" SP_Consultas_WS 190,'1','','','','','',''  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblViajes = lDts.Tables[0].Copy();
                PB.Maximum = lTblViajes.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                for (i = 0; i < lTblViajes.Rows.Count; i++)
                {
                    lSql = String.Concat(" SP_Consultas_WS 192,'", lTblViajes.Rows[i]["Codigo"].ToString(), "','','','','','',''  ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTblEt = lDts.Tables[0].Copy();
                        string[] separators = { "-" };
                        string[] lPartes = lTblViajes.Rows[i]["Codigo"].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        lPathSigla = lPartes[0].ToString();
                        lPathDest = Path.Combine(lPathArchivo, lPathSigla, lTblViajes.Rows[i]["Codigo"].ToString().Replace("/", "_"));
                        if (Directory.Exists(lPathDest) == false)
                        {
                            Directory.CreateDirectory(lPathDest);
                        }
                        //todos los paquetes del viaje ,  procesamos los Lotes
                        for (lCont = 0; lCont < lTblEt.Rows.Count; lCont++)
                        {
                            if (lLotesProc.IndexOf(lTblEt.Rows[lCont]["Lote"].ToString()) == -1)
                            {
                                //Si no existe archivo en destino se copian 
                                lNombreArc = string.Concat(lTblEt.Rows[lCont]["Lote"].ToString(), "_I.pdf");
                                lPathIni = Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                                lPathDest = Path.Combine(lPathArchivo, lPathSigla, lTblViajes.Rows[i]["Codigo"].ToString().Replace("/", "_"), lNombreArc);
                                if (File.Exists(lPathDest) == false)
                                    File.Copy(lPathIni, lPathDest);

                                lNombreArc = string.Concat(lTblEt.Rows[lCont]["Lote"].ToString(), "_C.pdf");
                                lPathIni = Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                                lPathDest = Path.Combine(lPathArchivo, lPathSigla, lTblViajes.Rows[i]["Codigo"].ToString().Replace("/", "_"), lNombreArc);
                                if (File.Exists(lPathDest) == false)
                                    File.Copy(lPathIni, lPathDest);


                                lLotesProc = lTblEt.Rows[lCont]["Lote"].ToString();
                                if (PB.Value < PB.Maximum)
                                    PB.Value = PB.Value + 1;
                            }
                        }
                    }

                }

                //}


                //}
                MessageBox.Show("FIN");
            }
        }
  


      

        private void PesisteDatosReProcesa(string iLote, string iUrlCert, string iUrlInf, string iPubInf, string iPubCert)
        {
            string lLote = ""; string lUrlCert = ""; string lUrlInf = ""; string lPubInf = ""; string lPubCert = "";
            //{"2612489402":{"Colada":"2612489402"
            string[] lPartes = (iLote.Split(new Char[] { ':' }));
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();
            if (lPartes.Length == 3)
            {
                lLote = lLot.LimpiaTx(lPartes[2].ToString());
            }
            lPartes = (iUrlCert.Split(new Char[] { ':' }));
            //"Certificado":"http://repositorio.idiem.cl/verifica/hqlivHPuq8"
            if (lPartes.Length == 3)
            {
                lUrlCert = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString());
                lUrlCert = lLot.LimpiaTx(lUrlCert);
            }
            lPartes = (iUrlInf.Split(new Char[] { ':' }));
            //"Informe":"http://repositorio.idiem.cl/verifica/UzCpzlzsLb"
            if (lPartes.Length == 3)
            {
                lUrlInf = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString());
                lUrlInf = lLot.LimpiaTx(lUrlInf);
            }
            lPartes = (iPubInf.Split(new Char[] { ':' }));
            //"Publicacion_Informe":"2019-06-24 17:04:29"
            if (lPartes.Length == 4)
            {
                lPubInf = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString(), ":", lPartes[3].ToString());
                lPubInf = lLot.LimpiaTx(lPubInf);
            }
            lPartes = (iPubCert.Split(new Char[] { ':' }));
            //"Publicacion_Certificado":"2019-06-25 10:03:29"}}
            if (lPartes.Length == 4)
            {
                lPubCert = string.Concat(lPartes[1].ToString(), ":", lPartes[2].ToString(), ":", lPartes[3].ToString().Substring(0, 2));
                lPubCert = lLot.LimpiaTx(lPubCert);
            }
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            string lSql = string.Concat(" Select 1 from CertificadosColadas where lote='", iLote, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0)) //&& (lDts.Tables[0].Rows.Count > 0))
            {
                if (lDts.Tables[0].Rows.Count == 0)
                {
                    lSql = string.Concat(" insert into CertificadosColadas (Lote,Url_Certificado, Url_Informe,PublicacionInforme, PublicacionCertificado , ObsDescarga ) ");
                    lSql = string.Concat(lSql, " values ('", iLote, "','", lUrlCert, "','", lUrlInf, "','", lPubInf, "','", lPubCert, "','*')  select @@Identity ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lSql = string.Concat(" update  Lotes set Procesado='F' where lote='", iLote, "'");
                        lLot.CargarDatos(lSql);

                    }
                }
                else
                {
                    //lSql = string.Concat("  Update  CertificadosColadas set Url_Certificado='", lUrlCert, "', Url_Informe='", lUrlInf, "',");
                    //lSql = string.Concat(lSql, " PublicacionInforme='", lPubInf, "', PublicacionCertificado='", lPubCert, "'");
                    //lSql = string.Concat(lSql, " Where lote='", lLote, "'");
                    ////, PublicacionInforme, PublicacionCertificado ) ");
                    //lDts = lPx.ObtenerDatos(lSql);
                    //lSql = string.Concat(" update  Lotes set Procesado='F' where lote='", lLote, "'");
                    //CargarDatos(lSql);
                }

            }

        }


        private void Btn_CargaDatos_Click(object sender, EventArgs e)
        {
            ObtenerRegistrosColadasCetificados();
        }

        private void Btn_Actualiza_Click(object sender, EventArgs e)
        {
            ActualizaCetificados();
        }

        private void Btn_DescargaPdf_Click(object sender, EventArgs e)
        {
            DescargaPdfs_WB();
        }

        private void Btn_CD_Click(object sender, EventArgs e)
        {
            GeneraCarpeta_();
        }

        private void Frm_RevisaColadas_Load(object sender, EventArgs e)
        {
            CargaBmd();
            CargaViajes();

        }

        private void Btn_Generar_Click(object sender, EventArgs e)
        {
            GenerarDatos();
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

        private void GenerarDatos()
        {
            int i = 0; string lCodigo = ""; DataTable lTNl = new DataTable(); string UsaQR = "";
            int KgsIt = 0; int kgsProd = 0; int kgsCert = 0; Clases.Cls_EnvioDoc lCom = new Clases.Cls_EnvioDoc();
            int lDif = 0;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            for (i = 0; i < Dtg_Datos.RowCount-1; i++)
            {
                KgsIt = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsIT"].Value.ToString());
                kgsProd = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsProducidos"].Value.ToString());
                kgsCert = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString());
                UsaQR = Dtg_Datos.Rows[i].Cells["UsaQR"].Value.ToString();

                //if (Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString() != "0")
                //{
                //lDif = Math.Abs(kgsCert - kgsProd);
                //if (UsaQR == "S" )    //if (kgsCert!= kgsProd)
                //if (lDif > 10)
                //{

                    lCodigo = Dtg_Datos.Rows[i].Cells["Codigo"].Value.ToString();
                    Lbl_Msg.Text = "OBteniendo Datos . . . 1/4 "; Application.DoEvents();
                    ObtenerdatosPorViaje(lCodigo, UsaQR);
                    // MessageBox.Show("Se debe ejecutar PHP");
                    lLot.ObtenerDatosCertificados_WB();
                    Lbl_Msg.Text = "OBteniendo Datos . . . 2/4 "; Application.DoEvents();
                    ObtenerRegistrosColadasCetificados();
                    Lbl_Msg.Text = "Actualizando  Datos . . . 3/4 "; Application.DoEvents();
                    ActualizaCetificados();
                    Lbl_Msg.Text = "Descargando   Datos . . . 4/4 "; Application.DoEvents();
                    DescargaPdfs_WB();
                    Lbl_Msg.Text = " Inicializando  "; Application.DoEvents();
                    Repara();
                    CargaViajes();
               // }
                //}
            }
        }



        private void CopiarCertificados()
        {
            int i = 0; string lCodigo = ""; DataTable lTNl = new DataTable();
            string lSucursal = "Calama";

            for (i = 0; i < Dtg_Datos.RowCount; i++)
            {
                //if (Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString() == "0")
                //{
                lCodigo = Dtg_Datos.Rows[i].Cells["Codigo"].Value.ToString();



            }


        }

        private void Btn_Copia_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GeneraDoc_Click(object sender, EventArgs e)
        {


            //If(Dtg_Datos .s)
            //ImprimeCertificadoManofactura(Lbl_Viaje.Text, "123", "Pruebas", "9999999", "Nro Pedido", "Empresa constructora");
            //ImprimeResumenTrazabilidad(Lbl_Viaje.Text );
        }


        


       

        
       
        private void Dtg_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;

            if (lIndex > -1)
            {
                this.Lbl_Viaje.Text = Dtg_Datos.Rows[lIndex].Cells["Codigo"].Value.ToString();
            }
        }

        private void Btn_ProcesaViaje_Click(object sender, EventArgs e)
        {
            ClasificaViajes();
        }


        private void ProcesaViaje(string iViaje)
        {
            string lPathArchivo = ""; string[] separators = { "-" };
            string[] lPartes = iViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (lPartes.Length > 1)
            {
                lPathArchivo = string.Concat(lPathArchivo, lPartes[0], "\\");
                if (Directory.Exists(lPathArchivo) == false)
                {
                    Directory.CreateDirectory(lPathArchivo);
                }
                lPathArchivo = string.Concat(lPathArchivo, iViaje.Replace("/", "_"), "\\");
                // creamos el directorio de la IT EJEMPLO  AVA/AVA-1_1
                if (Directory.Exists(lPathArchivo) == false)
                {
                    Directory.CreateDirectory(lPathArchivo);
                }
                //lPathArchivo ESTA La path de los archivos a copiar
                //Archivos: Certificados de GArdau, Certificado de fabricacion, 



            }



        }

        private void CambiaEstosCertificadosOK(string iviaje, string iTipo)
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";

            if (iTipo == "O")
            {
                lSql = string.Concat(" Update viaje set CertificadosOK='S' where codigo='", iviaje, "'");
                lPx.ObtenerDatos(lSql);
            }
            else
            {
                lSql = string.Concat(" Update viaje set CertificadosOK='P' where codigo='", iviaje, "'");
                lPx.ObtenerDatos(lSql);
            }


            Lbl_Viaje.Text = "";


        }

        private void Btn_CertificadosOK_Click(object sender, EventArgs e)
        {

            CambiaEstosCertificadosOK(Lbl_Viaje.Text, "O");
        }

        private void Btn_GeneraDocumentacion_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0; int k = 1;
            Clases.Cls_EnvioDoc lCom = new Clases.Cls_EnvioDoc();

            //            Select*
            //from viaje v, it, Obras o , DetallePaquetesPieza d, LOG_PIEZA_PRODUCCION
            // where CertificadosOK = 'S' and(CarpetaOK is null or CarpetaOK <> 'S')
            //and v.idit = it.id and it.idobra = o.id and o.estadoalta not in ('Fin')
            //and d.IdViaje = v.id and d.id = LOG_ETIQUETA_PIEZA  and LOG_FECHA > '01/03/2020 00:00:01'
            //order by log_fecha


            //lSql = "  Select distinct  Codigo  from viaje v, it, Obras o , DetallePaquetesPieza d , LOG_PIEZA_PRODUCCION       ";
            lSql = "  Select distinct  Codigo  from viaje v, it, Obras o , DetallePaquetesPieza d       ";
            lSql = string.Concat(lSql, " where CertificadosOK = 'S' and(CarpetaOK is null or CarpetaOK <> 'S') ");
            lSql = string.Concat(lSql, " and v.idit = it.id and it.idobra = o.id and o.estadoalta not in ('Fin')   ");
            lSql = string.Concat(lSql, " and d.IdViaje = v.id  ");
            // and d.id = LOG_ETIQUETA_PIEZA
            //lSql = string.Concat(lSql, " and  codigo in ('QBF-944/1','QBF-949/1') ");
            // and LOG_FECHA > '01/03/2020 00:00:01'  "); 
            lDts = lPx.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                if (k > 15)
                    this.Close();

                lTbl = lDts.Tables[0].Copy();
                Dtg_Datos.DataSource = lTbl;
                Dtg_Datos.Refresh();
                Application.DoEvents();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lCom.GeneraDocumentacionEnCarpeta(lTbl.Rows[i]["Codigo"].ToString());
                    Lbl_Msg.Text = string.Concat("Procesando ", i, " de ", lTbl.Rows.Count, " Viaje: ", lTbl.Rows[i]["Codigo"].ToString());
                    System.Threading.Thread.Sleep(1000);
                    k = k++;
                }

            }

        }



       

       
        private void Btn_CertPEND_Click(object sender, EventArgs e)
        {
            CambiaEstosCertificadosOK(Lbl_Viaje.Text, "P");
        }

        private void Btn_RepararDup_Click(object sender, EventArgs e)
        {
            Repara();
        }

        private void Repara_OLd()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string IdEt = ""; string lLote = ""; DataSet lDtsTmp = new DataSet();

            lSql = " select  IdPaquete , count(1) , ((Select NroColada  from Colada c , PIEZA_PRODUCCION  where c.id=PIE_ETIQUETA_COLADA  and PIE_ETIQUETA_PIEZA =IdPaquete )) coladaOK    ";
            lSql = string.Concat(lSql, "  from CertificadosPaquete group by  IdPaquete having count(1) >1   ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();  // tabla con los lotes del viaje 
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    // Pueden haber 2 coladas, pero la que esta en tabla Pieza_produccion es la buena.
                    IdEt = lTbl.Rows[i]["IdPaquete"].ToString();
                    lLote = lTbl.Rows[i]["coladaOK"].ToString();
                    lSql = string.Concat(" Delete from CertificadosPaquete where idpaquete=", IdEt);
                    lSql = string.Concat(lSql, " and lote <> '", lLote, "'");
                    lDtsTmp = lPx.ObtenerDatos(lSql);

                }
            }
        }

        private void Repara()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataSet lDtsTmp = new DataSet();

            lSql = "select idpaquete, count(1), 'delete from CertificadosPaquete where id=' + convert(varchar, min(id) ) as TxSql  ";
            lSql = string.Concat(lSql, " from CertificadosPaquete group by idpaquete  having count(1) >1   ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0];
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lSql = lTbl.Rows[i]["TxSql"].ToString();
                    lPx.ObtenerDatos(lSql);
                }
            }
        }

        private void ClasificaViajes()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataSet lDtsTmp = new DataSet();
            string lCodigo = ""; DataTable lTNl = new DataTable(); string UsaQR = "";
            int KgsIt = 0; int kgsProd = 0; int kgsCert = 0; Clases.Cls_EnvioDoc lCom = new Clases.Cls_EnvioDoc();
            int lDif = 0;

            for (i = 0; i < Dtg_Datos.RowCount-1; i++)
            {
                KgsIt = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsIT"].Value.ToString());
                kgsProd = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsProducidos"].Value.ToString());
                kgsCert = lCom.Val(Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString());
                //UsaQR = Dtg_Datos.Rows[i].Cells["UsaQR"].Value.ToString();
                lCodigo = Dtg_Datos.Rows[i].Cells["Codigo"].Value.ToString();

                lDif = Math.Abs(kgsCert - kgsProd);

                //if (kgsProd == KgsIt)
                //{
                if ((lDif < 3) && (lDif > -2))//Estamos OK
                    CambiaEstosCertificadosOK(lCodigo, "O");
                else
                    CambiaEstosCertificadosOK(lCodigo, "P");
                //}
            }
        }


        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            CargaViajes();
        }

        private void Btn_Reprocesacol_Click(object sender, EventArgs e)
        {
            if (Lbl_Viaje.Text.Trim().Length > 0)
                ReprocesaColadas(Lbl_Viaje.Text);
            else
                ReprocesaColadas();
        }

        private void ReprocesaColadas( string iViaje )
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataSet lDtsTmp = new DataSet();string lDato = "";int lCont = 0;
            string[] separatingStrings = { "}," }; string lLote = "";
            DataTable lTblIT = new DataTable(); string lTx = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            lSql = String.Concat("  SP_Consultas_WS  192,'", iViaje, "','','','',',','',''");
            lDts = lPx.ObtenerDatos(lSql);
            //lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblIT = lDts.Tables[0].Copy();
                for (i = 0; i < lTblIT.Rows.Count; i++)
                {

                    lSql = string.Concat(" SP_Consultas_ActaEntrega  15,'", lTblIT.Rows[i]["LoteAza"].ToString(), "','", lTblIT.Rows[i]["Id"].ToString(),"','','','','',''");
                    lDtsTmp = lPx.ObtenerDatos(lSql);
                    if (lTblIT.Rows[i]["UrlCertificado"].ToString ().Trim ().Length ==0)
                    {
                   
                    lLote = lTblIT.Rows[i]["LoteAza"].ToString();
                        if (lTx.IndexOf(lLote) < 0)
                        {
                            lSql = string.Concat("select    * from  lotes  where  lote='", lLote, "'");
                            lTbl = lLot .CargarDatos(lSql);
                            if (lTbl.Rows.Count > 0)
                            {
                                lTx = string.Concat(lTx, " - ", lLote);
                                lDato = lTbl.Rows[0]["Respuesta"].ToString();
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
                                            string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                            if (lPartesColada.Length == 5)
                                            {
                                                PesisteDatosReProcesa(lLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } 
            }
            MessageBox.Show("Fin");
        }


        private void ProcesaColadaQR( string lViaje )
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            DataTable lTblIT = new DataTable(); string lTx = ""; int i = 0;
            DataSet lDtsTmp = new DataSet(); string lDato = ""; int lCont = 0;
            string[] separatingStrings = { "}," }; string lLote = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            lSql = String.Concat("  SP_Consultas_WS  192,'", lViaje, "','','','',',','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblIT = lDts.Tables[0].Copy();
                for (i = 0; i < lTblIT.Rows.Count; i++)
                {
                    lSql = string.Concat(" SP_Consultas_ActaEntrega  15,'", lTblIT.Rows[i]["LoteAza"].ToString(), "','", lTblIT.Rows[i]["Id"].ToString(), "','','','','',''");
                    lDtsTmp = lPx.ObtenerDatos(lSql);
                    if (lTblIT.Rows[i]["UrlCertificado"].ToString().Trim().Length == 0)
                    {
                        lLote = lTblIT.Rows[i]["LoteAza"].ToString();
                        if (lTx.IndexOf(lLote) < 0)
                        {
                            lSql = string.Concat("select    * from  lotes  where  lote='", lLote, "'");
                            lTbl = lLot.CargarDatos(lSql);
                            if (lTbl.Rows.Count > 0)
                            {
                                lTx = string.Concat(lTx, " - ", lLote);
                                lDato = lTbl.Rows[0]["Respuesta"].ToString();
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
                                            string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                            if (lPartesColada.Length == 5)
                                            {
                                                PesisteDatosReProcesa(lLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lSql = string.Concat(" SP_Consultas_ActaEntrega  17,'", lLote, "',' ','','','','',''");
                                lDtsTmp = lPx.ObtenerDatos(lSql);
                            }
                        }
                    }
                }
            }
            }

        private void ProcesaColada_SIN_QR(string lViaje)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            DataTable lTblIT = new DataTable(); string lTx = ""; int i = 0;
            DataSet lDtsTmp = new DataSet(); string lDato = ""; int lCont = 0;
            string[] separatingStrings = { "}," }; string lLote = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            lSql = String.Concat(" SP_Consultas_ActaEntrega 10, '",lViaje ,"', ' ', '', '', '', '', ''");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblIT = lDts.Tables[0].Copy();
                for (i = 0; i < lTblIT.Rows.Count; i++)
                {
                    lSql = string.Concat(" SP_Consultas_ActaEntrega  15,'", lTblIT.Rows[i]["NroColada"].ToString(), "','", lTblIT.Rows[i]["Id"].ToString(), "','','','','',''");
                    lDtsTmp = lPx.ObtenerDatos(lSql);
                    //if (lTblIT.Rows[i]["UrlCertificado"].ToString().Trim().Length == 0)
                    //{
                        lLote = lTblIT.Rows[i]["NroColada"].ToString();
                        if (lTx.IndexOf(lLote) < 0)
                        {
                            lSql = string.Concat("select    * from  lotes  where  lote='", lLote, "'");
                            lTbl = lLot.CargarDatos(lSql);
                            if (lTbl.Rows.Count > 0)
                            {
                                lTx = string.Concat(lTx, " - ", lLote);
                                lDato = lTbl.Rows[0]["Respuesta"].ToString();
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
                                            string[] lPartesColada = (lDato.Split(new Char[] { ',' }));
                                            if (lPartesColada.Length == 5)
                                            {
                                                PesisteDatosReProcesa(lLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());

                                            }
                                        }
                                    }
                                }
                            }
                        else
                        {
                            lSql = string.Concat(" SP_Consultas_ActaEntrega  17,'", lLote, "',' ','','','','',''");
                            lDtsTmp = lPx.ObtenerDatos(lSql);
                        }
                        //}
                    }
                }
            }
        }

        private void ReprocesaColadas( )
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            int k = 0;
            string lViaje = "";
         

            PB.Maximum = Dtg_Datos.Rows.Count;
            PB.Minimum = 0; PB.Value  = 0;
            for (k = 0; k < Dtg_Datos.Rows.Count -1; k++)
            {

                if (Dtg_Datos.Rows[k].Cells["UsaQR"].Value.ToString().Equals("S"))
                {
                    lViaje = Dtg_Datos.Rows[k].Cells["Codigo"].Value.ToString();
                    ProcesaColadaQR(lViaje);
                }
                else
                {
                    lViaje = Dtg_Datos.Rows[k].Cells["Codigo"].Value.ToString();
                    ProcesaColada_SIN_QR(lViaje);
                }
             
                if (PB.Value < PB.Maximum)
                    PB.Value = PB.Value + 1;
                else
                    PB.Value = PB.Value - 1;

                this.Refresh(); Application.DoEvents();
            }
        }


        private void NotificaLotesNOEncontrados()
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            int k = 0;
            string lViaje = "";


            PB.Maximum = Dtg_Datos.Rows.Count;
            PB.Minimum = 0; PB.Value = 0;
            for (k = 0; k < Dtg_Datos.Rows.Count - 1; k++)
            {
                lViaje = Dtg_Datos.Rows[k].Cells["Codigo"].Value.ToString();
                lSql = string.Concat(" SP_Consultas_WS  192,'", lViaje, "','','','',',','','' ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        if (lTbl.Rows[i]["UrlCertificado"].ToString().Trim().Length == 0)
                        {

                        }

                    }
                }

                if (Dtg_Datos.Rows[k].Cells["UsaQR"].Value.ToString().Equals("S"))
                {
                  
                    ProcesaColadaQR(lViaje);
                }
                else
                {
                    ProcesaColada_SIN_QR(lViaje);
                }

                if (PB.Value < PB.Maximum)
                    PB.Value = PB.Value + 1;
                else
                    PB.Value = PB.Value - 1;

                this.Refresh(); Application.DoEvents();
            }
        }

        private Boolean NotificarLote(string iLote)
        {
            Boolean lRes = false;

            return lRes;
        }

        private void BuscarDespachos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataSet lDtsTmp = new DataSet(); string lSuc = ""; string lEstado = "";
            DataSet lDts2 = new DataSet(); DataTable lTbl2 = new DataTable();
              int lKgsCert = 0; int lKgsProd = 0; int lDif = 0;

            lSuc = Cmb_Suc.SelectedValue.ToString();
            lEstado = Cmb_Estado.SelectedValue.ToString();
            lSql = String.Concat(" SP_Consultas_WS 203,'", lSuc, "','", lEstado, "',' ',' ','','',''  ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0];
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lSql = String.Concat(" SP_Consultas_WS 191,'", lTbl.Rows[i]["Codigo"].ToString(), "','','','','','',''  ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTbl2= lDts.Tables[0];
                        lTbl.Rows[i]["KgsCertificados"] = Math.Round (double .Parse (lTbl2.Rows[0]["KgsCertificado"].ToString ()) ,0);
                    }
                }
                Dtg_Datos.DataSource = lTbl;

                for (i = 0; i < Dtg_Datos.Rows.Count - 1; i++)
                {

                    lKgsCert = Val(Dtg_Datos.Rows[i].Cells["KgsCertificados"].Value.ToString());
                    lKgsProd = Val(Dtg_Datos.Rows[i].Cells["KgsProducidos"].Value.ToString());

                    lDif = lKgsProd - lKgsCert;



                    if (lDif < 3)
                        Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightYellow;

                    if (lDif > 2)
                        Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightSalmon;


                    if (lDif == 0)
                        Dtg_Datos.Rows[i].Cells["KgsCertificados"].Style.BackColor = Color.LightGreen;

                }
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            BuscarDespachos();
        }

        private void EnviarMail_ACliente()
        {


            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lBody = "";
            string lSql = ""; DataTable lTbl = new DataTable(); int i = 0;  DataSet  lTblViajes = new DataSet();
            EnviosAutomaticos lEnvio = new EnviosAutomaticos();

            lSql = String.Concat(" SP_Consultas_WS 206,'','',' ',' ','','',''  ");
            lTblViajes=lPx.ObtenerDatos(lSql);
            if ((lTblViajes.Tables.Count > 0) && (lTblViajes.Tables[0].Rows.Count > 0))
            {
                lTbl = lTblViajes.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lEnvio.EnviaMail_Doc_Calidad(lTbl.Rows[i]["Codigo"].ToString(), lTbl.Rows[i]["IdObra"].ToString());
           

                }
            }
            lEnvio.Close();
        }

        private void Btn_actualizaLote_Click(object sender, EventArgs e)
        {
            //DataTable lTbl = new DataTable(); DataView lVista = new DataView();
            //lTbl= VerProximosDespachos();
            //lVista = new DataView(lTbl, "", "Pr", DataViewRowState.CurrentRows);
            //Dtg_Datos.DataSource = lVista;

            //estiloMillaresDataGridViewColumn(Dtg_Datos, 2);
            //estiloMillaresDataGridViewColumn(Dtg_Datos, 3);
            //estiloMillaresDataGridViewColumn(Dtg_Datos, 4);

            ReparaCodigos();
        }

        private void ReparaCodigos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();string lSql = ""; DataTable lTbl = new DataTable();
            DataSet lDts  = new DataSet();int i = 0;string lCod = ""; DataTable lTbl2 = new DataTable();
            string lCodTO = "";

            lSql = " select codigo ,count(1)  from EtiquetaAZA e  where  not exists  ";
            lSql = string.Concat(lSql, "  ( select 1 from MateriaPrima m where m.codigo=e.codigo)   ");
            lSql = string.Concat(lSql, "  group by codigo  ");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables .Count >0)
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lCod = lTbl.Rows[i]["codigo"].ToString();
                    lSql = string .Concat (" select * from  to_parametros  where par1='", lCod,"' and par3='Santiago'");
                    lDts = lPx.ObtenerDatos(lSql);
                    lTbl2 = lDts.Tables[0].Copy();
                    if (lTbl2.Rows.Count > 0)
                    {
                        lCodTO= lTbl2.Rows[0]["Par2"].ToString();
                        lSql = string.Concat(" update EtiquetaAZA set  Codigo ='", lCodTO,"' where codigo ='", lCod,"' ");
                        lDts = lPx.ObtenerDatos(lSql);
                    }

                }
            }
        }


        private DataTable  VerProximosDespachos()
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lTmp = "";string lProcesados = "";
            string lSql = ""; DataTable lTbl = new DataTable(); int i = 0; DataSet lTblViajes = new DataSet();
            EnviosAutomaticos lEnvio = new EnviosAutomaticos(); string lCol_Obras = "";DataView lVista = null;
            DataTable lTblTmp = new DataTable(); DataTable lTblFin = new DataTable();DataRow lFila = null;
            DataView lVistaFecha = null;
            string[] separatingStrings = { "-" }; int k = 0; string lSiglaObra = ""; int lCont = 0; int lImporte = 0; int m = 0;

            lTblFin.Columns.Add("Pr", Type.GetType("System.String"));
            lTblFin.Columns.Add("Fecha", Type.GetType("System.DateTime"));
            //type.gettype( system.date )
            //lTblFin.Columns.Add("Total", Type.GetType("System.Int32"));


            lSql = "  SP_Consultas_WS  154, '%76879426%', '26/08/2020 00:00:01', '02/09/2021 23:59:59', '', '', '', '' ";
            lTblViajes = lPx.ObtenerDatos(lSql);
            if ((lTblViajes.Tables.Count > 0) && (lTblViajes.Tables[0].Rows.Count > 0))
            {
                lTbl = lTblViajes.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    // Obtenemos las distintas obras del Rut 
                    lTmp = lTbl.Rows[i]["SiglaObra"].ToString();
                    if (lProcesados.IndexOf(lTmp) == -1)
                    {
                        lProcesados = string.Concat(lProcesados, lTmp, "-");
                        lTblFin.Columns.Add(lTmp, Type.GetType("System.Int32"));

                    }
                }
                if (lProcesados.Length > 3)
                    lCol_Obras = lProcesados.Substring(0, lProcesados.Length - 1);

                lTblFin.Columns.Add("Total", Type.GetType("System.Int32"));

                string lTmpFc = "";
                //AHora los Meses-Años a visualizar
                string[] lpartes = lCol_Obras.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                lProcesados = ""; lTblTmp = lTbl.Copy();
                for (k = 0; k < lTblTmp.Rows .Count ; k++)
                {
                    lTmp = lTblTmp.Rows[k]["Id"].ToString();
                    lVista = new DataView(lTblTmp, string.Concat("Id=", lTmp), "", DataViewRowState.CurrentRows);
                    if ( (lProcesados.IndexOf(lTmp) == -1) &&  (lVista.Count > 0))
                    {
                        for (i = 0; i < lVista.Count; i++) //Por Obra 
                        {
                            lTmpFc = string.Concat(lVista[i]["Dia"].ToString(), "/",  lVista[i]["Mes"].ToString(), "/",   lVista[i]["Año"].ToString());
                            lSiglaObra = lVista[i]["SiglaObra"].ToString();
                            lFila = lTblFin.NewRow();
                            lVistaFecha = new DataView(lTblFin, string.Concat("Fecha='", lTmpFc, "'"), "", DataViewRowState.CurrentRows);
                            //if (lTblFin.Select(string.Concat("Fecha='", lTmpFc, "'")).Length == 0)
                            if (lVistaFecha.Count  == 0)
                            {
                                lImporte = 0;
                                lFila["Fecha"] = lTmpFc;
                                for (lCont = 0; lCont < lTblFin.Columns.Count; lCont++)
                                {
                                    if (lSiglaObra.ToUpper().Equals(lTblFin.Columns[lCont].ColumnName.ToString().ToUpper()))
                                    {
                                        for (m = 0; m < lVista.Count; m++)
                                        {
                                            if (string.Concat(lVista[m]["Dia"].ToString(), "/", lVista[m]["Mes"].ToString(), "/", lVista[m]["Año"].ToString()).Equals(lTmpFc))
                                                lImporte = lImporte + Val(lVista[m]["Kgs"].ToString()) * Val(lVista[m]["ImporteKgs"].ToString());
                                        }

                                        if (lProcesados.IndexOf(lTmp) == -1)
                                        {
                                            lProcesados = string.Concat(lProcesados, lTmp, "-");
                                        }
                                    }

                                    lFila[lSiglaObra] = lImporte;
                                }
                            }
                            else
                            {
                                for (lCont = 0; lCont < lTblFin.Columns.Count; lCont++)
                                {
                                    if (lSiglaObra.ToUpper().Equals(lTblFin.Columns[lCont].ColumnName.ToString().ToUpper()))
                                    {
                                        lImporte = 0;
                                        for (m = 0; m < lVista.Count; m++)
                                        {
                                            if (string.Concat(lVista[m]["Dia"].ToString(), "/", lVista[m]["Mes"].ToString(), "/", lVista[m]["Año"].ToString()).Equals(lTmpFc))
                                                lImporte = lImporte + Val(lVista[m]["Kgs"].ToString()) * Val(lVista[m]["ImporteKgs"].ToString());
                                        }

                                        if (lProcesados.IndexOf(lTmp) == -1)
                                        {
                                            lProcesados = string.Concat(lProcesados, lTmp, "-");
                                        }
                                    }
                                    lVistaFecha[0][lSiglaObra] = lImporte;
                                    //lFila[lSiglaObra] = lImporte;
                                }
                            }

                            if (lFila ["Fecha"].ToString ().Trim ().Length >0)
                            lTblFin.Rows.Add(lFila);
                        }
                    }
                }
   

            } 
                lFila = lTblFin.NewRow();
            for (m = 3; m < lTblFin.Columns .Count ; m++)
            {
                lImporte = 0;
                for (i = 0; i < lTblFin.Rows .Count; i++)
                {
                        lImporte = lImporte + Val(lTblFin.Rows [i][m].ToString()) ;
                }
                lFila[m] = lImporte;
            }
            lTblFin.Rows.Add(lFila);

            for (m = 0; m < lTblFin.Rows .Count; m++)
            {
                lImporte = 0;
                for (i = 3; i < lTblFin.Columns .Count; i++)
                {
                    lImporte = lImporte + Val(lTblFin.Rows[m][i].ToString());
                }
                lTblFin.Rows[m]["Total"] = lImporte;
            }


            lVista = new DataView(lTblFin, "", "Fecha", DataViewRowState.CurrentRows);
            for (i = 0; i < lVista.Count; i++)
            {
                lVista[i]["Pr"] = i + 1;
            }

            lVista[0]["Pr"] = lVista.Count + 2;

            return lTblFin;
        }

        public void estiloMillaresDataGridViewColumn(DataGridView dgv, int  columnsIndex)
        {
            //foreach (int columnIndex in columnsIndex)
            //{
                if (columnsIndex <= dgv.Columns.Count)
                {
                    dgv.Columns[columnsIndex].DefaultCellStyle.Format = "N0";
                    dgv.Columns[columnsIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ;
                }
            //}
        }

        private void Btn_NotificaLotes_Click(object sender, EventArgs e)
        {
            EnviarMail_ACliente();

            //EnviosAutomaticos lDal = new EnviosAutomaticos();
            //lDal.EnviaMail_Lotes_NO_Encontrados();
            //lDal.Close();

            //EnviosAutomaticos lDal = new EnviosAutomaticos();
            //lDal.NotificarCierreTotems();
            //lDal.Close();


        }

        private void Dtg_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int  lIndex = e.RowIndex;
            string lUsaQr = Dtg_Datos.Rows[lIndex].Cells["UsaQR"].Value.ToString();
            string lCodigo = Dtg_Datos.Rows[lIndex].Cells["Codigo"].Value.ToString();

            Frm_CertificacionViaje lFrm = new Frm_CertificacionViaje();
            lFrm.Inicialida(lCodigo);
            lFrm.ShowDialog();

        }

        private void Dtg_Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
