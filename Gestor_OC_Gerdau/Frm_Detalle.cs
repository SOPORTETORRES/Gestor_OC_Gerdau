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
    public partial class Frm_Detalle : Form
    {
        public Frm_Detalle()
        {
            InitializeComponent();
        }

        private void Frm_Detalle_Load(object sender, EventArgs e)
        {

        }

        public void CargaDatos(string iCod, string iEmp, string iSuc, string iyear, string iMes)
        {
            string lsql = "";  WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            if (iEmp .ToUpper ().Equals ("TO"))
            { 
            lsql = string.Concat(" SP_CambioPreciosINET 2,'", iSuc, "','", iyear, "','", iMes, "','", iCod,"','',''");
            }
            else
                lsql = string.Concat(" SP_CambioPreciosINET 4,'", iSuc, "','", iyear, "','", iMes, "','", iCod, "','',''");


            lDts = lPx.ObtenerDatos(lsql);

            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                Dtg_detalle.DataSource = lTbl;
            }
           


            Lbl_Msg.Text = Lbl_Msg.Text.Replace("XXX", iCod);
            Lbl_Msg.Text = Lbl_Msg.Text.Replace("EEE", iEmp);
            Lbl_Msg.Text = Lbl_Msg.Text.Replace("PPP", string.Concat (iMes,"-",iyear ));

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
