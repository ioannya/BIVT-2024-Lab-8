using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        private string _input;
        public string[] Output => _output;

        public Green_4(string input) : base(input)
        {
            _input = input;
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }
            string[] surnames = Input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < surnames.Length; i++)
            {
                surnames[i] = surnames[i].Trim();
            }

            for (int i = 1; i < surnames.Length; i++)
            {
                string key = surnames[i];
                int j = i - 1;
                while (j >= 0 && CompareStrings(surnames[j], key) > 0)
                {
                    surnames[j + 1] = surnames[j];
                    j--;
                }
                surnames[j + 1] = key;
            }
            _output = surnames;
        }
        private int CompareStrings(string a, string b)
        {
            int minlen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minlen; i++)
            {
                if (a[i] != b[i]) return Math.Sign(a[i] - b[i]);
            }
            return Math.Sign(a.Length - b.Length);
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, Output);
        }
    }
}
