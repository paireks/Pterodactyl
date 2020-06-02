namespace PterodactylEngine.MarkdownTools
{
    public class Strike
    {
        private readonly string _text;

        public Strike(string text)
        {
            _text = text;
        }

        public string Create()
        {
            return $"~~{_text}~~";
        }
    }
}
