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
    public partial class frmEmpleados: Form
    {
        CDempleados cd_empleados = new CDempleados();
        CLempleados cl_empleados = new CLempleados();

        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            MtdConsultarEmpleados();
            lblFecha.Text = cl_empleados.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        public void MtdConsultarEmpleados()
        {
            DataTable dtEmpleados = cd_empleados.MtdConsultarEmpleados();
            dgvEmpleados.DataSource = dtEmpleados;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoEmpleado.Text = "";
            txtNombre.Text = "";
            cboxCargo.Text = "";
            lblSalario.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Cargo = cboxCargo.Text;
                decimal Salario = cl_empleados.MtdSalarioEmpleado(Cargo);
                DateTime FechaContratacion = dtpFechaContratacion.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_empleados.MtdFechaHoy();

                cd_empleados.MtdAgregarEmpleados(Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Empleado agregado correctamente", "Agregar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarEmpleados();
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
                int CodigoEmpleado = int.Parse(txtCodigoEmpleado.Text);
                string Nombre = txtNombre.Text;
                string Cargo = cboxCargo.Text;
                decimal Salario = cl_empleados.MtdSalarioEmpleado(Cargo);
                DateTime FechaContratacion = dtpFechaContratacion.Value;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_empleados.MtdFechaHoy();

                cd_empleados.MtdActualizarEmpleados(CodigoEmpleado, Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Empleado actualizado correctamente", "Actualizar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarEmpleados();
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
                int CodigoEmpleado = int.Parse(txtCodigoEmpleado.Text);

                cd_empleados.MtdEliminarEmpleados(CodigoEmpleado);
                MessageBox.Show("Empleado eliminado correctamente", "Eliminar Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarEmpleados();
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

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEmpleado.Text = dgvEmpleados.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvEmpleados.SelectedCells[1].Value.ToString();
            cboxCargo.Text = dgvEmpleados.SelectedCells[2].Value.ToString();
            lblSalario.Text = dgvEmpleados.SelectedCells[3].Value.ToString();
            dtpFechaContratacion.Value = DateTime.Parse(dgvEmpleados.SelectedCells[4].Value.ToString());
            cboxEstado.Text = dgvEmpleados.SelectedCells[5].Value.ToString();
        }

        private void cboxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSalario.Text = cl_empleados.MtdSalarioEmpleado(cboxCargo.Text).ToString();
        }
    }
}
