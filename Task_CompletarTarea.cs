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
    public partial class Task_CompletarTarea : Form
    {
        public Task_CompletarTarea()
        {
            InitializeComponent();
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Task_CompletarTarea_Load(object sender, EventArgs e)
        {

            try
            {
                ConexionTask con = new ConexionTask();
                string cmd = "exec tareaspendientes_completar " + Task_Login.IDus + "";
                con.ExecuteDGV(cmd, dataGridCompletarTarea);
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboEstado_TextUpdate(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboEstado.Text == "Todas")
            {

                try
                {
                    ConexionTask con = new ConexionTask();
                    con.ExecuteDGV("Select idtarea as 'iD', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + " and estado != 'Completa'", dataGridCompletarTarea);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            if (comboEstado.Text == "Atrasada")
            {

                try
                {
                ConexionTask con = new ConexionTask();
                string cmd = "exec tareasatrasada_completar " + Task_Login.IDus + "";
                con.ExecuteDGV(cmd, dataGridCompletarTarea);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (comboEstado.Text == "Pendiente")
            {
                
                try
                {
                ConexionTask con = new ConexionTask();
                string cmd = "exec tareaspendientes_completar " + Task_Login.IDus + "";
                con.ExecuteDGV(cmd, dataGridCompletarTarea);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Task_CompletarTarea_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            this.Hide();
            abre.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de Tasks?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        int a = 0;
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

        private void dataGridCompletarTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Task_Menu.id = dataGridCompletarTarea.CurrentRow.Cells["ID"].Value.ToString();
            string cmd;
            ConexionTask con = new ConexionTask();
            if (MessageBox.Show("¿Desea completar esta tarea?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd = "exec completartarea " + Task_Menu.id + "";
                con.ExecuteSP(cmd);
                MessageBox.Show("Se ha completado la tarea", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboEstado.Text = "Pendiente";
                try
                {
                cmd = "exec tareaspendientes_completar " + Task_Login.IDus + "";
                con.ExecuteDGV(cmd, dataGridCompletarTarea);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
