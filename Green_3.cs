using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Green_3 : Green
    {
        private string[] _output;
        
        private string _sequence;
        public string[] Output => _output;

        public Green_3(string input, string sequence) : base(input)
        {
            _output = null;
            _sequence = sequence;
        }
        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }

            string normal = Input.ToLower();
            string searchSequence = _sequence.ToLower();
            char[] sep = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] text = normal.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            
            string[] selected = new string[0];
            foreach (var word in text)
            {
                bool onlyLetters = true;
                foreach (var ch in word)
                {
                    if (!char.IsLetter(ch))
                    {
                        onlyLetters = false;
                        break;
                    }
                }

                if (!onlyLetters)
                    continue;

                if (word.Contains(searchSequence))
                {
                    if (!selected.Contains(word))
                    {
                        Array.Resize(ref selected, selected.Length + 1);
                        selected[selected.Length - 1] = word;
                    }
                }
            }

            _output = selected;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, Output); 
        }
    }
}
