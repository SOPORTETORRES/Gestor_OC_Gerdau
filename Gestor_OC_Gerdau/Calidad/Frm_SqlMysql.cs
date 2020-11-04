using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_SqlMysql : Form
    {
        private string mCnnMySql = "Database=cubigest;Data Source=localhost;User Id=root;Password=";
        public Frm_SqlMysql()
        {
            InitializeComponent();
        }
        public DataTable CargarDatos(string lSql)
        {
            DataSet ds = new DataSet(); DataTable lTbl = new DataTable();
            try
            {
                MySqlConnection cnn = new MySqlConnection(this.mCnnMySql);
                MySqlDataAdapter mda = new MySqlDataAdapter(lSql, cnn);
               
                mda.Fill(ds, "MySql");
                if ((ds != null) && (ds.Tables.Count > 0))
                    lTbl = ds.Tables[0].Copy();

            }
            catch (Exception iEx)
            {
                Lbl_Msg.Text = iEx.Message.ToString();
                Lbl_Msg.Visible = true;
            }

            return lTbl;
        }
        private void Btn_ejecuta_Click(object sender, EventArgs e)
        {
            DataTable lTbl = new DataTable();

            lTbl = CargarDatos(Tx_sql.Text);
            if (lTbl.Rows.Count > 0)
            {
                Dtg_Res.DataSource = lTbl;
            }
            else
                Dtg_Res.DataSource = null ;

        }
    }
}
