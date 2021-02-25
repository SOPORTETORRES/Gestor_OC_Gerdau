using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_OC_Gerdau.Models
{
    public class LineaCredito
    {

        public String Rut { get; set; }

        public String Cliente { get; set; }

        public Int64 Monto { get; set; }

        public Int64 Coberturaseguro { get; set; }

        public Nullable<System.DateTime> Fecha_aprobacion { get; set; }

        public String Bloqueo { get; set; }

    


        //public virtual ICollection<LineaCreditoDetalle> Detalle { get; set; }

        //// Empresas
        //public virtual ICollection<LineaCreditoEmpresa> Empresas { get; set; }

        //// Log
        //public virtual ICollection<Log> Log { get; set; }

        // 2019-03-22
        public Int64 Fecha_ALCPC { get; set; } // yyyyMMdd

        public Int64 MontoTotalLCO_UF { get; set; }

        // 2019-04-02
        //1) Todo lo facturado (Pendiente de pago)
        //2) Despachado (No facturado)
        //3) Despachos programados (1 semana)

        public Int64 F_PP { get; set; }

        public Int64 D_SinFact  { get; set; }

        public Int64 D_ProximaSem   { get; set; }

        public Int64 D_ProximaSem_Mas7 { get; set; }

        public String Exepcionado { get; set; }


        public String LC_Disponible { get; set; }

        public Int64 COF_F { get; set; }

        public Int64 Diferencia_F { get; set; }

        public Int64 COF_J { get; set; }

        public Int64 Diferencia_J { get; set; }


    }
}
