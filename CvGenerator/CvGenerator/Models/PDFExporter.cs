using IronPdf;
using Microsoft.Win32;
using System;
using System.IO;

namespace CvGenerator.Models
{
    public class PDFExporter
    {
        private SaveFileDialog saveFileDialog;
        private string filePath = null;

        public PDFExporter()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save your CV";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Pliki pdf (*.pdf)|*.pdf|Pliki XML (*.xml)|*.xml|Pliki źródłowe (*.cs)|*.cs|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
        }       

        public void ExportCvToPDF(string name, string surname, string city, string country, string phone, string email, string date, string school, string experience, string skills)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(filePath);
                saveFileDialog.FileName = Path.GetFileName(filePath);
            }
            bool? wynik = saveFileDialog.ShowDialog();
            if (wynik.HasValue && wynik.Value)
            {
                filePath = saveFileDialog.FileName;
            }

            HtmlToPdf MakePDF = new HtmlToPdf();
            var PdfDoc = MakePDF.RenderHtmlAsPdf(
                "<link href='http://fonts.googleapis.com/css?family=Lato:400,700&subset=latin,latin-ext' rel='stylesheet' type='text/css'>" +
                "<body class='Main' style:' font-family:'Lato', sans-serif;' >" +
                "<div class='Header'style='font-size: 40; padding: 10; font-weight: bold; " +
                "margin-bottom: 40; margin-top: 30; '>" +
                name + " " + surname +
                "</div>" +
                "<div class='SubHeader' style='font-size: 30; color: #707070; padding: 10;'>Personal Data</div>" +
                "<div class='Column' style='font-size: 20; padding: 10;'>" +
                "E-mail: " + email + "<br>" +
                "Phone Number: " + phone + "<br>" +
                "Date of brith: " + date + "<br>" +
                "City: " + city + "<br>" +
                "Country: " + country + "<br>" +
                "</div>" +
                "<div class='SubHeader' style='font-size: 30; color: #707070; padding: 10;'>Education</div>" +
                "<div class='Column' style='font-size: 20; padding: 10;'>" +
                "School: " + school + "<br>" +
                "</div>" +
                "<div class='SubHeader' style='font-size: 30; color: #707070; padding: 10;'>" + IfExperience() + "</div>" +
                "<div class='Column' style='font-size: 20; padding: 10;'>" +
                experience + "<br>" +
                "</div>" +
                "<div class='SubHeader' style='font-size: 30; color: #707070; padding: 10;'>" + IfSkills() + "</div>" +
                "<div class='Column' style='font-size: 20; padding: 10;'>" +
                skills + "<br>" +
    

                "</body>"
                ).SaveAs(filePath);

                System.Diagnostics.Process.Start(filePath);

                /// <summary>
                /// Returns Label "Experience" if User typed any experience
                /// </summary>
                /// <returns></returns>
                string IfExperience()
                {
                    if (experience == "")
                        return String.Empty;
                    else
                        return "Experience";
                }

                /// <summary>
                /// Returns Label "Skills" if User typed any skills
                /// </summary>
                /// <returns></returns>
                string IfSkills()
                {
                    if (skills == "")
                        return String.Empty;
                    else
                        return "Skills";
                }
        }

    }
}
