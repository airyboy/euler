using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public static class Helper
    {
        public static int[] ToArray(this int num)
        {
            var lst = new List<int>();
            var quotient = (int)Math.Floor((decimal)num / 10);
            var remainder = num % 10;
            lst.Add(remainder);
            while (quotient > 0)
            {
                remainder = quotient % 10;
                lst.Add(remainder);
                quotient = (int)Math.Floor((decimal)quotient / 10);
            }

            return lst.ToArray();
        }

        public static int ToInt(this int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i] * (int)Math.Pow(10, i);
            }

            return result;
        }
    }
    public class Program
    {
        static List<int> lst = new List<int>();
        static List<decimal> primes = new List<decimal>(new decimal[] { 2 });
        public static void Main(string[] args)
        {
            int n = 478484;

            var arr = n.ToArray();

            Console.WriteLine(string.Join(",", arr.Select(a => a.ToString())));

            Console.WriteLine(arr.ToInt());
            // ErathosphenSieve();

            // var dig6 = lst.Where(a=>a > 100000 & a <= 999999 & HasRepeatedDigits(a));

            // Console.WriteLine(string.Join(",", dig6.Take(100).Select(a => a.ToString())));
            // Console.WriteLine(dig6.Count());
        }



        static bool HasRepeatedDigits(int num)
        {
            var dict = new Dictionary<char, int>();
            var arr = num.ToString().ToCharArray();

            var result = false;
            foreach (var ch in arr)
            {
                if (dict.ContainsKey(ch))
                {
                    result = true;
                    break;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }
            return result;
        }

        private static void ErathosphenSieve()
        {
            var limit = 100000000;

            var crosslimit = (int)Math.Floor(Math.Sqrt(limit));

            var sieve = new bool[limit];

            for (var i = 3; i <= crosslimit; i += 2)
            {
                if (sieve[i] == false)
                {
                    for (var j = i * i; j < limit; j += i)
                    {
                        sieve[j] = true;
                    }
                }
            }

            for (int i = 3; i < limit; i += 2)
            {
                if (sieve[i] == false)
                {
                    lst.Add(i);
                }
            }

            Console.WriteLine(lst.Count());
        }
    }
}
