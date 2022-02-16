using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestDatatable.Reports;

namespace TestDatatable
{
    /// <summary>
    /// Descripción breve de MyReporte
    /// </summary>
    public class MyReporte : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hola a todos");

            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.ContentType = "application/pdf";


            var data = Vacaciones.Reporte();


            context.Response.BinaryWrite(data);
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}