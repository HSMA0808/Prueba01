using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tasks
{
    class ConexionTask
    {
        public string titulo;

        public DataSet ExecuteDS(string comando)
        {
            SqlConnection Conexx;
            Conexx = new SqlConnection("Data Source=DESKTOP-8BMPE5K; Initial Catalog=Tasks; Integrated Security=True");
            Conexx.Open();

            DataSet DS = new DataSet();

            SqlDataAdapter DP = new SqlDataAdapter(comando, Conexx);
            DP.Fill(DS);
            Conexx.Close();
            return DS;
        }

        public void ExecuteDGV(string comando, DataGridView DGV)
        {
            SqlConnection Conexx;
            Conexx = new SqlConnection("Data Source=DESKTOP-8BMPE5K; Initial Catalog=Tasks; Integrated Security=True");
            Conexx.Open();

            SqlDataAdapter DP = new SqlDataAdapter(comando, Conexx);
            DataTable DT = new DataTable();
            DP.Fill(DT);
            DGV.DataSource = DT;
            Conexx.Close();
        }

        public void ExecuteSP(string comando)
        {
            SqlConnection Conexx;
            Conexx = new SqlConnection("Data Source=DESKTOP-8BMPE5K; Initial Catalog=Tasks; Integrated Security=True");
            Conexx.Open();

            SqlCommand cmd = new SqlCommand(comando, Conexx);
            cmd.ExecuteNonQuery();
            Conexx.Close();
            
        }
    
    }
}
