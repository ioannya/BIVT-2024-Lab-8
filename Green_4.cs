using System;
using System.Linq;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        public string[] Output => _output?.ToArray();

        public Green_4(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = new string[0];
                return;
            }

            string[] surnames = Input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

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
            int minLen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLen; i++)
            {
                if (a[i] != b[i]) return a[i] - b[i];
            }
            return a.Length - b.Length;
        }

        public override string ToString()
        {
            return _output == null || _output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, _output);
        }
    }
}
