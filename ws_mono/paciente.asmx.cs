using System;
using System.Text;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;

namespace ws_mono
{

	[WebService(Namespace = "http://www.example.org/", Description = "Example web service in C#")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class paciente : System.Web.Services.WebService
    {
		[WebMethod]
		public string getPacienteCPF(string strCPF)
        {
			Conexao cn = new Conexao();
            SqlParameter sqlPar = new SqlParameter();
            ArrayList colPar = new ArrayList();
            StringBuilder strSQL = new StringBuilder();
            DataTable tb;

			sqlPar.DbType = DbType.String;
            sqlPar.Value = strCPF;
            sqlPar.ParameterName = "@CPF";
            colPar.Add(sqlPar);

			strSQL.Append("SELECT * FROM PACIENTE where CNPJCPF=@CPF").AppendLine();

            tb = cn.OpenDataSetWithParam(strSQL.ToString(), "Paciente", colPar).Tables[0];

			return JsonConvert.SerializeObject(tb, Formatting.None);
        }

		[WebMethod]
		public string getEstadoCivil()
		{
			Conexao cn = new Conexao();
            DataTable tb;

			tb = cn.OpenDataSet("SELECT Codigo, Nome FROM ESTADO_CIVIL Order by NOME", "EstadoCivil").Tables[0];

            return JsonConvert.SerializeObject(tb, Formatting.None);
		}

    	[WebMethod]
        public string getProfissoes()
        {
            Conexao cn = new Conexao();
            DataTable tb;

    		tb = cn.OpenDataSet("SELECT Codigo, Nome FROM TABPROFISSOES Order by NOME", "Profissoes").Tables[0];

            return JsonConvert.SerializeObject(tb, Formatting.None);
        }

		[WebMethod]
        public string getConvenio()
        {
            Conexao cn = new Conexao();
            DataTable tb;

			tb = cn.OpenDataSet("SELECT Codigo, Nome FROM CONVENIO Order by NOME", "Convenios").Tables[0];

            return JsonConvert.SerializeObject(tb, Formatting.None);
        }

		[WebMethod]
        public string getBairro()
        {
            Conexao cn = new Conexao();
            DataTable tb;

			tb = cn.OpenDataSet("SELECT Codigo, Nome FROM BAIRRO Where NOME<>'' Order by NOME", "Bairros").Tables[0];

            return JsonConvert.SerializeObject(tb, Formatting.None);
        }

		[WebMethod]
        public string getCEP(string strCep)
        {
			strCep = strCep.Substring(0, 5);
            Conexao cn = new Conexao();
            DataTable tb;

			tb = cn.OpenDataSet("SELECT Cidade, UF, DDD FROM CEP Where Codigo='"+strCep+"'", "Bairros").Tables[0];

            return JsonConvert.SerializeObject(tb, Formatting.None);
        }
	}
}
