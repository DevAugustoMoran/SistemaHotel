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
using CapaPresentacion.Seguridad;

namespace CapaPresentación
{
    public partial class frmConsumos: Form
    {
        CDconsumos cd_consumos = new CDconsumos();
        CLconsumos cl_consumos = new CLconsumos();

        public frmConsumos()
        {
            InitializeComponent();
        }

        private void frmConsumos_Load(object sender, EventArgs e)
        {
            MtdMostrarReservas();
            MtdMostrarServicios();
            MtdConsultarConsumos();
            lblFecha.Text = cl_consumos.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarConsumos()
        {
            DataTable dtConsumos = cd_consumos.MtdConsultarConsumos();
            dgvConsumos.DataSource = dtConsumos;
        }

        private void MtdMostrarReservas()
        {
            var ListaReserva = cd_consumos.MtdListarReservas();

            foreach (var Reservas in ListaReserva)
            {
                cboxCodigoReserva.Items.Add(Reservas);
            }

            cboxCodigoReserva.DisplayMember = "Text";
            cboxCodigoReserva.ValueMember = "Value";
        }

        private void MtdMostrarServicios()
        {
            var ListaServicios = cd_consumos.MtdListarServicios();

            foreach (var Servicios in ListaServicios)
            {
                cboxCodigoServicio.Items.Add(Servicios);
            }

            cboxCodigoServicio.DisplayMember = "Text";
            cboxCodigoServicio.ValueMember = "Value";
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoConsumo.Text = "";
            cboxCodigoReserva.Text = "";
            cboxCodigoServicio.Text = "";
            lblMonto.Text = "0.00";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoReserva = int.Parse(cboxCodigoReserva.Text.Split('-')[0].Trim());
                int CodigoServicio = int.Parse(cboxCodigoServicio.Text.Split('-')[0].Trim());
                decimal Monto = cd_consumos.MtdMontoConsumo(CodigoServicio);
                DateTime FechaConsumo = dtpFechaConsumo.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_consumos.MtdFechaHoy();

                cd_consumos.MtdAgregarConsumos(CodigoReserva, CodigoServicio, Monto, FechaConsumo, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Consumo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarConsumos();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el consumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoConsumo = int.Parse(txtCodigoConsumo.Text);
                int CodigoReserva = int.Parse(cboxCodigoReserva.Text.Split('-')[0].Trim());
                int CodigoServicio = int.Parse(cboxCodigoServicio.Text.Split('-')[0].Trim());
                decimal Monto = cd_consumos.MtdMontoConsumo(CodigoServicio);
                DateTime FechaConsumo = dtpFechaConsumo.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_consumos.MtdFechaHoy();

                cd_consumos.MtdActualizarConsumos(CodigoConsumo, CodigoReserva, CodigoServicio, Monto, FechaConsumo, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Consumo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarConsumos();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el consumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboxCodigoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMonto.Text = cd_consumos.MtdMontoConsumo(int.Parse(cboxCodigoServicio.Text.Split('-')[0].Trim())).ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoConsumo = int.Parse(txtCodigoConsumo.Text);

                cd_consumos.MtdEliminarConsumos(CodigoConsumo);
                MessageBox.Show("Consumo eliminado correctamente", "Eliminar Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarConsumos();
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

        private void dgvConsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoConsumo.Text = dgvConsumos.SelectedCells[0].Value.ToString();
            cboxCodigoReserva.Text = dgvConsumos.SelectedCells[1].Value.ToString();
            cboxCodigoServicio.Text = dgvConsumos.SelectedCells[2].Value.ToString();
            lblMonto.Text = dgvConsumos.SelectedCells[3].Value.ToString();
            dtpFechaConsumo.Value = DateTime.Parse(dgvConsumos.SelectedCells[4].Value.ToString());
            cboxEstado.Text = dgvConsumos.SelectedCells[5].Value.ToString();
        }
    }
}
