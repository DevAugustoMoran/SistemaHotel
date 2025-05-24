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
    public partial class frmHuespedes : Form
    {
        CDhuespedes cd_huespedes = new CDhuespedes();
        CLhuespedes cl_huespedes = new CLhuespedes();

        public frmHuespedes()
        {
            InitializeComponent();
        }

        private void frmHuespedes_Load(object sender, EventArgs e)
        {
            MtdConsultarHuespedes();
            lblFecha.Text = cl_huespedes.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        public void MtdConsultarHuespedes()
        {
            DataTable dtHuespedes = cd_huespedes.MtdConsultarHuespedes();
            dgvHuespedes.DataSource = dtHuespedes;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoHuesped.Text = "";
            txtNombre.Text = "";
            txtNit.Text = "";
            txtTelefono.Text = "";
            cboxTipo.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Nit = txtNit.Text;
                string Telefono = txtTelefono.Text;
                string Tipo = cboxTipo.Text;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_huespedes.MtdFechaHoy();

                cd_huespedes.MtdAgregarHuespedes(Nombre, Nit, Telefono, Tipo, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Huesped agregado correctamente", "Agregar Huesped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHuespedes();
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
                int CodigoHuesped = int.Parse(txtCodigoHuesped.Text);
                string Nombre = txtNombre.Text;
                string Nit = txtNit.Text;
                string Telefono = txtTelefono.Text;
                string Tipo = cboxTipo.Text;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_huespedes.MtdFechaHoy();

                cd_huespedes.MtdActualizarHuespedes(CodigoHuesped, Nombre, Nit, Telefono, Tipo, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Huesped actualizado correctamente", "Actualizar Huesped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHuespedes();
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
                int CodigoHuesped = int.Parse(txtCodigoHuesped.Text);

                cd_huespedes.MtdEliminarHuespedes(CodigoHuesped);
                MessageBox.Show("Huesped eliminado correctamente", "Eliminar Huesped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarHuespedes();
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

        private void dgvHuespedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoHuesped.Text = dgvHuespedes.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvHuespedes.SelectedCells[1].Value.ToString();
            txtNit.Text = dgvHuespedes.SelectedCells[2].Value.ToString();
            txtTelefono.Text = dgvHuespedes.SelectedCells[3].Value.ToString();
            cboxTipo.Text = dgvHuespedes.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvHuespedes.SelectedCells[5].Value.ToString();
        }
    }
}
