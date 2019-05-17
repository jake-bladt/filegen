using System;
using System.Collections.Generic;
using System.Text;

namespace genfiles
{
    public class TextGenerator
    {
        protected readonly string[] _wordList;
        protected readonly int _targetParagraphLength;

        public TextGenerator(string[] wordList, int targetParagraphLength)
        {
            _wordList = wordList;
            _targetParagraphLength = targetParagraphLength;
        }

        public string GetRandomParagraph(int characterBudget)
        {
            var target = Math.Min(characterBudget, _targetParagraphLength);
            var sb = new StringBuilder();
            var rng = new Random();

            while (target > 0)
            {
                var wordCount = rng.NextDouble() * 12.0 + 3;
                var sentence = GetRandomSentence((int)wordCount);
                sb.Append(sentence);
                target -= sentence.Length;
                if (target > 0) sb.Append(" ");
            }

            sb.Append('\n');
            return sb.ToString();
        }

        public string GetRandomSentence(int wordCount)
        {
            var sb = new StringBuilder("The");
            var rng = new Random();
            for (int i = 0; i < wordCount - 1; i++)
            {
                sb.Append(" ");
                sb.Append(GetRandomWord());
            }

            sb.Append(".");
            return sb.ToString();

        }

        public string GetRandomDirName()
        {
            return $"{GetRandomWord()}-{GetRandomWord()}";
        }

        public string GetRandomWord()
        {
            var rng = new Random();
            var seed = rng.NextDouble() * _wordList.Length;
            return _wordList[(int)seed];
        }

    }
}
