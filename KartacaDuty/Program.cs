using System;
using System.IO;

namespace KartacaDuty
{
    class Program
    {
        public static int a = 0;
        public static long BinaryToLong(string strBinary)
        {

            long lReturn = 0;

            if (string.IsNullOrEmpty(strBinary))
                return 0;



            for (int i = strBinary.Length - 1; i > -1; --i)
            {
                
                if (strBinary[i] == '1')
                    lReturn |= (1L << (strBinary.Length - i - 1)); 
            }

            return lReturn;
        }
        public static void Split(string[] a, string[] c, int d)
        {
            string[] b = a[0].Split(" ");

            c[d] = b[0];
            c[d + 1] = b[1];
            c[d + 2] = b[2];
            c[d + 3] = b[3];
            c[d + 4] = b[4];
        }


        static void Main(string[] args)
        {
            string[] firstLetter = new string[] { "M", "N", "O" };
            string[] secondLetter = new string[] { "T", "D", "j", "z" };
            string[] thirdLetter = new string[] { "A", "E", "I", "M", "Q", "U", "Y", "c", "g", "k" };
            string[] lastLetter = new string[] { "w", "x", "y", "z", "0", "1", "2", "3", "4", "5" };
            string[] secondLetterforFirstLine = new string[] { "A", "Q", "g", "w" };
            string[] secondLettersforSecondLine = new string[] { "D", "T", "j", "z" };



            long[] arr = new long[2435];
            string[] text = new string[2435];
            decimal[] arr2 = new decimal[2435];
            string[] arr3 = new string[2435];


            DirectoryInfo di = new DirectoryInfo("C:\\abc");
            foreach (var first in firstLetter)
            {
                foreach (var second in secondLetterforFirstLine)
                {
                    FileInfo[] txts = di.GetFiles(first + second + "==" + ".txt");
                    foreach (var i in txts)
                    {
                        string path = i.DirectoryName;
                        string name = i.Name;
                        string fullpath = Path.Combine(path, name);
                        string[] data = File.ReadAllLines(fullpath);

                        Split(data, text, a);

                        a += 5;

                    }
                }

            }

            foreach (var first in firstLetter)
            {
                foreach (var second in secondLettersforSecondLine)
                {
                    foreach (var third in thirdLetter)
                    {
                        FileInfo[] txts = di.GetFiles(first + second + third + "=" + ".txt");
                        foreach (var i in txts)
                        {
                            string path = i.DirectoryName;
                            string name = i.Name;
                            string fullpath = Path.Combine(path, name);
                            string[] data = File.ReadAllLines(fullpath);

                            Split(data, text, a);
                            a += 5;



                        }
                    }
                }
            }


            foreach (var first in firstLetter)
            {
                foreach (var second in secondLetter)
                {
                    foreach (var third in thirdLetter)
                    {
                        foreach (var last in lastLetter)
                        {
                            FileInfo[] txts = di.GetFiles(first + second + third + last + ".txt");
                            foreach (var i in txts)
                            {
                                string path = i.DirectoryName;
                                string name = i.Name;
                                string fullpath = Path.Combine(path, name);
                                string[] data = File.ReadAllLines(fullpath);

                                Split(data, text, a);
                                a += 5;

                            }
                        }

                    }

                }

            }

            for (int item2 = 0; item2 < 2435; item2++)
            {
                arr[item2] = BinaryToLong(text[item2]);
                arr2[item2] = Convert.ToDecimal(arr[item2]);
                arr3[item2] = Convert.ToChar(arr[item2]).ToString();
            }


            using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(@"c:\Duty\Duty.txt", true))
            {
                for (int i = 0; i < arr3.Length; i++)
                {
                    dosya.Write(arr3[i]);
                }

            }

        }


    }
}
