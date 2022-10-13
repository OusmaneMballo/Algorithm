using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        //public class A
        //{
        //    public string str = "foo";
        //    public class B { }
        //    public static void Main(String[] args)
        //    {
        //        A.B b = new A.B();
        //        Console.WriteLine(b.str);
        //        Console.ReadKey();
        //    }
        //}
        /*=========ERROR COMPILATION==============*/
        //public class A
        //{
        //    protected string Str { get; set; }
        //}
        //public class B : A {
        //  //===========Str no visible in B===========
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var translated = Translate("hello, secret meeting to night");
            //Console.WriteLine(translated);

            //var cities = new Dictionary<string, string>()
            //{
            //    { "SN", "Dakar Tambacounda"},
            //    { "UK", "London Liverpool"},
            //    { "USA", "Washington New York"},
            //    { "IN", "Mumbai Pune"}
            //};
            //foreach(var c in cities.Keys)
            //{
            //    Console.WriteLine("{0} ===> {1}",c,cities[c]);
            //}

            //int[] array1 = new int[] { 1, 3, 5, 7, 9, 8, 4 };
            //var subTab = array1[^4..^0];
            //foreach (int i in subTab) { Console.WriteLine(i); }

            //var fruitz = new[] { "pomme", "orange", "abricot", "kiwi" }.Max(c =>c.Length);
            //Console.WriteLine(fruitz);

            //int[] array1 = new int[] { 1, 3, 5, 7, 9, 8, 4 };
            //ArrayMaxima(array1);

            //Console.WriteLine("on a {0} nombre paire(s)", Pairs(33));

            //var encodedText = Encoded("aaaabcccaaa");
            //Console.WriteLine(encodedText);

            //var resultCount = CountWords(new string[] { "the", "dog", "got", "the", "bone" });
            //foreach(var word in resultCount)
            //{
            //    Console.WriteLine(word);
            //}

            //var result = Degree(new int[] { 2, 3, 5, -7, 9, 21, -4 });

            //var result = FoundSumPair(new int[] { 1, 2, 3, 6, 8, 1, 6 }, 5);
            //foreach (var val in result)
            //{
            //    Console.WriteLine(val);
            //}

            //var result = HowManyPairs(10);
            var result = Factoriel(3);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        public static int[] FoundSumPair(int[] array, int sum)
        {
            int[] result = new int[2];

            if(array != null)
            {
                for(var i = 0; i < array.Length; i++)
                {
                    for(var j=i+1; j < array.Length; j++)
                    {
                        var x = array[i] + array[j];
                        if(x == sum)
                        {
                            result[0] = array[i];
                            result[1] = array[j];

                            return result;
                        }
                    }
                }
            }

            return result;
        }

        public static int Degree(int[] degrees)
        {
            var min = degrees[0];
            for(var i = 1; i< degrees.Length; i++)
            {
                if(Math.Abs(degrees[i]) < Math.Abs(min))
                {
                    min = degrees[i];
                }
            }
            
            return min;
        }

        public static string Translate(string text)
        {
            var textTranslated = "";
            if (text != null)
            {
                char tmp = '.';
                foreach (char c in text)
                {
                    if (tmp != 'a' && tmp != 'e' && tmp != 'i' && tmp != 'o' && tmp != 'u')
                    {
                        if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                        {
                            textTranslated += 'a';
                            textTranslated += 'v';
                        }
                        tmp = c;
                    }
                    else
                    {
                        tmp = c;
                    }
                    textTranslated += c;
                }
            }
            return textTranslated;
        }

        public static void ArrayMaxima(int[] A)
        {
            if(A.Length != 0 && A != null)
            {
                var maxP = 0;
                var maxI = 0;

                for (var i = 0; i < A.Length; i++)
                {
                    if(A[i]%2 == 0)
                    {
                        for(var j=i+1; j < A.Length; j++)
                        {
                            if (A[j]%2 == 0)
                            {
                                var difAbs = Math.Abs(A[i] - A[j]);
                                if(difAbs > maxP)
                                {
                                    maxP = difAbs;
                                }
                            }
                        }
                    }
                }

                for (var i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 != 0)
                    {
                        for (var j = i + 1; j < A.Length; j++)
                        {
                            if (A[j] % 2 != 0)
                            {
                                var difAbs = Math.Abs(A[i] - A[j]);
                                if (difAbs > maxI)
                                {
                                    maxI = difAbs;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("X = {0}\nY = {1}\nX + Y = {2}", maxP, maxI, maxP+maxI);
            }
            else
            {
                Console.WriteLine("Votre tableau est vide !");
            }
        }

        public static int Pairs(int n)
        {
            if(n > 1)
            {
                return n/2;
            }

            return 0;
        }

        public static string Encoded(string plainText)
        {
            if (plainText != null)
            {
                var encodedText = string.Empty;
                var cpt = 1;
                for(var i = 0; i < plainText.Length; i++)
                {
                    if(i != (plainText.Length - 1))
                    {
                        if (plainText[i] == plainText[i + 1])
                        {
                            cpt++;
                        }
                        else
                        {
                            encodedText += cpt.ToString() + plainText[i];
                            cpt = 1;
                        }
                    }
                    else
                    {
                        encodedText += cpt.ToString() + plainText[i];
                    }
                    
                }

                return encodedText;
            }
                return null;
        }

        public static int[] CountWords(string[] word)
        {
            if(word != null)
            {
                var tab = new int[word.Length];
                Array.Sort(word);
                var cpt = 1;
                for (var i=0; i < word.Length; i++)
                {
                    if (i != (word.Length - 1))
                    {
                        if (word[i] == word[i + 1])
                        {
                            cpt++;
                        }
                        else
                        {
                            tab[i] = cpt;
                            cpt = 1;
                        }
                    }
                    else
                    {
                        tab[i-1] = cpt;
                    }
                }

                return tab;
            }
            return null;
        }

        public static bool IsTwins(string a, string b)
        {
            if (a.Length != b.Length) return false;
            var bSet = new HashSet<char>(b.ToLower());
            var aSet = new HashSet<char>(a.ToLower());
            return aSet.SetEquals(bSet);
        }

        public static string LocateUniversFormula()
        {
            var files = Directory.GetFiles("/tmp/documents", "universe-formula.*", SearchOption.AllDirectories);
            if(files.Length > 0)
            {
                return files[0];
            }
            return null;
        }

        public static int HowManyPairs(int n)
        {
            var result = 0;

            if(n >= 2 && n <= 10000)
            {
                for(var i = 1; i <= n; i++)
                {
                    if(i % 2 == 0)
                    result++;
                }
            }

            return result;
        }
        
        public static int Factoriel(int n)
        {
            if(n == 1)
            {
                return 1;
            }

            return n * Factoriel(n-1);
        }

        public static string Solve(int width, int height, int length, int mass)
        {
            var volume = width * height * length;
            var res = volume >= 1_000_000 || width >= 150 || length >= 150 || height >= 150;
            var lourd = mass >= 20;

            if (!res || !lourd)
                return "STANDARD";

            if (res && lourd)
                return "REJECTED";

            if (res || lourd)
                return "SPECIAL";

            return "REJECTED";
        }
    }
}
