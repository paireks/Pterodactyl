namespace PterodactylEngine.MarkdownTools
{
    public class Image
    {
        private readonly string _text;
        private readonly string _path;

        public Image(string text, string path)
        {
            _text = text;
            _path = path;
        }

        public string Create()
        {
            return $"![{_text}]({_path})";
        }
    }
}

