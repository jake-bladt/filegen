using System;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace genfiles
{
    public class PdfGenerator
    {
        public class Plan
        {
            public int Files { get; set; }
            public int Directories { get; set; }
            public int Depth { get; set; }
        }

        public static readonly int TargetParagraphLength = 500;
        public static readonly int TargetHandleCountPerDirectory = 500;
        public static int AverageFileSize = 120;

        public readonly string _rootPath;
        protected readonly TextGenerator _textGen;

        public PdfGenerator(string rootPath, TextGenerator textGen)
        {
            _rootPath = rootPath;
            _textGen = textGen;
        }

        public Plan GetPlan(int targetBytes)
        {
            var files = targetBytes / AverageFileSize + 1;
            var dirs = files / TargetHandleCountPerDirectory + 1;
            var depth = (int)Math.Log(dirs, TargetHandleCountPerDirectory) + 1;

            return new Plan
            {
                Files = files,
                Directories = dirs,
                Depth = depth
            };
        }

        public string GetNextFileName(Plan plan, string rootPath, string lastFileName)
        {
            var newDir = String.IsNullOrEmpty(lastFileName);
            string lastPath;

            if (!newDir)
            {
                lastPath = Path.GetFullPath(lastFileName);
                var lastPathFileCount = new DirectoryInfo(lastPath).GetFiles().Length;
                if (lastPathFileCount >= TargetHandleCountPerDirectory) newDir = true;
            }

            if (newDir)
            {

            }
            else
            {

            }

        }

        public string GetNextDirectoryName(Plan plan, string currentDirName)
        {
            // All file paths are at max depth. All paths above max depth are folders only

        }

        public bool GenerateRandomPdfs(string rootDir, int targetKBytes, Action<String> outputFn)
        {
            var plan = GetPlan(targetKBytes);
            outputFn($"Generating {plan.Files:#,##0} file(s) in {plan.Directories:#,##0} directories to a depth of {plan.Depth}.");



            return false;
        }

        public bool GenerateRandomPdf(string path, int targetChars)
        {
            var charsLeft = targetChars;

            var doc = new Document(PageSize.LETTER, 10, 10, 10, 10);
            var stream = new FileStream(path, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, stream);

            doc.Open();

            var slack = targetChars * 0.01;
            while (charsLeft > slack)
            {
                var para = _textGen.GetRandomParagraph(charsLeft);
                charsLeft -= para.Length;
                doc.Add(new Paragraph(para));
            }

            doc.Close();
            writer.Close();
            stream.Close();

            return false;
        }


    }
}
