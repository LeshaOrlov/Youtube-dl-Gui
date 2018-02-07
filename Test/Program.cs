using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = @"[download]   0.0% of 3.00MiB at 63.78KiB/s ETA 00:48";
            Regex regex = new Regex(@"[0-9]+(?=\.[0-9]*%)");
            MatchCollection matches = regex.Matches(line);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }

            Console.ReadKey();
        }

        
    }
}
