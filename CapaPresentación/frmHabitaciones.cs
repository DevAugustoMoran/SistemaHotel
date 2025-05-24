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
    public partial class frmHabitaciones: Form
    {
        CDhabitaciones cd_habitaciones = new CDhabitaciones();
        CLhabitaciones cl_habitaciones = new CLhabitaciones();

        public frmHabitaciones()
        {
            InitializeComponent();
        }

        private void frmHabitaciones_Load(object sender, EventArgs e)
        {
            MtdConsultarHabitaciones();
            lblFecha.Text = cl_habitaciones.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        public void MtdConsultarHabitaciones()
        {
            DataTable dtHabitaciones = cd_habitaciones.MtdConsultarHabitaciones();
            dgvHabitaciones.DataSource = dtHabitaciones;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoHabitacion.Text = "";
            txtNumero.Text = "";
            txtUbicacion.Text = "";
            cboxTipo.Text = "";
            lblPrecio.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Numero = txtNumero.Text;
                string Ubicacion = txtUbicacion.Text;
                string Tipo = cboxTipo.Text;
                decimal Precio = cl_habitaciones.MtdPrecioHabitacion(Tipo);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_habitaciones.MtdFechaHoy();

                cd_habitaciones.MtdAgregarHabitaciones(Numero, Ubicacion, Tipo, Precio, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Habitación agregada correctamente", "Agregar Habitación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHabitaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoHabitacion = int.Parse(txtCodigoHabitacion.Text);
                string Numero = txtNumero.Text;
                string Ubicacion = txtUbicacion.Text;
                string Tipo = cboxTipo.Text;
                decimal Precio = cl_habitaciones.MtdPrecioHabitacion(Tipo);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_habitaciones.MtdFechaHoy();

                cd_habitaciones.MtdActualizarHabitaciones(CodigoHabitacion, Numero, Ubicacion, Tipo, Precio, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Habitación actualizada correctamente", "Actualizar Habitación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHabitaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
                int CodigoHabitacion = int.Parse(txtCodigoHabitacion.Text);

                cd_habitaciones.MtdEliminarHabitaciones(CodigoHabitacion);
                MessageBox.Show("Habitación eliminada correctamente", "Eliminar Habitación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHabitaciones();
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

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoHabitacion.Text = dgvHabitaciones.SelectedCells[0].Value.ToString();
            txtNumero.Text = dgvHabitaciones.SelectedCells[1].Value.ToString();
            txtUbicacion.Text = dgvHabitaciones.SelectedCells[2].Value.ToString();
            cboxTipo.Text = dgvHabitaciones.SelectedCells[3].Value.ToString();
            lblPrecio.Text = dgvHabitaciones.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvHabitaciones.SelectedCells[5].Value.ToString();
        }

        private void cboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrecio.Text = cl_habitaciones.MtdPrecioHabitacion(cboxTipo.Text).ToString();
        }
    }
}
