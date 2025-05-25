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
    public partial class frmUsuarios: Form
    {
        CDusuarios cd_usuarios = new CDusuarios();
        CLusuarios cl_usuarios = new CLusuarios();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            MtdMostrarEmpleados();
            MtdConsultarUsuarios();
            lblFecha.Text = cl_usuarios.MtdFechaHoy().ToString("dd/MM/yyyy");
        }

        private void MtdMostrarEmpleados()
        {
            var ListaEmpleados = cd_usuarios.MtdListarEmpleados();

            foreach (var Empleados in ListaEmpleados)
            {
                cboxCodigoEmpleado.Items.Add(Empleados);
            }

            cboxCodigoEmpleado.DisplayMember = "Text";
            cboxCodigoEmpleado.ValueMember = "Value";
        }

        private void MtdConsultarUsuarios()
        {
            DataTable dtUsuarios = cd_usuarios.MtdConsultarUsuarios();
            dgvUsuarios.DataSource = dtUsuarios;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoUsuario.Text = "";
            cboxCodigoEmpleado.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasena.Text = "";
            cboxRol.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                string NombreUsuario = txtNombreUsuario.Text;
                string Contrasena = txtContrasena.Text;
                string Rol = cboxRol.Text;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_usuarios.MtdFechaHoy();

                cd_usuarios.MtdAgregarUsuarios(CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Usuario agregado correctamente", "Gestión de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarUsuarios();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Gestión de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoUsuario = int.Parse(txtCodigoUsuario.Text);
                int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                string NombreUsuario = txtNombreUsuario.Text;
                string Contrasena = txtContrasena.Text;
                string Rol = cboxRol.Text;
                string Estado = cboxEstado.Text;
                string UsuarioSistema = UserCache.NombreUsuario;
                DateTime FechaSistema = cl_usuarios.MtdFechaHoy();

                cd_usuarios.MtdActualizarUsuarios(CodigoUsuario, CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Usuario actualizado correctamente", "Actualización de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarUsuarios();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Actualizar el usuario: " + ex.Message, "Actualización de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int CodigoUsuario = int.Parse(txtCodigoUsuario.Text);

                cd_usuarios.MtdEliminarUsuarios(CodigoUsuario);
                MessageBox.Show("Usuario eliminado correctamente", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarUsuarios();
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoUsuario.Text = dgvUsuarios.SelectedCells[0].Value.ToString();
            cboxCodigoEmpleado.Text = dgvUsuarios.SelectedCells[1].Value.ToString();
            txtNombreUsuario.Text = dgvUsuarios.SelectedCells[2].Value.ToString();
            txtContrasena.Text = dgvUsuarios.SelectedCells[3].Value.ToString();
            cboxRol.Text = dgvUsuarios.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvUsuarios.SelectedCells[5].Value.ToString();
        }
    }
}
