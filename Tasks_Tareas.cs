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
    public partial class Task_Tarea : Form
    {
        public Task_Tarea()
        {
            InitializeComponent();
        }
        int tipo, usu, urgencia;

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de Tasks?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaxi2_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (a == 0)
            {
                WindowState = FormWindowState.Maximized;
                a++;
            }
            else if (a == 1)
            {
                WindowState = FormWindowState.Normal;
                a--;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Task_Menu are = new Task_Menu();
            this.Hide();
            are.ShowDialog();
        }

        private void Task_Tarea_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "Personal";
            comboBox1.Text = "Normal";
        }

        public void Limpiar()
        {
            txtTitulo.Text = "";
            richTextBoxDescripcion.Text = "";
            comboBox2.Text = "Personal";
            comboBox1.Text = "Normal";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Personal")
            {
                tipo = 1;
            }
            else if (comboBox2.Text == "Estudiantil")
            {
                tipo = 2;
            }
            else if (comboBox2.Text == "Deportiva")
            {
                tipo = 3;
            }
            else if (comboBox2.Text == "Laboral")
            {
                tipo = 4;
            }
            else if (comboBox2.Text == "Espiritual")
            {
                tipo = 5;
            }
            else if (comboBox2.Text == "Emocional")
            {
                tipo = 6;
            }

            if (comboBox1.Text == "Urgente")
            {
                urgencia = 1;
            }
            else if (comboBox1.Text == "Muy Urgente")
            {
                urgencia = 2;
            }
            else if (comboBox1.Text == "Normal")
            {
                urgencia = 3;
            }
            else if (comboBox1.Text == "No Urgente")
            {
                urgencia = 4;
            }

            if (txtTitulo.Text == "" || richTextBoxDescripcion.Text == "" || urgencia == 0 || tipo == 0)
            {
                MessageBox.Show("Debe completar todos los campos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    usu = Convert.ToInt32(Task_Login.IDus);
                    ConexionTask Connect = new ConexionTask();
                    string cmd = "Exec InsertarTarea " + tipo + ", " + usu + ", " + urgencia + ", '" + txtTitulo.Text + "', '" + richTextBoxDescripcion.Text + "', 'Pendiente', '" + dateTimePicker1.Value.ToShortDateString() + "', '" + dateTimePicker2.Value.ToShortDateString() + "'";
                    Connect.ExecuteSP(cmd);
                    MessageBox.Show("Se ha guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error enla transacción" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
