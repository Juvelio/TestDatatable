using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestDatatable.Reports;

namespace TestDatatable
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        [WebMethod]
        public static string GenerarReporte()
        {
            var data = Vacaciones.Reporte();
            return Convert.ToBase64String(data);
        }

    }
}