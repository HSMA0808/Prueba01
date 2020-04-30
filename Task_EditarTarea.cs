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
    public partial class Task_EditarTarea : Form
    {
        public Task_EditarTarea()
        {
            InitializeComponent();
        }
        public static String idtarea;
        private void Task_EditarTarea_Load(object sender, EventArgs e)
        {
            try
            {
            ConexionTask con = new ConexionTask();
            string cmd = "exec MostrarTareasEditar " + Convert.ToInt32(Task_Login.IDus) + "";
            con.ExecuteDGV(cmd, dataGridEditarTarea);
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridEditarTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idtarea = dataGridEditarTarea.CurrentRow.Cells["ID"].Value.ToString();
            Task_TareaView abre = new Task_TareaView();
            abre.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConexionTask ConTask = new ConexionTask();
            try
            {

                if (comboEstado.Text == "Todas")
                {
                    ConTask.ExecuteDGV("Select idtarea as 'iD', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + " and estado != 'Completa'", dataGridEditarTarea);

                }
                else
                {
                    ConTask.ExecuteDGV("Select idtarea as 'iD', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + " and estado = '" + comboEstado.Text + "'", dataGridEditarTarea);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            this.Hide();
            abre.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int a;
        private void btnMaxi1_Click(object sender, EventArgs e)
        {
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

        private void btnMaxi2_Click(object sender, EventArgs e)
        {
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

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
