using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestDatatable.Reports
{
    /// <summary>
    /// Descripción breve de Rep
    /// </summary>
    public class Rep : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hola a todos");


            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.ContentType = "application/pdf";

            //Stream fileStream = publishBookManager.GetFile(documentId);
            //byte[] buffer = new byte[16 * 1024];
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    int read;
            //    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        ms.Write(buffer, 0, read);
            //    }
            //}


            //MemoryStream ms = new MemoryStream();
            //PdfWriter pw = new PdfWriter(ms);
            //PdfDocument pdfDocument = new PdfDocument(pw);
            //Document doc = new Document(pdfDocument, PageSize.A4);



            //Paragraph Titu = new Paragraph("POLICÍA NACIONAL DEL PERÚl").SetFontSize(25);
            //Titu.SetTextAlignment(TextAlignment.CENTER);
            //doc.Add(Titu);


            //doc.Close();
            //byte[] bytesStream = ms.ToArray();
            //ms.Close();

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