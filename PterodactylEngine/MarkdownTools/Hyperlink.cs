namespace PterodactylEngine.MarkdownTools
{
    public class Hyperlink
    {
        private readonly string _text;
        private readonly string _link;

        public Hyperlink(string text, string link)
        {
            _text = text;
            _link = link;
        }

        public string Create()
        {
            return $"[{_text}]({_link})";
        }
    }
}

