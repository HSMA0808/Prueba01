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
    public partial class Task_Login : Form
    {

        public Task_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de Tasks?", "Aviso" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionTask ConTask = new ConexionTask();

                DataSet ds = ConTask.ExecuteDS("Select * from usuarios where nombreusuario = '" + textBox1.Text.Trim() + "'and contraseña ='" + textBox2.Text.Trim() + "'");
                if (textBox1.Text.Trim() == ds.Tables[0].Rows[0]["NombreUsuario"].ToString().Trim() && textBox2.Text.Trim() == ds.Tables[0].Rows[0]["contraseña"].ToString().Trim())
                {
                    usuario = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
                    IDus = ds.Tables[0].Rows[0]["idusuario"].ToString().Trim();
                    Task_Menu abre = new Task_Menu();
                    this.Hide();
                    abre.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o constraseña incorrectos, intentelo de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }




            }
            catch 
            {
                MessageBox.Show("Nombre de usuario o constraseña incorrectos, intentelo de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task_ResgistroUsuarios abre = new Task_ResgistroUsuarios();
            this.Hide();
            abre.ShowDialog();
        }

        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public static String usuario;
        public static String IDus;

        private void Task_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
