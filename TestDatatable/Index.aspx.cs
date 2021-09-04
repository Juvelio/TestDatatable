using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestDatatable
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<Asistencia> ListarAsistencias()
        {
            //var Usuario = System.Web.HttpContext.Current.Session["UserSession"];      //Ejemplopara que puedas recuperrar sesion

            List<Asistencia> Lista = new List<Asistencia>();
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000767", Entrada = DateTime.Now, Salida = DateTime.Now.AddHours(8), Canal = 1 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000768", Entrada = DateTime.Now, Salida = null, Canal = 2 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000769", Entrada = null, Salida = null, Canal = 1 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000770", Entrada = DateTime.Now, Salida = DateTime.Now.AddHours(8), Canal = 1 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000771", Entrada = DateTime.Now, Salida = DateTime.Now.AddHours(8), Canal = 2 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000772", Entrada = DateTime.Now, Salida = DateTime.Now.AddHours(8), Canal = 1 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000773", Entrada = DateTime.Now, Salida = DateTime.Now.AddHours(8), Canal = 2 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000774", Entrada = null, Salida = null, Canal = 1 });
            Lista.Add(new Asistencia() { MASPE_CARNE = "20000775", Entrada = null, Salida = null, Canal = 1 });


            for (int i = 0; i < 30; i++)
            {
                Lista.Add(new Asistencia() { MASPE_CARNE = "3000000" + i, Entrada = DateTime.Now, Salida = null, Canal = 1 });
            }

            return Lista;
        }
    }
}