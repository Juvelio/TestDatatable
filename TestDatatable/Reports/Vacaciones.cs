using iText.Barcodes;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestDatatable.Reports
{
    public static class Vacaciones
    {
        readonly static PdfFont Arial = PdfFontFactory.CreateFont(HttpContext.Current.Request.MapPath("Reports/Fonts/Arial/arial.ttf"), PdfEncodings.IDENTITY_H);
        readonly static PdfFont ArialBlack = PdfFontFactory.CreateFont(HttpContext.Current.Request.MapPath("Reports/Fonts/Arial/arialbd.ttf"), PdfEncodings.IDENTITY_H);
        readonly static PdfFont Impact = PdfFontFactory.CreateFont(HttpContext.Current.Request.MapPath("Reports/Fonts/impact.ttf"), PdfEncodings.IDENTITY_H);



        public static byte[] Reporte()
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.A4);


            #region Cabezera
            var path = HttpContext.Current.Request.MapPath(@"~/Reports/Images/CabeceraMoarh-min.png");
            Image imgCabecera = new Image(ImageDataFactory.Create(path));
            imgCabecera.SetMarginTop(-doc.GetTopMargin());
            imgCabecera.SetMarginLeft(-doc.GetLeftMargin());
            imgCabecera.SetMarginRight(-doc.GetRightMargin());
            doc.Add(imgCabecera);
            #endregion

            #region Titulo
            Paragraph Titu = new Paragraph("POLICÍA NACIONAL DEL PERÚ").SetFontSize(25);
            Titu.SetTextAlignment(TextAlignment.CENTER);
            Titu.SetFont(Impact);
            doc.Add(Titu);


            Paragraph Des = new Paragraph("ORDEN DE VACACIONES REGLAMENTARIAS NRO 586798 XII MACREPOL ANCASH_DIVPOL CHIMBOTE_URH 09/02/2022").SetFontSize(10);
            Des.SetMargins(0, 25, 0, 25);
            Des.SetTextAlignment(TextAlignment.CENTER);
            Des.SetFont(ArialBlack);
            doc.Add(Des);
            #endregion



            SolidLine lineDrawer = new SolidLine(1.2f);
            lineDrawer.SetColor(ColorConstants.BLACK);
            doc.Add(new LineSeparator(lineDrawer));

            doc.Add(tCuerpo(pdfDocument));

            doc.Add(new LineSeparator(lineDrawer));



            #region OperadorFechaHora
            Paragraph Operador = new Paragraph("BENITES JARA, MIGUEL ANGEL").SetFontSize(6).SetItalic();
            doc.Add(Operador);


            //Paragraph impresion = new Paragraph($"Imp: {DateTime.Now.ToString("dddd dd MMMM yyyy")}").SetFontSize(7);
            //impresion.SetFont(ArialBlack);
            //doc.Add(impresion);


            //Paragraph fecha = new Paragraph($"FECHA: {DateTime.Now.ToString("dd/mm/yyyy")}").SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT);
            //fecha.SetMarginRight(50);
            //fecha.SetFont(ArialBlack);
            //doc.Add(fecha);

            #endregion

            doc.Add(tPie(pdfDocument));


            doc.Close();
            byte[] bytesStream = ms.ToArray();
            ms.Close();
            return bytesStream;
        }




        private static Table tCuerpo(PdfDocument pdfDocument)
        {
            Table table = new Table(1);
            Cell cell = new Cell();
            cell.SetWidth(PageSize.A4.GetWidth());
            cell.SetHeight(100);
            cell.Add(new Paragraph("Aqui todo el cuerpo del reporte ...").SetTextAlignment(TextAlignment.CENTER).SetFontSize(8));
            table.AddCell(cell.SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
            return table;
        }



        private static Table tPie(PdfDocument pdfDocument)
        {
            string Linia = "_____________________________________";
            string Cip = "CIP  00338389";
            string ApellidosNombres = "NUÑEZ SEGURA CLEMISTENE";
            string Grado = "CMDTE. PNP";
            string Cargo = "JEFE (I) DEL DEPARTAMENTO DE ADMINISTRACION ADMINISTRACION SRH";

            var path = HttpContext.Current.Request.MapPath(@"~/Reports/Images/SelloRedondo.png");
            Image imgSelloRedondo = new Image(ImageDataFactory.Create(path));
            imgSelloRedondo.SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            imgSelloRedondo.SetWidth(85.039f);
            imgSelloRedondo.SetHeight(85.039f);


            var qr = createBarcodeQr(pdfDocument, "https://sigcpd.policia.gob.pe/moarh/Vistas/reportes/reportes.aspx?QR=1&Imp=2&IdRegistro=2640392");
            qr.SetWidth(50);
            qr.SetHeight(50);

            Table table = new Table(3).UseAllAvailableWidth().SetFontSize(7).SetFont(ArialBlack);
            table.AddCell(CeldaSinBorde($"Imp: {DateTime.Now.ToString("dddd dd MMMM yyyy")}"));
            table.AddCell(CeldaSinBorde(""));
            table.AddCell(CeldaSinBorde($"FECHA: {DateTime.Now.ToString("dd/mm/yyyy")}", TextAlignment.CENTER));



            table.AddCell(new Cell(2, 0).Add(qr).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(Border.NO_BORDER));
            table.AddCell(new Cell(2, 0).Add(imgSelloRedondo).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(HorizontalAlignment.RIGHT).SetBorder(Border.NO_BORDER));
            table.AddCell(new Cell().SetHeight(42.5f).SetBorderTop(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));


            table.AddCell(CeldaSinBorde($"{Cip}\n{ApellidosNombres}\n{Grado}\n{Cargo}", TextAlignment.CENTER).SetMaxWidth(75));


            return table;
        }

        private static Cell CeldaSinBorde(string texto, TextAlignment textAlignment = TextAlignment.LEFT)
        {
            Cell cell = new Cell().Add(new Paragraph(texto).SetTextAlignment(textAlignment)).SetBorder(Border.NO_BORDER);
            return cell;
        }


        public static Image CreateBarcode128(PdfDocument pdfDoc, string codigoUnico)
        {
            Barcode128 code128 = new Barcode128(pdfDoc);
            //code128.SetCode(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
            code128.SetCode(codigoUnico);
            code128.SetCodeType(Barcode128.CODE128);
            //code128.SetBaseline(-1);
            //PdfFormXObject xObject = code128.CreateFormXObject(ColorConstants.BLACK, ColorConstants.BLACK, pdfDoc);
            Image code128Image = new Image(code128.CreateFormXObject(ColorConstants.BLACK, ColorConstants.BLACK, pdfDoc));
            return code128Image;
        }


        public static Image createBarcodeQr(PdfDocument pdfDoc, string codigoUnico)
        {
            BarcodeQRCode barcode = new BarcodeQRCode();
            //barcode.SetCode(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
            barcode.SetCode(codigoUnico);
            Image barcodeImage = new Image(barcode.CreateFormXObject(ColorConstants.BLACK, pdfDoc));
            return barcodeImage;
        }

    }
}