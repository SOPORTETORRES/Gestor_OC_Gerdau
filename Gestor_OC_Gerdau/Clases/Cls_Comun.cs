using System;
using System.Collections.Generic;
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

    }
}
