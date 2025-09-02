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

        public Boolean CreacionPT_Procesado(string iArchivo)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); Boolean lRes = false;
            string lFechaIni = string.Concat(DateTime.Now.ToShortDateString(), " 00:00:01");
            string lfechaFin = string.Concat(DateTime.Now.ToShortDateString(), " 23:59:59");
            lSql = String.Concat(" SP_CRUD_ENVIO_DOCUMENTOS  0, '','Creacion_PT','','','','',4");
            Clases.Cls_Comun lCom = new Cls_Comun(); 

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    if (lCom.Val_INT64 (lTbl.Rows[0]["Dif"].ToString ())>60)
                         lRes = false;
                    else
                        lRes = true ;
                }    
                    else
                        lRes = true;
                

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

            if (iLote.Trim().Length<7)  // si el lote es 5 caracteres 
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
        private DataTable ObtenerTablaConLotes_TOSOL(string iViaje)
        {
       
                DataSet lDts = new DataSet(); DataTable lTblPaquetes = new DataTable(); int i = 0; DataTable lTblPaquetesTmp = new DataTable();
                DataTable lTbl = new DataTable(); WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = ""; int j = 0;
            DataTable lTblFinal = new DataTable(); DataRow lFila = null;int k = 0;string lLotesProcesados = ""; string lsucursal = "";

            lTblFinal.Columns.Add ("Lote");
            lTblFinal.Columns.Add("Sucursal");
            lSql = string.Concat("  select  s.nombre as Sucursal from viaje v , it , sucursal S where v.idit=it.id and it.idSucursal=s.Id and v.codigo='",iViaje ,"'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lsucursal = lDts.Tables[0].Rows[0][0].ToString();
                //1.- Obtenemos el detalle por Etiqueta
                lSql = string.Concat("  select  d.id  , (Select  count(1)  from  EtiquetasVinculadas where IdEtiquetaTO =d.id   ) 'TOSOL',  ");
                lSql = string.Concat(lSql, " (Select  count(1)  from  EtiquetasVinculadasTOSOL  where IdEtiquetaTOSOL =d.id   ) 'TO' ");
                lSql = string.Concat(lSql, "  from viaje v, DetallePaquetesPieza d     where  v.id =d.IdViaje  and  v.codigo='", iViaje, "'");

                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTblPaquetes = lDts.Tables[0].Copy();
                    //2.- Por cada etiqueta, Quie lo Fabrico el paquete  TOSOL ó TO 
                    for (i = 0; i < lTblPaquetes.Rows.Count; i++)
                    {
                        if (lTblPaquetes.Rows[i]["TOSOL"].ToString().ToUpper().Equals("0")) // lo Fabrico TORRES
                        {
                            lSql = string.Concat("  select *  from EtiquetasVinculadasTOSOL  where IdEtiquetaTOSOL =", lTblPaquetes.Rows[i]["Id"].ToString());
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTblPaquetesTmp = lDts.Tables[0].Copy();
                                for (j = 0; j < lTblPaquetesTmp.Rows.Count; j++)
                                {
                                    lSql = string.Concat("   select  e.lote from  EtiquetasVinculadas , etiquetaaza e  where e.id = idqr and IdEtiquetaTO=", lTblPaquetesTmp.Rows[j]["IdEtiquetaTO"].ToString());
                                    lDts = lPx.ObtenerDatos(lSql);
                                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                                        for (k = 0; k < lDts.Tables[0].Rows.Count; k++)
                                        {
                                            if (lLotesProcesados.IndexOf(lDts.Tables[0].Rows[k]["Lote"].ToString()) == -1)
                                            {
                                                lFila = lTblFinal.NewRow();
                                                lFila["Lote"] = lDts.Tables[0].Rows[k]["Lote"].ToString();
                                                lFila["Sucursal"] = lsucursal;
                                                lTblFinal.Rows.Add(lFila);
                                                lLotesProcesados = string.Concat(lLotesProcesados, " - ", lDts.Tables[0].Rows[k]["Lote"].ToString());
                                            }
                                        }
                                }
                            }
                        }
                        if (lTblPaquetes.Rows[i]["TO"].ToString().ToUpper().Equals("0")) // lo Fabrico TOSOL
                        {
                            lSql = string.Concat("   select  e.lote from  EtiquetasVinculadas , etiquetaaza e  where e.id = idqr and IdEtiquetaTO=", lTblPaquetes.Rows[i]["Id"].ToString());
                            lDts = lPx.ObtenerDatos(lSql);
                            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                            {
                                lTblPaquetesTmp = lDts.Tables[0].Copy();
                                for (j = 0; j < lTblPaquetesTmp.Rows.Count; j++)
                                {
                                    if (lLotesProcesados.IndexOf(lDts.Tables[0].Rows[j]["Lote"].ToString()) == -1)
                                    {
                                        lFila = lTblFinal.NewRow();
                                        lFila["Lote"] = lDts.Tables[0].Rows[j]["Lote"].ToString();
                                        lFila["Sucursal"] = lsucursal;
                                        lTblFinal.Rows.Add(lFila);
                                        lLotesProcesados = string.Concat(lLotesProcesados, " - ", lDts.Tables[0].Rows[j]["Lote"].ToString());
                                    }
                                }
                            }
                        }
                    }

                }
                }
                return lTblFinal;
            }


       
        public void Reprocesa_CertificadoManofacturacionTOSOL(string iViaje, string lPathDestino)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            //3.- Certificado de Fabricación
            // Obtenemos los datos  para la realización del certificado de fabricacion
            lSql = "   select  o.id , o.nombre , o.cliente , NroGuiaInet,   ";
            lSql = string.Concat(lSql, "     (Select round(sum(d.kgsPaquete),0) from DetallePaquetesPieza d where d.IdViaje =v.id ) Kgs    ");
            lSql = string.Concat(lSql, "  from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows .Count >0)
                    ImprimeCertificadoManofactura_TOSOL(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);


                lSql = string.Concat(" Update viaje set CarpetaOK='S' where codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
            }
        }

        public  void GeneraDocumentacionEnCarpeta(string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathColadas = ""; string lPathDestino = ""; string lSuc = ""; string lPathCalidad = "";

            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
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
            {
                if (lSuc.ToUpper().IndexOf ("TOSOL")==-1)
                    ImprimeResumenTrazabilidad(lPathDestino, iViaje);
                else
                    ImprimeResumenTrazabilidad_TOSOL(lPathDestino, iViaje);
            }
                
            

            //3.- Certificado de Fabricación
            // Obtenemos los datos  para la realización del certificado de fabricacion
            lSql = "   select  o.id , o.nombre , o.cliente , NroGuiaInet,   ";
            lSql = string.Concat(lSql, "     (Select round(sum(d.kgsPaquete),0) from DetallePaquetesPieza d where d.IdViaje =v.id ) Kgs    ");
            lSql = string.Concat(lSql, "  from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if(lSuc.ToUpper().IndexOf("TOSOL") == -1)
                    ImprimeCertificadoManofactura(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);
                else
                    ImprimeCertificadoManofactura_TOSOL(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);


                lSql = string.Concat(" Update viaje set CarpetaOK='S' where codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
            }

            // si es de TOSOL se debe imprimir ImprimeAseguramientoPilote
            //Verificamos que la It Sea de TOSOL                       
            lSql = string.Concat(lSql, " select  Empresa    from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0) && (lDts.Tables[0].Rows[0][0].ToString ().ToUpper ().Equals ("TOSOL")))
            {
                ImprimeAseguramientoPilote(lPathDestino, iViaje);
                lSql = string.Concat(" Update viaje set mailcalidadenviado='S' where codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
            }


                
        }

        public void GeneraDocumentacionEnCarpeta_ReprocesoTosol(string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            string lPathColadas = ""; string lPathDestino = ""; string lSuc = ""; string lPathCalidad = "";

            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
            lTbl = ObtenerTablaConLotes_TOSOL(iViaje);
            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                // hay que buscar las coladas en el repositorio y copiarlas al destino
                if (lTbl.Rows[i]["Lote"].ToString().Trim().Length > 0)
                {
                    if (EsLoteAza(lTbl.Rows[i]["Lote"].ToString()) == true)
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
            {
                if (lSuc.ToUpper().IndexOf("TOSOL") == -1)
                    ImprimeResumenTrazabilidad(lPathDestino, iViaje);
                else
                    ImprimeResumenTrazabilidad_TOSOL(lPathDestino, iViaje);
            }



            //3.- Certificado de Fabricación
            // Obtenemos los datos  para la realización del certificado de fabricacion
            lSql = "   select  o.id , o.nombre , o.cliente , NroGuiaInet,   ";
            lSql = string.Concat(lSql, "     (Select round(sum(d.kgsPaquete),0) from DetallePaquetesPieza d where d.IdViaje =v.id ) Kgs    ");
            lSql = string.Concat(lSql, "  from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                if (lSuc.ToUpper().IndexOf("TOSOL") == -1)
                    ImprimeCertificadoManofactura(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);
                else
                    ImprimeCertificadoManofactura_TOSOL(iViaje, lTbl.Rows[0]["id"].ToString(), lTbl.Rows[0]["Nombre"].ToString(), lTbl.Rows[0]["Kgs"].ToString(), lTbl.Rows[0]["NroGuiaINET"].ToString(), lTbl.Rows[0]["Cliente"].ToString(), lPathDestino);


                lSql = string.Concat(" Update viaje set CarpetaOK='S' where codigo='", iViaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
            }

            // si es de TOSOL se debe imprimir ImprimeAseguramientoPilote
            //Verificamos que la It Sea de TOSOL                       
            lSql = string.Concat(lSql, " select  Empresa    from viaje v, it, Obras o   where v.idit=it.id and it.idobra=o.id and codigo='", iViaje, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0) && (lDts.Tables[0].Rows[0][0].ToString().ToUpper().Equals("TOSOL")))
            {
                ImprimeAseguramientoPilote(lPathDestino, iViaje);
            }



        }

        private string ObtenerExtensionarchivo(string iArchivo)
        {
            string lRes = "";
            string[] split = iArchivo.Split(new Char[] { '.' });

            if (split.Length > 1)
                lRes = split[1].ToString();

            return lRes;
        }
        public void GeneraDocumentacionExtra_EnCarpeta(string iViaje)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lSql = "";string lSuc;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();string lPathCalidad = "";
            string lNroGDE = ""; string lPathDestino = ""; string lPath_GDE = ""; string lPathDest = "";
            string lRes = ""; string lExtensionFile = ""; ; string lArchivo = "";string lPathOrigen = "";

            // generamos El PL de despacho
            lPathCalidad = ConfigurationManager.AppSettings["Path_Calidad"].ToString();
            lTbl = ObtenerTablaConLotes(iViaje);
            lSuc = string.Concat(lTbl.Rows[0]["Sucursal"].ToString(), "\\");
            lPathDestino = Path.Combine(lPathCalidad, lSuc);
                 EstadosdePagos.Utils lEP = new EstadosdePagos.Utils();
            string[] separators = { "-" };
            string[] lPartes = iViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries); string lPathSigla = "";
            lPathSigla = lPartes[0].ToString();
            lPathDestino = Path.Combine(lPathDestino, lPathSigla); //, iViaje.Replace("/", "_"));        
            lEP.CreaInforme_Autom(iViaje, true, lPathDestino);


            //Revisamos las GDE, si existe lo guardamos en el Directorio
            lPathDestino = string.Concat(lPathDestino,  "\\", iViaje.Replace("/", "_"), "\\");
            try
            {
                lSql = string.Concat("Select NroGuiaINET from viaje where codigo='", iViaje, "'");

                {
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lPath_GDE = @"T:\";
                        lNroGDE = lDts.Tables[0].Rows[0][0].ToString();
                        DirectoryInfo lFolder = new DirectoryInfo(lPath_GDE);
                        foreach (var fi in lFolder.GetFiles())
                        {
                            if ((fi.Name.ToString().IndexOf(lNroGDE) > -1) && (lRes != "OK"))
                            {
                                //*******************************************
                                try
                                {
                                    lExtensionFile = ObtenerExtensionarchivo(fi.Name);
                                    lArchivo = fi.Name.ToString(); // string.Concat(iNroGDE, ".", lExtensionFile);
                                    if (Directory.Exists(lPathDestino) == true)
                                    {
                                        lPathOrigen = Path.Combine(lPath_GDE, lArchivo);
                                        lPathDest = Path.Combine(lPathDestino, lArchivo);
                                        File.Copy(lPathOrigen, lPathDest, true);
                                        //lError = string.Concat("Finalizado, OK: ", lPathDest);
                                        lRes = "OK";
                                    }
                                }
                                catch (Exception iEx)
                                {
                                    //lError = string.Concat("Error: ", iEx.Message.ToString());
                                    //MessageBox.Show(lError);
                                }

                            }
                        }
                    }
                }
            }
             catch (Exception iEx)
            {

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

        public string Obtener_NroColadasPorDiametro_TOSOL(string iViaje, string iDiam)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i = 0; string lRes = ""; int j = 0;
            DataSet lDts = new DataSet(); string lSql = ""; string lTmp = "";DataTable lTbl = new DataTable();
            
            lSql = string.Concat("EXEC SP_Consultas_ActaEntrega 18,'", iViaje, "','", iDiam, "','','','','',''");

            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    if (lTbl.Rows[i]["Aza"].ToString() != "0")
                    {
                        lSql = string.Concat("EXEC SP_Consultas_ActaEntrega 6,'", iViaje, "','", iDiam, "','','','','',''");                        
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            for (j = 0; j < lDts.Tables[0].Rows.Count; j++)
                            {
                                if (lTmp.IndexOf(lDts.Tables[0].Rows[j]["NroColada"].ToString()) < 0)
                                {
                                    lRes = string.Concat(lRes, lDts.Tables[0].Rows[j]["NroColada"].ToString(), "-");
                                    lTmp = string.Concat(lTmp, lDts.Tables[0].Rows[j]["NroColada"].ToString(), " - ");
                                }
                            }                            
                        }
                    }
                    if (lTbl.Rows[i]["TO"].ToString() != "0")
                    {
                        lSql = string.Concat("EXEC SP_Consultas_ActaEntrega 19,'", lTbl.Rows[i]["IdPaquete"].ToString(), "','','','','','',''");
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            for (j = 0; j < lDts.Tables[0].Rows.Count; j++)
                            {
                                if (lTmp.IndexOf(lDts.Tables[0].Rows[j]["NroColada"].ToString()) < 0)
                                {
                                    lRes = string.Concat(lRes, lDts.Tables[0].Rows[j]["NroColada"].ToString(), "-");
                                    lTmp = string.Concat(lTmp, lDts.Tables[0].Rows[j]["NroColada"].ToString(), " - ");
                                }
                            }
                        }
                    }

                    //if (lTmp.IndexOf(lDts.Tables[0].Rows[i]["NroColada"].ToString()) < 0)
                    //{
                    //    lRes = string.Concat(lRes, lDts.Tables[0].Rows[i]["NroColada"].ToString(), "-");
                    //    lTmp = string.Concat(lTmp, lDts.Tables[0].Rows[i]["NroColada"].ToString(), " - ");
                    //}
                }

                if (lRes.ToString().Length > 0)
                    lRes = lRes.Substring(0, lRes.Length - 1);



            }
            return lRes;
        }



        public void ImprimeCertificadoManofactura(string iviaje, string IdObra, string iNombreObra, string iKilos, string iNroGuiaINET, string iConstructora, string iPathDestino)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; 
            Frm_Visualizador frmVisualiza = new Frm_Visualizador(); 
            Dts_Informes.CertificadoManDataTable lTbl = new Dts_Informes.CertificadoManDataTable();
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            Dts_Informes.Cabecera_CertManDataTable lTblCap = new Dts_Informes.Cabecera_CertManDataTable();
            DataSet lDtsTablas = new DataSet();

            string lSql = ""; string lEmpresa = "";

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
                lSql = string.Concat(" Select Empresa from  viaje v, it, obras o where v.idit=it.id and o.id=it.idObra and codigo='", iviaje, "'");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    lEmpresa = lDts.Tables[0].Rows[0][0].ToString();

                if (lEmpresa.ToUpper().Equals("TO"))
                    frmVisualiza.GeneraPdf_CertificadoFabricacion(iPathDestino, iviaje);

                if (lEmpresa.ToUpper().Equals("TOSOL"))
                    frmVisualiza.GeneraPdf_CertificadoFabricacion_TOSOL(iPathDestino, iviaje);

                //frmVisualiza.ShowDialog ();
                frmVisualiza.Close();
                frmVisualiza.Dispose();


            }
        }

        public void ImprimeCertificadoManofactura_TOSOL(string iviaje, string IdObra, string iNombreObra, string iKilos, string iNroGuiaINET, string iConstructora, string iPathDestino)
        {
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i;
            Frm_Visualizador frmVisualiza = new Frm_Visualizador();
            Dts_Informes.CertificadoManDataTable lTbl = new Dts_Informes.CertificadoManDataTable();
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            Dts_Informes.Cabecera_CertManDataTable lTblCap = new Dts_Informes.Cabecera_CertManDataTable();
            DataSet lDtsTablas = new DataSet();

            lDtsTablas = lPx.ObtenerDiametrosPorViaje_Tosol(iviaje);
            if (lDtsTablas.Tables.Count > 0)
            {
                for (i = 0; i < lDtsTablas.Tables[0].Rows.Count; i++)
                {
                    lFila = dtsPl.CertificadoMan.NewCertificadoManRow();
                    lFila["Nro"] = i + 1;
                    lFila["Viaje"] = iviaje;
                    lFila["Diametro"] = lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString();
                    lFila["Kilos"] = lDtsTablas.Tables[0].Rows[i]["KilosDesp"].ToString();
                    lFila["Colada"] = Obtener_NroColadasPorDiametro_TOSOL(iviaje, lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString());
                    //lFila["Figura"] = lDtsTablas.Tables[0].Rows[i]["Figura"].ToString();
                    //lFila["Referencia"] = lDtsTablas.Tables[0].Rows[i]["Referencia"].ToString();
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
                lFila["Figura"] = lDtsTablas.Tables[0].Rows[0]["Figura"].ToString(); 
                lFila["Referencia"] = lDtsTablas.Tables[0].Rows[0]["Referencia"].ToString(); ; ;
                dtsPl.Cabecera_CertMan.Rows.Add(lFila);

                frmVisualiza = new Frm_Visualizador();
                frmVisualiza.InicializaInforme("", dtsPl, iviaje, true);
                frmVisualiza.VerInforme();
                frmVisualiza.GeneraPdf_CertificadoFabricacion_TOSOL(iPathDestino, iviaje);
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
                    FileInfo lInfoArch = new FileInfo(lPathInfLote);
                    if ((File.Exists(lPathInfLote) == true))
                    {
                        // Obtenrmos el tamaño de una Archivo                    
                        if ((lInfoArch.Length / 1000) < 50)
                            lRes=string.Concat("Parece que el archivo esta Malo:", lPathInfLote);
                        
                    }
                    else
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


        private void ImprimeAseguramientoPilote(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient();
            Frm_Visualizador frmVisualiza = new Frm_Visualizador();
            Dts_Informes.CalidadPiloteDataTable lTblCal = new Dts_Informes.CalidadPiloteDataTable();            
            Dts_Informes dtsPl = new Dts_Informes(); DataSet lDts = new DataSet(); DataRow lFila = null;
            DataSet lDtsTablas = new DataSet(); DataTable lTblViajes = new DataTable(); DataSet lDtsViajes = new DataSet();
            DataSet lDtsDatos = new DataSet();             string lSql = ""; string lMaquina = "";

            try
            {
                lSql = string.Concat(" 	select  top 1 (select LOG_TERMINAL  from LOG_PIEZA_PRODUCCION where log_estado= 'O45' and LOG_ETIQUETA_PIEZA =d.id ) ");
                lSql = string.Concat(lSql , " 	from viaje v, DetallePaquetesPieza d where v.id=d.IdViaje  and codigo='", iviaje,"'  ");
                lDtsDatos = lPx.ObtenerDatos(lSql);
                if (lDtsDatos.Tables.Count > 0)
                        lMaquina = lDtsDatos.Tables[0].Rows[0][0].ToString();
               



                    lSql = string.Concat(" select *  from Calidad_Pilotes where cal_codigo='",iviaje ,"'");
                lDtsDatos = lPx.ObtenerDatos(lSql);
                if ((lDtsDatos.Tables.Count > 0) && (lDtsDatos.Tables[0].Rows .Count >0))
                {
                    //'   Carga Tabla 
                    //if (lDtsDatos.Tables.Count > 1)
                    //{                    //Cal_UsuarioAprueba
                        lTblTmp = lDtsDatos.Tables[0].Copy();
                        lFila = lTblCal.NewCalidadPiloteRow();
                        lFila["Fecha"] = lTblTmp.Rows [0]["Cal_FechaRegistro"];
                        lFila["Codigo"] = lTblTmp.Rows[0]["Cal_Codigo"];
                    // Obtenemos las procedencias cuando es materia prima
                        lFila["Procedencia"] = Obtener_ProcedenciasPorViaje(iviaje);

                    //lFila["Procedencia"] = string.Concat (lFila["Procedencia"],Obtener_ProcedenciasPorViaje(iviaje));
                    lFila["Operador"] = lTblTmp.Rows[0]["Cal_Usuario"];
                        lFila["Maquina"] = lMaquina;
                        lFila["Amperaje"] = lTblTmp.Rows[0]["Cal_Amp1"];
                        lFila["Voltaje"] = lTblTmp.Rows[0]["Cal_Vol1"];
                        lFila["Amperaje1"] = lTblTmp.Rows[0]["Cal_Amp2"];
                        lFila["Voltaje1"] = lTblTmp.Rows[0]["Cal_Vol2"];
                        lFila["Amperaje2"] = lTblTmp.Rows[0]["Cal_Amp3"];
                        lFila["Voltaje2"] = lTblTmp.Rows[0]["Cal_Vol3"];
                        lFila["MRT"] = lTblTmp.Rows[0]["Cal_MRT"];
                        lFila["MDE"] = lTblTmp.Rows[0]["Cal_MDE"];
                        lFila["PasoEspiral"] = lTblTmp.Rows[0]["Cal_PE1"];
                        lFila["PasoEspiral1"] = lTblTmp.Rows[0]["Cal_PE2"];
                        lFila["PasoEspira2"] = lTblTmp.Rows[0]["Cal_PE3"];
                        lFila["Aprobacion"] = lTblTmp.Rows[0]["Cal_UsuarioAprueba"];
                        lTblCal.Rows.Add(lFila);
                        lDts.Merge(lTblCal);

                        //' Imprimimos y visualizamos
                        Frm_Visualizador lFrmInf = new Frm_Visualizador();
                        lFrmInf.InicializaInforme("PL", lDts, "", false);
                        lFrmInf.VerInforme();
                        lFrmInf.GeneraPdf_AseguramientoPilote(iPathDestino, iviaje, "PL");
                        lFrmInf.Close();
                        lFrmInf.Dispose();
                    //}
                }
            }
            catch (Exception iex)
            {
                
            }
        }



        private void ImprimeResumenTrazabilidad(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; 
            Frm_Visualizador frmVisualiza = new Frm_Visualizador(); 
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

        private void ImprimeResumenTrazabilidad_TOSOL(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i;
            Frm_Visualizador frmVisualiza = new Frm_Visualizador();
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
            lDtsDatos = lPx.ObtenerTrazabilidadColadas_TOSOL(lDtsViajes);
            if (lDtsDatos.Tables.Count > 0)
            {
                // Validamos que  todas las etiquetas tengan datos.
                lTblTmp = lDtsDatos.Tables["Detalle"].Copy();
                for (i = 0; i < lTblTmp.Rows.Count; i++)
                {
                    if ((lTblTmp.Rows[i]["Procedencia"].ToString().Trim().Length < 2) || (lTblTmp.Rows[i]["COLADA"].ToString().Trim().Length < 10))
                    {
                        System.Windows.Forms.MessageBox.Show("Faltan datos de Colada o Procedencia, No Se puede continuar", "Avisos Sistema", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                    else
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
                            lFrmInf.GeneraPdf_TrazabilidadColadas(iPathDestino, iviaje, "TOSOL");
                            lFrmInf.Close();
                            lFrmInf.Dispose();
                        }

                        //Verificamos que todas las coladas esten copiadas, se hace aca, ya que hay coladas de etiquetas fabricadas  por TO
                        string lColada = "";                        string lPathColadas = ""; int k = 0; 
                        lTblTmp = lDtsDatos.Tables["Detalle"].Copy();
                        for (i = 0; i < lTblTmp.Rows.Count; i++)
                        {
                            lColada=lTblTmp.Rows[i]["COLADA"].ToString();

                            if (lColada.IndexOf("-") > -1)
                            {
                                string[] separators = { "-" };
                                string[] lPartes = lColada.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                for (k = 0; k < lPartes.Length  ; k++)
                                {
                                    if (lPartes[k].ToString().Trim().Length > 0)
                                    {
                                        lColada = lPartes[k].ToString();
                                        if (EsLoteAza(lColada.ToString()) == true)
                                        {                                     
                                            lPathColadas = @"C:\TMP\Calidad\Docs\";
                                            CopiarDocumentosIdiem(lTblTmp.Rows[i]["Codigo"].ToString(), lPathColadas, iPathDestino, lColada.ToString());
                                        }
                                        else
                                        {                                         
                                            lPathColadas = @"C:\TMP\Calidad\Docs\CAP\";
                                            CopiarDocumentosIdiem_CAP(lTblTmp.Rows[i]["Codigo"].ToString(), lPathColadas, iPathDestino, lColada.ToString());
                                        }
                                    }
                                }
                            }
                            else     // hay que buscar las coladas en el repositorio y copiarlas al destino
                            if (lColada.ToString().Trim().Length > 0)
                            {
                                if (EsLoteAza(lColada.ToString()) == true)
                                {                                 
                                    lPathColadas = @"C:\TMP\Calidad\Docs\";
                                    CopiarDocumentosIdiem(lTblTmp.Rows[i]["Codigo"].ToString(), lPathColadas, iPathDestino, lColada.ToString());
                                }
                                else
                                {                                    
                                    lPathColadas = @"C:\TMP\Calidad\Docs\CAP\";                                 
                                    CopiarDocumentosIdiem_CAP(lTblTmp.Rows[i]["Codigo"].ToString(), lPathColadas, iPathDestino, lColada.ToString());
                                }
                            }
                        }

                    }
                    
                }

                    
            }

        }


        public  void ImprimeResumenTrazabilidad_V2(string iPathDestino, string iviaje)
        {
            DataTable lTblTmp = new DataTable();
            WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); int i; 
            Frm_Visualizador frmVisualiza = new Frm_Visualizador();
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
