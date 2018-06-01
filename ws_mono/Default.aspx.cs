using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ws_mono
{

    public partial class Default : System.Web.UI.Page
    {
		public void button2Clicked(object sender, EventArgs args)
		{

		}

        public void button1Clicked(object sender, EventArgs args)
        {
			button1.Text = "OK";

			/*ws_mono.paciente ws_pc = new ws_mono.paciente();
            string strx = ws_pc.getPacienteCPF();
            
			Conexao cn = new Conexao();
            SqlParameter sqlPar = new SqlParameter();
            ArrayList colPar = new ArrayList();
            StringBuilder strSQL = new StringBuilder();
            DataTable tb;

            sqlPar.DbType = DbType.Int32;
            sqlPar.Value = 10;
            sqlPar.ParameterName = "@Codigo";
            colPar.Add(sqlPar);

			strSQL.Append("SELECT Codigo, Descricao FROM tbTipoUsuario where Codigo<=@Codigo").AppendLine();

            tb = cn.OpenDataSetWithParam(strSQL.ToString(), "X", colPar).Tables[0];

			foreach (DataRow aRow in tb.Rows)
            {
				Console.WriteLine(aRow["Codigo"].ToString() + " - " + aRow["Descricao"].ToString());
            }

			ws_mono.teste ws = new ws_mono.teste();
			int x = ws.AddNumbers(1, 2);
            */
		}
    }
}
