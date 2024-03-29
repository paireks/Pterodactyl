﻿using System;

namespace PterodactylEngine
{
    public class Quote
    {
        private string _text;

        public Quote(string text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "> " + Text;

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
