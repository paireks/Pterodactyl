namespace PterodactylEngine.MarkdownTools
{
    public class Underline
    {
        private readonly string _text;

        public Underline(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"<u>{_text}</u>";
        }
    }
}
