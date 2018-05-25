using System;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
            
namespace ws_mono
{
	[WebService(Namespace = "http://www.example.org/", Description = "Example web service in C#")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class teste : System.Web.Services.WebService
    {
		[WebMethod]
		public int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
