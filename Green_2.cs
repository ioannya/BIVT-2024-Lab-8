using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[] _output;
        public char[] Output => _output?.ToArray();

        public Green_2(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new char[0];
                return;
            }
            string normal = Input.ToLower();
            
            char[] sep = { ' ', '.', '!', '?', ',', ':', '\"',';', '–', '(', ')', '[', ']', '{', '}', '/'};
           
            char[] letters = new char[0];
            
            int[] counts = new int[0];
            
            for (int i = 0; i < normal.Length; i++)
            {
                char current = normal[i];

                if (char.IsLetter(current) && (i == 0 || sep.Contains(normal[i - 1])))
                {
                    int index = Array.IndexOf(letters, current);

                    if (index == -1)
                    {
                        Array.Resize(ref letters, letters.Length + 1);
                        Array.Resize(ref counts, counts.Length + 1);
                        letters[letters.Length - 1] = current;
                        counts[counts.Length - 1] = 1;
                    }
                    else
                    {
                        counts[index]++;
                    }
                }
            }

            for (int i = 0; i < letters.Length - 1; i++)
            {
                for (int j = i + 1; j < letters.Length; j++)
                {
                    if (counts[i] < counts[j] || (counts[i] == counts[j] && letters[i] > letters[j]))
                    {
                        (letters[i], letters[j]) = (letters[j], letters[i]);
                        (counts[i], counts[j]) = (counts[j], counts[i]);
                    }
                }
            }

            _output = letters;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", Output);
        }
    }
}

