using System;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace genfiles
{
    public class PdfGenerator
    {

        protected readonly string[] _wordList;

        public PdfGenerator(string[] wordList)
        {
            _wordList = wordList;
        }
        
        public bool GenerateRandomPdfs(string rootDir, long targetBytes, int targetChars)
        {
            


            return false;
        }

        public bool GenerateRandomPdf(string path, int targetChars)
        {
            var charsLeft = targetChars;

            var doc = new Document(PageSize.LETTER, 10, 10, 10, 10);
            var stream = new FileStream(path, FileMode.OpenOrCreate);
            var writer = PdfWriter.GetInstance(doc, stream);

            doc.Open();
            doc.Add(new Paragraph("Secret and Confidential."));

            doc.Close();
            writer.Close();
            stream.Close();

            return false;
        }

    }
}
