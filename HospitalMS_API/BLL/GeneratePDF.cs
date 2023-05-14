using BLL.DTOs;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;

namespace BLL
{
    public class GeneratePDF
    {
        public static string RenderToString(string viewName, AppointmentDTO obj)
        {
            var razorEngineService = Engine.Razor;
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);
            var result = razorEngineService.RunCompile(viewContent, filePath, null, obj);
            return result;
        }
        public static string RenderToString(string viewName, OPDBillAllDetailsDTO obj)
        {
            var razorEngineService = Engine.Razor;
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);
            var result = razorEngineService.RunCompile(viewContent, filePath, null, obj);
            var count = 0;
            return result;
        }

        public static byte[] GetPDF(string viewName, AppointmentDTO obj)
        {
            {
                var html = RenderToString(viewName, obj).ToString();
                MemoryStream ms = new MemoryStream();
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                pdfDocument.GetDocumentInfo().SetTitle("appointment_"+obj.Id);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
              
                pdfDocument.Close();
                byte[] pdfBytes = ms.ToArray();
                return pdfBytes;
            }
        } 
        public static byte[] GetPDF(string viewName, OPDBillAllDetailsDTO obj)
        {
            {
                var html = RenderToString(viewName, obj).ToString();
                MemoryStream ms = new MemoryStream();
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(ms));
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                pdfDocument.GetDocumentInfo().SetTitle("OPD_Bill_"+obj.OPDBillId);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
              
                pdfDocument.Close();
                byte[] pdfBytes = ms.ToArray();
                return pdfBytes;
            }
        }
    }
}
