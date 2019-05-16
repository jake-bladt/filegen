using System;
using System.IO;
using System.Text;

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
            var sb = new StringBuilder();

            for (int i = 0; i < 128; i++)
            {
                var para = GetRandomParagraph(4);
                doc.Add(new Paragraph(para));
            }

            doc.Close();
            writer.Close();
            stream.Close();

            return false;
        }

        public string GetRandomParagraph(int sentenceCount)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < sentenceCount; i++)
            {
                sb.Append(GetRandomSentence(12));
                if (i < sentenceCount - 1) sb.Append(" ");
            }

            return sb.ToString();
        }

        public string GetRandomSentence(int wordCount)
        {
            var sb = new StringBuilder("The");
            var rng = new Random();
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(" ");
                var seed = rng.NextDouble() * _wordList.Length;
                sb.Append(_wordList[(int)seed]);
            }

            sb.Append(".");
            sb.Append('\n');
            return sb.ToString();

        }

    }
}
