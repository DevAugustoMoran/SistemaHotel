using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentación
{
    public partial class frmReservaciones: Form
    {
        CDreservaciones cd_reservaciones = new CDreservaciones();

        public frmReservaciones()
        {
            InitializeComponent();
        }

        private void frmReservaciones_Load(object sender, EventArgs e)
        {
            MtdMostrarHuespedes();
            MtdMostrarHabitaciones();
        }

        private void MtdMostrarHuespedes()
        {
            var ListaHuesped = cd_reservaciones.MtdListarHuesped();

            foreach (var Huesped in ListaHuesped)
            {
                cboxCodigoHuesped.Items.Add(Huesped);
            }

            cboxCodigoHuesped.DisplayMember = "Text";
            cboxCodigoHuesped.ValueMember = "Value";
        }

        private void MtdMostrarHabitaciones()
        {
            var ListaHabitaciones = cd_reservaciones.MtdListarHabitaciones();

            foreach (var Habitaciones in ListaHabitaciones)
            {
                cboxCodigoHabitacion.Items.Add(Habitaciones);
            }

            cboxCodigoHabitacion.DisplayMember = "Text";
            cboxCodigoHabitacion.ValueMember = "Value";
        }
    }
}
