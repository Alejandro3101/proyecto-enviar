using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        servicioEscritorio.ServicioProyecSoapClient miservicio = new servicioEscritorio.ServicioProyecSoapClient();



        public void mtdcargarUsuarios()
        {
            DataSet dsDatos = new DataSet();
            dsDatos = miservicio.mtdListarUsuarios();
            dgvUsuarios.DataSource = dsDatos.Tables["tbldatos"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            DataSet dsRol = new DataSet();
            dsRol = miservicio.mtdListarRol();
            cmbRol.DataSource = dsRol.Tables["tblDatos"];
            cmbRol.DisplayMember = "Rol";
            cmbRol.ValueMember = "IdRol";


            mtdcargarUsuarios();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            servicioEscritorio.clUsuarios objusuarios = new servicioEscritorio.clUsuarios();

            objusuarios.Documento = txtDocumento.Text;
            objusuarios.Nombre = txtNombre.Text;
            objusuarios.Apellido = (txtApellido.Text.ToString());
            objusuarios.Email = (txtEmail.Text.ToString());
            objusuarios.Telefono = txtTelefono.Text;
            objusuarios.IdRol = int.Parse(cmbRol.SelectedValue.ToString());

            int.Parse(cmbRol.SelectedValue.ToString());


            int res = miservicio.mtdRegistrarUsuario(objusuarios);

            if (res > 0)
            {
                MessageBox.Show("Registro correctamente");
                mtdcargarUsuarios();
            }
        }
    }
}
