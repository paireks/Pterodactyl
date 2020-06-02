namespace PterodactylEngine.MarkdownTools
{
    public class Quote
    {
        private readonly string _text;

        public Quote(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"> {_text}";
        }

    }
}
