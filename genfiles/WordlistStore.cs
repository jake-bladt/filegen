using System;
using System.Collections.Generic;
using System.IO;

namespace genfiles
{
    public class WordlistStore
    {
        protected readonly string _path;

        public WordlistStore(string path)
        {
            _path = path;
        }

        public string[] GetWordlst()
        {
            var words = new List<String>();
            string line;
            var reader = new StreamReader(_path);

            while(!String.IsNullOrEmpty(line = reader.ReadLine()))
            {
                if(line.Length > 0) words.Add(line);
            }
            return words.ToArray();
        }

    }
}
