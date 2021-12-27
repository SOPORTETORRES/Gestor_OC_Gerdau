using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Produccion
{
    public partial class Frm_DescargarArchivos : Form
    {
        public Frm_DescargarArchivos()
        {
            InitializeComponent();
        }

        private void Cal_Fechas_DateChanged(object sender, DateRangeEventArgs e)
        {
            string lfecha = Cal_Fechas.SelectionEnd.ToShortDateString();
            string lDiaSel = ""; int lDiasResta = 0;
            //'para Calendar1.SelectedDate.DayOfWeek
            //'0  ==>  domingo        '1 ==> Lunes          '2  ==>  Martes
            //'3  ==>  Miercoles      '4 ==> Jueves         '5  ==>  Viernes
            //'6  ==>  sabado         
            tx_Inicio.Text = lfecha;
            lDiaSel = Cal_Fechas.SelectionEnd.DayOfWeek.ToString ();
            switch (lDiaSel)
            {
                case "Sunday": //  "0":
                    lDiasResta = -6;
                    break;
                case "Monday": //  "1":
                    lDiasResta = 0;
                    break;
                case "Tuesday": // "2":
                    lDiasResta = -1;
                    break;
                case "Wednesday": //  "3":
                    lDiasResta = -2;
                    break;
                case "Thursday": // "4":
                    lDiasResta = -3;
                    break;
                case "Friday"  : // "5":
                    lDiasResta = -4;
                    break;
                case "Saturday": //"6":
                    lDiasResta = -5;
                    break;
            }

            DateTime nuevaFecha = Cal_Fechas.SelectionEnd;
            nuevaFecha = nuevaFecha.AddDays(lDiasResta);
            tx_Inicio.Text = nuevaFecha.ToShortDateString();

            nuevaFecha = nuevaFecha.AddDays(5);

            tx_Fin .Text = nuevaFecha.ToShortDateString();
       

        }

        private void Frm_DescargarArchivos_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void CargaDatos()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataTable lTbl = new DataTable();
            string  lsql = "exec SP_Consultas_WS 34,'','','','','','',''"; DataSet  Dts = new DataSet ();

            Dts = lPx.ObtenerDatos(lsql);
            if ((Dts.Tables.Count > 0) && (Dts.Tables[0].Rows.Count > 0))
            {
                lTbl = Dts.Tables[0].Copy();
                Cmb_Sucursal.ValueMember = "Suc";
                Cmb_Sucursal.DisplayMember = "Sucursal";
                Cmb_Sucursal.DataSource = lTbl;

            }
            DataTable lTbTmp = new DataTable(); DataRow lFila = null;

            lTbTmp.Columns.Add("Codigo", Type.GetType("System.String"));
            lTbTmp.Columns.Add("Nombre", Type.GetType("System.String"));

            lFila = lTbTmp.NewRow(); lFila["Codigo"] = "F"; lFila["Nombre"] = "Facturable"; lTbTmp.Rows.Add(lFila);
            lFila = lTbTmp.NewRow(); lFila["Codigo"] = "R"; lFila["Nombre"] = "Reposición"; lTbTmp.Rows.Add(lFila);
            lFila = lTbTmp.NewRow(); lFila["Codigo"] = "FE"; lFila["Nombre"] = "Fierro en Punta"; lTbTmp.Rows.Add(lFila);
            lFila = lTbTmp.NewRow(); lFila["Codigo"] = "T"; lFila["Nombre"] = "Todas"; lTbTmp.Rows.Add(lFila);


            Cmb_TipoGuia.DataSource = lTbTmp;
            Cmb_TipoGuia.DisplayMember  = "Nombre";
            Cmb_TipoGuia.ValueMember = "Codigo";
            Cmb_TipoGuia.SelectedIndex = lTbTmp.Rows.Count - 1;

            //CargaCombo_Suc_Clientes("")
            //CargaCombo_TipoGuiaINET()

        }

        private void Btn_Descargar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
