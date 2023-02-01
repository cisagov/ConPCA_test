using CSET_Selenium.DriverConfiguration;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NUnit.Framework;
using System;
using System.Text;

namespace ConPCA_Selenium.Tests.Con_PCA.Scrach
{
    [TestFixture]
    public class PDFContentTest : BaseTest
    {
        private SoftAssertions softAssertions = new SoftAssertions();

        [Test]
        public void PDFFileTest()
        {

            PdfReader.unethicalreading = true;
            PdfReader reader = new PdfReader("C:\\tmp\\CISA_PCA_CYCLE_report.pdf");

            softAssertions.Add("The number of pages is incorrect.", 17, reader.NumberOfPages);

            StringBuilder reportBd = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                reportBd.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            String reportText = reportBd.ToString();
            String section1 = "1. How to Use This Report";
            String section2 = "TOTAL TARGETS";
            String section3 = "3. Framework";
            String section4 = "4. Red Flags and Sophisticated Techniques";
            String section5 = "5. Performance Over Time";
            String section6 = "6. Time Intervals";

            softAssertions.Add("Didn't find section " + section1, true, reportText.Contains(section1));
            softAssertions.Add("Didn't find section " + section2, true, reportText.Contains(section2));
            softAssertions.Add("Didn't find section " + section3, true, reportText.Contains(section3));
            softAssertions.Add("Didn't find section " + section4, true, reportText.Contains(section4));
            softAssertions.Add("Didn't find section " + section5, true, reportText.Contains(section5));
            softAssertions.Add("Didn't find section " + section6, true, reportText.Contains(section6));
            Console.WriteLine(reportText);
            softAssertions.AssertAll();
        }
    }
}
