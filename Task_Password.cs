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
    public partial class Task_Password : Form
    {
        public Task_Password()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            UserOption abre = new UserOption();
            this.Hide();
            abre.ShowDialog();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtantpass.Text == string.Empty || txtcommitpass.Text == string.Empty || txtnewpass.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar todos los campos requeridos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ConexionTask Con = new ConexionTask();
                    DataSet dt;
                    dt = Con.ExecuteDS("Select contraseña from usuarios where idusuario = " + Convert.ToInt32(Task_Login.IDus) + "");
                    if (txtantpass.Text == dt.Tables[0].Rows[0]["contraseña"].ToString())
                    {
                        if (txtnewpass.Text == txtcommitpass.Text)
                        {
                            Con.ExecuteSP("update usuarios set contraseña = " + txtcommitpass.Text + " where idusuario = " + Convert.ToInt32(Task_Login.IDus) + "");
                            txtantpass.Clear();
                            txtcommitpass.Clear();
                            txtnewpass.Clear();
                        }
                        else
                        {
                            MessageBox.Show("El campo 'Nueva Contraseña' no coincide con el campo 'Confirmar Contraseña'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña a modificar no coincide con el campo 'Antigua Contraseña'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show("Ha ocurrido un error en la trasnsacción: " + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
