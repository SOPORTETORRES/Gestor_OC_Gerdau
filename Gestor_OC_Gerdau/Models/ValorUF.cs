using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_OC_Gerdau.Models
{
   public  class ValorUF
    {
        private string _fecha;
        private string _valor;
        private string _errorMessage;

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
    }
}
