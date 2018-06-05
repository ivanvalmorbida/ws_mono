using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ws_mono
{

    public partial class login : System.Web.UI.Page
    {
		public void btnOkClicked(object sender, EventArgs args)
		{
			txtUsuario.Text = Encrypt("CT informatica", "^%$#@");
			/*Conexao cn = new Conexao();
            SqlParameter sqlPar = new SqlParameter();
            ArrayList colPar = new ArrayList();
            StringBuilder strSQL = new StringBuilder();
			SqlDataReader sqlReader;

            sqlPar.DbType = DbType.String;
			sqlPar.Value = txtUsuario.Text;
			sqlPar.ParameterName = "@Apelido";
            colPar.Add(sqlPar);

			strSQL.Append("FROM MEDICO Where Apelido=@Apelido").AppendLine();

			sqlReader = cn.OpenReaderWithParam(strSQL.ToString(),colPar);

			FormsAuthentication.RedirectFromLoginPage("123", false);*/
		}
        
		public string Encrypt(string Password, string Key)
        {
			string strAUX = "";
            int c = 0;
            int I = -1;
            int l = 0;
			int x = 0;

			l = Key.Length;
			for (I = 1; I <= Password.Length; I++)
            {
				x = I % l;
				if (x == 0) x = -1; else x = 0;

				c = Convert.ToInt32(Convert.ToChar(Key.Substring(((I % l) - l * x)-1, 1)));
				strAUX += Convert.ToChar(Convert.ToInt32(Convert.ToChar(Password.Substring(I-1, 1))) ^ c);
            }
            return strAUX;
        }
	}
}