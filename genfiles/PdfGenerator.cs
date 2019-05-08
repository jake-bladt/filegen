using System;
using System.Collections.Generic;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace genfiles
{
    public class PdfGenerator
    {

        public bool GenerateRandomPdfs(string rootDir, long targetBytes, int maxBytesPerFile)
        {



            return false;
        }

        public bool GenerateRandomPdf(int maxBytes)
        {
            var doc = new Document(PageSize.LETTER, 10, 10, 10, 10);

        }

    }
}
