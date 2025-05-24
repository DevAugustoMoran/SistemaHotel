using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLpagos
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Today;
        }

        public decimal MtdPropinaPago(decimal MontoPago)
        {
            return MontoPago * 0.10M;
        }

        public decimal MtdImpuestoPago(decimal MontoPago)
        {
            return MontoPago * 0.12M;
        }

        public decimal MtdDescuentoPago(decimal MontoPago)
        {
            decimal descuento = 0;

            if (MontoPago > 0 && MontoPago <= 500)
            {
                descuento = MontoPago * 0.03M;
            }
            else if (MontoPago > 500 && MontoPago <= 5000)
            {
                descuento = MontoPago * 0.05M;
            }
            else if (MontoPago > 5000)
            {
                descuento = MontoPago * 0.07M;
            }
            else
            {
                descuento = 0;
            }

            return descuento;
        }

        public decimal MtdTotalPago(decimal Monto, decimal Propina, decimal Impuesto, decimal Descuento)
        {
            return Monto + Propina + Impuesto - Descuento;
        }
    }
}
