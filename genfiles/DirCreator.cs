using System;
using System.Collections.Generic;
using System.IO;

namespace genfiles
{
    public class DirCreator
    {
        protected readonly TextGenerator _textGen;
        protected readonly Action<string> Output;
        protected readonly Queue<String> _pathQueue;
        protected string _currentDir;

        public DirCreator(TextGenerator textGen, string rootPath, Action<string> outputFn)
        {
            _textGen = textGen;
            Output = outputFn;
            _pathQueue = new Queue<string>();
            _currentDir = rootPath;
        }

        public string GetNextSubdirectory()
        {
            var newPath = String.Empty;
            while (String.IsNullOrEmpty(newPath))
            {
                var currentPath = _currentDir;
                var subdirCount = new DirectoryInfo(currentPath).GetDirectories().Length;
                if (subdirCount >= Program.TargetHandleCount / 2)
                {
                    _currentDir = _pathQueue.Dequeue();
                }
                else
                {
                    var newDirName = _textGen.GetRandomWord();
                    newPath = Path.Combine(currentPath, newDirName);
                    Directory.CreateDirectory(newPath);
                    _pathQueue.Enqueue(newPath);
                }
            }
            return newPath;
        }

    }
}
