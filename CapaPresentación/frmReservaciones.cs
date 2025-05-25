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
using CapaPresentacion.Seguridad;

namespace CapaPresentación
{
    public partial class frmReservaciones: Form
    {
        CDreservaciones cd_reservaciones = new CDreservaciones();
        CLreservaciones cl_reservaciones = new CLreservaciones();

        public frmReservaciones()
        {
            InitializeComponent();
        }

        private void frmReservaciones_Load(object sender, EventArgs e)
        {
            MtdMostrarHuespedes();
            MtdMostrarHabitaciones();
            MtdConsultarReservaciones();
            lblFecha.Text = cl_reservaciones.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarReservaciones()
        {
            DataTable dtReservas = cd_reservaciones.MtdConsultarReservaciones();
            dgvReservaciones.DataSource = dtReservas;
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

        private void MtdLimpiarCampos()
        {
            txtCodigoReserva.Text = "";
            cboxCodigoHuesped.Text = "";
            cboxCodigoHabitacion.Text = "";
            lblTotal.Text = "0.00";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoHuesped = int.Parse(cboxCodigoHuesped.Text.Split('-')[0].Trim());
                int CodigoHabitacion = int.Parse(cboxCodigoHabitacion.Text.Split('-')[0].Trim());
                DateTime FechaEntrada = dtpFechaEntrada.Value;
                DateTime FechaSalida = dtpFechaSalida.Value;
                decimal lblTotal = cd_reservaciones.MtdTotalReservacion(CodigoHabitacion);
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_reservaciones.MtdFechaHoy();
            
                cd_reservaciones.MtdAgregarReservaciones(CodigoHuesped, CodigoHabitacion, FechaEntrada, FechaSalida, lblTotal, UsuarioSistema, FechaSistema);
                MessageBox.Show("Reservación Agregada", "Sistema de Reservaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarReservaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoReserva = int.Parse(txtCodigoReserva.Text);
                int CodigoHuesped = int.Parse(cboxCodigoHuesped.Text.Split('-')[0].Trim());
                int CodigoHabitacion = int.Parse(cboxCodigoHabitacion.Text.Split('-')[0].Trim());
                DateTime FechaEntrada = dtpFechaEntrada.Value;
                DateTime FechaSalida = dtpFechaSalida.Value;
                decimal lblTotal = cd_reservaciones.MtdTotalReservacion(CodigoHabitacion);
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_reservaciones.MtdFechaHoy();

                cd_reservaciones.MtdActualizarReservaciones(CodigoReserva, CodigoHuesped, CodigoHabitacion, FechaEntrada, FechaSalida, lblTotal, UsuarioSistema, FechaSistema);
                MessageBox.Show("Reservación Actualizada", "Sistema de Reservaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarReservaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoReserva = int.Parse(txtCodigoReserva.Text);

                cd_reservaciones.MtdEliminarReservaciones(CodigoReserva);
                MessageBox.Show("Reservación eliminada correctamente", "Eliminar Reservación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarReservaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxCodigoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTotal.Text = cd_reservaciones.MtdTotalReservacion(int.Parse(cboxCodigoHabitacion.Text.Split('-')[0].Trim())).ToString();
        }

        private void dgvReservaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoReserva.Text = dgvReservaciones.SelectedCells[0].Value.ToString();
            cboxCodigoHuesped.Text = dgvReservaciones.SelectedCells[1].Value.ToString();
            cboxCodigoHabitacion.Text = dgvReservaciones.SelectedCells[2].Value.ToString();
            dtpFechaEntrada.Value = DateTime.Parse(dgvReservaciones.SelectedCells[3].Value.ToString());
            dtpFechaSalida.Value = DateTime.Parse(dgvReservaciones.SelectedCells[4].Value.ToString());
            lblTotal.Text = dgvReservaciones.SelectedCells[5].Value.ToString();
        }
    }
}
