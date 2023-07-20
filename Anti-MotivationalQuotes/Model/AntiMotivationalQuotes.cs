using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_MotivationalQuotes.Model
{
    internal class AntiMotivationalQuotes
    {
        private int _MAX_STEP = 10;
        public int MAX_STEP { get { return _MAX_STEP; } }

        private string[] quotesList;
        public string[] QuotesList { get { return quotesList; } set { quotesList = value; } }

        private int showIndex = 0;
        public int ShowIndex { get { return showIndex; } set { showIndex = value; } }

        private int step = 1;
        public int Step { get { return step; } set { step = value; } }

        private int lines = 0;
        public int Lines { get { return lines; } set { lines = value; } }
    }
}
