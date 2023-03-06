using api_calc_net.Models;
using System.Data;

namespace api_calc_net.Services
{
    public class CalcService
    {
        public List<decimal> CalcResults(List<CalcInput> inputs)
        {
            List<decimal> results = new();
            inputs.ForEach(calc => results.Add(Calculate(calc)));
            return results;
        }


        public decimal Calculate(CalcInput calc)
        {
            int x = calc.X;
            int y = calc.Y;
            string? operation = calc.Operation;
            CheckDivisionByZero(operation + y);
            double result = operation switch
            {
                "+" => x + y,
                "-" => x - y,
                "*" => x * y,
                "/" => (double)x / y,
                _ => 0
            };
            return Math.Round((decimal)result, 2);
        }
        public void CheckDivisionByZero(string input)
        {
            if (input.Contains("/0"))
            {
                throw new BadHttpRequestException("Cannot divide by zero");
            }
        }

        public List<decimal> CalculateFromString(List<string> input)
        {
            List<decimal> list = new();
            ValidateStringList(input);
            DataTable dt = new();
            input.ForEach(str => list.Add(Convert.ToDecimal(dt.Compute(str, ""))));
            list = list.Select(num => Math.Round(num, 2)).ToList();
            return list;
        }

        public void ValidateStringList(List<string> input)
        {
            foreach (string str in input)
            {
                CheckDivisionByZero(str);
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (i % 2 == 0 && !Char.IsDigit(c))
                    {
                        throw new BadHttpRequestException("Invalid input format");
                    }
                    else if (i % 2 == 1 && c != '*' && c != '/' && c != '+' && c != '-')
                    {
                        throw new BadHttpRequestException("Invalid input format");
                    }
                }
            }
        }

        public List<MinMaxInt> GetMinMaxIntList(List<List<int>> input)
        {
            List<MinMaxInt> minMaxList = new();
            foreach (List<int> list in input)
            {
                ValidateList(list);
                list.Sort(Comparer<int>.Create((x, y) => y.CompareTo(x)));
                minMaxList.Add(new MinMaxInt(list[0], list[^1]));
            }
            return minMaxList;
        }

        public void ValidateList(List<int> list)
        {
            if (list.Count > 5)
            {
                throw new BadHttpRequestException("array is too long");
            }
        }
    }
}
