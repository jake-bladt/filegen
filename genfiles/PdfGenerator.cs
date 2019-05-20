using System;
using System.Data;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

namespace genfiles
{
    public class PdfGenerator
    {
        protected readonly TextGenerator _textGen;
        public readonly Action<String> Output;

        public PdfGenerator(TextGenerator textGen, Action<String> output)
        {
            _textGen = textGen;
        }

        public double GenerateRandomPdf(string path, int targetChars)
        {
            var charsLeft = targetChars;
            var doc = new Document(PageSize.LETTER, 10, 10, 10, 10);
            var stream = new FileStream(path, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, stream);

            try
            {
                doc.Open();

                var slack = targetChars * 0.01;
                while (charsLeft > slack)
                {
                    var para = _textGen.GetRandomParagraph(charsLeft);
                    charsLeft -= para.Length;
                    doc.Add(new Paragraph(para));
                }
            }
            catch (Exception ex)
            {
                Output(ex.Message);
                throw;
            }
            finally
            {
                doc.Close();
                writer.Close();
                stream.Close();
            }

            var fileInfo = new FileInfo(path);
            return fileInfo.Length / 1024.0;

        }

    }
}
