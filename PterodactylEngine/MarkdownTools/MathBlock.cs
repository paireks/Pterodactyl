using System;

namespace PterodactylEngine.MarkdownTools
{
    public class MathBlock
    {
        private readonly string _text;

        public MathBlock(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"$${Environment.NewLine}{_text}{Environment.NewLine}$$";
        }
    }
}
