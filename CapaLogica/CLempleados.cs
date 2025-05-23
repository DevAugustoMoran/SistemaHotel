using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLempleados
    {
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public decimal MtdSalarioEmpleado(string Cargo)
        {
            decimal salario = 0;

            switch (Cargo)
            {
                case "Gerente":
                    salario = 35000;
                    break;
                case "Recepcionista":
                    salario = 7000;
                    break;
                case "Botones":
                    salario = 5000;
                    break;
                case "Conserje":
                    salario = 3000;
                    break;
                case "Chef":
                    salario = 1000;
                    break;
                default:
                    salario = 0;
                    break;
            }

            return salario;
        }
    }
}
