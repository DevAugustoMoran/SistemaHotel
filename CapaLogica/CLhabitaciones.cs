using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLhabitaciones
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public decimal MtdPrecioHabitacion(string tipo)
        {
            decimal precio = 0;

            switch (tipo)
            {
                case "Individual":
                    precio = 500;
                    break;
                case "Ejecutiva":
                    precio = 1500;
                    break;
                case "Familiar":
                    precio = 5000;
                    break;
                case "Suite":
                    precio = 10000;
                    break;
                case "Presidencial":
                    precio = 50000;
                    break;
                default:
                    precio = 0;
                    break;
            }

            return precio;
        }
    }
}
