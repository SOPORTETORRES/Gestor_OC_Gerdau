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
    public partial class Importar_NewCodigos : Form
    {
        private DataTable mTblDatos = new DataTable();

        public Importar_NewCodigos()
        {
            InitializeComponent();
        }

        private void CargaDatos(string iFilaTx, string iSucursal)
        {
            DataRow lFila = mTblDatos.NewRow();
           
            string[] lPartes = iFilaTx.Split(new Char[] { ';' });

            if (lPartes[0].ToString().Equals(iSucursal))
            {
                lFila["CodigoANT"] = lPartes[1].ToString().Trim();
                lFila["CodigoNew"] = lPartes[2].ToString().Trim();
                mTblDatos.Rows.Add(lFila);
            }

            Dtg_Archivo.DataSource = mTblDatos;

        }

        private void CargaDatos_Traspaso_Consumo(string iFilaTx )
        {
          

            DataRow lFila = mTblDatos.NewRow();

            string[] lPartes = iFilaTx.Split(new Char[] { ';' });

     
                lFila["Id_Anterior"] = lPartes[0].ToString().Trim();
                lFila["Id_New"] = lPartes[1].ToString().Trim();
                mTblDatos.Rows.Add(lFila);
           

           

        }

        private void btn_sel_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;int i = 0;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    Tx_path.Text = filePath;
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                    mTblDatos = new DataTable();
                    mTblDatos.Columns.Add("Id_Anterior");
                    mTblDatos.Columns.Add("Id_New");
                    foreach (string line in System.IO.File.ReadLines(Tx_path.Text))
                    {
                        //CargaDatos(line, Tx_sucursal.Text);
                        CargaDatos_Traspaso_Consumo(line);
                         i++;
                    }
                    Dtg_Archivo.DataSource = mTblDatos;
                }
            }
        }

        private void Importar_NewCodigos_Load(object sender, EventArgs e)
        {
            mTblDatos.Columns.Add("CodigoANT");
            mTblDatos.Columns.Add("CodigoNew");
        }

        private Boolean ExisteCodigoMP(string lsucursal, string lCodigo)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" Select 1 from  materiaPrima where bodega='", lsucursal, "' and codigo='", lCodigo, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }

        private Boolean ExisteCodigo_ProductoIntegrado(string lsucursal, string lCodigo)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" Select 1 from  productosIntegradosINET where CodProducto='", lCodigo, "'  and Idsucursal=",lsucursal );
            lSql = string.Concat(lSql, "  and FechaIntegracion >'03/01/2022 00:00:01' ");

           lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }


        private Boolean ExisteCodigo_DePara(string lsucursal, string lCodigo)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" Select 1 from  to_parametros where subtabla like '%CodigoProd_INET_Cubigest%' " );
            lSql = string.Concat(lSql, "  and par3='", lsucursal, "' and par2='", lCodigo, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }

        private Boolean ActualizaCodifoMP(string lsucursal, string lCodigoANT, string lCodNew)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" update  materiaPrima  set   codigo='", lCodNew,"'  where bodega='", lsucursal, "' and codigo='", lCodigoANT, "'");
            lSql = string.Concat(lSql, "  select @@ROWCOUNT  ");
            lDts = lPx.ObtenerDatos(lSql);
           if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }


        private Boolean ActualizaCodigo_ProductoIntegrado(string lsucursal, string lCodigoANT, string lCodNew)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" update  productosIntegradosINET  set   codproducto='", lCodNew, "'  where Idsucursal='", lsucursal, "' and codproducto ='", lCodigoANT, "'");
            lSql = string.Concat(lSql, " and FechaIntegracion >'03/01/2022 00:00:01'  select @@ROWCOUNT  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }

        private Boolean ActualizaCodigo_DePara(string lsucursal, string lCodigoANT, string lCodNew)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" update  to_parametros  set   Par2='", lCodNew, "'  where Par3='", lsucursal, "' and par2='", lCodigoANT, "'");
            lSql = string.Concat(lSql, "  select @@ROWCOUNT  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }

        private Boolean ActualizaCodigo_EtiquetaAza(string lsucursal, string lCodigoANT, string lCodNew)
        {
            int IdSucursal = 0;

            if (lsucursal.ToUpper().Equals("1"))  //Santiago
                IdSucursal = 4;

            if (lsucursal.ToUpper().Equals("2")) //Calama
                IdSucursal = 1;

            if (lsucursal.ToUpper().Equals("3")) //Coronel
                IdSucursal = 14;

            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();
            lSql = string.Concat(" update  etiquetaAza  set   Codigo='", lCodNew, "'  where Id_sucursal=",IdSucursal );
            lSql = string.Concat(lSql, " and  Codigo='", lCodigoANT ,"'    select @@ROWCOUNT  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lRes = true;


            return lRes;
        }


        private void PintaFila(int iIndex, Color iColor)
        {
            int i = 0;
            for (i = 0; i < Dtg_Archivo.Columns.Count; i++)
            {
                Dtg_Archivo.Rows[iIndex].Cells[i].Style.BackColor = iColor;
            }

        }

        private void Btn_Procesar_Click(object sender, EventArgs e)
        {
            int i = 0; 
            string lSucursal = "";string lCodANT = ""; string lCodNew = "";

            if (Tx_sucursal.Text == "1")
                lSucursal = "Santiago";
            if (Tx_sucursal.Text == "2")
                lSucursal = "Calama";
            if (Tx_sucursal.Text == "3")
                lSucursal = "Coronel";

            for (i=0;i<Dtg_Archivo .Rows .Count;i++)
            {
                lCodANT = Dtg_Archivo.Rows[i].Cells["CodigoANT"].Value.ToString();
                lCodNew = Dtg_Archivo.Rows[i].Cells["CodigoNew"].Value.ToString();
                // para MateriaPrima
                //Si el codigo antiguo, existe en la tabla MateriaPrima ==> se actualiza con el codigo Nuevo, en Verde
                if (ExisteCodigoMP(lSucursal, lCodANT) == true)
                {
                    ActualizaCodifoMP(lSucursal, lCodANT, lCodNew);
                    PintaFila(i, Color.LightGreen);
                }
                //sino, si el codigo Nuevo existe en la tabla de materia prima ==> OK, en verde
                else
                    if (ExisteCodigoMP(lSucursal, lCodNew) == true)
                    PintaFila(i, Color.LightGreen);
                else
                    PintaFila(i, Color.LightSalmon);
                //Si el codigo antiguo y el codigo nuevo, NO existe en la tabla MateriaPrima ==> Se deja en Rojo.


                //******************Tabla de Intercambio de Para con AZA
                //    Si el codigo antiguo, existe en la tabla de Intercambio==> Se actualiza con el codigo Nuevo
                //    sino, si el codigo Nuevo existe en la tabla de Intercambio ==> OK, en verde
                //Si el codigo antiguo y el codigo Nuevo, NO existe en la tabla de Intercambio ==> Se deja en Rojo.
                if (ExisteCodigo_DePara(lSucursal, lCodANT) == true)
                {
                    ActualizaCodigo_DePara(lSucursal, lCodANT, lCodNew);
                    PintaFila(i, Color.LightGreen);
                }
                //sino, si el codigo Nuevo existe en la tabla de materia prima ==> OK, en verde
                else
                   if (ExisteCodigo_DePara(lSucursal, lCodNew) == true)
                    PintaFila(i, Color.LightGreen);
                else
                    PintaFila(i, Color.LightSalmon);

                //**************************Tabla EtiquetaAza
                ActualizaCodigo_EtiquetaAza(Tx_sucursal.Text, lCodANT, lCodNew);


            }


        }

        private void Btn_CambiaCod_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //string lSucursal = ""; string lCodANT = ""; string lCodNew = "";

            //if (Tx_sucursal.Text == "1")
            //    lSucursal = "4";
            //if (Tx_sucursal.Text == "2")
            //    lSucursal = "1";
            //if (Tx_sucursal.Text == "3")
            //    lSucursal = "14";

            //for (i = 0; i < Dtg_Archivo.Rows.Count; i++)
            //{
            //    lCodANT = Dtg_Archivo.Rows[i].Cells["CodigoANT"].Value.ToString();
            //    lCodNew = Dtg_Archivo.Rows[i].Cells["CodigoNew"].Value.ToString();
            //    // para MateriaPrima
            //    //Si el codigo antiguo, existe en la tabla MateriaPrima ==> se actualiza con el codigo Nuevo, en Verde
            //    if (ExisteCodigo_ProductoIntegrado(lSucursal, lCodANT) == true)
            //    {
            //        ActualizaCodigo_ProductoIntegrado(lSucursal, lCodANT, lCodNew);
            //        PintaFila(i, Color.LightGreen);
            //    }
             
              

            //}

        }

        private void Btn_EliminaConsumos_Click(object sender, EventArgs e)
        {
            Boolean lRes = false; string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();int i = 0;string lIdProcesado = "";string lIdActual = "";
            lSql = string.Concat("Select  IdMaquinaIntegra , p.CodProducto , idsucursal, d.id , p.id IdProducto,   *   ");
            lSql = string.Concat(lSql, " from DetalleProductoIntegrado  d, productosIntegradosINET p  ");
            lSql = string.Concat(lSql, "  where FechaRegistro >'03/01/2022 00:00:01' and EstadoIntegracion ='ER' ");
            lSql = string.Concat(lSql, "  and p.id =IdProductoIntegrado  and Idsucursal=4  ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lIdActual = lTbl.Rows[i]["IdProducto"].ToString();
                    lSql = string.Concat(" delete from  DetalleProductoIntegrado  where id=", lTbl.Rows[i]["Id"].ToString());
                    lDts = lPx.ObtenerDatos(lSql);

                    if (lIdProcesado.IndexOf(lIdActual) == -1)
                    {
                    lSql = string.Concat(" delete from  productosIntegradosINET  where id=", lTbl.Rows[i]["IdProducto"].ToString());
                    lDts = lPx.ObtenerDatos(lSql);
                        lIdProcesado = string.Concat(lIdProcesado , lIdActual, ",");
                    }
                }


            }

        }

        private void BTN_TOSOL_Click(object sender, EventArgs e)
        {
            ReparaTosol();
        }

        private void ReparaTosol()
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0; string lLogId = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); DataTable lTblTmp = new DataTable();
            lSql = string.Concat(" Select   log_ETIQUETA_PIEZA , count (1) Nro   ");
            lSql = string.Concat(lSql, " from LOG_PIEZA_PRODUCCION  ");
            lSql = string.Concat(lSql, "  where LOG_FECHA between '01/02/2022 00:00:01' and '28/02/2022 23:59:59'  ");
            lSql = string.Concat(lSql, "     and  log_IdMaquina in ( 301,302,303,304,306,308,309)   and LOG_ESTADO ='O40' ");
            lSql = string.Concat(lSql, " group by log_ETIQUETA_PIEZA  having count(1) >1 order by  log_ETIQUETA_PIEZA ");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lSql = string.Concat(" Update  LOG_PIEZA_PRODUCCION set LOG_ETIQUETA_COLADA='' where LOG_ESTADO='O60' and log_ETIQUETA_PIEZA=", lTbl.Rows[i]["log_ETIQUETA_PIEZA"].ToString());
                    lDts = lPx.ObtenerDatos(lSql);

                    lSql = string.Concat(" Select  top 1 *  from LOG_PIEZA_PRODUCCION where log_ETIQUETA_PIEZA=", lTbl.Rows[i]["log_ETIQUETA_PIEZA"].ToString(), "   and LOG_ESTADO ='O40' ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) || (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTblTmp = lDts.Tables[0].Copy();
                        lLogId = lTblTmp.Rows[0][0].ToString();
                        lSql = string.Concat(" Update  LOG_PIEZA_PRODUCCION set LOG_ETIQUETA_COLADA ='-5' where log_id=", lLogId);
                        lDts = lPx.ObtenerDatos(lSql);
                    }
                }
            }


        }

        private void Btn_CambiosConsumo_Click(object sender, EventArgs e)
        {
            CambioConsumo();
        }

        private void CambioConsumo()
        {
            DataSet lDts = new DataSet();
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0;
            for (i = 0; i < mTblDatos .Rows.Count; i++)
            {
                lSql = string.Concat(" update  PIEZA_PRODUCCION set  pie_etiqueta_pieza=", mTblDatos.Rows[i][1].ToString());
                lSql = string.Concat(lSql , " where  pie_etiqueta_pieza=",mTblDatos.Rows[i][0].ToString());
                lDts = lPx.ObtenerDatos(lSql);

                lSql = string.Concat(" update  Log_PIEZA_PRODUCCION set  log_etiqueta_pieza=", mTblDatos.Rows[i][1].ToString());
                lSql = string.Concat(lSql, " where  log_etiqueta_pieza=", mTblDatos.Rows[i][0].ToString());
                lDts = lPx.ObtenerDatos(lSql);

                lSql = string.Concat(" update  etiquetasVinculadas set  IdEtiquetaTO=", mTblDatos.Rows[i][1].ToString());
                lSql = string.Concat(lSql, " where  IdEtiquetaTO=", mTblDatos.Rows[i][0].ToString());
                lDts = lPx.ObtenerDatos(lSql);

            }

        }

        private void Btn_corrigueLC_Click(object sender, EventArgs e)
        {
            CorrigueLC();

        }

        private void CorrigueLC()
        {
            DataSet lDts = new DataSet(); DataTable lTblDatos = new DataTable(); DataTable lTmp = new DataTable();
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0; int k  = 0;
            string lRut = "";

            lSql = "  select *, (Select Count(1) from  LINEA_CREDITO_DETALLE where det_rut=Lin_rut ) as Nro ";
            lSql = string.Concat(lSql, " from linea_credito  where lin_bloqueado='N'  ");
       //     lSql = string.Concat(lSql, "  and ((Select Count(1) from  LINEA_CREDITO_DETALLE where det_rut=Lin_rut )=0)  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblDatos = lDts.Tables[0].Copy();
                for (i = 0; i < lTblDatos.Rows.Count; i++)
                {
                    lSql = string.Concat(" Select * from LINEA_CREDITO_DETALLE where det_rut  like '%");
                    lSql = string.Concat(lSql, lTblDatos.Rows[i]["Lin_Rut"].ToString().Substring(0, lTblDatos.Rows[i]["Lin_Rut"].ToString().Length - 2), "%'");
                    //lSql = string.Concat(lSql, "'");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTmp = lDts.Tables[0].Copy();
                        for (k = 0; k < lTmp.Rows.Count; k++)
                        {
                           // DataView lVista=new DataView (lTmp,"" )
                            if (lTmp.Rows[k]["Det_rut"].ToString().IndexOf ("-")==-1 )
                                {
                                lRut = string.Concat (lTblDatos.Rows[i]["Lin_Rut"].ToString().Substring(0, lTblDatos.Rows[i]["Lin_Rut"].ToString().Length - 2),"-", lTblDatos.Rows[i]["Lin_Rut"].ToString().Substring(  lTblDatos.Rows[i]["Lin_Rut"].ToString().Length - 1),1) ;
                            //    lSql = string.Concat(" update  LINEA_CREDITO_DETALLE set  det_rut='", lTblDatos.Rows[i]["Lin_Rut"].ToString(), "'");
                            //    lSql = string.Concat(lSql, " where  det_rut like '%", lTblDatos.Rows[i]["Lin_Rut"].ToString().Substring(0, lTblDatos.Rows[i]["Lin_Rut"].ToString().Length - 2), "%'");
                            //    lDts = lPx.ObtenerDatos(lSql);
                            }
                        }         
                    }                   
                }
            }
        }

    }
}
