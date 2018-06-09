using System;
using System.Text;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;

namespace ws_mono
{
	[WebService(Namespace = "http://www.example.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class paciente : System.Web.Services.WebService
    {
		[WebMethod]
		public string setPacienteCPF(object objPac)
		{
            /*Conexao cn = new Conexao();
            SqlParameter sqlPar = new SqlParameter();
            ArrayList colPar = new ArrayList();
            StringBuilder strSQL = new StringBuilder();

            sqlPar.DbType = DbType.String;
			sqlPar.Value = objPac.cpf;
            sqlPar.ParameterName = "@CPF";
            colPar.Add(sqlPar);

			objPes.CODIGO;
            = $scope.cpf
            objPes.NOME = $scope.nome
            objPes.DATA_NASCIM = $scope.nascimento
            objPes.SEXO = $scope.sexo
            objPes.RG = $scope.rg
            objPes.EST_CIVIL = $scope.estadocivil
            objPes.PROFISSAO = $scope.profissao
            objPes.NOMEPAI = $scope.pai
            objPes.NOMEMAE = $scope.mae
            objPes.CONVENIO = $scope.convenio
            objPes.CONVENIO_PLANO = $scope.plano
            objPes.NRCONVENIO = $scope.carteirinha
            objPes.TITULAR = $scope.titular
            objPes.CONVENIO_VALIDADE_CARTEIRA = $scope.validade_cart
            objPes.CEP = $scope.cep
            objPes.BAIRRO = $scope.bairro
            objPes.Celular = $scope.celular
            objPes.FONERESID = $scope.telefone
            objPes.EMAIL = $scope.email*/

            return "Ok";
		}

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

    public class oPaciente
    {
        private int _codigo;
        private string _cpf;
        private string _nome;
        private DateTime _nascimento;
        private string _sexo;
        private string _rg;
        private int _estadocivil;
        private int _profissao;
        private string _pai;
        private string _mae;
        private int _convenio;
        private string _plano;
        private string _carteirinha;
        private string _titular;
        private DateTime _validade_cart;
        private string _cep;
        private string _bairro;
        private string _celular;
        private string _telefone;
        private string _email;

        public int codigo
        {
            get => codigo = _codigo;
            set => _codigo = value;
        }

        public string cpf
        {
            get => cpf = _cpf;
            set => _cpf = value;
        }

        public string nome
        {
            get => nome = _nome;
            set => _nome = value;
        }

        public DateTime nascimento
        {
            get => nascimento = _nascimento;
            set => _nascimento = value;
        }

        public string sexo
        {
            get => sexo = _sexo;
            set => _sexo = value;
        }

        public string rg
        {
            get => rg = _rg;
            set => _rg = value;
        }

        public int estadocivil
        {
            get => estadocivil = _estadocivil;
            set => _estadocivil = value;
        }

        public int profissao
        {
            get => profissao = _profissao;
            set => _profissao = value;
        }

        public string pai
        {
            get => pai = _pai;
            set => _pai = value;
        }

        public string mae
        {
            get => mae = _mae;
            set => _mae = value;
        }

        public int convenio
        {
            get => convenio = _convenio;
            set => _convenio = value;
        }

        public string plano
        {
            get => plano = _plano;
            set => _plano = value;
        }

        public string carteirinha
        {
            get => carteirinha = _carteirinha;
            set => _carteirinha = value;
        }

        public string titular
        {
            get => titular = _titular;
            set => _titular = value;
        }

        public DateTime validade_cart
        {
            get => validade_cart = _validade_cart;
            set => _validade_cart = value;
        }

        public string cep
        {
            get => cep = _cep;
            set => _cep = value;
        }

        public string bairro
        {
            get => bairro = _bairro;
            set => _bairro = value;
        }

        public string celular
        {
            get => celular = _celular;
            set => _celular = value;
        }

        public string telefone
        {
            get => telefone = _telefone;
            set => _telefone = value;
        }

        public string email
        {
            get => email = _email;
            set => _email = value;
        }
    }
}
