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
    public partial class Task_TareaView : Form
    {
        int valor;

        public Task_TareaView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            txtTitulo.Enabled = true;
            richTextBoxDescripcion.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int tipo = 0, urgencia = 0;
            string estado;

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

            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                estado = "Pendiente";
            }
            else
            {
                estado = "Atrasada";
            }
            try
            {
                string cmd = string.Format("UpdateTarea " + Convert.ToInt32(Task_Menu.id) + ", " + tipo + ", " + urgencia + ", '" + txtTitulo.Text + "', '" + richTextBoxDescripcion.Text + "', " +
                "'" + estado + "', '" + dateTimePicker2.Value.ToShortDateString() + "', '" + dateTimePicker1.Value.ToShortDateString() + "'");
                ConexionTask abre = new ConexionTask();
                abre.ExecuteSP(cmd);
                MessageBox.Show("Se ha actualizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitulo.Enabled = false;
                richTextBoxDescripcion.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                btnEditar.Enabled = true;
                btnGuardar.Visible = false;
            }
            catch (Exception Error)
            {
                MessageBox.Show("Ha ocurrido un error" + Error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Task_TareaView_Load(object sender, EventArgs e)
        {
            string cmd;
            valor = Convert.ToInt32(Task_EditarTarea.idtarea);
            ConexionTask abre = new ConexionTask();
            cmd = string.Format("select tarea.titulotarea, tarea.descripciontarea, urgencia.nonurgencia, tipo.tipo, tarea.fechacreada, tarea.fecharecordatorio  from tarea join urgencia on tarea.idurgencia = urgencia.idurgencia join tipo on tarea.idtipo = tipo.idtipo where tarea.idtarea ="+ valor + "");
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

        private void richTextBoxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
