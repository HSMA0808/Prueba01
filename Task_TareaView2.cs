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
    public partial class Task_TareaView2 : Form
    {
        public Task_TareaView2()
        {
            InitializeComponent();
        }

        private void Task_TareaView2_Load(object sender, EventArgs e)
        {
            string cmd;
            int valor;
            valor = Convert.ToInt32(Task_Menu.id);
            ConexionTask abre = new ConexionTask();
            cmd = string.Format("select tarea.titulotarea, tarea.descripciontarea, urgencia.nonurgencia, tipo.tipo, tarea.fechacreada, tarea.fecharecordatorio  from tarea join urgencia on tarea.idurgencia = urgencia.idurgencia join tipo on tarea.idtipo = tipo.idtipo where tarea.idtarea =" + valor + "");
            DataSet DataS;
            try
            {
                DataS = abre.ExecuteDS(cmd);
                txtTitulo.Text = DataS.Tables[0].Rows[0]["titulotarea"].ToString();
                richTextBoxDescripcion.Text = DataS.Tables[0].Rows[0]["descripciontarea"].ToString();
                comboBox1.Text = DataS.Tables[0].Rows[0]["nonurgencia"].ToString();
                comboBox2.Text = DataS.Tables[0].Rows[0]["tipo"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(DataS.Tables[0].Rows[0]["fecharecordatorio"].ToString());
         
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
