using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output;
        private (char, double)[] Output => _output;
        public Green_1(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new (char, double)[0];
                return;
            }
            string normalized = Input.ToLower();
            char[] alphabet = new char[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й','к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф','х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };
            int[] count = new int[alphabet.Length];
            int total = 0;
            for (int i = 0; i < normalized.Length; i++)
            {
                char a = normalized[i];
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (a == alphabet[j])
                    {
                        count[j]++;
                        break;
                    }
                }
                if (char.IsLetter(a)) { total++; }
            }

            if (total == 0)
            {
                _output = new (char, double)[0];
                return;
            }
            int frequency = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    frequency++;
                }
            }

            (char, double)[] result = new (char, double)[frequency];
            int temp = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (count[i] > 0)
                {
                    result[temp] = (alphabet[i], (double)count[i] / total);
                    temp++;
                }
            }
            _output = result;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine,
                Output.Select(pair => $"{pair.Item1} - {pair.Item2:F4}"));
        }
    }
}
