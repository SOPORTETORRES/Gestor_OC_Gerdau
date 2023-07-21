

namespace Gestor_OC_Gerdau.Logistica
{
    class Cls_Sql
    {
        public string ObtenerSql_Etiquetas(string iFechaIni, string iFechaFin, string  iSucursal)
        {
            //string lSql = " select d.id, d.kgspaquete ,  (select sum(importeservicio) from ServiciosObra where o.id = IdObra and EsFacturable = 'S' ) Pr,codigo_inet ";
            //lSql = string.Concat(lSql  , "  from DetallePaquetesPieza d, pieza_produccion, viaje v , it , Obras o  ");
            //lSql = string.Concat(lSql, "    where d.id = pie_etiqueta_pieza and pie_avance = 100 and v.id = d.idviaje and v.idit = it.id ");
            //lSql = string.Concat(lSql, "   and PIE_FECHA_PRODUCCION between '", iFechaIni  , "' And '"  , iFechaFin, "'" );
            //lSql = string.Concat(lSql, "  and o.id = it.idobra  and it.IdSucursal =", iSucursal );


            string lSql = string.Concat(" SP_CRUD_ETIQUETAS_PT 0,0,'','", iFechaIni, "','", iFechaFin, "','");
            lSql = string.Concat(lSql, iSucursal, "','',2");

            return lSql;

        }


    }
}
