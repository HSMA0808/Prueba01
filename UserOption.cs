using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class UserOption : Form
    {
        public UserOption()
        {
            InitializeComponent();
        }

        public void Desactivar()
        {       
                btnguardar.Visible = false;
                btnCancelar.Visible = false;
                txtApellido.Enabled = false;
                txtCedula.Enabled = false;
                txtEmail.Enabled = false;
                txtNombre.Enabled = false;
                txtUsuario.Enabled = false;
                richTextBoxDescripcion.Enabled = false;
                richTextBoxDireccion.Enabled = false;
                radioButtonF.Enabled = false;
                radioButtonM.Enabled = false;
                dateTimePicker1.Enabled = false;
                btnguardar.Visible = false;
        }

        public void Activar()
        {
            btnguardar.Visible = true;
            btnCancelar.Visible = true;
            txtApellido.Enabled = true;
            txtCedula.Enabled = true;
            txtEmail.Enabled = true;
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            richTextBoxDescripcion.Enabled = true;
            richTextBoxDireccion.Enabled = true;
            radioButtonF.Enabled = true;
            radioButtonM.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            this.Hide();
            abre.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de que desea cerrar la sesion?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Task_Login abre = new Task_Login();
                this.Hide();
                abre.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void linkMostrarMas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (linkMostrarMas.Text == "Mostrar Mas")
            {
                btnContraseña.Visible = true;
                linkMostrarMas.Text = "Mostrar Menos";

            }else if (linkMostrarMas.Text == "Mostrar Menos")
            {
                btnContraseña.Visible = false;
                linkMostrarMas.Text = "Mostrar Mas";

            }
        }

        private void UserOption_Load(object sender, EventArgs e)
        {
            ConexionTask Conexion = new ConexionTask();
            DataSet ds;
            lblnombre.Text = Task_Login.usuario;
            string comando;
            comando = "exec CargarUsuario " + Convert.ToInt32(Task_Login.IDus) + "";
            ds = Conexion.ExecuteDS(comando);
            txtNombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            txtApellido.Text = ds.Tables[0].Rows[0]["apellido"].ToString();
            txtCedula.Text = ds.Tables[0].Rows[0]["cedula"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtUsuario.Text = ds.Tables[0].Rows[0]["nombreusuario"].ToString();
            richTextBoxDescripcion.Text = ds.Tables[0].Rows[0]["descripcion"].ToString();
            richTextBoxDireccion.Text = ds.Tables[0].Rows[0]["direccion"].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["fechanacimiento"].ToString());
            if (ds.Tables[0].Rows[0]["sexo"].ToString().ToString() == "M")
            {
                radioButtonM.Checked = true;
            }else if (ds.Tables[0].Rows[0]["sexo"].ToString().ToString() == "F")
            {
                radioButtonF.Checked = true;
            }

        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            ConexionTask Conexion = new ConexionTask();
            string sexo = string.Empty;
            string cmd;
            if (radioButtonF.Checked == true)
            {
                sexo = "F";
            }
            else if (radioButtonM.Checked == true)
            {
                sexo = "M";
            }

            if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtCedula.Text == string.Empty || txtEmail.Text == string.Empty || txtUsuario.Text == string.Empty || richTextBoxDescripcion.Text == string.Empty || richTextBoxDireccion.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos para guardar la información", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    cmd = string.Format("exec UpdateUsuario " + Convert.ToInt32(Task_Login.IDus) + ", '" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtCedula.Text + "', '" + sexo + "', '" + richTextBoxDireccion.Text + "', '" + txtEmail.Text + "', '" + dateTimePicker1.Value.ToShortDateString() + "', '" + richTextBoxDescripcion.Text + "', '" + txtUsuario.Text + "'");
                    Conexion.ExecuteSP(cmd);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception Error)
                {
                    MessageBox.Show("Ha ocurrido un error en la transaccion" + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Desactivar();
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desactivar();
        }

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            Task_Password abre = new Task_Password();
            this.Hide();
            abre.ShowDialog();
        }
    }
}
