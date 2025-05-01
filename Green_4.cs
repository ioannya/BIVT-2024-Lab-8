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
            string[] surnamesNorm = new string[surnames.Length];

            for (int i = 0; i < surnames.Length; i++)
            {
                surnamesNorm[i] = surnames[i].Trim();
            }

            for (int i = 1; i < surnamesNorm.Length; i++)
            {
                string key = surnamesNorm[i];
                int j = i - 1;
                while (j >= 0 && CompareStrings(surnamesNorm[j], key) > 0)
                {
                    surnamesNorm[j + 1] = surnamesNorm[j];
                    j--;
                }
                surnamesNorm[j + 1] = key;
            }
            _output = surnamesNorm;
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
