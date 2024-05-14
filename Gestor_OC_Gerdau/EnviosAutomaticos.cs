using System;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;

namespace Gestor_OC_Gerdau
{
    public partial class EnviosAutomaticos : Form
    {
        static string excelFile = "";
        private DataTable mTblEnvios = new DataTable();
        public  Boolean mGenerandoArchivo = false;
        public EnviosAutomaticos()
        {
            InitializeComponent();
        }

        private void Btn_EnviaPL_Click(object sender, EventArgs e)
        {
         //   EnviarPL("772", "500");
            //System.Threading.Thread.Sleep(1000);
            //EnviarPL( "807", "600");


            //ProcesaEnvioBOM();
        }

        public void EscribeArchivoLog(string lLinea, string lpatharchivo)
        {
            string rutaArchivo = "miArchivo.txt"; // Define la ruta y el nombre del archivo
            string contenido = "Hola, ¡este es el contenido de mi archivo!"; // Define el contenido del archivo

            // Crear el archivo con el contenido especificado
            lLinea = string.Concat(lLinea, Environment.NewLine);
            File.AppendAllText(lpatharchivo, lLinea);
            //File.WriteAllText(lpatharchivo, lLinea);

        }

        public void Desactivar_Timmer()
        {
            Tm_Envios.Enabled = false;
        }
        private void ProcesaEnvio_ProduccionTOSOL(string iDia, string iHora)
        {
             WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc(); string lPathArchivo = "";

          
            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            switch (lDia.ToUpper())
            {
                case "T": //Todos los días 
                    if (lHora == lHoraActual)
                    {
                      if (lLN_EnvioDoc.ArchivoFueEnviado("PR_TOSOL") == false)
                        {
                            // enviar el archivo
                            lPathArchivo = Enviar_ProduccionTosol();
                            if (lPathArchivo.ToString().Length > 0)
                                lLN_EnvioDoc.GrabarEnvioArchivo("PR_TOSOL", lPathArchivo);

                        }
                    }
                    break;

                default:

                    break;
            }

        }



        private void Btn_EnvioProdTosol_Click(object sender, EventArgs e)
        {
            
               
        }




        #region Metodos Privados

        private string Enviar_ProduccionTosol()
        {
            string lMsg = ""; string lRes = ""; DataTable lTblDest = new DataTable();
            string lErr = ""; string lTitulo = ""; string lPathArc = "";
            try
            {
                lTitulo = string.Concat(" Detalle de Produccion a la Fecha ", DateTime.Now.ToShortDateString());
                Lbl_Inicio.Text = DateTime.Now.ToLongTimeString();
                // 1.- Generar el documentos e PL
                lPathArc = GeneraProduccionTOSOL( );
                //2.- Obtener los destinatarios
                lTblDest = ObtenerDestinatarios("-1300");
                if (lTblDest.Rows.Count > 0)
                {
                    //3.- Envio de PL..
                    lMsg = " Hola Estimados(as) : <br>   <br> ";
                    lMsg = string.Concat(lMsg, " Se adjunta    ", lTitulo);
                    lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
                    lMsg = string.Concat(lMsg, "  Torres Ocaranza  <Br> ");
                    lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");

                    lRes = EnviarArchivo(lMsg, lTitulo, lPathArc, lTblDest);

                    if (lRes.ToUpper().Equals("OK"))
                    {
                        // Se debe Persistir el archivo 
                    }

                    Lbl_Estado.Text = lRes;
                    Lbl_Fin.Text = DateTime.Now.ToLongTimeString();
                }
                lErr = "";

            }
            catch (Exception iex)
            {
                lErr = String.Concat(" Ha Ocurrido el Siguiente Error <Br> Detalle Error:", iex.Message.ToString(), " <Br> Traza: ", iex.StackTrace.ToString());
                RegistraError(lErr, "Error Al enviar PL Electronico");
            }
            finally
            {

            }
            return lPathArc;
        }

        private string EnviarBOM(string iIdObra, string iTipo )
        {
            string lMsg = ""; string lRes = ""; DataTable lTblDest = new DataTable();
            string lErr = ""; string lTitulo = ""; string lPathArc = "";
            try
            {
                switch (iTipo.ToUpper())
                {
                    case "220": //Todos los días 
                        //lTitulo = string.Concat("Bill Of Material electrónico al ", DateTime.Now.ToShortDateString());
                        lTitulo = string.Concat("BOM electrónico 25800-220-POA-DG01-00001 al", DateTime.Now.ToShortDateString());
                        //lPathArc = GeneraBOM("682", iTipo);
                        lPathArc = GeneraBOM(iIdObra, iTipo);
                        break;
                    case "500": //Todos los días 
                        //lTitulo = string.Concat("Bill Of Material electrónico al ", DateTime.Now.ToShortDateString()); 
                        lTitulo = string.Concat("BOM electrónico 25800-500-POA-DG01-00001 al", DateTime.Now.ToShortDateString());
                        //lPathArc = GeneraBOM("772", iTipo);
                        lPathArc = GeneraBOM(iIdObra, iTipo);
                        break;
                    case "400": //Todos los días 
                        lTitulo = string.Concat("BOM electrónico 25800-400-POA-DG01-00001 al", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraBOM(iIdObra, iTipo);
                        break;
                    case "470": //Todos los días 
                        lTitulo = string.Concat("BOM electrónico 25800-470-POA-DG01-00001 al", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraBOM(iIdObra, iTipo);
                        break;
                    case "600": //Todos los días 
                        lTitulo = string.Concat("BOM electrónico 25800-600-POA-DG01-00001 al", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraBOM(iIdObra, iTipo);
                        break;
                }

                        //lTitulo = string.Concat("Bill Of Material electrónico al ", DateTime.Now.ToShortDateString());
                Lbl_Inicio.Text = DateTime.Now.ToLongTimeString();
                // 1.- Generar el documentos e PL
              //  lPathArc = GeneraBOM ("682");
                //2.- Obtener los destinatarios
                lTblDest = ObtenerDestinatarios("-210");
                if (lTblDest.Rows.Count > 0)
                {
                    //3.- Envio de PL..
                    lMsg = " Señores  Bechtel : <br>   <br> ";
                    lMsg = string.Concat(lMsg, " Según lo solicitado,  les adjuntamos  ", lTitulo);
                    lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
                    lMsg = string.Concat(lMsg, "  Torres Ocaranza  <Br> ");
                    lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");

                    lRes = EnviarArchivo(lMsg, lTitulo, lPathArc, lTblDest);

                    if (lRes.ToUpper().Equals("OK"))
                    {
                        // Se debe Persistir el archivo 
                    }

                    Lbl_Estado.Text = lRes;
                    Lbl_Fin.Text = DateTime.Now.ToLongTimeString();
                }
                lErr = "";

            }
            catch (Exception iex)
            {
                lErr = String.Concat(" Ha Ocurrido el Siguiente Error <Br> Detalle Error:", iex.Message.ToString(), " <Br> Traza: ", iex.StackTrace.ToString());
                RegistraError(lErr, "Error Al enviar PL Electronico");
            }
            finally
            {

            }
            return lPathArc;
        }


        private string  EnviarPL(string iIdObra, string iTipo)
        {
            string lMsg = ""; string lRes = ""; DataTable lTblDest = new DataTable();
            string lErr = "";string lTitulo = ""; string lPathArc = "";
            try
            {
                 Lbl_Inicio.Text = DateTime.Now.ToLongTimeString();
                switch (iTipo.ToUpper())
                {
                    case "220": //Todos los días 
                        //lTitulo = string.Concat("Bill Of Material electrónico al ", DateTime.Now.ToShortDateString());
                        lTitulo = string.Concat("Packing List electrónico 25800-220-POA-DG01-00001 al ", DateTime.Now.ToShortDateString());
                        //lPathArc = GeneraBOM("682", iTipo);
                        // 1.- Generar el documentos e PL
                        lPathArc = GeneraPlElectronico("682", iTipo);
                        break;
                    case "500": //Todos los días 
                        //lTitulo = string.Concat("Bill Of Material electrónico al ", DateTime.Now.ToShortDateString()); 
                        lTitulo = string.Concat("Packing List electrónico 25800-500-POA-DG01-00001 al ", DateTime.Now.ToShortDateString());
                        //lPathArc = GeneraBOM("772", iTipo);
                        // 1.- Generar el documentos e PL
                        lPathArc = GeneraPlElectronico("772", iTipo);
                        break;
                    case "400": //Todos los días 
                        lTitulo = string.Concat("Packing List electrónico 25800-400-POA-DG01-00001 al ", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraPlElectronico("803", iTipo);
                        break;
                    case "470": //QBF 470
                        lTitulo = string.Concat("Packing List electrónico 25800-470-POA-DG01-00001 al ", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraPlElectronico("806", iTipo);
                        break;
                    case "600": //Todos los días 
                        lTitulo = string.Concat("Packing List electrónico 25800-600-POA-DG01-00001 al ", DateTime.Now.ToShortDateString());
                        lPathArc = GeneraPlElectronico("807", iTipo);
                        break;
                }

             //   lTitulo = string.Concat("Packing List electrónico al " , DateTime.Now.ToShortDateString());
              
                
                //2.- Obtener los destinatarios
                lTblDest = ObtenerDestinatarios("-200");
                if (lTblDest.Rows.Count > 0)
                {
                    //3.- Envio de PL..
                    lMsg = " Señores  Bechtel : <br>   <br> ";
                    lMsg = string.Concat(lMsg, " Según lo solicitado,  les adjuntamos  ", lTitulo);
                    lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
                    lMsg = string.Concat(lMsg, "  Torres Ocaranza  <Br> ");
                    lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");

                    lRes = EnviarArchivo(lMsg, lTitulo, lPathArc, lTblDest);

                    //if (lRes.ToUpper().Equals("OK"))
                    //{
                    //    // Se debe Persistir el archivo 
                    //}

                    Lbl_Estado.Text = lRes;
                    Lbl_Fin.Text = DateTime.Now.ToLongTimeString();
                }
                lErr = "";
               
            }
            catch (Exception iex)
            {
                lErr = String.Concat(" Ha Ocurrido el Siguiente Error <Br>EnviarPL IdObra: ", iIdObra ," Tipo:", iTipo ," PathArchivo: ", lPathArc ," < Br> Detalle Error:", iex.Message.ToString(), " <Br> Traza: ", iex.StackTrace.ToString());
                RegistraError(lErr, "Error Al enviar PL Electronico");
            }
            finally
            {

            }
            return lPathArc;
        }

        private string Enviar_ILC()
        {
            string lMsg = ""; string lRes = ""; DataTable lTblDest = new DataTable();
            string lErr = ""; string lTitulo = ""; string lPathArc = "";
            try
            {
                lTitulo = string.Concat("Informe de Linea de Credito  ", DateTime.Now.ToShortDateString());
                Lbl_Inicio.Text = DateTime.Now.ToLongTimeString();
                // 1.- Generar el documentos e PL
                lPathArc = Genera_InformeLC( );
                //2.- Obtener los destinatarios
                lTblDest = ObtenerDestinatarios("-1200");
                if (lTblDest.Rows.Count > 0)
                {
                    //3.- Envio de PL..
                    lMsg = " Hola Estimados  : <br>   <br> ";
                    lMsg = string.Concat(lMsg, " Según lo programado,  les adjuntamos  ", lTitulo);
                    lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
                    lMsg = string.Concat(lMsg, "  Torres Ocaranza  <Br> ");
                    lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");

                    lRes = EnviarArchivo(lMsg, lTitulo, lPathArc, lTblDest);

                    if (lRes.ToUpper().Equals("OK"))
                    {
                        // Se debe Persistir el archivo 
                    }

                    Lbl_Estado.Text = lRes;
                    Lbl_Fin.Text = DateTime.Now.ToLongTimeString();
                }
                lErr = "";

            }
            catch (Exception iex)
            {
                lErr = String.Concat(" Ha Ocurrido el Siguiente Error <Br> Detalle Error:", iex.Message.ToString(), " <Br> Traza: ", iex.StackTrace.ToString());
                RegistraError(lErr, "Error Al enviar PL Electronico");
            }
            finally
            {

            }
            return lPathArc;
        }

        private DataTable ObtenerDestinatarios(string itipo )
        {
            string lSql = String.Concat(" SP_ConsultasInformes  20, '", itipo ,"',' ','','',''");
              WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                }
            }
            catch (Exception iex)
            {
                throw iex;
            }
            return lTbl;
        }

        private string GeneraPlElectronico(string iIdObra, string iTipo)
        {
             WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathBase = ""; string lPathArchivo = ""; string lSql = "";

            try
            {
                lPathBase = ConfigurationManager.AppSettings["Path_ePL"].ToString();
                switch (iIdObra)
                {
                    case "682": //QBF 2
                        lSql = String.Concat(" SP_ConsultasInformes  19, '", iIdObra, "',' ','','',''");
                        lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL_220.xlsx");
                        break;
                    case "772": //QBF 5
                        lSql = String.Concat(" SP_ConsultasInformes  25, '", iIdObra, "',' ','','',''");
                        lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL_500.xlsx");
                        break;
                    case "803": //QBF 4
                        lSql = String.Concat(" SP_ConsultasInformes  26, '", iIdObra, "',' ','','',''");
                        lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL_500.xlsx");
                        break;
                    case "806": //QBF 470
                    case "807": //QBF 6
                        lSql = String.Concat(" SP_ConsultasInformes  28, '", iIdObra, "',' ','','',''");
                        lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL_500.xlsx");
                        break;
                    default:

                        break;
                }
                //string lSql = String.Concat(" SP_ConsultasInformes  19, '", iIdObra, "',' ','','',''");
            
            

            Microsoft.Office.Interop.Excel.Application lApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook lLibro = lApp.Workbooks.Open(lPathArchivo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet lHoja = (Microsoft.Office.Interop.Excel.Worksheet)lLibro.Worksheets.Item[1];
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                //lPathBase = ConfigurationManager.AppSettings["Path_ePL"].ToString();
                //lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL.xlsx");

                //lApp = new Microsoft.Office.Interop.Excel.Application();
                //lLibro = lApp.Workbooks.Open(lPathArchivo);
                Pb_Avance.Maximum = lTbl.Rows.Count;
                Pb_Avance.Minimum = 0; Pb_Avance.Value = 0;
                for (i = 0; i < lTbl.Rows.Count; i++)
                {

                    Lbl_Estado.Text = string.Concat(i, " de ", lTbl.Rows.Count);
                        Lbl_Estado.Refresh();

                    if (Pb_Avance.Value < Pb_Avance.Maximum)
                        Pb_Avance.Value = Pb_Avance.Value + 1;
                    else
                        Pb_Avance.Value = Pb_Avance.Value - 1;

                        Application.DoEvents();
                    lHoja.Cells[19 + i, "A"] = i + 1; lHoja.Cells[19 + i, "B"] = "Torres Ocaranza Ltda";
                    lHoja.Cells[19 + i, "C"] = lTbl.Rows[i]["PO Number"].ToString();
                    lHoja.Cells[19 + i, "D"] = lTbl.Rows[i]["PO Line Item # "].ToString();
                    lHoja.Cells[19 + i, "E"] = "NA";  //'PO Equipment or Tag # (Numero de Equipo de etiqueta)
                    lHoja.Cells[19 + i, "F"] = lTbl.Rows[i]["ESP"].ToString();
                    lHoja.Cells[19 + i, "G"] = lTbl.Rows[i]["Number (numero de parte del vendedor)"].ToString();
                    lHoja.Cells[19 + i, "H"] = lTbl.Rows[i]["Material Description"].ToString();
                    lHoja.Cells[19 + i, "I"] = lTbl.Rows[i]["Qty"].ToString();
                    lHoja.Cells[19 + i, "J"] = "CU";
                    lHoja.Cells[19 + i, "K"] = "NA";
                    lHoja.Cells[19 + i, "L"] = "NA";
                    lHoja.Cells[19 + i, "M"] = "NA";
                    lHoja.Cells[19 + i, "N"] = "NA";
                    lHoja.Cells[19 + i, "O"] = lTbl.Rows[i]["Package/ Crate/ Bundle/ Box Number /GSE BOL NO"].ToString(); 
                    lHoja.Cells[19 + i, "P"] = "NA";
                    lHoja.Cells[19 + i, "Q"] = "NA";
                    lHoja.Cells[19 + i, "R"] = lTbl.Rows[i][" Length"].ToString();
                    lHoja.Cells[19 + i, "S"] = "MTS";
                    lHoja.Cells[19 + i, "T"] = "NA";
                    lHoja.Cells[19 + i, "U"] = "NA";
                    lHoja.Cells[19 + i, "V"] = "NA";
                    lHoja.Cells[19 + i, "W"] = lTbl.Rows[i]["Total Package Weight"].ToString();
                    lHoja.Cells[19 + i, "X"] = "NA";
                    lHoja.Cells[19 + i, "Y"] = "NA";
                    lHoja.Cells[19 + i, "Z"] = "NA";
                    lHoja.Cells[19 + i, "AA"] = lTbl.Rows[i]["SCN Number"].ToString();
                    lHoja.Cells[19 + i, "AB"] = lTbl.Rows[i]["N GD"].ToString();
                    lHoja.Cells[19 + i, "AC"] = lTbl.Rows[i]["Fecha GD"].ToString();
                    lHoja.Cells[19 + i, "AD"] = lTbl.Rows[i]["Codigo"].ToString();
                    lHoja.Cells[19 + i, "AE"] = lTbl.Rows[i]["TipoIT"].ToString();

                        //'N GD'
                        //'Material Description
                    }
                lPathArchivo = String.Concat(lPathBase, "E_PL_", iTipo,"_",DateTime.Now.ToShortDateString().Replace("/","-"), ".xlsx");
                if (System.IO.File.Exists(lPathArchivo) == true)
                    System.IO.File.Delete(lPathArchivo);


                lLibro.SaveAs(lPathArchivo);
                lLibro.Close();
                lApp.Quit();

                ReleaseObject(lApp);
                ReleaseObject(lLibro);
                ReleaseObject(lHoja);

            }
            }
            catch (Exception iex)
            {
                throw iex;
            }


            return lPathArchivo;
        }

        private string Genera_InformeLC( )
        {
          WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathBase = ""; string lPathArchivo = ""; 
            string lMes = ""; string  lDia = ""; string lTxFecha = "";

            try
            {
                lTxFecha=String.Concat(DateTime.Now.Year); //, DateTime.Now.Month, DateTime.Now.Day)
                if (DateTime.Now.Month.ToString ().Length ==1)
                    lMes= String.Concat("0",DateTime.Now.Month);
                else
                    lMes = String.Concat(  DateTime.Now.Month);

                if (DateTime.Now.Day.ToString().Length == 1)
                    lDia = String.Concat("0", DateTime.Now.Day);
                else
                    lDia = String.Concat(DateTime.Now.Day);

                lTxFecha = String.Concat(DateTime.Now.Year, lMes, lDia);

                lPathBase = string.Concat (ConfigurationManager.AppSettings["Path_ILC"].ToString(), "InformeLC.exe");
                if (System.IO.File.Exists(lPathBase) == true)
                {

                    ProcessStartInfo cmdsi = new ProcessStartInfo();
                    //cmdsi.FileName = @"D:\Gerardo\Dropbox\Proyectos\rbecerra\Metalurgica\2018\1.LineaCredito\Fuentes\InformeLC\bin\Debug\InformeLC.exe";
                    cmdsi.FileName = lPathBase;
                    cmdsi.Arguments = "";
                    cmdsi.WorkingDirectory = Path.GetDirectoryName(cmdsi.FileName);
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                   // MessageBox.Show("Proceso finalizado");
                    //Esperamos 2 SEGUNDOS antes de seguir el proceso
                    System.Threading.Thread.Sleep(2000);
                    //Revisamos el Archivo de Log
                    lPathBase = string.Concat(ConfigurationManager.AppSettings["Path_ILC"].ToString(), "log.txt");
                    if (System.IO.File.Exists(lPathBase) == true)
                    {
                        lPathArchivo = string.Concat(ConfigurationManager.AppSettings["Path_ILC"].ToString(),lArchivoGenerado(lPathBase, lTxFecha));
                      //  Enviar_ILC();
                    }

                }
            }
            catch (Exception iex)
            {
                throw iex;
            }


            return lPathArchivo;
        }

        private string lArchivoGenerado(string iPathArchivo, string iFecha)
        {
            string lArchivo = "";
            StreamReader objReader = new StreamReader(iPathArchivo);
            string sLine = "";
            ArrayList lLista = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    if (sLine.ToString().IndexOf(iFecha) > -1)
                    {
                        lArchivo = sLine;
                        lLista.Add(lArchivo);
                    }
                }
            }
            objReader.Close();

            if (lLista.Count > 0)
            {
                lArchivo = lLista[lLista.Count - 1].ToString ();
                string[] split = lArchivo.Split(new Char[] { '|' });
                lArchivo = string.Concat(  split[1].Trim() );


            }

            //lPathBase = string.Concat(ConfigurationManager.AppSettings["Path_ILC"].ToString(), "log.txt");

            return lArchivo;
        }

        private string GeneraProduccionTOSOL()
        {
       WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathBase = ""; string lPathArchivo = ""; string lFecha = "";
            string lLinea = ""; List<string> lListaLineas = new List<string>();

            try
            {
                string lSql = String.Concat(" SP_ConsultasInformes  22, '',' ','','',''");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    lFecha = string.Concat (lTbl.Rows[0]["FechaEnvio"].ToString().Substring(0, 10), " 00:00:01");

                    lSql = String.Concat(" SP_ConsultasInformes  21, '", lFecha,"',' ','','',''");
                    lPathBase = ConfigurationManager.AppSettings["Path_Pr_TOSOL"].ToString();
                    lPathArchivo = String.Concat(lPathBase, "ProduccionTOSOL.csv");

                    lPathArchivo = String.Concat(lPathBase, "ProduccionTOSOL_", DateTime.Now.ToShortDateString().Replace("/", "-"), ".csv");



                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        if (System.IO.File.Exists(lPathArchivo) == true)
                            System.IO.File.Delete(lPathArchivo);


                        lTbl = lDts.Tables[0].Copy();

                        Pb_Avance.Maximum = lTbl.Rows.Count;
                        Pb_Avance.Minimum = 0; Pb_Avance.Value = 0;

                        lLinea = string.Concat("Fecha;Diametro;Mts;mm;Maquina;Kgs");
                        lListaLineas.Add(lLinea);
                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            if (Pb_Avance.Value < Pb_Avance.Maximum)
                                Pb_Avance.Value = Pb_Avance.Value + 1;
                            else
                                Pb_Avance.Value = Pb_Avance.Value - 1;


                            lLinea = "";
                            lLinea = string.Concat(lTbl.Rows[i]["Fecha"].ToString(), ";", lTbl.Rows[i]["Diametro"].ToString(), ";", lTbl.Rows[i]["Mts"].ToString(), ";", lTbl.Rows[i]["mm"].ToString(), ";", lTbl.Rows[i]["Maquina"].ToString(), ";", lTbl.Rows[i]["Kgs"].ToString(), ";");
                            lListaLineas.Add(lLinea);

                        }
                        File.AppendAllLines(lPathArchivo, lListaLineas);
                    }
                }
                   
            }
            catch (Exception iex)
            {
                throw iex;
            }


            return lPathArchivo;
        }
        private string GeneraBOM(string iIdObra, string iTipo)
        {
   WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathBase = ""; string lPathArchivo = ""; string lSql = "";

            try
            {
                switch (iIdObra)
                {
                    case "682": //QBF 2  OK
                          lSql = String.Concat(" SP_ConsultasInformes  17, '", iIdObra, "',' ','','',''");
                        break;
                    case "772": //QBF 5
                        lSql = String.Concat(" SP_ConsultasInformes  24, '", iIdObra, "',' ','','',''");
                        break;
                    case "803": //QBF 4  OK
                        lSql = String.Concat(" SP_ConsultasInformes  27, '", iIdObra, "',' ','','',''");
                        break;
                    case "806": //QBF 470
                    case "807": //QBF 6
                        lSql = String.Concat(" SP_ConsultasInformes  29, '", iIdObra, "',' ','','',''");
                        break;
                    default:

                        break;
                }
               
                lPathBase = ConfigurationManager.AppSettings["Path_BOM"].ToString();
                lPathArchivo = String.Concat(lPathBase, "Plantilla_BOM.xlsx");

                Microsoft.Office.Interop.Excel.Application lApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook lLibro = lApp.Workbooks.Open(lPathArchivo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet lHoja = (Microsoft.Office.Interop.Excel.Worksheet)lLibro.Worksheets.Item[1];
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    //lPathBase = ConfigurationManager.AppSettings["Path_ePL"].ToString();
                    //lPathArchivo = String.Concat(lPathBase, "Plantilla_ePL.xlsx");

                    //lApp = new Microsoft.Office.Interop.Excel.Application();
                    //lLibro = lApp.Workbooks.Open(lPathArchivo);
                    Pb_Avance.Maximum = lTbl.Rows.Count;
                    Pb_Avance.Minimum = 0; Pb_Avance.Value = 0;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        if (Pb_Avance.Value < Pb_Avance.Maximum)
                            Pb_Avance.Value = Pb_Avance.Value + 1;
                        else
                            Pb_Avance.Value = Pb_Avance.Value - 1;


                        Lbl_Estado.Text = string.Concat("  Registro ", i , " de " , lTbl.Rows.Count);
                        lHoja.Cells[2 + i, "A"] = lTbl.Rows[i]["PO Line Item Number"].ToString();
                        lHoja.Cells[2 + i, "B"] = lTbl.Rows[i]["Material Description"].ToString();
                        lHoja.Cells[2 + i, "C"] = lTbl.Rows[i]["MR Number"].ToString();
                        lHoja.Cells[2 + i, "D"] = lTbl.Rows[i]["PO Equipment or Tag Number"].ToString();
                        lHoja.Cells[2 + i, "E"] = lTbl.Rows[i]["Stockcode"].ToString();
                        lHoja.Cells[2 + i, "F"] = lTbl.Rows[i]["Qty"].ToString();
                        lHoja.Cells[2 + i, "G"] = lTbl.Rows[i]["Unit"].ToString();
                        lHoja.Cells[2 + i, "H"] = lTbl.Rows[i][" Length (Meters)"].ToString();
                        lHoja.Cells[2 + i, "I"] = lTbl.Rows[i]["Width (Meters)"].ToString();
                        lHoja.Cells[2 + i, "J"] = lTbl.Rows[i]["Height (Meters)"].ToString();
                        lHoja.Cells[2 + i, "K"] = lTbl.Rows[i]["Total Package Weight  (Peso Total de Paquete)"].ToString();
                        lHoja.Cells[2 + i, "L"] = lTbl.Rows[i]["Point of Shipment"].ToString();
                        lHoja.Cells[2 + i, "M"] = lTbl.Rows[i][" Length (Meters)"].ToString();
                        lHoja.Cells[2 + i, "N"] = lTbl.Rows[i]["Width (Meters)"].ToString();
                        lHoja.Cells[2 + i, "O"] = lTbl.Rows[i]["Height (Meters)"].ToString();
                        lHoja.Cells[2 + i, "P"] = lTbl.Rows[i]["IdPaquete"].ToString();
                        lHoja.Cells[2 + i, "Q"] = lTbl.Rows[i]["Fecha despacho Programada"].ToString();
                        lHoja.Cells[2 + i, "R"] = lTbl.Rows[i]["Nro GD"].ToString();
                        lHoja.Cells[2 + i, "S"] = lTbl.Rows[i]["Fecha GD INET"].ToString();
                        lHoja.Cells[2 + i, "T"] = lTbl.Rows[i]["ESP"].ToString();
                        lHoja.Cells[2 + i, "U"] = lTbl.Rows[i]["PO Number"].ToString();
                        lHoja.Cells[2 + i, "V"] = lTbl.Rows[i]["Plano"].ToString();
                        lHoja.Cells[2 + i, "W"] = lTbl.Rows[i]["Referencia"].ToString();
                        lHoja.Cells[2 + i, "X"] = lTbl.Rows[i]["Status"].ToString();
                        lHoja.Cells[2 + i, "Y"] = lTbl.Rows[i]["Etiqueta"].ToString();
                        lHoja.Cells[2 + i, "Z"] = lTbl.Rows[i]["Viaje"].ToString();
                        lHoja.Cells[2 + i, "AA"] = lTbl.Rows[i]["Marca"].ToString();

                    }
                    lPathArchivo = String.Concat(lPathBase, "BOM_", iTipo, DateTime.Now.ToShortDateString().Replace("/", "-"), ".xlsx");
                  //  lPathArchivo = String.Concat(lPathBase, "E_PL_", DateTime.Now.ToShortDateString().Replace("/", "-"), ".xlsx");
                    if (System.IO.File.Exists(lPathArchivo) == true)
                        System.IO.File.Delete(lPathArchivo);


                    lLibro.SaveAs(lPathArchivo);
                    lLibro.Close();
                    lApp.Quit();

                    ReleaseObject(lApp);
                    ReleaseObject(lLibro);
                    ReleaseObject(lHoja);

                }
            }
            catch (Exception iex)
            {
                throw iex;
            }


            return lPathArchivo;
        }

        private void ReleaseObject(Object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception iex)
            {
                obj = null;
            }
            finally
            { GC.Collect(); }
           
            }

        private string EnviarArchivo(string iMgs, string iTitulo, string iArchivos, DataTable lTblDest)
        {
            MailMessage MMessage = new MailMessage();int i = 0;
           
            string lRes = "";
            try
            {
                for (i=0; i<lTblDest .Rows.Count;i++)
                {
                    MMessage.To.Add(lTblDest.Rows [i]["MailDest"].ToString ());
                }
                //MMessage.To.Add("lgallardo@torresocaranza.cl");
                //MMessage.To.Add("rbecerra@torresocaranza.cl");

                MMessage.From = new MailAddress("notificaciones@smtyo.cl", "NoResponder", System.Text.Encoding.UTF8);


                MMessage.Subject = iTitulo; // '"Notificación por Reglas de Negocio "
                MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                MMessage.Body = iMgs;// '"Esto es una prueba";
                MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                MMessage.IsBodyHtml = true; // 'Formato html
                MMessage.Attachments.Add(new Attachment(iArchivos));

                //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                SmtpClient SClient = new SmtpClient();
                SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                //SClient.Credentials = new System.Net.NetworkCredential("notificaciones@smtyo.cl", "ADM_OC.SSGT.2013");
                SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                SClient.Port = 587; // 'Puerto del SMTP de Gmail
                SClient.EnableSsl = true; // 'Habilita el SSL, necesio en Gmail
                //'Capturamos los errores en el envio


                SClient.Send(MMessage);
                lRes = "Ok";
            }
            catch (Exception iex)
            {
                // MessageBox.Show(string.Concat("Ha Ocurrido el Siguiente Error: ", iex.Message.ToString(), "Avisos Sistema")); 
                //  lRes = iex.Message.ToString();
                throw iex;
            }
                return lRes;
        }

        private string RegistraError(string iMgs, string iTitulo)
        {
            MailMessage MMessage = new MailMessage();

            string lRes = "";
            try
            {
                
                    MMessage.To.Add("Soporte@torresOcaranza.cl");
             
                MMessage.From = new MailAddress("notificaciones@smtyo.cl", "NoResponder", System.Text.Encoding.UTF8);


                MMessage.Subject = iTitulo; // '"Notificación por Reglas de Negocio "
                MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                MMessage.Body = iMgs;// '"Esto es una prueba";
                MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                MMessage.IsBodyHtml = true; // 'Formato html
                //MMessage.Attachments.Add(new Attachment(iArchivos));

                //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                SmtpClient SClient = new SmtpClient();
                //SClient.Credentials = new System.Net.NetworkCredential("notificaciones@smtyo.cl", "ADM_OC.SSGT.2013");
                SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                SClient.Port = 587; // 'Puerto del SMTP de Gmail
                SClient.EnableSsl = true; // 'Habilita el SSL, necesio en Gmail
                //'Capturamos los errores en el envio


                SClient.Send(MMessage);
                lRes = "Ok";
            }
            catch (Exception iex)
            {
                // MessageBox.Show(string.Concat("Ha Ocurrido el Siguiente Error: ", iex.Message.ToString(), "Avisos Sistema")); 
                //  lRes = iex.Message.ToString();
               // throw iex;
            }
            return lRes;
        }

        private int Val(string iValor)
        {
            int lRes = 0;
            try
            {
                lRes = int.Parse(iValor);
            }
            catch (Exception iEx)
            {
                lRes = 0;
            }
            return lRes;
        }

        private Boolean ProcesaEnvioPL(string iDia, string iHora, string iIdObra, string iTipo)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet();DataTable lTbl = new DataTable();
            string lDia = ""; int  lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc(); string lPathArchivo = "";

            
                    lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
                lHoraActual =  DateTime.Now.Hour;
                lDiaActual = DateTime.Now.ToString("dddd");

                switch (lDia.ToUpper() )
                {
                    case "T": //Todos los días 
                        if (lHora == lHoraActual)
                        {
                            // si no se ha enviado el archivo
                            //entonces enviarlo
                            //si el envio esta OK==> registrar el envio.
                            if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat ("e_PL_", iTipo)) == false)
                            {
                                // enviar el archivo
                                lPathArchivo = EnviarPL(iIdObra, iTipo);
                                if (lPathArchivo.ToString().Length > 0)
                                    lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("e_PL_", iTipo), lPathArchivo);
                            }
                        }
                        break;
                    
                    default:
                   
                        break;
                }
            //}

            return lRes;

            }


        private Boolean ProcesaEnvioBOM( string iDia, string iHora, string iIdObra, string iTipo)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc(); string lPathArchivo = "";

           
            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
                lHoraActual = DateTime.Now.Hour;
                lDiaActual = DateTime.Now.ToString("dddd");
            switch (iIdObra)
            {
                //case "682": //QBF 2
                //    if (lDiaActual.ToString().ToUpper().Equals("VIERNES") && (lHora == lHoraActual))
                //    {
                //        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BOM_", iTipo)) == false)
                //        {
                //            // enviar el archivo
                //            lPathArchivo = EnviarBOM(iIdObra, iTipo);
                //            if (lPathArchivo.ToString().Length > 0)
                //                lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BOM_", iTipo), lPathArchivo);
                //        }
                //    }
                //    break;
                case "682": //QBF 2
                case "803": //QBF 4
                case "806": //QBF 470
                case "807": //QBF 6
                case "772": //QBF 5
                    if (lDiaActual.ToString().ToUpper().Equals("VIERNES") && (lHora == lHoraActual))
                    {
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BOM_", iTipo)) == false)
                        {
                            // enviar el archivo
                            lPathArchivo = EnviarBOM(iIdObra, iTipo);
                            if (lPathArchivo.ToString().Length > 0)
                                lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BOM_", iTipo), lPathArchivo);
                        }
                    }
                    else
                        if (lDiaActual.ToString().ToUpper().Equals("MIÉRCOLES") && (lHora == lHoraActual))
                    {
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BOM_", iTipo)) == false)
                        {
                            // enviar el archivo
                            lPathArchivo = EnviarBOM(iIdObra, iTipo);
                            if (lPathArchivo.ToString().Length > 0)
                                lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BOM_", iTipo), lPathArchivo);
                        }
                    }

                    break;
                default:

                    break;
            }

            

            //}

            return lRes;

        }

        private Boolean ProcesaEnvioBOM_inmediato(string iDia, string iHora, string iIdObra, string iTipo)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc(); string lPathArchivo = "";


            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");
            switch (iIdObra)
            {
               
                case "682": //QBF 2
                case "803": //QBF 4
                case "806": //QBF 470
                case "807": //QBF 6
                case "772": //QBF 5
                   
                            lPathArchivo = EnviarBOM(iIdObra, iTipo);
                            
             
                    break;
                default:

                    break;
            }



            //}

            return lRes;

        }

        private void RevisaLC(string iTipo)
        {
            string lRes = "";
            Frm_WB_EnvAut lFrm = new Frm_WB_EnvAut();
            lFrm.ShowDialog(this);

            if (AppDomain.CurrentDomain.GetData("Res") != null)
            {
                lRes = AppDomain.CurrentDomain.GetData("Res").ToString();

                if (!lRes.ToUpper().Equals("OK"))
                        {
                    lRes = "Esperando";


                }

            }




        }

        private Boolean ProcesaRevisionBloqueos_LC(string iDia, string iHora)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
            string lPathArchivo = "";string lTipo = "";

            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            if (iDia.ToString().ToUpper().Equals("T") ) //&& (lHora == lHoraActual))
            {
                switch  ( lHoraActual)
                 {  
                    case 9:  
                         mGenerandoArchivo = true;
                        lTipo = "1";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BLC_", lTipo)) == false)
                        {
                            RevisaLC(lTipo);
                            lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BLC_", lTipo), "");
                            NotificarRevisionLC(string.Concat("BLC_", lTipo));
                        }
                           
                        mGenerandoArchivo = false;
                        break;
                    case 13:  
                        mGenerandoArchivo = true;
                        lTipo = "2";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BLC_", lTipo)) == false)
                        {
                            RevisaLC(lTipo);
                            lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BLC_", lTipo), "");
                            NotificarRevisionLC(string.Concat("BLC_", lTipo));
                        }
                        mGenerandoArchivo = false;
                        break;
                    case 19:  
                        mGenerandoArchivo = true;
                        lTipo = "3";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BLC_", lTipo)) == false)
                        {
                            RevisaLC(lTipo);
                            lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BLC_", lTipo), "");
                            NotificarRevisionLC(string.Concat("BLC_", lTipo));
                        }
                        mGenerandoArchivo = false;
                        break;
                    case 1: 
                        mGenerandoArchivo = true;
                        lTipo = "4";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("BLC_", lTipo)) == false)
                        {
                            RevisaLC(lTipo);
                            lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("BLC_", lTipo), "");
                            NotificarRevisionLC(string.Concat("BLC_", lTipo));
                        }
                        mGenerandoArchivo = false;
                        break;
                }   
            }
                    
            return lRes;
        }


        private Boolean Envia_DocumentosCalidad( )
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lSql = "";int i = 0;
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
    

            // una Query a los viajes que estan al 100% de su certificación, se envian via mail
            lSql = String.Concat("  SP_ConsultasGenerales  154,'','','','','' ");
            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        EnviaMail_Doc_Calidad(lTbl.Rows[i]["Codigo"].ToString(), lTbl .Rows [i]["IdObra"].ToString ());
                    }
                
                }
                // Se verifican las ITs que NO estan certificadas en un 100%, Lotes No Encontrados 
                //lSql = String.Concat("  SP_ConsultasGenerales  155,'','','','','' ");
                //lDts = lPx.ObtenerDatos(lSql);
                //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                //{
                //    lTbl = lDts.Tables[0].Copy();
                //    for (i = 0; i < lTbl.Rows.Count; i++)
                //    {
                        EnviaMail_Lotes_NO_Encontrados();
                    //}
                //}


            }
            catch (Exception iEx)
            { }

            return lRes;
        }

        public void Envia_Guias_Pendientes_Entrega_Camion()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0; int j = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = "";  DataRow lFila = null;
            WS_Gerdau.WS_IntegracionGerdauSoapClient lDal = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataView lVista = null; string lwheres = ""; DataTable lTblTrans = new DataTable(); DataTable lTblDest = new DataTable();

            lSql = String.Concat("  exec SP_Consultas_WS 218, '', '', '', '', '', '', '' ");
            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    lSql = String.Concat(" select distinct  par4  from to_parametros  where subtabla='Transportistas'  ");
                    lDts = lPx.ObtenerDatos(lSql);
                    lTblTrans = lDts.Tables[0].Copy();
                    for (j = 0; j < lTblTrans.Rows.Count; j++)
                    {
                        lwheres = string.Concat(" DiasPendientes>2  and Mail='", lTblTrans.Rows[j][0].ToString(),"'");
                        lVista = new DataView(lTbl, lwheres, "Mail ", DataViewRowState.CurrentRows);
                        if (lVista.Count > 0)
                        {
                            lTx = String.Concat(" Estimado/a: <br> De acuerdo a nuestros registros, están pendientes algunas de las guías de despacho firmadas por cliente en Obra, las cuales no han sido recibidas en nuestras  oficinas de Torres Ocaranza  <br>  ");
                            lTx = String.Concat(lTx, "  Favor hacer llegar las siguientes guías de despacho  a la brevedad:   ");
                            lTx = String.Concat(lTx, "   <br> <br> ");
                            lTx = String.Concat(lTx, "<table   border='1'>    <tr>  ");
                            lTx = String.Concat(lTx, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Nro. Guia </td> ");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> OBRA  </td>");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> FECHA </td> ");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> PATENTE </td> ");
                            lTx = String.Concat(lTx, "  </tr> ");
                            for (i = 0; i < lVista.Count; i++)
                            {
                                lTx = String.Concat(lTx, "  <tr> ");
                                lTx = String.Concat(lTx, "  <td>", lVista[i]["NroGuiaInet"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  <td>", lVista[i]["Obra"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  <td>  ", lVista[i]["fechaDoc"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  <td>", lVista[i]["patente"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  </tr> ");

                            }
                            lTx = String.Concat(lTx, " </table > <BR> <BR>  ");
                            lTx = String.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR> Se ha omitido algunos caracteres, como los acentos");



                            lTblDest = ObtenerDestinatarios("-2000");
                            MailMessage MMessage = new MailMessage();
                            //agregamos el correo del trasportista
                            MMessage.To .Add(lTblTrans.Rows[j][0].ToString());

                            for (i = 0; i < lTblDest.Rows.Count; i++)
                                MMessage.CC.Add(lTblDest.Rows[i]["MailDest"].ToString());

                            

                            MMessage.From = new MailAddress("notificaciones@smtyo.cl", " Guias NO Entregadas ", System.Text.Encoding.UTF8);
                            MMessage.Subject = " Guias pendientes de firma por cliente en Obra ";
                            MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                            MMessage.Body = lTx;
                            MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                            MMessage.IsBodyHtml = true; // 'Formato html;
                                                        // '    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                            SmtpClient SClient = new SmtpClient();
                            SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                            //SClient.Credentials = new System.Net.NetworkCredential("notificaciones@smtyo.cl", "ADM_OC.SSGT.2013");
                            SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                            SClient.Port = 587;  // 'Puerto del SMTP de Gmail
                            SClient.EnableSsl = true; // ' // 'Habilita el SSL, necesio en Gmail
                                                      // ' //'Capturamos los errores en el envio
                            SClient.Send(MMessage);




                        }


                    }

                }
            }
            catch (Exception iex)
            {

            }

        }

        public  void EnviaMail_Lotes_NO_Encontrados()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = "";
            WS_Gerdau.WS_IntegracionGerdauSoapClient lDal = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataSet lDtsViajes = new DataSet();

            //lSql = String.Concat("  [SP_ConsultasGenerales]  155,'','','','',''  ");

            lSql = String.Concat("    SP_ConsultasInformes  30, ' ', ' ', '', '', '' ");


            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    if ((lTbl.Rows.Count > 0))
                    {
                        lTx = "";
                        if (lTbl.Rows.Count > 0)
                        {
                            lTx = String.Concat(" Hola Estimados: <br> A continuación les enviamos el detalle de los Lotes con problemas, puede ser por lote mal digitado o el certificado NO esta disponible en IDIEM <br>  ");
                            lTx = String.Concat(lTx, "   <br> <br> ");
                            lTx = String.Concat(lTx, "<table   border='1'>    <tr>  ");
                            lTx = String.Concat(lTx, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Sucursal</td> ");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>IT </td>");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Lote</td> ");
                            //lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Lote</td> ");
                            lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fecha Despacho</td> ");
                            lTx = String.Concat(lTx, "  </tr> ");
                            for (i = 0; i < lTbl.Rows.Count; i++)
                            {
                                lTx = String.Concat(lTx, "  <tr> ");
                                lTx = String.Concat(lTx, "  <td>", lTbl.Rows[i]["Sucursal"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  <td>", lTbl.Rows[i]["Codigo"].ToString(), "</td> ");
                                //lTx = String.Concat(lTx, "  <td>", lTbl.Rows[i]["Lote"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  <td> <a href=http://200.29.219.24/Certificados/RevisaColada.php?Lote=", lTbl.Rows[i]["Lote"].ToString(),">", lTbl.Rows[i]["Lote"].ToString(), "</td> ");
                                // <a href=", lTbl.Rows[i]["UrlCertificado"].ToString(), ">

                                lTx = String.Concat(lTx, "  <td>", lTbl.Rows[i]["FechaDespacho"].ToString(), "</td> ");
                                lTx = String.Concat(lTx, "  </tr> ");
                            }
                            lTx = String.Concat(lTx, " </table > <BR> <BR>  ");

                                lTx = String.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                            // '  lTx = String.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>")



                            lTbl = ObtenerDestinatarios("-1700");
                            MailMessage MMessage = new MailMessage(); 
                            string[] separators = { "-" };

                            //lPathDest = Path.Combine(ipathDestino, lPathSigla);

                            for (i = 0; i < lTbl.Rows.Count; i++)
                                MMessage.To.Add(lTbl.Rows[i]["MailDest"].ToString());

                            MMessage.From = new MailAddress("notificaciones@smtyo.cl", " Lotes con Problema ", System.Text.Encoding.UTF8);
                            MMessage.Subject = " Envío de  Lotes Con Problemas  ";
                            MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                            MMessage.Body = lTx;

                      

                                MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                                MMessage.IsBodyHtml = true; // 'Formato html;

                                // '    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                                SmtpClient SClient = new SmtpClient();
                            SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                          //  SClient.Credentials = new System.Net.NetworkCredential("notificaciones@smtyo.cl", "ADM_OC.SSGT.2013");
                                SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                                SClient.Port = 587;  // 'Puerto del SMTP de Gmail
                                SClient.EnableSsl = true; // ' // 'Habilita el SSL, necesio en Gmail
                                                          // ' //'Capturamos los errores en el envio
                                SClient.Send(MMessage);
                             

                        }
                    }
                }
            }
            catch (Exception iex)
            {

            }

        }

        public void EnviaMail_RevisionSaldos_LC(List<Models.LineaCredito> iLista)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();  int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = "";
            WS_Gerdau.WS_IntegracionGerdauSoapClient lDal = new WS_Gerdau.WS_IntegracionGerdauSoapClient();
            DataSet lDtsViajes = new DataSet();

            try
            {
                Tm_Envios.Enabled = false;
                mGenerandoArchivo = true;
            
                if (iLista.Count >0)
                {
                    lTx = "";
                    lTx = String.Concat(" Hola Estimados: <br> A continuación les enviamos el detalle de los Clientes con inconsistencias  <br>  ");
                    lTx = String.Concat(lTx, "   <br> <br> ");
                    lTx = String.Concat(lTx, "<table   border='1'>    <tr>  ");
                    lTx = String.Concat(lTx, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>R.U.T.</td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Cliente</td>");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Monto</td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Bloqueo</td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fact. P P </td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desp. Sin Fact</td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>COF F </td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Diferencia F</td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>COF J </td> ");
                    lTx = String.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Diferencia J</td> ");
                    lTx = String.Concat(lTx, "  </tr> ");
                    for (i = 0; i < iLista.Count; i++)
                    {
                        if ((iLista[i].Diferencia_F != 0) || (iLista[i].Diferencia_J != 0))
                        {
                            lTx = String.Concat(lTx, "  <tr> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].Rut.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].Cliente.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td> ", iLista[i].Monto.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].Bloqueo.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].F_PP.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].D_SinFact.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td> ", iLista[i].COF_F.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].Diferencia_F.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td> ", iLista[i].COF_J.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  <td>", iLista[i].Diferencia_J.ToString(), "</td> ");
                            lTx = String.Concat(lTx, "  </tr> ");
                        }
                    }
                    lTx = String.Concat(lTx, " </table > <BR> <BR>  ");
                    lTx = String.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                    lTx = String.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>");



                    lTbl = ObtenerDestinatarios("-1800");
                    MailMessage MMessage = new MailMessage();  
                    string[] separators = { "-" };  

                    //lPathDest = Path.Combine(ipathDestino, lPathSigla);

                    for (i = 0; i < lTbl.Rows.Count; i++)
                        MMessage.To.Add(lTbl.Rows[i]["MailDest"].ToString());

                    MMessage.From = new MailAddress("notificaciones@smtyo.cl", " Revisión de saldos en Línea de Crédito  ", System.Text.Encoding.UTF8);
                    MMessage.Subject = "Revisión de saldos en Línea de Crédito  ";
                    MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    MMessage.Body = lTx;

                    MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    MMessage.IsBodyHtml = true; // 'Formato html;

                    // '    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                    SmtpClient SClient = new SmtpClient();
                    SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                   // SClient.Credentials = new System.Net.NetworkCredential("notificaciones@smtyo.cl", "ADM_OC.SSGT.2013");
                    SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                    SClient.Port = 587;  // 'Puerto del SMTP de Gmail
                    SClient.EnableSsl = true; // ' // 'Habilita el SSL, necesio en Gmail
                                                // ' //'Capturamos los errores en el envio
                    SClient.Send(MMessage);

                }
            }
            catch (Exception iex)
            {

            }

        }

        public  string VerificaLotePaquete(string iLote, string iIdEtiqueta)
        {
            string lRes = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; 
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lLoteCP = "";

            lSql = String.Concat(" Select Lote from CertificadosPaquete where  IdPaquete=", iIdEtiqueta );
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                lLoteCP = lTbl.Rows[0][0].ToString();
                if (lLoteCP.Equals(iLote))
                    lRes = "S";
                else
                    lRes = "N";
            }


                return lRes;
        }

        public  void EnviaMail_Doc_Calidad(string iCodigo, string iObra)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = ""; DataTable lTblDetalle = new DataTable();
            DataTable TblUC = new DataTable() ; string lLote = ""; Boolean lPuedeSeguir = true;
            string lPathInfLote = ""; string lPathCertLote = ""; string lLotesEnviados = "";
            lSql = String.Concat("  SP_Consultas_WS  192,'", iCodigo, "','','','',',','',''");
            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblDetalle = lDts.Tables[0].Copy();
                    TblUC = ObtenerDestinatarios("-1700");
                    lTx = "";
                    if (lTblDetalle.Rows.Count > 0)
                    {
                        lTx = String.Concat(" Hola Estimados: <br> A continuación les enviamos la información referente a los Certificados de Calidad <br>  ");
                        lTx = String.Concat(lTx, " Para la obra: ", lTblDetalle.Rows[0]["NombreObra"].ToString(), " <br> <br> ");
                        lTx = String.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                        // '  lTx = String.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>")

                        for (i = 0; i < lTblDetalle.Rows.Count; i++)
                        {
                            if (lTblDetalle.Rows[i]["LoteAza"].ToString().Trim().Length > 0)
                                lLote = lTblDetalle.Rows[i]["LoteAza"].ToString();
                            else
                                lLote = lTblDetalle.Rows[i]["Lote"].ToString();
                            if (VerificaLotePaquete(lLote, lTblDetalle.Rows[i]["Id"].ToString()) == "N")
                            {
                                lPuedeSeguir = false;
                                i = lTblDetalle.Rows.Count;
                            }
                        }

                        if (lPuedeSeguir == true)
                        {
                            lTbl = ObtenerDestinatarios(iObra);
                            lTbl.Merge(TblUC);
                            MailMessage MMessage = new MailMessage(); string lSuc = ""; string lPathCertificado = "";
                            string[] separators = { "-" }; string lPathInforme = "";
                            string[] lPartes = iCodigo.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            string lPathSigla = lPartes[0].ToString();
                            //lPathDest = Path.Combine(ipathDestino, lPathSigla);

                            for (i = 0; i < lTbl.Rows.Count; i++)
                                MMessage.To.Add(lTbl.Rows[i]["MailDest"].ToString());

                            MMessage.From = new MailAddress("Calidad@smtyo.cl", "Envio Certificados ", System.Text.Encoding.UTF8);
                            MMessage.Subject = " Envío de Certificados  electronicos T.O. ";
                            MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                            MMessage.Body = lTx;

                            // DAtos de los archivos adjuntos

                            lSql = "  select distinct    s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s   ";
                            lSql = string.Concat(lSql, "    where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id   ");
                            lSql = string.Concat(lSql, " and  codigo='", iCodigo, "'");
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTbl = lDts.Tables[0].Copy();  // tabla con los lotes del viaje 
                                lSuc = string.Concat(lTbl.Rows[0]["Sucursal"].ToString(), "\\");
                                lPathCertificado = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), "CertificadoFabricacion.pdf");
                                lPathInforme = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), "TrazabilidadColadas.pdf");

                                if ((File.Exists(lPathCertificado) == true) && (File.Exists(lPathInforme) == true))
                                {
                                    // Siempre deben haber 2  archivos 
                                    MMessage.Attachments.Add(new Attachment(lPathCertificado));
                                    MMessage.Attachments.Add(new Attachment(lPathInforme));
                                }

                                for (i = 0; i < lTblDetalle.Rows.Count; i++)
                                {


                                    if (lTblDetalle.Rows[i]["LoteAza"].ToString().Trim().Length > 0)
                                        lLote = string.Concat(lTblDetalle.Rows[i]["LoteAza"].ToString(), "_");
                                    else
                                        lLote = string.Concat(lTblDetalle.Rows[i]["Lote"].ToString(), "_");

                                    if (lLotesEnviados.IndexOf(lLote) == -1)
                                    {
                                        lPathInfLote = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), string.Concat(lLote, "I.pdf"));
                                        lPathCertLote = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), string.Concat(lLote, "C.pdf"));
                                        if ((File.Exists(lPathInfLote) == true) && (File.Exists(lPathCertLote) == true))
                                        {
                                            // Siempre deben haber 2  archivos 
                                            MMessage.Attachments.Add(new Attachment(lPathInfLote));
                                            MMessage.Attachments.Add(new Attachment(lPathCertLote));
                                        }
                                        else
                                        {
                                            lPuedeSeguir = false;
                                            i = lTbl.Rows.Count;
                                        }
                                        lLotesEnviados = string.Concat(lLotesEnviados, lLote, "-");
                                    }
                                }

                                if (lPuedeSeguir == true)
                                {
                                    MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                                    MMessage.IsBodyHtml = true; // 'Formato html;

                                    // '    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                                    SmtpClient SClient = new SmtpClient();
                                    SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                                    SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                                    SClient.Port = 587;  // 'Puerto del SMTP de Gmail
                                    SClient.EnableSsl = true; // ' // 'Habilita el SSL, necesio en Gmail
                                                              // ' //'Capturamos los errores en el envio
                                    SClient.Send(MMessage);

                                    //persistimo el envio para no enviarlo nuevamente
                                    lSql = String.Concat("  Update viaje set mailCalidadEnviado='S' where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                }
                                else
                                {
                                   lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                }
                            }
                        }
                        else
                        {
                            lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' where Codigo='", iCodigo, "' ");
                            lDts = lPx.ObtenerDatos(lSql);
                        }
                    }
                }
            } catch (Exception iex)
            {
                //persistimo el envio para no enviarlo nuevamente
                lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' where Codigo='", iCodigo, "' ");
                lDts = lPx.ObtenerDatos(lSql);
            }

        }

        public Boolean EsLoteAza(string iLote)
        {
            Boolean lRes = true; string lTmp = "";

            if (iLote.Trim().Length < 7 )  // si el lote es 5 caracteres 
                lRes = false;

            lTmp = string.Concat("00000", iLote);
            if (iLote.IndexOf("00000") > -1)  // si el lote del tipo 0000054321
                lRes = false;


            return lRes;
        }

        private Boolean ExisteArchivo(string iPath, string lArchivo)
        {
            Boolean lRes = false;string directoryName = "";
            directoryName = Path.GetDirectoryName(iPath);

            try
            {
                if (Directory.Exists(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\SANTIAGO\HCI\HCI-110_1\"))
                {
                    DirectoryInfo di = new DirectoryInfo(directoryName);

                    foreach (var fi in di.GetFiles())
                    {
                        //Console.WriteLine(fi.Name);
                        if (fi.Name == lArchivo)
                        {

                        }
                    }
                }
            }
            catch (Exception iEx)
            {
                MessageBox.Show(iEx.Message.ToString());
            }


            return lRes;
        }

        public string  EnviaMail_Doc_Calidad_ZIP(string iCodigo, string iObra)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0; string lRes = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string lTx = ""; DataTable lTblDetalle = new DataTable();
            DataTable TblUC = new DataTable(); string lLote = ""; Boolean lPuedeSeguir = true; MailMessage MMessage = new MailMessage();
           string lLotesEnviados = ""; string lPathZip = ""; string lPathArchs = "";
            DataTable lTblLotes = new DataTable();string lPathCalidad = "";string lTmp = "";string lLog = "";
            Clases.Cls_EnvioDoc lDoc = new Clases.Cls_EnvioDoc();
            lSql = String.Concat("  SP_Consultas_WS  192,'", iCodigo, "','','','',',','',''");
            try
            {
                Desactivar_Timmer();
                lPathCalidad=string.Concat (ConfigurationManager.AppSettings["Path_Calidad"].ToString());
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblDetalle = lDts.Tables[0].Copy();
                    

                    lTx = "";
                    if (lTblDetalle.Rows.Count > 0)
                    {
                        for (i = 0; i < lTblDetalle.Rows.Count; i++)
                        {
                           // if (EsLoteAza ())
                            if (lTblDetalle.Rows[i]["Lote"].ToString().Trim().Length > 0)
                                lLote = lTblDetalle.Rows[i]["Lote"].ToString();
                            else
                                lLote = lTblDetalle.Rows[i]["LoteAza"].ToString();

                            if (VerificaLotePaquete(lLote, lTblDetalle.Rows[i]["Id"].ToString()) == "N")
                            {
                                lPuedeSeguir = false;
                                lLog = string.Concat("lEnv.VerificaLotePaquete=N - IdPaq=", lTblDetalle.Rows[i]["Id"].ToString(), Environment.NewLine);
                                i = lTblDetalle.Rows.Count;
                               
                            }

                        }

                        if (lPuedeSeguir == true)
                        {
                      
                            string lSuc = ""; string lPathCertificado = "";
                            string[] separators = { "-" }; string lPathInforme = "";
                            string[] lPartes = iCodigo.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            string lPathSigla = lPartes[0].ToString();

                            lSql = "  select distinct    s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s   ";
                            lSql = string.Concat(lSql, "    where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id   ");
                            lSql = string.Concat(lSql, " and  codigo='", iCodigo, "'");
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTbl = lDts.Tables[0].Copy();  // tabla con los lotes del viaje 
                                lSuc = string.Concat(lTbl.Rows[0]["Sucursal"].ToString(), "\\");
                                lPathCertificado = Path.Combine(lPathCalidad, lSuc, lPathSigla, iCodigo.Replace("/", "_"), "CertificadoFabricacion.pdf");
                                lPathInforme = Path.Combine(lPathCalidad, lSuc, lPathSigla, iCodigo.Replace("/", "_"), "TrazabilidadColadas.pdf");

                                //lPathCertificado = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), "CertificadoFabricacion.pdf");
                                //lPathInforme = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"), "TrazabilidadColadas.pdf");

                                //lPathCertificado = @"\\192.168.1.191\Gestion de Calidad\GeneracionDocumentosAutomatico\SANTIAGO\HCI\HCI-110_1\CertificadoFabricacion.pdf";
                                //lPathInforme = @"\\192.168.1.191\Gestion de Calidad\GeneracionDocumentosAutomatico\SANTIAGO\HCI\HCI-110_1\TrazabilidadColadas.pdf";

                                //ExisteArchivo(lPathInforme, "TrazabilidadColadas.pdf");

                                new Clases.Cls_EnvioDoc().GeneraDocumentacionEnCarpeta(iCodigo);

                                if ((File.Exists(lPathCertificado) == true) && (File.Exists(lPathInforme) == true))
                                {
                                    // Siempre deben haber 2  archivos 
                                    for (i = 0; i < lTblDetalle.Rows.Count; i++)
                                    {
                                        if (lTblDetalle.Rows[i]["Lote"].ToString().Trim().Length > 0)
                                            lLote = string.Concat(lTblDetalle.Rows[i]["Lote"].ToString()); //, "_");
                                        else
                                            lLote = string.Concat(lTblDetalle.Rows[i]["Lote"].ToString());//, "_");


                                        if (lLotesEnviados.IndexOf(lLote) == -1)
                                        {

                                            lTmp = lDoc.ExisteArchivoEnServer(lLote, lSuc, lPathSigla, iCodigo, lTblDetalle.Rows[i]["idcolada"].ToString(), lTblDetalle.Rows[i]["id"].ToString());
                                            if (lTmp.Trim().Length == 0)
                                                lPuedeSeguir = true;
                                            else
                                                lPuedeSeguir = false;

                                            if (lPuedeSeguir == true)
                                            {
                                                lPuedeSeguir = true;
                                            }
                                            else
                                            {
                                                lPuedeSeguir = false;
                                                i = lTblDetalle.Rows.Count;
                                            }
                                            

                                            lLotesEnviados = string.Concat(lLotesEnviados, lLote, "-");
                                        }
                                    }


                                }
                                else
                                {
                                    lPuedeSeguir = false;
                                    PersisteLog_EnviosCalidad(iCodigo, "NO Estan los archivos CertificadoFabricacion.pdf - TrazabilidadColadas.pdf", "E");
                                }



                                if (lPuedeSeguir == true)
                                {
                                    // De momento  Se debe Crear el archivo .Zip. (Pendiente, enviarlo a la lista de destinatarios)
                                    lPathZip = Path.Combine(lPathCalidad, lSuc, lPathSigla, string.Concat(iCodigo.Replace("/", "_"), ".zip"));
                                    lPathArchs = Path.Combine(lPathCalidad, lSuc, lPathSigla, iCodigo.Replace("/", "_"));
                                    //lPathZip = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, string.Concat (iCodigo.Replace("/", "_"),".zip") );
                                    //lPathArchs = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc, lPathSigla, iCodigo.Replace("/", "_"));

                                    if ((File.Exists(lPathZip) == true))
                                        File.Delete(lPathZip);



                                        ZipFile.CreateFromDirectory(lPathArchs, lPathZip);


                                    MMessage = new MailMessage();

                                    // Cargamos en copia oculta a los destinatarios de Calidad y TI.
                                    TblUC = ObtenerDestinatarios("-1700");
                                    for (i = 0; i < TblUC.Rows.Count; i++)
                                        MMessage.Bcc.Add (TblUC.Rows[i]["MailDest"].ToString());

                                    lTbl = ObtenerDestinatarios(iObra);
                                    //lTbl.Merge(TblUC);

                                    // Cargamos a los destinatarios  ingresado por sistema
                                    for (i = 0; i < lTbl.Rows.Count; i++)
                                        MMessage.To.Add(lTbl.Rows[i]["MailDest"].ToString());


                                    lTx = String.Concat(" Hola Estimados: <br> A continuación les enviamos la información referente a los Certificados de Calidad <br>  ");
                                    lTx = String.Concat(lTx, " Para la obra: ", lTblDetalle.Rows[0]["NombreObra"].ToString(), " <br> <br> ");
                                    lTx = String.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");

                                    MMessage.From = new MailAddress("Calidad@smtyo.cl", "Envio Certificados ", System.Text.Encoding.UTF8);
                                    MMessage.Subject = " Envío de Certificados  electronicos T.O. ";
                                    MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                                    MMessage.Body = lTx;

                                    MMessage.Attachments.Add(new Attachment(lPathZip));

                                    MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                                    MMessage.IsBodyHtml = true; // 'Formato html;

                                    // '    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                                    SmtpClient SClient = new SmtpClient();
                                    //SClient.Credentials = new System.Net.NetworkCredential("Calidad@smtyo.cl", "1ToiZfb0Br");
                                    SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion1@gmail.com", "azghaiokqalrqqtc");
                                    SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                                    SClient.Port = 587;  // 'Puerto del SMTP de Gmail
                                    SClient.EnableSsl = true; // ' // 'Habilita el SSL, necesio en Gmail
                                                              // ' //'Capturamos los errores en el envio
                                    SClient.Send(MMessage);


                                    //persistimo el envio para no enviarlo nuevamente
                                    lSql = String.Concat("  Update viaje set mailCalidadEnviado='S' , FechaMailCalidad=getdate()  where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                }
                                else
                                {
                                    lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' , FechaMailCalidad=getdate()  where Codigo='", iCodigo, "' ");
                                    lDts = lPx.ObtenerDatos(lSql);
                                    if (lTmp.Trim().Length >0 )
                                    PersisteLog_EnviosCalidad(iCodigo, lTmp, "E");
                                }
                            }
                        }
                        else
                        {
                            lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' , FechaMailCalidad=getdate()  where Codigo='", iCodigo, "' ");
                            lDts = lPx.ObtenerDatos(lSql);
                            PersisteLog_EnviosCalidad(iCodigo, lTmp, "E");
                        }
                    }
                }
                lRes = lLog;
            }
            catch (Exception iex)
            {
                //persistimo el envio para no enviarlo nuevamente
                MessageBox.Show(iex.Message.ToString(), " Error en el sistema");
                lSql = String.Concat("  Update viaje set mailCalidadEnviado='E' , FechaMailCalidad=getdate()  where Codigo='", iCodigo, "' ");
                lDts = lPx.ObtenerDatos(lSql);
                PersisteLog_EnviosCalidad(iCodigo, string.Concat (iex .Message .ToString (), " Traza: ",iex .StackTrace .ToString ()), "E");
            }
            return lLog;
        }

        private void PersisteLog_EnviosCalidad(string iCodigo, string iMsg, string  iEstado)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();

            lSql = " Insert into  Log_MailCalidadEnviado (Codigo, Mensaje,Estado,FechaEnvio) values ('";
            lSql = string.Concat(lSql, iCodigo, "','", iMsg, "','", iEstado, "', getdate())");
            lPx.ObtenerDatos(lSql);

        }

        private Boolean ProcesaCierreTotems(string iDia, string iHora)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
 

            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            if (iDia.ToString().ToUpper().Equals("T")) //&& (lHora == lHoraActual))
            {
                switch (lHoraActual)
                {
                    case 9:
                        mGenerandoArchivo = true;
                        //lTipo = "1";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("NotificaCierreTotems_", lHoraActual.ToString ())) == false)
                        {
                            NotificarCierreTotems();
                        }

                        mGenerandoArchivo = false;
                        break;
                    case 21:
                        mGenerandoArchivo = true;
                        //lTipo = "2";
                        if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("NotificaCierreTotems_", lHoraActual.ToString())) == false)
                        {
                            NotificarCierreTotems();
                        }
                        mGenerandoArchivo = false;
                        break;
                }
            }

            return lRes;
        }


        private void NotificarRevisionLC(string iArchivo)
        {
            DataTable lTblDest = new DataTable(); string lMsg = "";
            //if (iArchivo .IndexOf ("1")>-1)
            lMsg = " Hola estimadas : <br>   <br> ";
            lMsg = string.Concat(lMsg, " Según Porgramado, se ha realizado la revisión de las Lineas de Crédito de nuestros Clientes ");
            lMsg = string.Concat(lMsg, "  <Br>   Las notificaciones de Bloqueos y/o Desbloqueos fueron enviadas por Mail ");
            lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
            lMsg = string.Concat(lMsg, " Sistema de  Revisión de Bloqueos de Linea de Crédito de Torres Ocaranza  <Br> ");
            lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");

            lTblDest = ObtenerDestinatarios("-1400");
            if (lTblDest.Rows.Count > 0)
            {
                //string.Concat("BLC_", lTipo)
                MailMessage MMessage = new MailMessage(); int i = 0;
                try
                {
                    for (i = 0; i < lTblDest.Rows.Count; i++)
                    {
                        MMessage.To.Add(lTblDest.Rows[i]["MailDest"].ToString());
                    }
                   
                    MMessage.From = new MailAddress("notificaciones@smtyo.cl", "NoResponder", System.Text.Encoding.UTF8);
                    
                    MMessage.Subject ="Notificación de Revisión de Lineas de Credito "; // '"Notificación por Reglas de Negocio "
                    MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    MMessage.Body = lMsg;// '"Esto es una prueba";
                    MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    MMessage.IsBodyHtml = true; // 'Formato html
                  

                    //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                    SmtpClient SClient = new SmtpClient();
                    SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                    SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                    SClient.Port = 587; // 'Puerto del SMTP de Gmail
                    SClient.EnableSsl = true; // 'Habilita el SSL, necesio en Gmail
                                              //'Capturamos los errores en el envio
                    SClient.Send(MMessage);
                   
                }
                catch (Exception iex)
                {
                    // MessageBox.Show(string.Concat("Ha Ocurrido el Siguiente Error: ", iex.Message.ToString(), "Avisos Sistema")); 
                    //  lRes = iex.Message.ToString();
                    throw iex;
                }
                //return lRes;
            }
          

        }

        public void NotificarCierreTotems( )
        {
            DataTable lTblDest = new DataTable(); string lMsg = "";string lSql = "";
            DataSet  lTblEstadoMaq = new DataSet (); DataSet  lBtnDetalle = new DataSet ();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();  

            lSql = "  SP_ConsultasGenerales  152,'','','','',''";
            lBtnDetalle = lPx.ObtenerDatos(lSql);

            lSql = "  SP_ConsultasGenerales  153,'','','','',''";
            lTblEstadoMaq = lPx.ObtenerDatos(lSql);


            if ((lBtnDetalle.Tables.Count > 0) && (lBtnDetalle.Tables[0].Rows.Count > 0))
            {
                lMsg = " Señores : <br>   <br> ";
                lMsg = string.Concat(lMsg, " Resumen de cierre en los tótem en la planta de Cerrillos <Br>   <Br>  ");
                lMsg = string.Concat(lMsg, "        <Br>  <table   border='1'>   <tr>  ");
                lMsg = string.Concat(lMsg, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Totem o máquina</td> ");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fecha Último Cierre  </td>");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Operario</td> ");
                lMsg = string.Concat(lMsg, "  </tr> ");
                for (i = 0; i < lTblEstadoMaq.Tables[0].Rows.Count; i++)
                {

                    lMsg = String.Concat(lMsg, "  <tr> ");
                    lMsg = String.Concat(lMsg, "  <td>", lTblEstadoMaq.Tables[0].Rows[i]["MAq_descripcion"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lTblEstadoMaq.Tables[0].Rows[i]["UltimaIntegracion"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lTblEstadoMaq.Tables[0].Rows[i]["Operario"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  </tr> ");
                }
                lMsg = String.Concat(lMsg, " </table > <BR> <BR>   ");
            };

            if ((lBtnDetalle.Tables.Count > 0) && (lBtnDetalle.Tables[0].Rows.Count > 0))
            {
                lMsg = string.Concat(lMsg, "  <br> ") ;
                lMsg = string.Concat(lMsg, " Detalle del Consumo  <Br>   ");
                lMsg = string.Concat(lMsg, " <Br>  <table   border='1'>   <tr>  ");
                lMsg = string.Concat(lMsg, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Código </td> ");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>MovNumDoc  </td>");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fecha Integración</td> ");
                lMsg = string.Concat(lMsg, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Usuario </td> ");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Máquina   </td>");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Kgs OK </td> ");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Kgs Err </td> ");
                lMsg = string.Concat(lMsg, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'> Tipo Error </td> ");
                 lMsg = string.Concat(lMsg, "  </tr> ");
                for (i = 0; i < lBtnDetalle.Tables[0].Rows.Count; i++)
                {

                    lMsg = String.Concat(lMsg, "  <tr> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["CodProducto"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["MovNumDoc"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["FechaIntegracion"].ToString(), "</td> ");

                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["Usuario"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["Maq_Nombre"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["Kgs_Err"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["Kgs_OK"].ToString(), "</td> ");

                    //lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["Sol"].ToString(), "</td> ");
                    lMsg = String.Concat(lMsg, "  <td>", lBtnDetalle.Tables[0].Rows[i]["TipoError"].ToString(), "</td> ");

                    lMsg = String.Concat(lMsg, "  </tr> ");
                }
                lMsg = String.Concat(lMsg, " </table > <BR> <BR>   ");
                lMsg = string.Concat(lMsg, "  <Br>   <Br>   Saludos   <Br> ");
 
                lMsg = string.Concat(lMsg, " Sistema de  Revisión de Cierres de Tótems  -  Torres Ocaranza  <Br> ");
                lMsg = string.Concat(lMsg, " Favor NO responder a este correo, ya que ha sido generado de forma Automatica  <Br> ");


                lTblDest = ObtenerDestinatarios("-1600");
                if (lTblDest.Rows.Count > 0)
                {
                    MailMessage MMessage = new MailMessage();
                    try
                    {
                        for (i = 0; i < lTblDest.Rows.Count; i++)
                        {
                            MMessage.To.Add(lTblDest.Rows[i]["MailDest"].ToString());
                        }

                        MMessage.From = new MailAddress("notificaciones@smtyo.cl", "Consumo MP ", System.Text.Encoding.UTF8);

                        MMessage.Subject = "Resumen de cierre en los tótem en la planta de Cerrillos "; // '"Notificación por Reglas de Negocio "
                        MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                        MMessage.Body = lMsg;// '"Esto es una prueba";
                        MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                        MMessage.IsBodyHtml = true; // 'Formato html


                        //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                        SmtpClient SClient = new SmtpClient();
                        SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                        SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                        SClient.Port = 587; // 'Puerto del SMTP de Gmail
                        SClient.EnableSsl = true; // 'Habilita el SSL, necesio en Gmail
                                                  //'Capturamos los errores en el envio
                        SClient.Send(MMessage);
                    }
                    catch (Exception iex)
                    {
                        // MessageBox.Show(string.Concat("Ha Ocurrido el Siguiente Error: ", iex.Message.ToString(), "Avisos Sistema")); 
                        //  lRes = iex.Message.ToString();
                        throw iex;
                    }


                }
               
                //return lRes;
            }


        }
        private Boolean ProcesaRevisionGuias(string iDia, string iHora)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
            string lResultado = "";

            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            if (iDia.ToUpper().Equals("T") && (lHora == lHoraActual))
            {
                if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("Guias_IC")) == false)
                {
                    //RevisaLC(lTipo);
                    lResultado = lPx.RevisionGuias_C_I();
                    lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("Guias_IC"), "");
                }
            }
            return lRes;
        }

        private Boolean ProcesaRevisionGuias_Escaneadas(string iDia, string iHora)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
            string lResultado = "";

            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
            lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            if (iDia.ToUpper().Equals("T") && (lHora == lHoraActual))
            {
                if (lLN_EnvioDoc.ArchivoFueEnviado(string.Concat("Guias_Scan")) == false)
                {
                    
                    lResultado = Procesa_GuiasEscaneadas();
                    lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("Guias_Scan"), "");
                }
            }
            return lRes;
        }

        private string Procesa_GuiasEscaneadas( )
        {
            string  lRes = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();  string lSql = "";

            try
            {


                lSql = "  select convert(date,a.atefchdoc)  atefchdoc ,  (Select Par1 from   to_parametros where subtabla like '%TiposGuiaINET%' and par2= doccod ), ";
                lSql = String.Concat(lSql, "   (select Count(1) from  GuiasRecibidas g  where g.Doccod=a.doccod and NroGuiaInet=a.atenum   ), ");
                lSql = String.Concat(lSql, "  * from   Tocaranza.dbo.ateclien a where a.atefchdoc> '01/06/2022' and doccod between 300 and 400   ");
                lSql = String.Concat(lSql, "   and    not exists  ( select 1 from  GuiasRecibidas where  NroGuiaInet=a.atenum ) ");
                lSql = String.Concat(lSql, "  Order by   a.atenum ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lSql = " Insert into GuiasRecibidas (NroGuiaInet,FechaProceso,NombreArchivo, Estado, FechaGuiaInet, DocCod) Values (";
                        lSql = String.Concat(lSql, Val(lTbl.Rows[i]["atenum"].ToString()), ",Getdate(),'','I','", lTbl.Rows[i]["atefchdoc"].ToString());
                        lSql = String.Concat(lSql, "',", lTbl.Rows[i]["doccod"].ToString(), ")");
                        lPx.ObtenerDatos(lSql);
                    }

                }
                // ahora Invocamos el formulario que procesa.
                Logistica.Frm_ProcesaGDE lFrm = new Logistica.Frm_ProcesaGDE();
                lFrm.CargaDatos();
                lFrm.ProcesaDatos();

               
                mGenerandoArchivo = false;
                Envia_Guias_Pendientes_Entrega_Camion();
                mGenerandoArchivo = true;
                lRes = "OK";
            }
            catch (Exception iEx)
            {
                lRes = iEx.Message.ToString();
            }




            return lRes;
        }

        private Boolean ProcesaPT(string iDia, string iHora)
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0; string lDiaActual = "";
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();
             

            lDia = iDia; // lTbl.Rows[0]["Par1"].ToString();
           // lHora = Val(iHora); // Val(lTbl.Rows[0]["Par2"].ToString());
            lHoraActual = DateTime.Now.Hour;
            lDiaActual = DateTime.Now.ToString("dddd");

            if (iDia .ToUpper().Equals("C") && (iHora == "1"))
            {
                if (lLN_EnvioDoc.CreacionPT_Procesado(string.Concat("Creacion_PT" )) == false)
                {
                    //Primero Calama
                    Logistica.Frm_BodegaPT lForm = new Logistica.Frm_BodegaPT();
                    lForm.mSucursal = "1";
                    lForm.ShowDialog();
                    System.Threading.Thread.Sleep(2000);

                    //Luego Coronel
                    lForm = new Logistica.Frm_BodegaPT();
                    lForm.mSucursal = "14";
                    lForm.ShowDialog();
                    System.Threading.Thread.Sleep(2000);

                    //Luego santiago
                    lForm = new Logistica.Frm_BodegaPT();
                    lForm.mSucursal = "4";
                    lForm.ShowDialog();

                    ////Luego Concepción
                    //lForm = new Logistica.Frm_BodegaPT();
                    //lForm.mSucursal = "16";
                    //lForm.ShowDialog();
                    lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("Creacion_PT"),"");
                }

               
            }
            return lRes;
        }

        private void  Procesa_Certificados_Calidad()
        {
            Boolean lRes = false; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lDia = ""; int lHora = 0; int lHoraActual = 0;  int lMinActual = 0;
            Clases.Cls_EnvioDoc lLN_EnvioDoc = new Clases.Cls_EnvioDoc();


            lMinActual = DateTime.Now.Minute;
                
            if ((lMinActual>10) && (lMinActual < 40))
            {
                if (lLN_EnvioDoc.CreacionPT_Procesado(string.Concat("Creacion_PT")) == false)
                {
                    //Procesamos la generación de los certificados de calidad
                    Logistica.Frm_BodegaPT lForm = new Logistica.Frm_BodegaPT();
                    lForm.mSucursal = "1";
                    lForm.ShowDialog();
                    System.Threading.Thread.Sleep(2000);
                    //Luego Coronel
           

                    lLN_EnvioDoc.GrabarEnvioArchivo(string.Concat("Creacion_PT"), "");
                }


            }
          
        }


        #endregion

        private void Btn_Envia_ILC_Click(object sender, EventArgs e)
        {
             Enviar_ILC();

        }

        private void CargaEnvios()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();int i = 0;
            DataSet lDts = new DataSet(); Clases.Cls_EnvioDoc lN = new Clases.Cls_EnvioDoc();
            string lVersion =   ConfigurationManager.AppSettings["Version"].ToString();

            this.Text = string.Concat("Formulario de Envios Automaticos (versión:", lVersion, ")");


            lDts = lPx.ObtenerParametro("EnviosAutomaticos");

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblEnvios = lDts.Tables[0].Copy();

                mTblEnvios.Columns.Add("UltimoEnvio", Type.GetType("System.String"));

                for (i = 0; i < mTblEnvios.Rows.Count; i++)
                {
                    mTblEnvios.Rows[i]["UltimoEnvio"] = lN.ObtenerUltimoEnvio(mTblEnvios.Rows[i]["par3"].ToString());
                }

                Dtg_Envios.DataSource = mTblEnvios;

                Dtg_Envios.Columns["Id"].Visible = false;
                Dtg_Envios.Columns["subtabla"].Visible = false;
                Dtg_Envios.Columns["Descripcion"].Width = 300;
                Dtg_Envios.Columns["UltimoEnvio"].Width = 150;
                Dtg_Envios.Columns["Par1"].Width = 50;
                Dtg_Envios.Columns["Par2"].Width = 50;
                Dtg_Envios.Columns["Vermantenedor"].Visible = false;
                Dtg_Envios.Columns["Par3"].Visible = false;
            }
            mGenerandoArchivo = false;
            ProcesaEnvios();
        }

 

        private void EnviosAutomaticos_Load(object sender, EventArgs e)
        {
            CargaEnvios();

        }


        private void EnviarArhivo(string iCod, string iDia, string iHora)
        {

        switch (iCod )
            {
                case "e_PL": //Todos los días 
                    //mGenerandoArchivo = true;
                    //ProcesaEnvioPL(iDia, iHora, "682", "220");
                    //mGenerandoArchivo = false;
                    //mGenerandoArchivo = true;
                    //ProcesaEnvioPL(iDia, iHora, "807", "600");
                    //mGenerandoArchivo = false;
                    break;

                case "BOM": //Todos los días 
                    //mGenerandoArchivo = true;
                    //ProcesaEnvioBOM(iDia, iHora, "682", "220");
                    //mGenerandoArchivo = false;
                    //mGenerandoArchivo = true;
                    //ProcesaEnvioBOM(iDia, iHora, "807", "600");
                    //mGenerandoArchivo = false;

                    break;
                case "LC": //Todos los días 
                    //Enviar_ILC
                    break;

                case "PR_TOSOL": //Todos los días 
                    //mGenerandoArchivo = true;
                    //ProcesaEnvio_ProduccionTOSOL(iDia, iHora);
                    //mGenerandoArchivo = false;
                    //break;

                case "BL_LC": //Todos los días 

                    mGenerandoArchivo = true;
                    ProcesaRevisionBloqueos_LC(iDia, iHora);
                    mGenerandoArchivo = false;
                    break;
                case "Guias_IC": //Todos los días  Revision de las guias INET Cubigest
                    mGenerandoArchivo = true;
                    ProcesaRevisionGuias(iDia, iHora); 
                    mGenerandoArchivo = false;
                    break;

                case "Cierre_Maq": //Todos los días  Revision de las guias INET Cubigest
                    //mGenerandoArchivo = true;
                    //ProcesaCierreTotems(iDia, iHora);
                    //mGenerandoArchivo = false;
                    break;

                case "Doc_Cal": //Las certificaciones  que esten OK, se enviaran a clientes, que consta de:
                    //Certificado de Fabricacion y  certificado de trazabilidad.
                    //mGenerandoArchivo = true;
                    //Envia_DocumentosCalidad( );
                    //mGenerandoArchivo = false;
                    break;
                case "Guias_Scan": //Todos los días  Revision de las guias INET Cubigest
                    ProcesaRevisionGuias_Escaneadas(iDia, iHora);
                    break;

                case "PT": //Todos los días cada una hora se procesa el producto Terminado
                    // Abrimos Formulario 
                    mGenerandoArchivo = true;
                    ProcesaPT(iDia, iHora);
                    mGenerandoArchivo = false;
                    break;
                //case "BOM_5": //Todos los días 
                //    mGenerandoArchivo = true;
                //    ProcesaEnvioBOM_5(iDia, iHora);
                //    mGenerandoArchivo = false;
                //    break;
            //    default:
            //        mGenerandoArchivo = true;
            //        ProcesaPT(iDia, iHora);
            //        mGenerandoArchivo = false;
            //        break;
            }

        }

        private void ProcesaEnvios()
        {
            int i = 0;string lCod = "";

            for (i = 0; i < Dtg_Envios.Rows.Count; i++)
            {
                lCod = Dtg_Envios.Rows[i].Cells["Par3"].Value.ToString();
                EnviarArhivo(lCod,Dtg_Envios.Rows[i].Cells["Par1"].Value.ToString(), Dtg_Envios.Rows[i].Cells["Par2"].Value.ToString());
                PintaFila(i, Color.LightGreen);
            }
            //CargaEnvios();

        }

        private void PintaFila(int iFila, Color iColor)
        {
            int i = 0;
            for (i=0;i< Dtg_Envios.ColumnCount ;i++)
            {
                Dtg_Envios.Rows[iFila].Cells[i].Style.BackColor = iColor;
            }
        }

        private void Tm_Envios_Tick(object sender, EventArgs e)
        {

            if (mGenerandoArchivo==false )
            {
                ProcesaEnvios();
                //CargaEnvios();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //mGenerandoArchivo = true;
            //ProcesaEnvioBOM_inmediato("", "", "682", "220");
            ////ProcesaEnvioBOM("", "", "807", "600");

            //mGenerandoArchivo = false;

            EnviaMail_Lotes_NO_Encontrados();

        }

        private void Btn_CorrigePreIT_Click(object sender, EventArgs e)
        {
            CorrigePreIT();
        }


        private void CorrigePreIT()
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lIdMov = "0"; string lIdPieza = "0";  string lKgsOK = "0";
         

            lSql = String.Concat("  select p.TotalKgs KgsOK , p1.TotalKgs Kgs_Err, IdMov , p1.id idPieza , p.id IdPiezaTipoB ,  ");
            lSql = String.Concat(lSql, "  (Select count(1) from DetallePaquetesPieza d where d.IdPieza=p1.id ) ");
            lSql = String.Concat(lSql, "  from  PiezasTipoB p, hojadespiece hd  , piezas  p1  where hd.id=p.id_hd ");
            lSql = String.Concat(lSql, " and hd.idobra=940 and  p1.IdPiezaTipoB =p.id     ");
            lSql = String.Concat(lSql, " and (Select count(1) from DetallePaquetesPieza d where d.IdPieza=p1.id )=1  and p.TotalKgs<>p1.TotalKgs  ");
    
            try
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    if ((lTbl.Rows.Count > 0))
                    {
                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            lIdMov = lTbl.Rows[i]["IdMov"].ToString();
                            lIdPieza = lTbl.Rows[i]["idPieza"].ToString();
                            lKgsOK = lTbl.Rows[i]["KgsOK"].ToString();

                            lSql = String.Concat("update movimientos set pesoasignado=", lKgsOK," where id=",lIdMov );
                            lDts = lPx.ObtenerDatos(lSql);
                            lSql = String.Concat("update piezas set  totalKgs=", lKgsOK, " where id=", lIdPieza);
                            lDts = lPx.ObtenerDatos(lSql);
                            lSql = String.Concat(" update  detallepaquetespieza set kgspaquete=", lKgsOK, " where idpieza=", lIdPieza);
                            lDts = lPx.ObtenerDatos(lSql);

                        }
                           


                       
                    }
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void Btn_Prueba_Click(object sender, EventArgs e)
        {
            WS_ClientesWeb.WS_WebClientesSoapClient lWeb = new WS_ClientesWeb.WS_WebClientesSoapClient();
            DataSet lDts = new DataSet();
            lDts = lWeb.ObtenerObras();



        }
    }
}
