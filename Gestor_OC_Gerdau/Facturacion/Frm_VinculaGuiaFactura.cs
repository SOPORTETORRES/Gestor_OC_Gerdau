using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_OC_Gerdau.Facturacion
{
    public partial class Frm_VinculaGuiaFactura : Form
    {
        public Frm_VinculaGuiaFactura()
        {
            InitializeComponent();
        }

        private void Btn_Revisa_Click(object sender, EventArgs e)
        {
            Revisa();
        }




        private void Revisa()
        {
            string lsql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataTable lTbl2 = new DataTable();

            lsql = "	select   a2.BarCod ,convert(int,a.AteProCan) Kgs  ,atenum,  a.AteObsuno ,  AteObsDos ";
            lsql = string.Concat(lsql, " , convert(varchar, a.AteFchAte, 103) FechaAtencion , '0' NroFactura, '' GlosaFact ");
            lsql = string.Concat(lsql, "  from TORRESOCARANZA.dbo.ATECLIEN a , TORRESOCARANZA.dbo.ATECLI2 a2  ");
            lsql = string.Concat(lsql, "  where a.DocCod = 331   and a.AteNumRea = a2.AteNumRea ");
            lsql = string.Concat(lsql, "     and AteNum >   79402  	and not exists ( select 1 from GuiasPorFactura where NroGuiaINET =a.AteNum )  ");

            lsql = string.Concat(lsql, "   order by a.AteNum  ");
            //64073 

            lDts = lPx.ObtenerDatos(lsql);
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();

                Pb_Avance.Maximum = lTbl.Rows.Count;
                Pb_Avance.Minimum = 0; Pb_Avance.Value = 0;
          
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                        if (Pb_Avance.Value < Pb_Avance.Maximum)
                            Pb_Avance.Value = Pb_Avance.Value + 1;
                        else
                            Pb_Avance.Value = Pb_Avance.Value - 1;


                    Lbl_avance.Text = string.Concat(i, "  de  ", lTbl.Rows.Count);
                    Pb_Avance.Refresh();
                    Application.DoEvents();

                        lsql = string.Concat("select * from TORRESOCARANZA.dbo.ATECLIEN where AteObsUno  like '%");
                    lsql = string.Concat(lsql, lTbl.Rows[i]["atenum"].ToString(), "%' and ateglo like '%INET%'");
                    lsql = string.Concat(lsql, "    ");
                    lDts = lPx.ObtenerDatos(lsql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTbl.Rows[i]["NroFactura"] = lDts.Tables[0].Rows[0]["atenum"].ToString();
                        lTbl.Rows[i]["GlosaFact"] = lDts.Tables[0].Rows[0]["ateglo"].ToString();
                    }
                }
                dataGridView1.DataSource = lTbl;
            }
        }


        private void Actualiza()
        {
            string lsql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            DataTable lTbl2 = new DataTable();string lTx = "";

            Pb_Avance.Maximum = dataGridView1.Rows.Count;
            Pb_Avance.Minimum = 0; Pb_Avance.Value = 0;

            for (i = 0; i < dataGridView1 .Rows.Count; i++)
            {
                if (Pb_Avance.Value < Pb_Avance.Maximum)
                    Pb_Avance.Value = Pb_Avance.Value + 1;
                else
                    Pb_Avance.Value = Pb_Avance.Value - 1;


                Lbl_avance.Text = string.Concat(i, "  de  ", lTbl.Rows.Count);
                Pb_Avance.Refresh();
                Application.DoEvents();

                string[] split = dataGridView1.Rows[i].Cells ["GlosaFact"].Value .ToString ().Split(new Char[] { '%' });
                if (split .Length >1)
                {
                    lTx = split[1].ToString();
                    if (dataGridView1.Rows[i].Cells["AteObsDos"].Value.ToString().Trim().ToUpper().Equals(lTx.ToUpper().Trim()))
                    {
                        lsql = string.Concat(" insert into GuiasPorFactura (NroFactura, NroGuiaINET, IdUser, FechaRegistro) ");
                        lsql = string.Concat(lsql, " values (", dataGridView1.Rows[i].Cells["NroFactura"].Value.ToString(),",");
                        lsql = string.Concat(lsql,  dataGridView1.Rows[i].Cells["atenum"].Value.ToString(), ",1, getdate() )");
                        lPx.ObtenerDatos(lsql);
                    }
                }
            }


            //lsql = "	select top 100  a2.BarCod ,convert(int,a.AteProCan) Kgs  ,atenum,  a.AteObsuno ,  AteObsDos ";
            //lsql = string.Concat(lsql, " , convert(varchar, a.AteFchAte, 103) FechaAtencion , '0' NroFactura, '' GlosaFact ");
            //lsql = string.Concat(lsql, "  from TORRESOCARANZA.dbo.ATECLIEN a , TORRESOCARANZA.dbo.ATECLI2 a2  ");
            //lsql = string.Concat(lsql, "  where a.DocCod = 331   and a.AteNumRea = a2.AteNumRea ");
            //lsql = string.Concat(lsql, "     and AteNum >   64072    order by a.AteNum  ");


            //lDts = lPx.ObtenerDatos(lsql);
           
        }


        private void Btn_Actualiza_Click(object sender, EventArgs e)
        {
            Actualiza();
        }
    }
}
