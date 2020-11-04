using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gestor_OC_Gerdau.Facturacion
{
    class Cls_RevisaBloqueos_LC
    {
        //private List<Models.LineaCredito> listarLC(DataTable dt, string filtro) //Tbl:LC
        //{
        //    List<Models.LineaCredito> list = new List<Models.LineaCredito>();
        //    Models.LineaCredito lc = null;
        //    bool add = false;
        //    string fechaHoy_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
        //    List<string> listTest_RutBloqueo = utils.obtenerListadoTest_RutBloqueo();

        //    try
        //    {
        //        //float valorUF = float.Parse(Session["ValorUF"].ToString());
        //        Int32 valorUF = Convert.ToInt32(float.Parse(Session["ValorUF"].ToString()));
        //        string bloqueoClientesEnabled = Session["BloqueoClientesEnabled"].ToString();
        //        string notificacionesEnabled = Session["NotificacionesEnabled"].ToString();
        //        string destinatariosNotificaciones = utils.obtenerDestinatariosNotificaciones();

        //        // Instancia del WS
        //        WsFacturacion.FacturacionSoapClient wsFacturacion = new WsFacturacion.FacturacionSoapClient();
        //        WsFacturacion.ListaDataSet lsDs = new WsFacturacion.ListaDataSet();
        //        String rutCompleto = "", rut = "", bloqueado = "N", correspondeBloquear = "N";
        //        Int64 valor1 = 0, valor2 = 0, valor3 = 0, totalLC = 0, totalLCO_UF = 0, porcUtilizadoLC = 0;

        //        foreach (DataRow dataRow in dt.Rows)
        //        {
        //            // WS
        //            bloqueado = "N";
        //            valor1 = 0; valor2 = 0; valor3 = 0; totalLC = 0; totalLCO_UF = 0; porcUtilizadoLC = 0;
        //            totalLC = Convert.ToInt64(dataRow["monto_linea_aprobada"].ToString());
        //            rutCompleto = dataRow["rut"].ToString().Trim();
        //            rut = utils.rutSinDigVer(rutCompleto);
        //            lsDs = wsFacturacion.ObtenerDatosLN_Cliente(rut);
        //            if (lsDs.MensajeError.Equals(""))
        //            {
        //                if (lsDs.DataSet != null)
        //                {
        //                    if (lsDs.DataSet.Tables.Count > 0)
        //                    {
        //                        if (lsDs.DataSet.Tables[0].Rows.Count > 0)
        //                        {
        //                            valor1 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][1].ToString()) / valorUF;
        //                            valor2 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][2].ToString()) / valorUF;
        //                            valor3 = Convert.ToInt64(lsDs.DataSet.Tables[0].Rows[0][3].ToString()) / valorUF;
        //                            totalLCO_UF = valor1 + valor2 + valor3;
        //                            bloqueado = lsDs.DataSet.Tables[0].Rows[0][4].ToString(); // S/N
        //                                                                                      // 2019-03-26 Monto linea credito ocupada
        //                                                                                      //totalLCO_UF = totalLCO / Convert.ToInt32(valorUF);
        //                                                                                      // 2019-03-22 Verifica si se debe bloquear el cliente o enviar la notificacion
        //                            if (bloqueoClientesEnabled.Equals("S") || notificacionesEnabled.Equals("S"))
        //                            {
        //                                correspondeBloquear = (totalLCO_UF >= totalLC) ? "S" : "N"; // 2019-03-26
        //                                if (totalLC > 0)
        //                                    porcUtilizadoLC = (totalLCO_UF * 100) / totalLC;
        //                                if (bloqueoClientesEnabled.Equals("S") && totalLC > 0)
        //                                {
        //                                    if (!bloqueado.Equals(correspondeBloquear))
        //                                    {
        //                                        if ((listTest_RutBloqueo.Count == 0) || (!listTest_RutBloqueo.IndexOf(rutCompleto).Equals(-1))) // Filtro QA // (listTest_RutBloqueo.Contains(rutCompleto)))
        //                                        {
        //                                            wsFacturacion.CambiaEstadoCliente(rut, (correspondeBloquear.Equals("S") ? true : false));
        //                                            // 2019-03-26
        //                                            if (notificacionesEnabled.Equals("S") && !destinatariosNotificaciones.Trim().Equals(""))
        //                                            {
        //                                                if (correspondeBloquear.Equals("S"))
        //                                                    wsFacturacion.EnviaCorreoNotificacion_LC(rut, "LCC", destinatariosNotificaciones, dataRow["cliente"].ToString(), totalLC.ToString());
        //                                                else
        //                                                    wsFacturacion.EnviaCorreoNotificacion_LC(rut, "DLC", destinatariosNotificaciones, dataRow["cliente"].ToString(), totalLC.ToString());
        //                                            }
        //                                            // Fin
        //                                            bloqueado = correspondeBloquear;
        //                                        }
        //                                    }
        //                                }
        //                                if (notificacionesEnabled.Equals("S") && correspondeBloquear.Equals("N") && !destinatariosNotificaciones.Trim().Equals("") && porcUtilizadoLC >= 80) // LC ocupada >= 80% ???
        //                                {
        //                                    if ((listTest_RutBloqueo.Count == 0) || (!listTest_RutBloqueo.IndexOf(rutCompleto).Equals(-1))) // Filtro QA // (listTest_RutBloqueo.Contains(rutCompleto)))
        //                                    {
        //                                        if (!fechaHoy_yyyyMMdd.Equals(dataRow["fecha_alcpc"].ToString())) // Solo se notifica una vez al día: LC por coparse
        //                                        {
        //                                            dataAccess.executeNonQuery(obtenerSQL.registrarLC_FechaALCPC(rutCompleto)); // Registra la fecha de notificacion de la LC por coparse
        //                                            if (dataAccess.error == null)
        //                                                wsFacturacion.EnviaCorreoNotificacion_LC(rut, "ALCPC", destinatariosNotificaciones, dataRow["cliente"].ToString(), totalLC.ToString());
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            // 2019-03-18 Fin
        //                        }
        //                    }
        //                }
        //            }
        //            // Logica del parametro: filtro
        //            if (filtro.Equals("%"))
        //                add = true;
        //            else
        //            {
        //                if (filtro.Equals("LC"))
        //                    add = totalLC > 0;
        //                else if (filtro.Equals("LCO"))
        //                    add = totalLCO_UF > 0;
        //            }
        //            //
        //            if (add)
        //            {
        //                lc = new Models.LineaCredito();
        //                lc.Rut = rutCompleto;
        //                lc.Cliente = dataRow["cliente"].ToString();
        //                lc.Monto = totalLC; // Convert.ToInt64(dataRow["monto_linea_aprobada"].ToString());
        //                if (!String.IsNullOrEmpty(dataRow["fecha_aprobacion_linea"].ToString()))
        //                    lc.Fecha_aprobacion = Convert.ToDateTime(dataRow["fecha_aprobacion_linea"].ToString());
        //                lc.Bloqueo = bloqueado;
        //                // 2019-03-22 Fecha de alerta LC por coparse
        //                if (!String.IsNullOrEmpty(dataRow["fecha_alcpc"].ToString()))
        //                    lc.Fecha_ALCPC = Convert.ToInt64(dataRow["fecha_alcpc"].ToString());
        //                // 2019-03-26
        //                lc.MontoTotalLCO_UF = totalLCO_UF;
        //                // 2019-04-02
        //                //1) Todo lo facturado (Pendiente de pago)
        //                //2) Despachado (No facturado)
        //                //3) Despachos programados (1 semana)
        //                lc.F_PP = valor1; // / Convert.ToInt32(valorUF);
        //                lc.D_ProximaSem = valor2; // / Convert.ToInt32(valorUF);
        //                lc.D_SinFact = valor3; // / Convert.ToInt32(valorUF);
        //                                       // 2019-04-22
        //                lc.MontoLCDisponible_UF = totalLC - totalLCO_UF;
        //                lc.PorcUtilizadoLC = porcUtilizadoLC;
        //                //
        //                list.Add(lc);
        //            }
        //        }
        //    }
        //    catch (Exception exc)
        //    {

        //    }
        //    return list;
        //}

    }
}
