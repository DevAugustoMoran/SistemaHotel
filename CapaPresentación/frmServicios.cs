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
    public partial class frmServicios: Form
    {
        CDservicios cd_servicios = new CDservicios();
        CLservicios cl_servicios = new CLservicios(); 

        public frmServicios()
        {
            InitializeComponent();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            MtdConsultarServicios();
            lblFecha.Text = cl_servicios.MtdFechaHoy().ToString();
        }

        public void MtdConsultarServicios()
        {
            DataTable dtServicios = cd_servicios.MtdConsultarServicios();
            dgvServicios.DataSource = dtServicios;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoServicio.Text = "";
            txtNombre.Text = "";
            cboxTipo.Text = "";
            lblPrecio.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Tipo = cboxTipo.Text;
                decimal Precio = cl_servicios.MtdPrecioServicio(Tipo);
                DateTime FechaVigencia = dtpFechaVigencia.Value;
                DateTime FechaVencimiento = dtpFechaVencimiento.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = "Usuario"; // Cambiar por el usuario del sistema
                DateTime FechaSistema = cl_servicios.MtdFechaHoy();

                cd_servicios.MtdAgregarServicios(Nombre, Tipo, Precio, FechaVigencia, FechaVencimiento, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Servicio agregado correctamente", "Agregar Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarServicios();
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
                int CodigoServicio = int.Parse(txtCodigoServicio.Text);
                string Nombre = txtNombre.Text;
                string Tipo = cboxTipo.Text;
                decimal Precio = cl_servicios.MtdPrecioServicio(Tipo);
                DateTime FechaVigencia = dtpFechaVigencia.Value;
                DateTime FechaVencimiento = dtpFechaVencimiento.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = "Usuario"; // Cambiar por el usuario del sistema
                DateTime FechaSistema = cl_servicios.MtdFechaHoy();

                cd_servicios.MtdActualizarServicios(CodigoServicio, Nombre, Tipo, Precio, FechaVigencia, FechaVencimiento, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Servicio actualizado correctamente", "Actualizar Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarServicios();
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
                int CodigoServicio = int.Parse(txtCodigoServicio.Text);

                cd_servicios.MtdEliminarServicios(CodigoServicio);
                MessageBox.Show("Servicio eliminado correctamente", "Eliminar Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarServicios();
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

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoServicio.Text = dgvServicios.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvServicios.SelectedCells[1].Value.ToString();
            cboxTipo.Text = dgvServicios.SelectedCells[2].Value.ToString();
            lblPrecio.Text = dgvServicios.SelectedCells[3].Value.ToString();
            dtpFechaVigencia.Value = DateTime.Parse(dgvServicios.SelectedCells[4].Value.ToString());
            dtpFechaVencimiento.Value = DateTime.Parse(dgvServicios.SelectedCells[5].Value.ToString());
            cboxEstado.Text = dgvServicios.SelectedCells[6].Value.ToString();
        }

        private void cboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrecio.Text = cl_servicios.MtdPrecioServicio(cboxTipo.Text).ToString();
        }
    }
}
