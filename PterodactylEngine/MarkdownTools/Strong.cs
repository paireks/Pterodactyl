namespace PterodactylEngine.MarkdownTools
{
    public class Strong
    {
        private readonly string _text;

        public Strong(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"**{_text}**";
        }
    }
}
