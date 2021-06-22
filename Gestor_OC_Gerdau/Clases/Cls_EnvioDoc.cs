using Gestor_OC_Gerdau.Calidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_OC_Gerdau.Clases
{
    public class Cls_EnvioDoc
    {

        public string GrabarEnvioArchivo(string iArchivo, string iPathArchivo)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); string  lRes = "";

            lSql = String.Concat(" SP_CRUD_ENVIO_DOCUMENTOS  0, '','", iArchivo, "','", iPathArchivo,"','','','',1");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //lTbl = lDts.Tables[0].Copy();
                //if (lTbl.Rows.Count > 0)
                //{
                //    if (lTbl.Rows[0][0].ToString().ToUpper().Equals("N"))
                //        lRes = false;
                //    else
                //        lRes = true;
                //}

            }

            return  lRes;
        }


        public Boolean ArchivoFueEnviado(string iArchivo)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Boolean lRes = false;
            string lFechaIni = string.Concat (DateTime .Now .ToShortDateString() , " 00:00:01" ) ;
            string lfechaFin = string.Concat(DateTime.Now.ToShortDateString(), " 23:59:59");
              lSql = String.Concat(" SP_CRUD_ENVIO_DOCUMENTOS  0, '','", iArchivo,"','','", lFechaIni,"','", lfechaFin,"','',2");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    if (lTbl.Rows[0][0].ToString().ToUpper().Equals("N"))
                        lRes = false;
                    else
                        lRes = true;
                }

             
            }

            return lRes;
        }



        public string  ObtenerUltimoEnvio(string iCodArchivo)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lRes = "";
          
            lSql = String.Concat(" SP_CRUD_ENVIO_DOCUMENTOS  0, '','%", iCodArchivo, "%','',' ',' ','',3");

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    
                        lRes = lTbl.Rows[0]["FechaEnvio"].ToString();
                }


            }

            return lRes;
        }


        public int Val(string iNro)
        {
            int lRes = 0;
            try
            {
                lRes = int.Parse(iNro);
            }

            catch (Exception iEx)
            {
                lRes = 0;
            }

            return lRes;
        }

        private Boolean CopiarDocumentosIdiem(string iViaje, string iPathColadas, string ipathDestino, string iLote)
        {
            Boolean lRes = true; string lPathSigla = ""; string lPathDest = "";
            string[] separators = { "-" }; string lArchivoTmp = "";
            string[] lPartes = iViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                lPathSigla = lPartes[0].ToString();
                lPathDest = Path.Combine(ipathDestino, lPathSigla);
                if (Directory.Exists(lPathDest) == false)
                {
                    Directory.CreateDirectory(lPathDest);
                }

                lPathDest = Path.Combine(ipathDestino, lPathSigla, iViaje.Replace("/", "_"));
                if (Directory.Exists(lPathDest) == false)
                {
                    Directory.CreateDirectory(lPathDest);
                }
                // Ahora que esta creado el directorio, se copia el Archivo
                // Verificamos que exista en Origen 
                lArchivoTmp = string.Concat(iLote, "_I.pdf");
                lPathSigla = Path.Combine(iPathColadas, lArchivoTmp);

                if (File.Exists(lPathSigla) == true)
                {
                    File.Copy(lPathSigla, Path.Combine(lPathDest, lArchivoTmp), true);
                }

                lArchivoTmp = string.Concat(iLote, "_C.pdf");
                lPathSigla = Path.Combine(iPathColadas, lArchivoTmp);
                if (File.Exists(lPathSigla) == true)
                {
                    File.Copy(lPathSigla, Path.Combine(lPathDest, lArchivoTmp), true);
                }
            }
            catch (Exception iEx)
            {
                lRes = false;
            }

            return lRes;
        }

        private Boolean CopiarDocumentosIdiem_CAP(string iViaje, string iPathColadas, string ipathDestino, string iLote)
        {
            Boolean lRes = true; string lPathSigla = ""; string lPathDest = ""; int i = 0;string lArchFinal = "";
            string[] separators = { "-" }; string lArchivoTmp = "";string lInforme = ""; string lCertificado = "";
            string[] lPartes = iViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                lPathSigla = lPartes[0].ToString();
                lPathDest = Path.Combine(ipathDestino, lPathSigla);
                if (Directory.Exists(lPathDest) == false)
                {
                    Directory.CreateDirectory(lPathDest);
                }

                lPathDest = Path.Combine(ipathDestino, lPathSigla, iViaje.Replace("/", "_"));
                if (Directory.Exists(lPathDest) == false)
                {
                    Directory.CreateDirectory(lPathDest);
                }
                //**************************
                string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
                DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

                lSql = String.Concat("    select * from certificadoscoladasCap where lote='", iLote,"'  ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    if (lTbl.Rows.Count > 1)
                    {
                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            if (lTbl.Rows[i]["TipoDocumento"].ToString().ToUpper().Equals("INFORME"))
                            {
                                lArchFinal = string.Concat(iLote, "_", lTbl.Rows[i]["IdDocumento"].ToString(), "_I.pdf");
                                lInforme = string.Concat(iPathColadas,  lArchFinal);
                            }
                            else
                            {
                                lArchFinal = string.Concat(iLote, "_", lTbl.Rows[i]["IdDocumento"].ToString(), "_C.pdf");
                                lCertificado = string.Concat(iPathColadas,   lArchFinal);
                            }
                                

                            if (lInforme.Trim().Length > 0)
                            {
                                if (File.Exists(lInforme) == true)
                                {
                                    File.Copy(lInforme, Path.Combine(lPathDest, lArchFinal), true);
                                    lInforme = "";
                                }
                            }

                            if (lCertificado.Trim().Length > 0)
                            {
                                if (File.Exists(lCertificado) == true)
                                {
                                    File.Copy(lCertificado, Path.Combine(lPathDest, lArchFinal), true);
                                    lCertificado = "";
                                }
                            }

                        }

                    }
                }            
            }
            catch (Exception iEx)
            {
                lRes = false;
            }

            return lRes;
        }
        public  Boolean EsLoteAza(string iLote)
        {
            Boolean lRes = true; string lTmp = "";

            if (iLote.Trim().Length<9)  // si el lote es 5 caracteres 
                lRes = false;

            lTmp = string.Concat("00000", iLote);
            if (iLote.Equals(lTmp))  // si el lote del tipo 0000054321
                lRes = false;


            return lRes;
        }

        private DataTable ObtenerTablaConLotes(string iViaje)
        {
            DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable(); WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            //1.- Por viaje Obtener Certificado e Informe
            lSql = "  select distinct    Lote ,   s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s  , EtiquetasVinculadas e , EtiquetaAZA ea   ";
            lSql = string.Concat(lSql, "   where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id    and e.IdQR =ea.id and e.IdEtiquetaTO =d.id ");
            lSql = string.Concat(lSql, " and  v.codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
            }
            else
            {
                lSql = "  select distinct    ( select lote   from   CertificadosPaquete c where d.Id =c.IdPaquete  ) Lote ,  ";
                lSql = string.Concat(lSql, " s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s   ");
                lSql = string.Concat(lSql, "    where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id   ");
                lSql = string.Concat(lSql, " and  codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                }
            }


                return lTbl;
        }


        public  void GeneraDocumentacionEnCarpeta(string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathColadas = ""; string lPathDestino = ""; string lSuc = ""; string lPathCalidad = "";

            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
            ////1.- Por viaje Obtener Certificado e Informe
            //lSql = "  select distinct    Lote ,   s.nombre sucursal   from viaje v, DetallePaquetesPieza d   , it , sucursal s  , EtiquetasVinculadas e , EtiquetaAZA ea   ";
            //lSql = string.Concat(lSql, "   where  v.id =d.IdViaje and  v.idit=it.id and it.idsucursal=s.id    and e.IdQR =ea.id and e.IdEtiquetaTO =d.id ");
            //lSql = string.Concat(lSql, " and  v.codigo='", iViaje, "'");
            //lDts = lPx.ObtenerDatos(lSql);


            //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            //{
            // lTbl = lDts.Tables[0].Copy();  // tabla con los lotes del viaje 
            lTbl = ObtenerTablaConLotes(iViaje);
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    // hay que buscar las coladas en el repositorio y copiarlas al destino
                    if (lTbl.Rows[i]["Lote"].ToString().Trim().Length > 0)
                    {
                        if (EsLoteAza(lTbl.Rows[i]["Lote"].ToString())==true )
                        { 
                            lSuc = string.Concat(lTbl.Rows[i]["Sucursal"].ToString(), "\\");
                            lPathColadas = @"C:\TMP\Calidad\Docs\";

                            lPathDestino = Path.Combine(lPathCalidad, lSuc);
                            //lPathDestino = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc);
                            CopiarDocumentosIdiem(iViaje, lPathColadas, lPathDestino, lTbl.Rows[i]["Lote"].ToString());
                        }
                        else
                        {
                            lSuc = string.Concat(lTbl.Rows[i]["Sucursal"].ToString(), "\\");
                            lPathColadas = @"C:\TMP\Calidad\Docs\CAP\";
                            lPathDestino = Path.Combine(lPathCalidad, lSuc);
                            //lPathDestino = Path.Combine(@"\\200.29.219.22\Gestion de Calidad\GeneracionDocumentosAutomatico\", lSuc);
                            CopiarDocumentosIdiem_CAP(iViaje, lPathColadas, lPathDestino, lTbl.Rows[i]["Lote"].ToString());

                        }

                    }
                    else
                    {
                        lSql = string.Concat(" Update viaje set CertificadosOK='P' where codigo='", iViaje, "'");
                        lDts = lPx.ObtenerDatos(lSql);
                    }
                //}
                }
            //2.- Resumen de trazabilidad
            if (iViaje.IndexOf("TCC") > -1)
                ImprimeResumenTrazabilidad_V2(lPathDestino, iViaje);
            else
                ImprimeResumenTrazabilidad(lPathDestino, iViaje);


            //3.- Certificado de Fabricación
            // Obtenemos los datos  para la realización del certificado de fabricacion
            lSql = "   select  o.id , o.nombre , o.cliente , NroGuiaInet,   ";
            lSql = string.Concat(lSql, "     (Select round(sum(d.kgsPaquete),0) from DetallePaquetesPieza d where d.IdViaje =v.id ) Kgs    ");
            lSql = string.Concat(lSql, "  from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                ImprimeCertificadoManofactura(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);

                lSql = string.Concat(" Update viaje set CarpetaOK='S' where codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
            }
        }

        public  string Obtener_ProcedenciasPorViaje(string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0; string lRes = "";
            DataSet lDts = new DataSet(); string lSql = "";
            lSql = string.Concat("EXEC SP_Consultas_ActaEntrega 7,'", iViaje, "','','','','','',''");

            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                {
                    lRes = string.Concat(lRes, lDts.Tables[0].Rows[i]["Procedencia"].ToString(), "-");
                }

                if (lRes.ToString().Length > 0)
                    lRes = lRes.Substring(0, lRes.Length - 1);

            }
            return lRes;
        }


        public  string Obtener_NroColadasPorDiametro(string iViaje, string iDiam)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0; string lRes = "";
            DataSet lDts = new DataSet(); string lSql = ""; string lTmp = "";

            lSql = string.Concat("EXEC SP_Consultas_ActaEntrega 6,'", iViaje, "','", iDiam, "','','','','',''");

            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                {
                    if (lTmp.IndexOf(lDts.Tables[0].Rows[i]["NroColada"].ToString() ) < 0)
                    {
                        lRes = string.Concat(lRes, lDts.Tables[0].Rows[i]["NroColada"].ToString(), "-");
                        lTmp= string.Concat(lTmp , lDts.Tables[0].Rows[i]["NroColada"].ToString(), " - ");
                    }
                }

                if (lRes.ToString().Length > 0)
                    lRes = lRes.Substring(0, lRes.Length - 1);



            }
            return lRes;
        }

        public  void ImprimeCertificadoManofactura(string iviaje, string IdObra, string iNombreObra, string iKilos, string iNroGuiaINET, string iConstructora, string iPathDestino)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; string lRes = "";
            Frm_Visualizador frmVisualiza = new Frm_Visualizador(); string lTmp = "";
            Dts_Informes.CertificadoManDataTable lTbl = new Dts_Informes.CertificadoManDataTable();
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            Dts_Informes.Cabecera_CertManDataTable lTblCap = new Dts_Informes.Cabecera_CertManDataTable();
            DataSet lDtsTablas = new DataSet();

            lDtsTablas = lPx.ObtenerDiametrosPorViaje(iviaje);
            if (lDtsTablas.Tables.Count > 0)
            {
                for (i = 0; i < lDtsTablas.Tables[0].Rows.Count; i++)
                {
                    lFila = dtsPl.CertificadoMan.NewCertificadoManRow();
                    lFila["Nro"] = i + 1;
                    lFila["Viaje"] = iviaje;
                    lFila["Diametro"] = lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString();
                    lFila["Kilos"] = lDtsTablas.Tables[0].Rows[i]["KilosDesp"].ToString();
                    lFila["Colada"] = Obtener_NroColadasPorDiametro(iviaje, lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString());
                    //'lFila("Colada") = "" 'lDtsTablas.Tables(0).Rows(i)("Colada")
                    dtsPl.CertificadoMan.Rows.Add(lFila);
                }

                lFila = dtsPl.Cabecera_CertMan.NewCabecera_CertManRow();
                lFila["Viaje"] = iviaje;
                lFila["NroPedido"] = string.Concat(iviaje, " Nº GD.", iNroGuiaINET);
                lFila["Peso"] = iKilos; // ' & "Kgs."
                lFila["NombreObra"] = iNombreObra;
                lFila["IdObra"] = IdObra.ToString();
                lFila["Procedencia"] = Obtener_ProcedenciasPorViaje(iviaje);
                lFila["NombreConstructora"] = iConstructora;
                dtsPl.Cabecera_CertMan.Rows.Add(lFila);

                frmVisualiza = new Frm_Visualizador();
                frmVisualiza.InicializaInforme("", dtsPl, iviaje, true);
                frmVisualiza.VerInforme();
                frmVisualiza.GeneraPdf_CertificadoFabricacion(iPathDestino, iviaje);
                //frmVisualiza.ShowDialog ();
                frmVisualiza.Close();
                frmVisualiza.Dispose();


            }
        }

        public string  ExisteArchivoEnServer(string iLote, string iSuc, string iPathSigla, string iCodigo, string iIdColada, string iIdEtiquetaTO)
        {
            string  lRes = ""; EnviosAutomaticos lEnv = new EnviosAutomaticos();
            string lPathCalidad = ""; DataTable lTblLotes = new DataTable(); string lPathInfLote = "";
            string[] separators = { "-" }; string lPathCertLote = ""; DataSet lDts = new DataSet();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int i = 0;
            DataTable lTblColadas = new DataTable(); DataRow lFila = null;

            lEnv.mGenerandoArchivo = true;

            lTblColadas.Columns.Add("Colada", Type.GetType("System.String"));
            //VErificamos si tiene una o varias coladas asociadas
            if (iIdColada.Equals("-1"))
            {
                lSql = string.Concat(" select distinct Lote  from EtiquetasVinculadas v , EtiquetaAZA e where v.IdQR =e.id  and   IdEtiquetaTO =", iIdEtiquetaTO);
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblLotes = lDts.Tables[0].Copy();
                    for (i = 0; i < lTblLotes.Rows.Count; i++)
                    {
                        lFila = lTblColadas.NewRow(); lFila["Colada"] = lTblLotes.Rows[i]["Lote"].ToString(); lTblColadas.Rows.Add(lFila);
                    }
                }

            }
            else  //HAy solo una colada para la Etiqueta
            {
                lFila = lTblColadas.NewRow(); lFila["Colada"] = iLote; lTblColadas.Rows.Add(lFila);
            }

            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
            for (i = 0; i < lTblColadas.Rows.Count; i++)
            {

                if (lEnv.EsLoteAza(iLote) == true)
                {
                    lPathInfLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), string.Concat(lTblColadas.Rows[i]["Colada"].ToString(), "_I.pdf"));
                    lPathCertLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), string.Concat(lTblColadas.Rows[i]["Colada"].ToString(), "_C.pdf"));
                    if ((File.Exists(lPathInfLote) == true) && (File.Exists(lPathCertLote) == true))
                    {
                        lRes = "" ;
                    }
                    else
                    {
                        lRes = string.Concat("NO se encontro la Path: ", lPathInfLote, "   -  ", lPathCertLote);
                        i = lTblColadas.Rows.Count;
                    }
                }
                else
                {
                    DataView lVista = null; string lNomLoteInf = ""; string lNomLoteCert = ""; int lCont = 0;
                    lSql = string.Concat("  Select * from certificadosColadasCap where lote='", iLote, "' ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTblLotes = lDts.Tables[0].Copy();
                        lVista = new DataView(lTblLotes, "", "", DataViewRowState.CurrentRows);
                        if (lVista.Count > 0)
                        {
                            for (lCont = 0; lCont < lVista.Count; lCont++)
                            {
                               if (lVista[lCont]["TipoDocumento"].ToString().ToUpper().Equals("INFORME"))
                                    lNomLoteInf = string.Concat(iLote, "_", lVista[lCont]["IdDocumento"].ToString(), "_I.pdf");
                                else
                                    lNomLoteCert = string.Concat(iLote, "_", lVista[lCont]["IdDocumento"].ToString(), "_C.pdf");


                                if (lCont == 1)
                                    lCont = lVista.Count;

                            }
                        }
                    }
                    lPathInfLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), lNomLoteInf);
                    lPathCertLote = Path.Combine(lPathCalidad, iSuc, iPathSigla, iCodigo.Replace("/", "_"), lNomLoteCert);
                    if ((File.Exists(lPathInfLote) == true) && (File.Exists(lPathCertLote) == true))
                    {
                        lRes = "";
                    }
                    else
                    {
                        lRes = lRes = string.Concat("NO se encontro la Path: ", lPathInfLote, "   -  ", lPathCertLote); ;
                    }
                }
            }
            return lRes;
        }

        private void ImprimeResumenTrazabilidad(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; string lRes = "";
            Frm_Visualizador frmVisualiza = new Frm_Visualizador(); string lTmp = "";
            Dts_Informes.CabeceraTrazColadasDataTable lTblCab = new Dts_Informes.CabeceraTrazColadasDataTable();
            Dts_Informes.DetalleTrazColadasDataTable lTblDet = new Dts_Informes.DetalleTrazColadasDataTable();
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            Dts_Informes.Cabecera_CertManDataTable lTblCap = new Dts_Informes.Cabecera_CertManDataTable();
            DataSet lDtsTablas = new DataSet(); DataTable lTblViajes = new DataTable(); DataSet lDtsViajes = new DataSet();
            DataRow lRow = null; DataSet lDtsDatos = new DataSet(); DataSet lDtsTmp = new DataSet();
            Dts_Informes.DetalleTrazColadasRow lFilaDet = null; string lEtiqueta = "";

            lTblViajes.Columns.Add("Viaje", Type.GetType("System.String"));
            lTblViajes.Clear();
            lDtsViajes.Tables.Clear();
            lRow = lTblViajes.NewRow();
            lRow["Viaje"] = iviaje;

            lTblViajes.Rows.Add(lRow);
            lDtsViajes.Tables.Add(lTblViajes);
            lDtsDatos = lPx.ObtenerTrazabilidadColadas(lDtsViajes);
            if (lDtsDatos.Tables.Count > 0)
            {
                //'   Carga Tabla Cabecera Informe
                if (lDtsDatos.Tables.Count > 1)
                {
                    lTblTmp = lDtsDatos.Tables["Informe"].Copy();
                    lFila = lTblCab.NewCabeceraTrazColadasRow();
                    lFila["CodigoInf"] = lTblTmp.Rows[0]["Codigo"].ToString();
                    lFila["RevisionInf"] = lTblTmp.Rows[0]["Ver"].ToString();
                    lFila["FechaRev_Inf"] = lTblTmp.Rows[0]["Fecha"].ToString();
                    lTblCab.Rows.Add(lFila);
                    lDts.Merge(lTblCab);

                    //   '   Carga Tabla Detalle Informe
                    //lTblTmp = New DataTable();
                    lTblTmp = lDtsDatos.Tables["Detalle"].Copy();
                    for (i = 0; i < lTblTmp.Rows.Count; i++)
                    {
                        lFilaDet = lTblDet.NewDetalleTrazColadasRow();
                        lFilaDet["Obra"] = lTblTmp.Rows[i]["Nombre"].ToString();
                        lFilaDet["Viaje"] = lTblTmp.Rows[i]["Codigo"].ToString();
                        lFilaDet["FechaCreacion"] = lTblTmp.Rows[i]["FechaCreacion"].ToString();
                        lFilaDet["Colada"] = lTblTmp.Rows[i]["COLADA"].ToString();
                        lFilaDet["NroCertificado"] = lTblTmp.Rows[i]["NroCertificado"].ToString();
                        lFilaDet["Kgs"] = lTblTmp.Rows[i]["CantidadKgs"].ToString();
                        lFilaDet["Procedencia"] = lTblTmp.Rows[i]["Procedencia"].ToString();
                        lFilaDet["Diametro"] = lTblTmp.Rows[i]["Diametro"].ToString();
                        lEtiqueta = lTblTmp.Rows[i]["NroEtiqueta"].ToString().Replace(" Tag #:  ", "");
                        lEtiqueta = lEtiqueta.Replace(" of ", "-");
                        lFilaDet["Etiqueta"] = lEtiqueta;
                        lFilaDet["IdDetallePieza"] = lTblTmp.Rows[i]["IdDetallePieza"].ToString();
                        lTblDet.Rows.Add(lFilaDet);
                    }

                    lDts.Merge(lTblDet);

                    //' Imprimimos y visualizamos
                    Frm_Visualizador lFrmInf = new Frm_Visualizador();
                    lFrmInf.InicializaInforme("TC", lDts, "", false);
                    lFrmInf.VerInforme();
                    lFrmInf.GeneraPdf_TrazabilidadColadas(iPathDestino, iviaje,"TC");
                    lFrmInf.Close();
                    lFrmInf.Dispose();
                }
            }

        }


        public  void ImprimeResumenTrazabilidad_V2(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; string lRes = "";
            Frm_Visualizador frmVisualiza = new Frm_Visualizador(); string lTmp = "";
            Dts_Informes.CabeceraTrazColadasDataTable lTblCab = new Dts_Informes.CabeceraTrazColadasDataTable();
            Dts_Informes.DetalleTrazColadasDataTable lTblDet = new Dts_Informes.DetalleTrazColadasDataTable();
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            Dts_Informes.Cabecera_CertManDataTable lTblCap = new Dts_Informes.Cabecera_CertManDataTable();
            DataSet lDtsTablas = new DataSet(); DataTable lTblViajes = new DataTable(); DataSet lDtsViajes = new DataSet();
            DataRow lRow = null; DataSet lDtsDatos = new DataSet(); DataSet lDtsTmp = new DataSet();
            Dts_Informes.DetalleTrazColadasRow lFilaDet = null; string lEtiqueta = "";

            lTblViajes.Columns.Add("Viaje", Type.GetType("System.String"));
            lTblViajes.Clear();
            lDtsViajes.Tables.Clear();
            lRow = lTblViajes.NewRow();
            lRow["Viaje"] = iviaje;

            lTblViajes.Rows.Add(lRow);
            lDtsViajes.Tables.Add(lTblViajes);
            lDtsDatos = lPx.ObtenerTrazabilidadColadas(lDtsViajes);
            if (lDtsDatos.Tables.Count > 0)
            {
                //'   Carga Tabla Cabecera Informe
                if (lDtsDatos.Tables.Count > 1)
                {
                    lTblTmp = lDtsDatos.Tables["Informe"].Copy();
                    lFila = lTblCab.NewCabeceraTrazColadasRow();
                    lFila["CodigoInf"] = lTblTmp.Rows[0]["Codigo"].ToString();
                    lFila["RevisionInf"] = lTblTmp.Rows[0]["Ver"].ToString();
                    lFila["FechaRev_Inf"] = lTblTmp.Rows[0]["Fecha"].ToString();
                    lTblCab.Rows.Add(lFila);
                    lDts.Merge(lTblCab);

                    //   '   Carga Tabla Detalle Informe
                    //lTblTmp = New DataTable();
                    lTblTmp = lDtsDatos.Tables["Detalle"].Copy();
                    for (i = 0; i < lTblTmp.Rows.Count; i++)
                    {
                        lFilaDet = lTblDet.NewDetalleTrazColadasRow();
                        lFilaDet["Obra"] = lTblTmp.Rows[i]["Nombre"].ToString();
                        lFilaDet["Viaje"] = lTblTmp.Rows[i]["Codigo"].ToString();
                        lFilaDet["FechaCreacion"] = lTblTmp.Rows[i]["FechaCreacion"].ToString();
                        lFilaDet["Colada"] = lTblTmp.Rows[i]["COLADA"].ToString();
                        lFilaDet["NroCertificado"] = lTblTmp.Rows[i]["NroCertificado"].ToString();
                        lFilaDet["Kgs"] = lTblTmp.Rows[i]["CantidadKgs"].ToString();
                        lFilaDet["Procedencia"] = lTblTmp.Rows[i]["Procedencia"].ToString();
                        lFilaDet["Diametro"] = lTblTmp.Rows[i]["Diametro"].ToString();
                        lEtiqueta = lTblTmp.Rows[i]["NroEtiqueta"].ToString().Replace(" Tag #:  ", "");
                        lEtiqueta = lEtiqueta.Replace(" of ", "-");
                        lFilaDet["Etiqueta"] = lEtiqueta;
                        lFilaDet["IdDetallePieza"] = lTblTmp.Rows[i]["IdDetallePieza"].ToString();
                        lFilaDet["Sector"] = lTblTmp.Rows[i]["Sector"].ToString();
                        lFilaDet["Referencia"] = lTblTmp.Rows[i]["Referencia"].ToString();
                        lTblDet.Rows.Add(lFilaDet);
                    }

                    lDts.Merge(lTblDet);

                    //' Imprimimos y visualizamos
                    Frm_Visualizador lFrmInf = new Frm_Visualizador();
                    lFrmInf.InicializaInforme("TC2", lDts, "", false);
                    lFrmInf.VerInforme();
                    lFrmInf.GeneraPdf_TrazabilidadColadas(iPathDestino, iviaje,"TC2");
                    lFrmInf.Close();
                    lFrmInf.Dispose();
                }
            }

        }


    }
}
