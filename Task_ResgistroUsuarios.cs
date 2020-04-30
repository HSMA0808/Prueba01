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
    public partial class Task_ResgistroUsuarios : Form
    {
        string sexo, fecha;
        public Task_ResgistroUsuarios()
        {
            InitializeComponent();
        }

        private void Task_ResgistroUsuarios_Load(object sender, EventArgs e)
        {
            fecha = dateTimePicker1.Value.ToShortDateString();
        }

        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "M";
        }

        private void radioButtonF_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "F";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtCedula.Text == "" || sexo == "" || richTextBoxDireccion.Text == "" || txtEmail.Text == "" || richTextBoxDescripcion.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos requeridos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    string Comando;
                    Comando = "insert into usuarios (nombre, apellido, cedula, sexo, direccion, email, fechanacimiento, Descripcion, nombreusuario, contraseña) values ('" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtCedula.Text.Trim() + "', " +
                        "'" + sexo + "', '" + richTextBoxDireccion.Text + "', '" + txtEmail.Text.Trim() + "', Convert(varchar(19), '" + dateTimePicker1.Value.ToShortDateString() + "'), '" + richTextBoxDescripcion.Text + "', '" + txtUsuario.Text.Trim() +"', '" + txtContraseña.Text.Trim() +"') ";

                    ConexionTask con = new ConexionTask();
                    con.ExecuteSP(Comando);
                    MessageBox.Show("Se ha Registrado un Nuevo Usuario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show("Ocurrio un error en la transaccion" + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBoxDireccion.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Task_Login abre = new Task_Login();
            this.Hide();
            abre.ShowDialog();
        }

        public void Limpiar()
        {
            txtApellido.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            richTextBoxDescripcion.Clear();
            richTextBoxDireccion.Clear();
            dateTimePicker1.ResetText();
        }
    }
    }

