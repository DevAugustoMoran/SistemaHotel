using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLpagoPlanillas
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Today;
        }

        public decimal MtdSalarioBono(decimal Salario)
        {
            return Salario * 0.15M;
        }

        public decimal MtdMontoTotal(decimal Salario, decimal Bono, decimal HorasExtras)
        {
            return Salario + Bono + (HorasExtras * 12);
        }
    }
}
