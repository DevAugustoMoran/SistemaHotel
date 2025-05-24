using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos;
using CapaPresentacion.Seguridad;

namespace CapaPresentación
{
    public partial class frmAsignaciones: Form
    {
        CDasignaciones cd_asignaciones = new CDasignaciones();
        CLasignaciones cl_asignaciones = new CLasignaciones();

        public frmAsignaciones()
        {
            InitializeComponent();
        }

        private void frmAsignaciones_Load(object sender, EventArgs e)
        {
            MtdMostrarEmpleados();
            MtdMostrarHabitaciones();
            MtdConsultarAsignaciones();
            lblFecha.Text = cl_asignaciones.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarAsignaciones()
        {
            DataTable dtAsignaciones = cd_asignaciones.MtdConsultarAsignaciones();
            dgvAsignaciones.DataSource = dtAsignaciones;
        }

        private void MtdMostrarEmpleados()
        {
            var ListaEmpleados = cd_asignaciones.MtdListarEmpleados();

            foreach (var Empleados in ListaEmpleados)
            {
                cboxCodigoEmpleado.Items.Add(Empleados);
            }

            cboxCodigoEmpleado.DisplayMember = "Text";
            cboxCodigoEmpleado.ValueMember = "Value";
        }

        private void MtdMostrarHabitaciones()
        {
            var ListaHabitaciones = cd_asignaciones.MtdListarHabitaciones();

            foreach (var Habitaciones in ListaHabitaciones)
            {
                cboxCodigoHabitacion.Items.Add(Habitaciones);
            }

            cboxCodigoHabitacion.DisplayMember = "Text";
            cboxCodigoHabitacion.ValueMember = "Value";
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoAsignacion.Text = "";
            cboxCodigoEmpleado.Text = "";
            cboxCodigoHabitacion.Text = "";
            cboxTipoAsignacion.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                int CodigoHabitacion = int.Parse(cboxCodigoHabitacion.Text.Split('-')[0].Trim());
                string TipoAsignacion = cboxTipoAsignacion.Text;
                DateTime FechaAsignacion = dtpFechaAsignacion.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_asignaciones.MtdFechaHoy();

                cd_asignaciones.MtdAgregarAsignaciones(CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Asignación registrada correctamente", "Registro de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarAsignaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoAsignacion = int.Parse(txtCodigoAsignacion.Text);
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                int CodigoHabitacion = int.Parse(cboxCodigoHabitacion.Text.Split('-')[0].Trim());
                string TipoAsignacion = cboxTipoAsignacion.Text;
                DateTime FechaAsignacion = dtpFechaAsignacion.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_asignaciones.MtdFechaHoy();

                cd_asignaciones.MtdActualizarAsignaciones(CodigoAsignacion, CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Asignación actualizada correctamente", "Actualización de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarAsignaciones();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int CodigoAsignacion = int.Parse(txtCodigoAsignacion.Text);

                cd_asignaciones.MtdEliminarAsignaciones(CodigoAsignacion);
                MessageBox.Show("Asignación eliminada correctamente", "Eliminar Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarAsignaciones();
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

        private void dgvAsignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoAsignacion.Text = dgvAsignaciones.SelectedCells[0].Value.ToString();
            cboxCodigoEmpleado.Text = dgvAsignaciones.SelectedCells[1].Value.ToString();
            cboxCodigoHabitacion.Text = dgvAsignaciones.SelectedCells[2].Value.ToString();
            cboxTipoAsignacion.Text = dgvAsignaciones.SelectedCells[3].Value.ToString();
            dtpFechaAsignacion.Value = DateTime.Parse(dgvAsignaciones.SelectedCells[4].Value.ToString());
            cboxEstado.Text = dgvAsignaciones.SelectedCells[5].Value.ToString();
        }
    }
}
