namespace Exercise_filter
{
    internal class Program
    {
        public static void filter()
        {
            List<string> words = new List<string> { "aaaa", "bbbb", "cccccc", "aaaa", "aaaa", "aaaa", "aaaaa" };
            List<string> filtredWords = words
                .Where(w => !w.Contains('x'))
                .Where(w => w.Length >= 4)
                .Where(w => w.Length == (int)words.Average(w => w.Length))
                .ToList();

            filtredWords.ForEach(w => Console.WriteLine(w));
        }

        public static void epsilon()
        {
            List<string> words = new List<string> { "bonjour" };
            Dictionary<string, double> ahe = new Dictionary<string, double>(new[] 
            { 
                new { Key = "e", Value = 12.10 }, new { Key = "a", Value = 7.11 }, new { Key = "i", Value = 6.59 }, new { Key = "s", Value = 6.51 }, 
                new { Key = "n", Value = 6.39 }, new { Key = "r", Value = 6.07 }, new { Key = "t", Value = 5.92 }, new { Key = "o", Value = 5.02 }, 
                new { Key = "l", Value = 4.96 }, new { Key = "u", Value = 4.49 }, new { Key = "d", Value = 3.67 }, new { Key = "c", Value = 3.18 }, 
                new { Key = "m", Value = 2.62 }, new { Key = "p", Value = 2.49 }, new { Key = "é", Value = 1.94 }, new { Key = "g", Value = 1.23 }, 
                new { Key = "b", Value = 1.14 }, new { Key = "v", Value = 1.11 }, new { Key = "h", Value = 1.11 }, new { Key = "f", Value = 1.11 },
                new { Key = "q", Value = 0.65 }, new { Key = "y", Value = 0.46 }, new { Key = "x", Value = 0.38 }, new { Key = "j", Value = 0.34 }, 
                new { Key = "è", Value = 0.31 }, new { Key = "à", Value = 0.31 }, new { Key = "k", Value = 0.29 }, new { Key = "w", Value = 0.17 }, 
                new { Key = "z", Value = 0.15 }, new { Key = "ê", Value = 0.08 }, new { Key = "ç", Value = 0.06 }, new { Key = "ô", Value = 0.04 }, 
                new { Key = "â", Value = 0.03 }, new { Key = "î", Value = 0.03 }, new { Key = "û", Value = 0.02 }, new { Key = "ù", Value = 0.02 }, 
                new { Key = "ï", Value = 0.01 }, new { Key = "á", Value = 0.01 }, new { Key = "ü", Value = 0.01 }, new { Key = "ë", Value = 0.01 }, 
                new { Key = "ö", Value = 0.01 }, new { Key = "í", Value = 0.01 } 
            }.ToDictionary(x => x.Key, x => x.Value));

            var doubles = new List<Tuple<char, double>>();

            words.ForEach(w =>
            {
                foreach (char l in w)
                {
                    if (!(doubles.Select(d => d.Item1).ToList().Contains(l)))
                    {
                        doubles.Add(Tuple.Create(l, ahe[l.ToString()] /100/ w.Where(a => a == l).Sum(_ => 1)));
                    }
                }
            });

            Console.WriteLine(doubles.Select(d => d.Item2).ToList().Sum(_ => _));

            /*Console.ReadLine().ToList().ForEach(w => {
                if (doubles.Contains(ahe[w.ToString()]))
                {
                    doubles[doubles.IndexOf(ahe[w.ToString()])] = doubles[doubles.IndexOf(ahe[w.ToString()])] / 2;
                }
                else
                {
                    doubles.Add(ahe[w.ToString()]);
                }
            });

            Console.WriteLine(doubles.Sum());*/
        }

        static void Main(string[] args)
        {
            // filter();

            epsilon();
        }
    }
}