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
    public partial class Task_Menu : Form
    {
        public Task_Menu()
        {
            InitializeComponent();
            /*
            ConexionTask ConTask = new ConexionTask();
            try
            {
                DateTime fecha;
                fecha = dateTimePicker1.Value;
                ConTask.ExecuteSP("exec validaratraso " + Convert.ToInt32(Task_Login.IDus) + ", '" + fecha.ToShortDateString().Trim() + "'");
                ConTask.ExecuteDGV("Select idtarea as 'ID', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + "", dataGridMenu);
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 236)
            {
                
                panel1.Width = 66;
                
            }
            else if (panel1.Width == 66)
            {
                
                panel1.Width = 236;


            }

        }

        private void Task_Menu_Load(object sender, EventArgs e)
        {
            
            //label2.Text = Task_Login.usuario;
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            abre.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            abre.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de Tasks?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task_Menu abre = new Task_Menu();
            abre.WindowState = FormWindowState.Minimized;
           
        }
        int a = 0;
        private void button4_Click(object sender, EventArgs e)
        {
                        
            if (a == 0)
            {
                WindowState = FormWindowState.Maximized;
                a++;
            }
            else if(a == 1)
                {
                WindowState = FormWindowState.Normal;
                a--;
            }
          
            
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Task_Tarea abre = new Task_Tarea();
            this.Hide();
            abre.ShowDialog();
        }
        public static String id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void comboEstado_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ConexionTask ConTask = new ConexionTask();
            try
            {
                if (comboEstado.Text == "Todas")
                {
                    ConTask.ExecuteDGV("Select idtarea as 'iD', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + "", dataGridMenu);
                }
                else
                {
                    ConTask.ExecuteDGV("Select idtarea as 'iD', titulotarea as 'Titulo', fechacreada as 'Emision', fecharecordatorio as 'Recordatorio', estado as 'Estado' from tarea where idusuario = " + Convert.ToInt32(Task_Login.IDus) + " and estado = '" + comboEstado.Text + "'", dataGridMenu);
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridMenu.CurrentRow.Cells["Id"].Value.ToString();
            Task_TareaView2 abre = new Task_TareaView2();
            abre.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UserOption abre = new UserOption();
            this.Hide();
            abre.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserOption abre = new UserOption();
            this.Hide();
            abre.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Task_CompletarTarea abre = new Task_CompletarTarea();
            this.Hide();
            abre.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Task_CompletarTarea abre = new Task_CompletarTarea();
            this.Hide();
            abre.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Task_EditarTarea abre = new Task_EditarTarea();
            this.Hide();
            abre.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Task_EditarTarea abre = new Task_EditarTarea();
            this.Hide();
            abre.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
       


        }

        private void button3_Click_2(object sender, EventArgs e)
        {
          
        }
    }
}
