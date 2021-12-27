using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Tools
{
    public partial class Frm_CreaMP : Form
    {
        public Frm_CreaMP()
        {
            InitializeComponent();
        }

        private void Btn_BuscaProd_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();DataSet ldts = new DataSet();
            string lSql = "  "; string iCodPord = "";
            DataTable lTbl = new DataTable();

            iCodPord = string.Concat("%", Tx_Codigo.Text, "%");
            lSql = string.Concat("   Select * from TorresOcaranza.dbo.PRODUCTO (nolock)   ");
            lSql = string.Concat(lSql , " Where PrdCod    like '", iCodPord, "' ");

            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                lTbl = ldts.Tables[0].Copy();


            Dtg_Prod.DataSource = lTbl;

            Dtg_Prod.Columns[0].Width = 100;
            Dtg_Prod.Columns[1].Width = 500;
            Dtg_Prod.Columns[2].Width = 500;


            lSql = string.Concat(" Select 1 from MateriaPrima where codigo='", Tx_Codigo.Text, "'");
            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                Tx_existe.Text = "S";
            else
                Tx_existe.Text = "N";


            button1_Click(null, null);
        }

        private void Frm_CreaMP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lDato = ""; string[] separatingStrings = { "DIAMETRO" };
            string[] lpartes = null;string lStrTmp = "";string lCalidadAcero = "";
            if (Dtg_Prod.Rows.Count > 1)
            {
                lDato = Dtg_Prod.Rows[0].Cells["PrdDesTra"].Value.ToString();

                Tx_Desc.Text = lDato;
                if (lDato.IndexOf("BARRA") > -1)
                    Tx_Tipo.Text = "B";
                else
                    Tx_Tipo.Text = "R";

                lpartes= lDato.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                if (lpartes.Length > 1)
                {
                    lStrTmp = lpartes[1];
                    Tx_Diam.Text = lStrTmp.Substring(0, 3).Trim();
                }
               
                string[] Largo= { "LARGO" };
                lpartes = lStrTmp.Split(Largo, System.StringSplitOptions.RemoveEmptyEntries);
                if (lpartes.Length > 1)
                {
                    Tx_LArgo.Text = lpartes[1].Replace("M", "").ToString().Trim();         // lStrTmp.Substring(0, 3).Trim();
                }
                

                if (lDato.IndexOf("A-44") > -1)
                    lCalidadAcero = "A440";

                if (lDato.IndexOf("A630") > -1)
                    lCalidadAcero = "A630";


                if (lDato.IndexOf("SOLDABLE") > -1)
                {
                    Chk_Soldable.Checked = true; lCalidadAcero = string.Concat (lCalidadAcero,"S");
                }                 
                else
                {
                    Chk_Soldable.Checked = false ; //Tx_TipoAcero.Text = "A630";
                }


                //Tx_existe.Text = "";
                WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataSet ldts = new DataSet();
                string lSql = "  ";
                lSql = string.Concat(" Select 1 from MateriaPrima where  bodega='Calama'  and codigo='", Tx_Codigo.Text, "'");
                ldts = lPx.ObtenerDatos(lSql);
                if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                    Tx_existe.Text = "S";
                else
                    Tx_existe.Text = "N";


            }
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {

            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataSet ldts = new DataSet();
            string lSql = "  "; string lEsSoldable = "";
            DataTable lTbl = new DataTable();

            if (Chk_Soldable.Checked == true)
                lEsSoldable = lEsSoldable = "S";
            else
                lEsSoldable = "N";

            lSql = string.Concat("  Insert into  materiaprima  (Bodega, Codigo ,Descripcion ,Tipo ,NombreMedidas  ");
            lSql = string.Concat(lSql, " ,largo,Soldable ,vigente ,CalidadAcero ) values ('Calama','", Tx_Codigo.Text,"','");
            lSql = string.Concat(lSql,   Tx_Desc .Text, "','", Tx_Tipo .Text, "','", Tx_Diam .Text, "','", Tx_LArgo .Text.Replace (",","."), "','");
            lSql = string.Concat(lSql, lEsSoldable, "','S','", Tx_TipoAcero.Text , "')  select @@identity ");

            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                MessageBox.Show("Datos Grabados Correctamente");




            lSql = string.Concat(" Select 1 from MateriaPrima where codigo='", Tx_Codigo.Text, "'");
            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                Tx_existe.Text = "S";
            else
                Tx_existe.Text = "N";



        }

        private void Btn_BuscarCodAza_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataSet ldts = new DataSet();
            string lSql = "  "; string iCodPord = "";
            DataTable lTbl = new DataTable();

            iCodPord = string.Concat("%", Tx_codigoAZA .Text, "%");
            lSql = string.Concat(" select  par2, *  from to_parametros  where SubTabla like '%CodigoProd_INET_Cubigest%'   ");
            lSql = string.Concat(lSql, " and Par1      like '", iCodPord, "' ");

            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                lTbl = ldts.Tables[0].Copy();


            Dtg_DePAra.DataSource = lTbl;

            //
            lSql = string.Concat(" Select 1 from to_parametros where Par1='", Tx_codigoAZA .Text, "'");
            lSql = string.Concat(lSql, " and SubTabla like '%CodigoProd_INET_Cubigest%'  and par3 ='Calama' ");

           ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                Tx_existe1.Text = "S";
            else
                Tx_existe1.Text = "N";

        }

        private void Btn_grabarDePara_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataSet ldts = new DataSet();
            string lSql = "  ";

            lSql = string.Concat("  Insert into  to_parametros  (SubTabla , Par1 ,Par2 ,Par3  ,VerMantenedor )  ");
            lSql = string.Concat(lSql, " values ('CodigoProd_INET_Cubigest','",  Tx_codigoAZA .Text, "','");
            lSql = string.Concat(lSql, Tx_codigoTO .Text, "','Calama','N' )  select @@identity ");
            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                MessageBox.Show("Datos Grabados Correctamente");


        }

        private void Btn_Coronel_Click(object sender, EventArgs e)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); DataSet ldts = new DataSet();
            string lSql = "  ";DataTable lTbl = new DataTable();int i = 0; string lEs_FE = "";string lLargo = ""; int lKgs = 0;

            //lSql = "select * from  Cubigestpruebas.dbo.materiaPrima  where  bodega = 'Coronel' ";
            lSql = " select  *   from  cubigestpruebas.dbo.to_parametros  where subtabla  like  '%CodigoProd_INET_Cubigest%' and Par3='Coronel' ";
            ldts = lPx.ObtenerDatos(lSql);
            if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
            {
                lTbl = ldts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    //if (lTbl.Rows[i]["Es_FE"].ToString ().Equals (""))
                    //    lEs_FE = "N";

                    //if (lTbl.Rows[i]["KgsEstimado"].ToString().Equals(""))
                    //    lKgs = 0;

                    //if (lTbl.Rows[i]["largo"].ToString().IndexOf(",")>-1)
                    //    lLargo = lTbl.Rows[i]["largo"].ToString().Replace (",",".");

                    // lSql = string.Concat("select 1 from   materiaPrima where  bodega ='Coronel' and codigo='", lTbl.Rows[i]["Codigo"].ToString(), "'");

                    lSql = string.Concat(" select 1 from   to_parametros where subtabla  like  '%CodigoProd_INET_Cubigest%' and Par3='Coronel' ");
                    lSql = string.Concat(lSql, " and par1='", lTbl.Rows[i]["par1"].ToString(),"' and  par2='", lTbl.Rows[i]["par2"].ToString(), "'");

                    ldts = lPx.ObtenerDatos(lSql);
                    if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count == 0))
                    {

                        //lSql = string.Concat("  Insert into  materiaPrima  (Bodega , codigo ,descripcion ,Tipo, NombreMedidas,largo,  ");
                        //lSql = string.Concat(lSql, " KgsEstimado , Soldable, Vigente , CalidadAcero, Es_FE) Values ('Coronel','");
                        //lSql = string.Concat(lSql, lTbl.Rows[i]["Codigo"].ToString(), "','", lTbl.Rows[i]["Descripcion"].ToString(), "','");
                        //lSql = string.Concat(lSql, lTbl.Rows[i]["Tipo"].ToString(), "','", lTbl.Rows[i]["NombreMedidas"].ToString(), "','");
                        //lSql = string.Concat(lSql, lLargo, "','", lKgs, "','");
                        //lSql = string.Concat(lSql, lTbl.Rows[i]["Soldable"].ToString(), "','", lTbl.Rows[i]["Vigente"].ToString(), "','");
                        //lSql = string.Concat(lSql, lTbl.Rows[i]["CalidadAcero"].ToString(), "','", lEs_FE, "')");

                        lSql = string.Concat("  Insert into  to_parametros  (subTabla , Descripcion ,Par1, par2 ,Vermantenedor, par3) Values ('CodigoProd_INET_Cubigest','");
                        lSql = string.Concat(lSql, lTbl.Rows[i]["Descripcion"].ToString(), "','", lTbl.Rows[i]["Par1"].ToString(), "','");
                        lSql = string.Concat(lSql, lTbl.Rows[i]["Par2"].ToString(), "','", lTbl.Rows[i]["Vermantenedor"].ToString(), "','");
                        lSql = string.Concat(lSql, lTbl.Rows[i]["Par3"].ToString(), "') ");
                        ldts = lPx.ObtenerDatos(lSql);
                    }
                }

            }


        }
    }
}
