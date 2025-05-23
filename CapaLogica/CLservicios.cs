using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLservicios
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public decimal MtdPrecioServicio(string tipo)
        {
            decimal precio = 0;

            switch (tipo)
            {
                case "Comida":
                    precio = 250;
                    break;
                case "Bebida":
                    precio = 100;
                    break;
                case "Transporte":
                    precio = 125;
                    break;
                case "Lavanderia":
                    precio = 75;
                    break;
                case "Medicina":
                    precio = 150;
                    break;
                default:
                    precio = 0;
                    break;  
            }

            return precio;
        }
    }
}
