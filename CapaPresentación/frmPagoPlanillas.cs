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
    public partial class frmPagoPlanillas: Form
    {
        CDpagoPlanillas cd_pagoPlanillas = new CDpagoPlanillas();
        CLpagoPlanillas cl_pagoPlanillas = new CLpagoPlanillas();

        public frmPagoPlanillas()
        {
            InitializeComponent();
        }

        private void frmPagoPlanillas_Load(object sender, EventArgs e)
        {
            MtdMostrarEmpleados();
            MtdConsultarPagoPlanillas();
            lblFecha.Text = cl_pagoPlanillas.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarPagoPlanillas()
        {
            DataTable dtPagoPlanillas = cd_pagoPlanillas.MtdConsultarPlanillas();
            dgvPagoPlanillas.DataSource = dtPagoPlanillas;
        }

        private void MtdMostrarEmpleados()
        {
            var ListaEmpleados = cd_pagoPlanillas.MtdListarEmpleados();

            foreach (var Empleados in ListaEmpleados)
            {
                cboxCodigoEmpleado.Items.Add(Empleados);
            }

            cboxCodigoEmpleado.DisplayMember = "Text";
            cboxCodigoEmpleado.ValueMember = "Value";
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoPagoPlanilla.Text = "";
            cboxCodigoEmpleado.Text = "";
            lblSalario.Text = "0.00";
            lblBono.Text = "0.00";
            txtHorasExtras.Text = "0";
            lblMontoTotal.Text = "0.00";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                DateTime FechaPago = dtpFechaPago.Value;
                decimal Salario = cd_pagoPlanillas.MtdSalarioPlanilla(CodigoEmpleado);
                decimal Bono = cl_pagoPlanillas.MtdSalarioBono(Salario);
                decimal HorasExtras = decimal.Parse(txtHorasExtras.Text);
                decimal MontoTotal = cl_pagoPlanillas.MtdMontoTotal(Salario, Bono, HorasExtras);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_pagoPlanillas.MtdFechaHoy();

                cd_pagoPlanillas.MtdAgregarPlanillas(CodigoEmpleado, FechaPago, Salario, Bono, (int)HorasExtras, MontoTotal, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Planilla agregada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagoPlanillas();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la planilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboxCodigoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSalario.Text = cd_pagoPlanillas.MtdSalarioPlanilla(int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim())).ToString("F2");
            lblBono.Text = cl_pagoPlanillas.MtdSalarioBono(decimal.Parse(lblSalario.Text)).ToString("F2");
        }

        private void txtHorasExtras_TextChanged(object sender, EventArgs e)
        {
            lblMontoTotal.Text = cl_pagoPlanillas.MtdMontoTotal(decimal.Parse(lblSalario.Text.ToString()), decimal.Parse(lblBono.Text.ToString()), decimal.Parse(txtHorasExtras.Text.ToString())).ToString("F2");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoPagoPlanilla = int.Parse(txtCodigoPagoPlanilla.Text);
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                DateTime FechaPago = dtpFechaPago.Value;
                decimal Salario = cd_pagoPlanillas.MtdSalarioPlanilla(CodigoEmpleado);
                decimal Bono = cl_pagoPlanillas.MtdSalarioBono(Salario);
                decimal HorasExtras = decimal.Parse(txtHorasExtras.Text);
                decimal MontoTotal = cl_pagoPlanillas.MtdMontoTotal(Salario, Bono, HorasExtras);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_pagoPlanillas.MtdFechaHoy();

                cd_pagoPlanillas.MtdActualizarPlanillas(CodigoPagoPlanilla, CodigoEmpleado, FechaPago, Salario, Bono, (int)HorasExtras, MontoTotal, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Planilla actualizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagoPlanillas();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la planilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoPagoPlanilla = int.Parse(txtCodigoPagoPlanilla.Text);

                cd_pagoPlanillas.MtdEliminarPlanillas(CodigoPagoPlanilla);
                MessageBox.Show("Planilla eliminada correctamente", "Eliminar Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarPagoPlanillas();
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

        private void dgvPagoPlanillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPagoPlanilla.Text = dgvPagoPlanillas.SelectedCells[0].Value.ToString();
            cboxCodigoEmpleado.Text = dgvPagoPlanillas.SelectedCells[1].Value.ToString();
            dtpFechaPago.Value = DateTime.Parse(dgvPagoPlanillas.SelectedCells[2].Value.ToString());
            lblSalario.Text = dgvPagoPlanillas.SelectedCells[3].Value.ToString();
            lblBono.Text = dgvPagoPlanillas.SelectedCells[4].Value.ToString();
            txtHorasExtras.Text = dgvPagoPlanillas.SelectedCells[5].Value.ToString();
            lblMontoTotal.Text = dgvPagoPlanillas.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgvPagoPlanillas.SelectedCells[7].Value.ToString();
        }
    }
}
