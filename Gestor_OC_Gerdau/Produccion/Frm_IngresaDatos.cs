using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace Gestor_OC_Gerdau.Produccion
{
    public partial class Frm_IngresaDatos : Form
    {
        private DataTable mTblExcel = new DataTable();
        public Frm_IngresaDatos()
        {
            InitializeComponent();
        }

        private void Btn_CargaArch_Click(object sender, EventArgs e)
        {
            if (Tb_Sku.Checked == true)
                MuestraArchivo_SKU();
            else
                MuestraArchivo_Optimizaciones();
        }

        private DataTable ObtenerTablaFinal()
        {
            DataTable lTblRes = new DataTable();
            lTblRes.Columns.Add("Codigo", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroBarras", Type.GetType("System.String"));
            lTblRes.Columns.Add("Diametro", Type.GetType("System.String"));
            lTblRes.Columns.Add("Largo_a_Pedir", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte1", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte2", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte3", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte4", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte5", Type.GetType("System.String"));
            lTblRes.Columns.Add("Corte6", Type.GetType("System.String"));
            lTblRes.Columns.Add("LargoTotal", Type.GetType("System.String"));
            lTblRes.Columns.Add("Kgs_a_Pedir", Type.GetType("System.String"));
            lTblRes.Columns.Add("KgsOcupado", Type.GetType("System.String"));
            lTblRes.Columns.Add("Etiquetas", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            return lTblRes;

        }

        private void MuestraArchivo_Optimizaciones()
        {
            string lPathCOF = ""; Clases.Cls_Comun lCom = new Clases.Cls_Comun();
            lPathCOF = Tx_Path.Text;
            object paramMissing = Type.Missing;
            ExcelApp.Application excelApplication = new ExcelApp.Application();
            excelApplication.DisplayAlerts = false;
            excelApplication.Visible = true;
            ExcelApp.Workbook excelWorkBook = excelApplication.Workbooks.Open(lPathCOF); //.Add(paramMissing);
            ExcelApp.Worksheet excelSheet = null;
            DataTable ltblDatos = new DataTable(); DataTable ltblDatosPor_IT = new DataTable();
            DataRow lFila = null;int lNroHoja = 1;string lNombreHoja = "";
            string lRangoEx = ""; int i = 0;int lCont = 0; Boolean lPuedeSeguir = true; 

            ltblDatos = ObtenerTablaFinal();


            if (excelWorkBook != null)
            {
                while (lPuedeSeguir==true )
                {
          //Iteramos por las Hojas excel hasta encontrara el nombre "resumen_kpi"
                //(excelSheet = (ExcelApp.Worksheet)excelWorkBook.Worksheets[1]).Select();
                (excelSheet = (ExcelApp.Worksheet)excelWorkBook.Worksheets[lNroHoja]).Select();
                lNombreHoja = excelSheet.Name;
                    if (lNombreHoja.IndexOf("resumen") == -1)
                    {
                        i = 4;
                        lRangoEx = string.Concat("A", (i).ToString());
                        //while (excelSheet.Range[lRangoEx].Value != null)
                        for (lCont = 1; lCont < 200; lCont++)
                        {
                            lRangoEx = string.Concat("A", (i).ToString());
                            if (excelSheet.Range[lRangoEx].Value != null)
                            {
                                if (lCom.EsNumero_Double(excelSheet.Range[lRangoEx].Value.ToString()) == true)
                                {
                                    lFila = ltblDatos.NewRow();
                                    lFila["Codigo"] = excelSheet.Range["A2"].Value;
                                    lRangoEx = string.Concat("A", (i).ToString());
                                    lFila["NroBarras"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("B", (i).ToString());
                                    lFila["Diametro"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("C", (i).ToString());
                                    lFila["Largo_a_Pedir"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("D", (i).ToString());
                                    lFila["Corte1"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("E", (i).ToString());
                                    lFila["Corte2"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("F", (i).ToString());
                                    lFila["Corte3"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("G", (i).ToString());
                                    lFila["Corte4"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("H", (i).ToString());
                                    lFila["Corte5"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("I", (i).ToString());
                                    lFila["Corte6"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("K", (i).ToString());
                                    lFila["LargoTotal"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("L", (i).ToString());
                                    lFila["Kgs_a_Pedir"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("M", (i).ToString());
                                    lFila["KgsOcupado"] = excelSheet.Range[lRangoEx].Value;
                                    lRangoEx = string.Concat("N", (i).ToString());
                                    lFila["Etiquetas"] = excelSheet.Range[lRangoEx].Value;
                                    ltblDatos.Rows.Add(lFila);
                                    //i++;
                                }
                                else
                                {
                                    lRangoEx = string.Concat("A", (i).ToString());

                                    if (excelSheet.Range[lRangoEx].Value != null)
                                        if (excelSheet.Range[lRangoEx].Value.ToString() == "Diametro")
                                            lCont = 201;

                                    //i++;
                                }

                            }
                            i++;
                        }


                        lNroHoja++;
                    }
                    else
                        lPuedeSeguir = false;

                }
                excelWorkBook.Close(false);
                excelApplication.Quit();

                if (excelSheet != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheet) != 0) { }
                    excelSheet = null;
                }
                if (excelWorkBook != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkBook) != 0) { }
                    excelWorkBook = null;
                }
                if (excelApplication != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication) != 0) { }
                    excelApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Dtg_Resultado.DataSource = ltblDatos;
        }


        private void MuestraArchivo_SKU()
        {
            string lPathCOF = "";
            lPathCOF = Tx_Path.Text;
            object paramMissing = Type.Missing;
            ExcelApp.Application excelApplication = new ExcelApp.Application();
            excelApplication.DisplayAlerts = false;
            excelApplication.Visible = true;
            ExcelApp.Workbook excelWorkBook = excelApplication.Workbooks.Open(lPathCOF); //.Add(paramMissing);
            ExcelApp.Worksheet excelSheet = null;
            DataTable ltblDatos = new DataTable(); DataTable ltblDatosPor_IT = new DataTable();
             DataRow lFila = null;
            string lRangoEx = ""; int i = 0;

            mTblExcel.Columns.Add("IdEtiqueta", Type.GetType("System.String"));
            mTblExcel.Columns.Add("Etiqueta", Type.GetType("System.String"));
            mTblExcel.Columns.Add("Codigo", Type.GetType("System.String"));
            mTblExcel.Columns.Add("SKU", Type.GetType("System.String"));

            if (excelWorkBook != null)
            {
                //LLenaremos primero el detalle de la pestaña de  Resumen GD, de la plantilla
                //Hoja: Resumen
                (excelSheet = (ExcelApp.Worksheet)excelWorkBook.Worksheets[1]).Select();

                    lRangoEx = string.Concat("A", (2 + i).ToString());
                    while (excelSheet.Range[lRangoEx].Value != null )
                    {
                        lFila = mTblExcel.NewRow();
                        lRangoEx = string.Concat("A", (2 + i).ToString());
                        lFila["Codigo"] = excelSheet.Range[lRangoEx].Value;
                        lRangoEx = string.Concat("L", (2 + i).ToString());
                        lFila["IdEtiqueta"] = excelSheet.Range[lRangoEx].Value;
                        lRangoEx = string.Concat("J", (2 + i).ToString());
                        lFila["Etiqueta"] = excelSheet.Range[lRangoEx].Value;
                        lRangoEx = string.Concat("K", (2 + i).ToString());
                        lFila["SKU"] = excelSheet.Range[lRangoEx].Value;
                    mTblExcel.Rows.Add(lFila);
                    i++;
                    }

                excelWorkBook.Close(false);
                excelApplication.Quit();

                if (excelSheet != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheet) != 0) { }
                    excelSheet = null;
                }
                if (excelWorkBook != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkBook) != 0) { }
                    excelWorkBook = null;
                }
                if (excelApplication != null)
                {
                    while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication) != 0) { }
                    excelApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Dtg_Resultado .DataSource = mTblExcel;
        }


        private void CargaArchivo()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Roberto Becerra\TO\Requerimientos\2021\Produccion\OptiSteel\Archivos OutPut";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            Tx_Path.Text = filePath;
            Tx_Path.Enabled = false;
        }

        private void GrabarArchivo()
        {
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            WS_Gerdau.WS_IntegracionGerdauSoapClient lPx = new WS_Gerdau.WS_IntegracionGerdauSoapClient();

            if (Rb_Optimizado.Checked == true)
            {
                lTbl = (DataTable)Dtg_Resultado.DataSource;
                lDts.Tables.Add(lTbl);
                lPx.PersisteViajeOpt(lDts);
            }
            else
            {
                lTbl = (DataTable)Dtg_Resultado.DataSource;
                lDts.Tables.Add(lTbl);
        
                //PersisteSKU metodo esta en Operacion  <WebMethod()> Public Function PersisteSKU(iDatos As DataSet) As String
            }

            MessageBox.Show("FIN");

        }


        private void Btn_Path_Click(object sender, EventArgs e)
        {
            CargaArchivo();
        }

        private void Btn_GrabarArch_Click(object sender, EventArgs e)
        {
            GrabarArchivo();
        }

        private void Btn_SolicitaMP_Click(object sender, EventArgs e)
        {
            DataSet lDts = new DataSet();DataTable lTbl = new DataTable();
            WS_Gerdau.WS_IntegracionGerdauSoapClient lDal = new WS_Gerdau.WS_IntegracionGerdauSoapClient();

            lDts = lDal.SolicitudMP_OptiSteelPorSucursal("4");
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Dtg_Resultado.DataSource = lTbl;
            }

        }
    }
}
