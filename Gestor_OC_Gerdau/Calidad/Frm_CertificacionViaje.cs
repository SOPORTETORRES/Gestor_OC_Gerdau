using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private string mDiametro = "";
        private string mIdEtiqueta = "";
        private DataTable mTblEtViaje = new DataTable();
        private DataTable mTblTotes = new DataTable();
        private DataTable mTblCC = new DataTable();

        public Frm_CertificacionViaje()
        {
            InitializeComponent();
        }


        private Boolean ExisteRegistro(string iDato, string iTipo)
        {
            DataView lVista = null; string lWhere = "";
           DataTable lTbl = new DataTable(); 
            Boolean lRes = false; string lSql = "";

            if (iTipo.ToUpper().Equals("E"))   //etiqeutaTO
            {
                lWhere = string.Concat(" id=", iDato );
                lVista = new DataView(mTblEtViaje, lWhere, "", DataViewRowState.CurrentRows);
                if (lVista.Count >0)
                      lRes = true;
                else
                    lRes = false;              
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

        public void Inicialida(string iViaje)
        {
            mViaje = iViaje;

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();  
            lSql = String.Concat("  select  d.id  from viaje v , DetallePaquetesPieza d where d.IdViaje =v.id  and codigo='", iViaje,"' ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblEtViaje = lDts.Tables[0].Copy();
            }


            lSql = String.Concat("  select  d.id  from viaje v , DetallePaquetesPieza d , certificadosPaquete cc ");
            lSql = String.Concat( lSql , " where d.IdViaje =v.id  and d.id=cc.IdPaquete  and codigo='", iViaje, "' and len(cc.lote)>0 ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblCC = lDts.Tables[0].Copy();
            }
            // 

        }

        public void ObtenerTblLotes(string iLotes)
        {
            
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            lSql = String.Concat("  select   lote from certificadosColadas where lote in ( ",iLotes ,")");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblTotes = lDts.Tables[0].Copy();
            }

        }

        public void CargaDatos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();            string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lLotesPr = ""; string lLote = "";
            if (Tx_Codigo.Text.Trim().Length > 4)
                mViaje = Tx_Codigo.Text;

            lSql = String.Concat("  SP_Consultas_WS  192,'", mViaje, "','','','',',','',''");

            Btn_CorrigueEV.Enabled = false;

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Dtg_Datos.DataSource = lTbl;

                for (i = 0; i < Dtg_Datos.RowCount - 1; i++)
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
                            Dtg_Datos.Rows[i].Cells["LoteAza"].Style.BackColor = Color.LightGreen;
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
            string lRes = ""; string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); WebClient cliente = null;
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            string lSql = string.Concat("  select top 1000 * from CertificadosColadas  where estado is null  ");
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
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString());
                        lLote = lTbl.Rows[i]["lote"].ToString();
                        lNombreArc = string.Concat(lLote, "_C.pdf");
                        lPathFin = System.IO.Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                        lLlave = lLot.ObtieneLlave(url);
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
                        //lDts = lPx.ObtenerDatos(lSql);
                        //if (PB.Value < PB.Maximum)
                        //    PB.Value = PB.Value + 1;
                        //else
                        //    PB.Value = PB.Value - 1;

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
            ActualizaLote(Lbl_Lote .Text );
            Lbl_Lote.Text = "";
            CargaDatos();
        }

        private void ActualizaLote(string iLote)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

            // 0.- Revisamos si esta en tabla certificadosColadas.
            lSql = string.Concat("select * from certificadosColadas  where  lote='", iLote, "'");
            lDts = lPx.ObtenerDatos(lSql);
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
                    DescargaPdfs_WB(iLote);
                
                //else
                //{
                //    ActualizaCetificados(iLote);
                //    DescargaPdfs_WB(iLote);
                //}

            }
            else
            {
                ActualizaCetificados(iLote);
                DescargaPdfs_WB(iLote);
            }


        }

        private void DescargaPdfs_WB(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; string lPathFin = "";
            string lRes = ""; string lLote = ""; string url = "";
            Calidad.Frm_WB lFrm = new Frm_WB(); string lLlave = ""; string lNombreArc = "";

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


                    //PB.Maximum = lTbl.Rows.Count; PB.Minimum = 0; PB.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        // 1.- Certificado Url_Certificado
                        url = System.IO.Path.Combine(lTbl.Rows[i]["Url_Certificado"].ToString());
                        lLote = lTbl.Rows[i]["lote"].ToString();
                        lNombreArc = string.Concat(lLote, "_C.pdf");
                        lPathFin = System.IO.Path.Combine(@"C:\Roberto Becerra\TO\Requerimientos\2019\Calidad\Docs\", lNombreArc);
                        lLlave = lLot.ObtieneLlave(url);
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
                        //if (PB.Value < PB.Maximum)
                        //    PB.Value = PB.Value + 1;
                        //else
                        //    PB.Value = PB.Value - 1;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem: " + ex.Message);

                }

            }

            //  MessageBox.Show("FIN");

        }

        private void ActualizaCetificados(string iLote)
        {
            DataTable lTbl = new DataTable(); int i = 0; int lCont = 0;
            string lSql = ""; string lRes = ""; string lDato = "";
            Clases.Cls_Lotes lLot = new Clases.Cls_Lotes();

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
                    if (lTbl.Rows[i]["Respuesta"].ToString ().Length>5 )
                    {
                        lDato = lTbl.Rows[i]["Respuesta"].ToString();
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
                                        lLot.PesisteDatos(iLote, lPartesColada[3].ToString(), lPartesColada[1].ToString(), lPartesColada[2].ToString(), lPartesColada[4].ToString());
                                        //if (PB.Value < PB.Maximum)
                                        //    PB.Value = PB.Value + 1;
                                        //else
                                        //    PB.Value = PB.Value - 1;
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
                        lLote = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();
                        if (lLote.Trim().Length == 0)
                            lLote = Dtg_Datos.Rows[i].Cells["LoteAZA"].Value.ToString();


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
                            lLote = Dtg_Datos.Rows[i].Cells["Lote"].Value.ToString();
                            if (lLote.Trim().Length == 0)
                                lLote = Dtg_Datos.Rows[i].Cells["LoteAZA"].Value.ToString();


                            lSql = string.Concat(lSql, lLote.ToString(), "',");
                            lSql = string.Concat(lSql, Dtg_Datos.Rows[i].Cells["Id"].Value.ToString(), ", getdate()) ");
                            lPx.ObtenerDatos(lSql);
                        }

                    }
                   
                }

            }
            Inicialida(mViaje );
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
    }
}
