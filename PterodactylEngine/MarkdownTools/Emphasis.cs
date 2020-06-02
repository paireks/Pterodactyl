namespace PterodactylEngine.MarkdownTools
{
    public class Emphasis
    {
        private readonly string _text;

        public Emphasis(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"*{_text}*";
        }
    }
}
