using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Heading
    {
        private string _text;
        private int _level;

        public Heading(string text, int level)
        {
            Text = text;
            Level = level;
        }

        public string Create()
        {
            string levelHash = "";
            for (int i = 0; i < Level; i++)
            {
                levelHash += "#";
            }
            string reportPart = levelHash + " " + Text;

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public int Level
        {
            get { return _level; }
            set {
                if (new List<int> { 1, 2, 3, 4, 5, 6 }.Contains(value) )
                {
                    _level = value;
                }
                else
                {
                    throw new ArgumentException("Level should be an integer between 1 and 6");
                }
            }
        }
    }
}
