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

namespace Gestor_OC_Gerdau.Calidad
{
    public partial class Frm_Visualizador : Form
    {
        DataSet mDtsInforme = new DataSet();
        string mInforme = "";
        string mViaje = "";
        Boolean mEliminaArchivo = false;
        public Frm_Visualizador()
        {
            InitializeComponent();
        }


        public void InicializaInforme(String lTipoInf, DataSet iDts, string lVIaje, Boolean iEliminaArchivo)
        {
            mDtsInforme = iDts;
            mInforme = lTipoInf;
            mViaje = lVIaje;
            mEliminaArchivo = iEliminaArchivo;
        }

        public void VerInforme()
        {

            if (mInforme.ToUpper().Equals("TC"))
            {
                Rep_TrazabilidadColada mReport = new Rep_TrazabilidadColada();
                if (mDtsInforme.Tables.Count > 0)
                {
                    mReport.SetDataSource(mDtsInforme);
                    this.crystalReportViewer1.ReportSource = mReport;
                }
            }
            else
            {
                if (mInforme.ToUpper().Equals("TC2"))
                {
                    Rep_trazabilidadCol_v2  mReport = new Rep_trazabilidadCol_v2();
                    if (mDtsInforme.Tables.Count > 0)
                    {
                        mReport.SetDataSource(mDtsInforme);
                        this.crystalReportViewer1.ReportSource = mReport;
                    }
                }
                else
                 if (mInforme.ToUpper().Equals("PL"))
                {
                    Rep_AseguramientoPilote  mReport = new Rep_AseguramientoPilote();
                    if (mDtsInforme.Tables.Count > 0)
                    {
                        mReport.SetDataSource(mDtsInforme);
                        this.crystalReportViewer1.ReportSource = mReport;
                    }
                }
                else
                { 
                    Rep_CertificadoMan mReport = new Rep_CertificadoMan();
                if (mDtsInforme.Tables.Count > 0)
                {
                    mReport.SetDataSource(mDtsInforme);
                    this.crystalReportViewer1.ReportSource = mReport;
                }
                }

            }
        }
        private void Frm_Visualizador_Load(object sender, EventArgs e)
        {
           

        }

        public void GeneraPdf_TrazabilidadColadas(string iPathDestino, string iViaje ,  string iTipo )
        {
       
            if (mDtsInforme != null)
            {
                string lPathArchivo = string.Concat(iPathDestino, ""); 
                //string lPathArchivo = "//192.168.1.191//Gerencia de Logistica//Guias de Despacho//Guías Santiago//IT//";
                string lArchivo = "";
                // CargarInforme(mDtsInforme, lInforme);
                Cursor = Cursors.WaitCursor;
                try
                {
                    string[] separators = { "-" };
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

                        lArchivo = string.Concat(lPathArchivo, "TrazabilidadColadas.pdf");
                        if (mEliminaArchivo == true)
                        {
                            if (File.Exists(lArchivo) == true)
                                File.Delete(lArchivo);
                        }

                        if (iTipo.ToUpper ().Equals ("TC"))
                        {
                            Calidad.Rep_TrazabilidadColada mReport = new Calidad.Rep_TrazabilidadColada();
                            mReport.SetDataSource(mDtsInforme);
                            this.crystalReportViewer1.ReportSource = mReport;
                            mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                            this.crystalReportViewer1.Dispose();
                            this.crystalReportViewer1 = null;
                            mReport.Close();
                            mReport.Dispose();
                        }
                        else
                        {
                            if (iTipo.ToUpper().Equals("TOSOL"))
                            {
                                Calidad.Rep_TrazabilidadTosol  mReport = new Calidad.Rep_TrazabilidadTosol();
                                mReport.SetDataSource(mDtsInforme);
                                this.crystalReportViewer1.ReportSource = mReport;
                                mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                                this.crystalReportViewer1.Dispose();
                                this.crystalReportViewer1 = null;
                                mReport.Close();
                                mReport.Dispose();
                            }
                            else
                            {
                                Calidad.Rep_trazabilidadCol_v2 mReport = new Calidad.Rep_trazabilidadCol_v2();
                                mReport.SetDataSource(mDtsInforme);
                                this.crystalReportViewer1.ReportSource = mReport;
                                mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                                this.crystalReportViewer1.Dispose();
                                this.crystalReportViewer1 = null;
                                mReport.Close();
                                mReport.Dispose();
                            }
                                
                        }
                    }                  
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw exc;
                    //Application.Restart();
                }
            }
        }


        public void GeneraPdf_AseguramientoPilote(string iPathDestino, string iViaje, string iTipo)
        {

            if (mDtsInforme != null)
            {
                string lPathArchivo = string.Concat(iPathDestino, "");
                //string lPathArchivo = "//192.168.1.191//Gerencia de Logistica//Guias de Despacho//Guías Santiago//IT//";
                string lArchivo = "";
                // CargarInforme(mDtsInforme, lInforme);
                Cursor = Cursors.WaitCursor;
                try
                {
                    string[] separators = { "-" };
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

                        lArchivo = string.Concat(lPathArchivo, "AseguramientoPilote.pdf");
                        if (mEliminaArchivo == true)
                        {
                            if (File.Exists(lArchivo) == true)
                                File.Delete(lArchivo);
                        }

                        if (iTipo.ToUpper().Equals("PL"))
                        {
                            Calidad.Rep_AseguramientoPilote mReport = new Rep_AseguramientoPilote();
                            mReport.SetDataSource(mDtsInforme);
                            this.crystalReportViewer1.ReportSource = mReport;
                            mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                            this.crystalReportViewer1.Dispose();
                            this.crystalReportViewer1 = null;
                            mReport.Close();
                            mReport.Dispose();
                        }
                        else
                        {
                            Calidad.Rep_trazabilidadCol_v2 mReport = new Calidad.Rep_trazabilidadCol_v2();
                            mReport.SetDataSource(mDtsInforme);
                            this.crystalReportViewer1.ReportSource = mReport;
                            mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                            this.crystalReportViewer1.Dispose();
                            this.crystalReportViewer1 = null;
                            mReport.Close();
                            mReport.Dispose();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw exc;
                    //Application.Restart();
                }
            }
        }


        public void GeneraPdf_CertificadoFabricacion(string iPathDestino, string iViaje)
        {
           

            if (mDtsInforme != null)
            {
                string lPathArchivo = string.Concat(iPathDestino, "");
                //string lPathArchivo = "//192.168.1.191//Gerencia de Logistica//Guias de Despacho//Guías Santiago//IT//";
                string lArchivo = "";
                // CargarInforme(mDtsInforme, lInforme);
                Cursor = Cursors.WaitCursor;
                try
                {
                    string[] separators = { "-" };
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

                        lArchivo = string.Concat(lPathArchivo, "CertificadoFabricacion.pdf");
                        if (mEliminaArchivo == true)
                        {
                            if (File.Exists(lArchivo) == true)
                                File.Delete(lArchivo);
                        }

                        //lSql = string.Concat(" Select Empresa from  viaje v, it, obras o where v.idit=it.id and o.id=it.idObra and codigo='", iViaje, "'");
                        //lDts = lPx.ObtenerDatos(lSql);
                        //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        //    lEmpresa = lDts.Tables[0].Rows[0][0].ToString();

                        //if (lEmpresa.ToUpper ().Equals ("TO"))
                            Rep_CertificadoMan mReport = new Rep_CertificadoMan();

                        //if (lEmpresa.ToUpper().Equals("TOSOL"))
                        //    Calidad.Rep_CertificadoMan mReport = new Calidad.Rep_CertificadoFab_Tosol ();

                        mReport.SetDataSource(mDtsInforme);
                        this.crystalReportViewer1.ReportSource = mReport;
                        mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                        //GrabaGeneracion_PL(mViaje, lPathArchivo, "P");
                        this.crystalReportViewer1.Dispose();
                        this.crystalReportViewer1 = null;
                        mReport.Close();
                        mReport.Dispose();
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw exc;
                    //Application.Restart();
                }

            }

        }

        public void GeneraPdf_CertificadoFabricacion_TOSOL(string iPathDestino, string iViaje)
        {
           

            if (mDtsInforme != null)
            {
                string lPathArchivo = string.Concat(iPathDestino, "");
                //string lPathArchivo = "//192.168.1.191//Gerencia de Logistica//Guias de Despacho//Guías Santiago//IT//";
                string lArchivo = "";
                // CargarInforme(mDtsInforme, lInforme);
                Cursor = Cursors.WaitCursor;
                try
                {
                    string[] separators = { "-" };
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

                        lArchivo = string.Concat(lPathArchivo, "CertificadoFabricacion.pdf");
                        if (mEliminaArchivo == true)
                        {
                            if (File.Exists(lArchivo) == true)
                                File.Delete(lArchivo);
                        }

                      
                            Rep_CertificadoFab_Tosol mReport = new Rep_CertificadoFab_Tosol();

                        mReport.SetDataSource(mDtsInforme);
                        this.crystalReportViewer1.ReportSource = mReport;
                        mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                        //GrabaGeneracion_PL(mViaje, lPathArchivo, "P");
                        this.crystalReportViewer1.Dispose();
                        this.crystalReportViewer1 = null;
                        mReport.Close();
                        mReport.Dispose();
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw exc;
                    //Application.Restart();
                }

            }

        }


    }




}
