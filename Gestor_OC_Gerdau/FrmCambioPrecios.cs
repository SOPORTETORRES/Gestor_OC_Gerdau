using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau
{
    public partial class FrmCambioPrecios : Form
    {
        DataTable mTblMeses = new DataTable();

        public FrmCambioPrecios()
        {
            InitializeComponent();
        }

        private void FrmCambioPrecios_Load(object sender, EventArgs e)
        {
            CargaDatosIniciales();
        }


        #region Metodos Privados

        private void CargaDatosIniciales()
        {
            DataRow lFila = null;
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();

            lDts = lPx.ObtenerParametro("Meses");
            if (lDts.Tables.Count > 0)
                mTblMeses = lDts.Tables[0].Copy();


            DateTime Hoy = DateTime.Today; string lDia = "";

            Cmb_Mes.DataSource = mTblMeses;
            Cmb_Mes.ValueMember = "Par2";
            Cmb_Mes.DisplayMember = "Par1";

            Tx_Year.Text = Hoy.Year.ToString();
            //lDia= Hoy.Month .ToString();

            if (Hoy.Month < 10)
                lDia = string.Concat("0", Hoy.Month.ToString());
            else
                lDia = Hoy.Month.ToString();


            //Cmb_Mes.SelectedValue  = lDia;
        }

        private DataTable ObtenerDatos(  string iYear, string iMes)
        {
            string lsql = ""; string lSucursal = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

        
            if (Rb_Santiago.Checked == true)
                lSucursal = "1";

            if (Rb_Calama .Checked == true)
                lSucursal = "2";

            if (Rb_Coronel .Checked == true)
                lSucursal = "3";

            //else
            //    lSucursal = "2";

            if (Rb_TO.Checked == true)
            {
                lsql = string.Concat(" SP_CambioPreciosINET 1,'", lSucursal, "','", iYear, "','", iMes, "','','',''");
                lDts = lPx.ObtenerDatos(lsql);
            }
            else
            {
                lsql = string.Concat(" SP_CambioPreciosINET 3,'", lSucursal, "','", iYear, "','", iMes, "','','',''");
                lDts = lPx.ObtenerDatos(lsql);
            }

            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;


            }


        private void CargaDatos(   string iYear, string iMes)
        {
            DataTable lTbl = new DataTable();
            int i = 0; int lNroReg = 0;

            //    if (Rb_Santiago.Checked == true)
            //        lSucursal = "1";
            //    else
            //        lSucursal = "2";

            //if (Rb_TO.Checked == true)
            //{
            //    lsql = string.Concat(" SP_CambioPreciosINET 1,'", lSucursal, "','", iYear, "','", iMes, "','','',''");
            //    lDts = lPx.ObtenerDatos(lsql);
            //}
            //else
            //{
            //    lsql = string.Concat(" SP_CambioPreciosINET 3,'", lSucursal, "','", iYear, "','", iMes, "','','',''");
            //    lDts = lPx.ObtenerDatos(lsql);
            //}

            lTbl = ObtenerDatos(iYear, iMes);
            if (lTbl.Rows .Count > 0)
                {
                    //lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lNroReg = lNroReg + int.Parse(lTbl.Rows[i]["NroRegistros"].ToString());
                }
                DataRow lFila = lTbl.NewRow();
                lFila["Codigo"] = "Total";
                lFila["NroRegistros"] = lNroReg;
                lTbl.Rows.Add(lFila);

                Dtg_Resultado.DataSource = lTbl;

                string lEmp = "";
                if (Rb_TO.Checked == true)
                    lEmp  = "TO";
                else
                    lEmp = "TOSOL";

                if (MesEstaCerrado(iYear, iMes, lEmp) == true)
                {
                    Btn_Grabar.Enabled = false;
                    MessageBox.Show("El Mes Seleccionado se encuentra Abierto, No se puede realizar ninguna Operación ", "Avisos Sistema", MessageBoxButtons.OK);
                }
                else
                    Btn_Grabar.Enabled = true;

                }
        }

        private Boolean MesEstaCerrado(string iYear, string iMes, string iEmpresa)
        {
            Boolean lRes = true;
            string lsql = "";  ; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            if (iEmpresa.ToUpper().Equals("TO"))
            {
                lsql = string.Concat(" SP_CambioPreciosINET 10,'','", iYear, "','", iMes, "','','',''");
            }
            if (iEmpresa.ToUpper().Equals("TOSOL"))
            {
                lsql = string.Concat(" SP_CambioPreciosINET 11,'','", iYear, "','", iMes, "','','',''");
            }

            if (lsql.Trim().Length > 0)
            {
                lDts = lPx.ObtenerDatos(lsql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    if (lDts.Tables[0].Rows[0][0].ToString().ToUpper().Equals("V"))
                    {
                        lRes = false;
                    }
                }

            }

            return lRes;
        }

        private Boolean EsNumero(string iDato)
        {
            Boolean lRes = true;
            try
            {
                int.Parse(iDato);
            }
             catch (Exception exc)
            {
                lRes = false;
            }
            return lRes;

        }


        private string EnvioCorreoPorCambioPrecio(string iEmp, string iSuc, string iYear, string iMes, string iNewPrecio, DataTable iTbl)
        {
             WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string iAsunto = string.Concat (" Cambio Precio Periodo ", iYear ,"-", iMes ," para Empresa: ", iEmp ) ;
             string lRes = ""; string lFuente = "";

            lRes = string.Concat(" Señores:  ", "  <br> ", "  <br> ");
            lRes = string.Concat(lRes, " Se ha realizado un cambio de precios con los siguientes datos", "  <br> ", "  <br> ");
            lRes = string.Concat(lRes, " Empresa            :", iEmp, "  <br> ");
            lRes = string.Concat(lRes, " Sucursal           :", iSuc  , "  <br> ");
            lRes = string.Concat(lRes, " Periodo            :", iMes, "-", iYear,"  <br> ");
            lRes = string.Concat(lRes, " Nuevo Precio       :", iNewPrecio, "  <br> ");

            //**********************************************************
            lRes = string.Concat(lRes, "  <br> ", " El Detalle es el Siguiente: ", "  <br> <br> ");
            lRes = string.Concat(lRes, "  <br> <br>   <table border = '1' >  <tr>   ");
            lRes = string.Concat(lRes, " <td style = 'font - family: Arial; font - weight: bold; font - size: 12px;'> Codigo </ td >  ");
            lRes = string.Concat(lRes, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'> Nro. Registros </ td >   ");
            lRes = string.Concat(lRes, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'> Estado </ td >   ");
            lRes = string.Concat(lRes, " </tr> ");

            lFuente = "<td style='font-family: Arial;font - weight: bold; font-size: 12px;'> ";

            lTbl = ObtenerDatos(iYear, iMes);
            for (i = 0; i < iTbl.Rows.Count; i++)
            {
                lRes = string.Concat(lRes, " <tr> ");
                lRes = string.Concat(lRes, lFuente, iTbl.Rows[i]["Codigo"].ToString(), " </td >");
                lRes = string.Concat(lRes, lFuente, iTbl.Rows[i]["NroRegistros"].ToString(), "</td >");
                 lRes = string.Concat(lRes, lFuente, iTbl.Rows[i]["Estado"].ToString(), "</td >  ");
                lRes = string.Concat(lRes, " </tr> ");

            }
            lRes = string.Concat(lRes, "</table>  <br> <br> No responder a este correo, ya que fue generado de forma automatica <br> <br> ");
            lRes = string.Concat(lRes, "  Toda solicitud al Depto. de Informatica, debe ser con correo a  <b> SOPORTE@TORRESOCARANZA.CL, NO A OTRA DIRECCION  </b>  <br> <br> ");
            lRes = string.Concat(lRes, "  Los acentos han sido eliminados para evitar problemas con caracteres extaños ");

            return  lPx.EnviaNotificacionesEnviaMsgDeNotificacion("Cambio de Precios en INET ", lRes, -800, iAsunto);
          
        }

        private void PintaFila(int iIndexFila, Boolean iEstado)
        {
            int x = 0;
            Color lColor = Color.Black;

            if (iEstado == true)
                lColor = Color.LightGreen;
            else
                lColor = Color.LightSalmon;


            for (x = 0; x < Dtg_Resultado.ColumnCount; x++)
            {
                Dtg_Resultado.Rows[iIndexFila].Cells[x].Style.BackColor = lColor;
            }
            Dtg_Resultado.Refresh();
            Application.DoEvents();

        }

        private DataTable  CambiarPrecio()
        {
            string lsql = ""; string lSucursal = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0; int lNroReg = 0;
            string lYear = "";string lMes = "";int NroRegAfectados = 0;DataRow lFila = null;

            if (Rb_Santiago.Checked == true)
                lSucursal = "1";

            if (Rb_Calama .Checked == true)
                lSucursal = "2";

            if (Rb_Coronel .Checked == true)
                lSucursal = "3";



            lYear = Tx_Year.Text;
            lMes = Cmb_Mes.Text;

            //creamos las columnas
            lTbl.Columns.Add("Codigo", Type.GetType("System.String"));
            lTbl.Columns.Add("NroRegistros", Type.GetType("System.String"));
            lTbl.Columns.Add("Empresa", Type.GetType("System.String"));
            lTbl.Columns.Add("Estado", Type.GetType("System.String"));
            

            //if (lDts.Tables.Count > 0)
            //{
            //lTbl = lDts.Tables[0].Copy();
            PB.Maximum = Dtg_Resultado.Rows.Count - 1;
                PB.Minimum = 0;
                PB.Value = 0;
                Pnl_CambioPrecio.Visible = true;
                for (i = 0; i < Dtg_Resultado.Rows.Count -1 ; i++)
                {
                lFila = lTbl.NewRow();
                lFila["Codigo"] = Dtg_Resultado.Rows[i].Cells["Codigo"].Value.ToString().Trim();
                if (Rb_TO.Checked == true)
                    {
                        lFila["Empresa"] = "TO"; 
                         lsql = string.Concat(" SP_CambioPreciosINET 6,'", lSucursal, "','", lYear, "','", lMes, "','", Dtg_Resultado.Rows[i].Cells ["Codigo"].Value.ToString ().Trim (),"','",Tx_Precio .Text ,"',''");
                        lDts = lPx.ObtenerDatos(lsql);
                    }
                    else
                    {
                        lFila["Empresa"] = "TOSOL";
                        lsql = string.Concat(" SP_CambioPreciosINET 8,'", lSucursal, "','", lYear, "','", lMes, "','", Dtg_Resultado.Rows[i].Cells["Codigo"].Value.ToString().Trim (), "','", Tx_Precio.Text, "',''");
                        lDts = lPx.ObtenerDatos(lsql);
                    }
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows .Count  > 0))
                    {
                        if (EsNumero(lDts.Tables[0].Rows[0][0].ToString()) == true)
                        {
                             lFila["NroRegistros"] = Dtg_Resultado.Rows[i].Cells["NroRegistros"].Value.ToString().Trim();
                             NroRegAfectados = int.Parse(lDts.Tables[0].Rows[0][0].ToString());
                            lNroReg = int.Parse(Dtg_Resultado.Rows[i].Cells ["NroRegistros"].Value .ToString ());
                            if (NroRegAfectados == lNroReg)
                            {
                                PintaFila(i, true);
                                lFila["Estado"] = "OK";
                            }
                            else
                            {
                                PintaFila(i, false);
                                lFila["Estado"] = "ERR";
                            }

                         }
                    }
                    if (PB.Value < PB.Maximum)
                        PB.Value = PB.Value + 1;
                    else
                        PB.Value = PB.Value - 1;

                    Pnl_CambioPrecio.Refresh();
                    PB.Refresh();
                    Application.DoEvents();
                    lTbl.Rows.Add(lFila);
                }
            return lTbl;
        }


        private Boolean ValidaDatos()
        {
            Boolean lRes = true; string lMgs = "";
            if (EsNumero(Tx_Precio.Text) == false)
            {
                lMgs = "Debe indicar un Valor numerico mayor que cero en el campo Precio";
                lRes = false;
                Tx_Precio.Focus();
            }
            else
            {
                if (int.Parse(Tx_Precio.Text) == 0)
                {
                    lMgs = "Debe indicar un Valor numerico mayor que cero en el campo Precio";
                    lRes = false;
                    Tx_Precio.Focus();
                }
            }

            if (lRes == false)
            {
                MessageBox.Show(lMgs, "Avisos Sistema", MessageBoxButtons.OK);
                Tx_Precio.Focus();
            }


            //Validar que el año seleccionado sea el año en curso, o con un mes hacia atras

            // Validar que el Mes seleccionado sea el mes en curso o un mes hacia atras


                return lRes;
        }

        #endregion

        private void Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lMes = Cmb_Mes.SelectedValue.ToString();
            Lbl_Mes.Text = lMes;
        }

        private void MuestraMensaje(Boolean iMostrar, string iMgs)
        {
            Lbl_msgPB.Text = iMgs;
            Pnl_CambioPrecio.Visible = iMostrar;
            Lbl_msgPB.Refresh();
            Pnl_CambioPrecio.Refresh();
            Application.DoEvents();

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            MuestraMensaje(true, "... CARGANDO  DATOS ...");
            CargaDatos(Tx_Year.Text, Cmb_Mes.Text .ToString());
            MuestraMensaje(false , "... CARGANDO  DATOS ...");
        }

        private void RegistraLog(string iEmp, string iSuc, string iYear, string iMes, string iPrecio)
        {
            string lsql = "";   WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
//            @Opcion INT,              //@Sucursal Varchar(5),                 //@Year Varchar(5),
//@Mes Varchar(5),                      //@Par1 Varchar(50),                    //@Par2 Varchar(50),
//@Par3 Varchar(50)

            lsql = string.Concat(" SP_CambioPreciosINET 9,'", iSuc, "','", iYear, "','", iMes, "','", iEmp, "','", Tx_Precio.Text, "',''");
            lDts = lPx.ObtenerDatos(lsql);

        }

        private void Dtg_Resultado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex; string lCodigo = "";string lEmp = "";
            string lSuc = "";string lYear = "";string lMes = "";

            if (lFila > -1)
            {
                lCodigo = Dtg_Resultado.Rows[lFila].Cells["codigo"].Value.ToString().Trim ();
                if (Rb_TO.Checked == true)
                    lEmp = "TO";
                else
                    lEmp = "TOSOL";
                //-------------------------------
                if (Rb_Santiago.Checked == true)
                    lSuc = "1";

                if (Rb_Calama .Checked == true)
                    lSuc = "2";

                if (Rb_Coronel .Checked == true)
                    lSuc = "3";


                //-------------------------------
                lYear = Tx_Year.Text;
                lMes = Cmb_Mes.Text;

                Frm_Detalle lFrm = new Gestor_OC_Gerdau.Frm_Detalle();
                lFrm.CargaDatos(lCodigo, lEmp, lSuc, lYear, lMes);
                lFrm.ShowDialog(this);

            }



        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            string lSuc = ""; string lYear = ""; string lMes = ""; string lEmp = "";
            string lMsg = "";DataTable lTblRes = new DataTable();
            if (ValidaDatos() == true)
            {
                lMsg = string.Concat("¿ Esta Seguro que desea cambiar el precio de los productos a :",Tx_Precio .Text ," pesos ?");
                if (MessageBox.Show(lMsg, "Confirmación Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lTblRes=CambiarPrecio();

                    // registro en el LOG 
                    if (Rb_TO.Checked == true)
                        lEmp = "TO";
                    else
                        lEmp = "TOSOL";
                    //-------------------------------
                    if (Rb_Santiago.Checked == true)
                        lSuc = "1";

                    if (Rb_Calama.Checked == true)
                        lSuc = "2";

                    if (Rb_Coronel.Checked == true)
                        lSuc = "3";
                    //-------------------------------
                    lYear = Tx_Year.Text;
                    lMes = Cmb_Mes.Text;

                    MuestraMensaje(true, " . . . GRABANDO DATOS EN LOG DE TRANSACCIONES . . . ");
                    RegistraLog(lEmp, lSuc, lYear, lMes, Tx_Precio.Text);

                    // envio de correo
                    MuestraMensaje(true, " . . . ENVIANDO CORREO DE NOTIFICACIÓN A USUARIOS . . . ");
                    EnvioCorreoPorCambioPrecio(lEmp, lSuc, lYear, lMes, Tx_Precio.Text, lTblRes);
                    // ocultar Panel
                    MuestraMensaje(false , " ");
                    // refrescar pantalla.
                    
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
