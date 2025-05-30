using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_OC_Gerdau.Clases
{
    public class Cls_Comun
    {
        public Boolean EsNumero_INT64(string iValor)
        {
            Boolean lRes = false; Int64 lNro = 0;
            try
            {
                lNro = Int64.Parse(iValor);
                lRes = true ;
            }
            catch (Exception iex)
            {
                lRes = false;
            }

            return lRes;
        }

        public Boolean EsNumero_Double(string iValor)
        {
            Boolean lRes = false; Double  lNro = 0;
            try
            {
                lNro = Double.Parse(iValor);
                lRes = true;
            }
            catch (Exception iex)
            {
                lRes = false;
            }

            return lRes;
        }

        public Int64 Val_INT64(string iValor)
        {
            Int64 lRes = 0; Int64 lNro = 0;
            try
            {
                lRes = Int64.Parse(iValor);
               
            }
            catch (Exception iex)
            {
                lRes = 0;
            }

            return lRes;
        }

        public void PersisteLog_EnviosMail(string iCuenta)
        {
            string lSql = ""; WS_TO.Ws_ToSoapClient lPx = new WS_TO.Ws_ToSoapClient(); string lId = "";
            string lFecha = string.Concat(DateTime.Now.ToShortDateString(), " 00:00:01"); DataSet lDts = new DataSet();

            lSql = string.Concat("  select Id from Envios_Mail where cuentaMail='", iCuenta, "' and fecha>'", lFecha, "'");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))  // existe registro
            {
                lId = lDts.Tables[0].Rows[0][0].ToString();
                lSql = string.Concat(" update  Envios_Mail set  NroEnvios=NroEnvios + 1  where id=", lId);
                lPx.ObtenerDatos(lSql);
            }
            else
            {
                lSql = " Insert into  Envios_Mail (cuentaMail, fecha,NroEnvios) values ('";
                lSql = string.Concat(lSql, iCuenta, "',getdate(),1)");
                lPx.ObtenerDatos(lSql);
            }

        }
    }
}
