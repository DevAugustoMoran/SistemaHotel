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
    public partial class frmPagos: Form
    {
        CDpagos cd_pagos = new CDpagos();
        CLpagos cl_pagos = new CLpagos();

        public frmPagos()
        {
            InitializeComponent();
        }
        
        private void frmPagos_Load(object sender, EventArgs e)
        {
            MtdMostrarReservas();
            MtdConsultarPagos();
            lblFecha.Text = cl_pagos.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarPagos()
        {
            DataTable dtPagos = cd_pagos.MtdConsultarPagos();
            dgvPagos.DataSource = dtPagos;
        }


        private void MtdMostrarReservas()
        {
            var ListaReserva = cd_pagos.MtdListarReservas();

            foreach (var Reservas in ListaReserva)
            {
                cboxCodigoReserva.Items.Add(Reservas);
            }

            cboxCodigoReserva.DisplayMember = "Text";
            cboxCodigoReserva.ValueMember = "Value";
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoPago.Text = "";
            cboxCodigoReserva.Text = "";
            lblMonto.Text = "0.00";
            lblPropina.Text = "0.00";
            lblImpuesto.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblTotalPago.Text = "0.00";
            cboxMetodoPago.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoReserva = int.Parse(cboxCodigoReserva.Text.Split('-')[0].Trim());
                decimal Monto = cd_pagos.MtdMontoPago(CodigoReserva);
                decimal Propina = cl_pagos.MtdPropinaPago(Monto);
                decimal Impuesto = cl_pagos.MtdImpuestoPago(Monto);
                decimal Descuento = cl_pagos.MtdDescuentoPago(Monto);
                decimal TotalPago = cl_pagos.MtdTotalPago(Monto, Propina, Impuesto, Descuento);
                DateTime FechaPago = dtpFechaPago.Value;
                string MetodoPago = cboxMetodoPago.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_pagos.MtdFechaHoy();

                cd_pagos.MtdAgregarPagos(CodigoReserva, Monto, Propina, Impuesto, Descuento, TotalPago, FechaPago, MetodoPago, UsuarioSistema, FechaSistema);
                MessageBox.Show("Pago registrado correctamente", "Registro de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagos();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoPago = int.Parse(txtCodigoPago.Text);
                int CodigoReserva = int.Parse(cboxCodigoReserva.Text.Split('-')[0].Trim());
                decimal Monto = cd_pagos.MtdMontoPago(CodigoReserva);
                decimal Propina = cl_pagos.MtdPropinaPago(Monto);
                decimal Impuesto = cl_pagos.MtdImpuestoPago(Monto);
                decimal Descuento = cl_pagos.MtdDescuentoPago(Monto);
                decimal TotalPago = cl_pagos.MtdTotalPago(Monto, Propina, Impuesto, Descuento);
                DateTime FechaPago = dtpFechaPago.Value;
                string MetodoPago = cboxMetodoPago.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_pagos.MtdFechaHoy();

                cd_pagos.MtdActualizarPagos(CodigoPago, CodigoReserva, Monto, Propina, Impuesto, Descuento, TotalPago, FechaPago, MetodoPago, UsuarioSistema, FechaSistema);
                MessageBox.Show("Pago actualizado correctamente", "Actualización de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagos();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int CodigoPago = int.Parse(txtCodigoPago.Text);

                cd_pagos.MtdEliminarPagos(CodigoPago);
                MessageBox.Show("Pago eliminado correctamente", "Eliminar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagos();
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

        private void cboxCodigoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CodigoReserva = int.Parse(cboxCodigoReserva.Text.Split('-')[0].Trim());
            decimal Monto = cd_pagos.MtdMontoPago(CodigoReserva);
            decimal Propina = cl_pagos.MtdPropinaPago(Monto);
            decimal Impuesto = cl_pagos.MtdImpuestoPago(Monto);
            decimal Descuento = cl_pagos.MtdDescuentoPago(Monto);
            decimal TotalPago = cl_pagos.MtdTotalPago(Monto, Propina, Impuesto, Descuento);

            lblMonto.Text = Monto.ToString("F2");
            lblPropina.Text = Propina.ToString("F2");
            lblImpuesto.Text = Impuesto.ToString("F2");
            lblDescuento.Text = Descuento.ToString("F2");
            lblTotalPago.Text = TotalPago.ToString("F2");
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPago.Text = dgvPagos.SelectedCells[0].Value.ToString();
            cboxCodigoReserva.Text = dgvPagos.SelectedCells[1].Value.ToString();
            lblMonto.Text = dgvPagos.SelectedCells[2].Value.ToString();
            lblPropina.Text = dgvPagos.SelectedCells[3].Value.ToString();
            lblImpuesto.Text = dgvPagos.SelectedCells[4].Value.ToString();
            lblDescuento.Text = dgvPagos.SelectedCells[5].Value.ToString();
            lblTotalPago.Text = dgvPagos.SelectedCells[6].Value.ToString();
            dtpFechaPago.Value = DateTime.Parse(dgvPagos.SelectedCells[7].Value.ToString());
            cboxMetodoPago.Text = dgvPagos.SelectedCells[8].Value.ToString();
        }
    }
}
