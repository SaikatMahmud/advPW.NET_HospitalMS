using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;
using System.IO;
using BLL.DTOs;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Html2pdf;

//using iText.Html2pdf;
//using iTextSharp.text;
//using iTextSharp.text.pdf;


namespace BLL.Services
{
    public class RenderTestService
    {
        public static string RenderViewToString(string viewName, RenderTestDTO model)
        {
            model = new RenderTestDTO()
            {
                Name = "Saikat",
                Age = 22,
                Gender = "Male"
            };
            var razorEngineService = Engine.Razor;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\BLL\\Views\\" + viewName + ".cshtml");
            var viewContent = File.ReadAllText(filePath);

            var result = razorEngineService.RunCompile(viewContent, filePath, null, model);

            return result;
        }
        public static MemoryStream GetPDF()
        {
            {
                var model = new RenderTestDTO();
                // Render the view to a string
                var html = RenderViewToString("AppointmentRecept", model).ToString();

                //// Create a PDF document
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    Document document = new Document();
                //    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                //    document.Open();

                //    // Add the HTML content to the PDF
                //    using (StringReader stringReader = new StringReader(html))
                //    {
                //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                //    }

                //    document.Close();

                //    // Return the PDF as a file download
                //    return File(memoryStream.ToArray(), "application/pdf", "MyPDF.pdf");

                // HTML string to convert to PDF


                // Create a PDF document
                using (var pdfStream = new MemoryStream())
                {
                    var writer = new PdfWriter(pdfStream);
                    var pdf = new PdfDocument(writer);

                    // Convert HTML to PDF using pdfHTML
                    ConverterProperties converterProperties = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(html, pdf, converterProperties);

                    pdf.Close();
                    writer.Close();
                    return pdfStream;
                    // Return the PDF as a file download
                    //return File(pdfStream.ToArray(), "application/pdf", "MyPDF.pdf");
                }
            }
        }
    }


}
