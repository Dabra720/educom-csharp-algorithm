using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //List<int> randomList = new List<int>() { -33, 3, 2, 2, 3, 34, 34, 32, 1, 3, 5, 3, -22, -99, 33, -22, 11, 3, 33, 12, -2, -21, 4, 34, 22, 15, 34, -22 };
            //List<int> randomList = new() { 2, 4, 1, 3, 5, 7, 9, 6, 8 };
            List<int> randomList = GetRandomIntegers(2000);
            List<double> randomListD = GetRandomDoubles(30);

            ShowList("RandomList", randomListD);

            var shiftHighestSort = new ShiftHighestSort();
            var rotateSortD = new RotateSort<double>();
            var rotateSort = new RotateSort<int>();

            /*Stopwatch stopWatch = new();
            stopWatch.Start();
            List<int> sortedList1 = shiftHighestSort.Sort(randomList);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            ShowList("SortedList 1", sortedList1);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine();
            Console.WriteLine("Is this list sorted?");
            IsThisSorted(sortedList1);*/

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            var sortedList2 = rotateSortD.Sort(randomListD, Comparer<double>.Default);
            //var sortedList2 = rotateSort.Sort(randomList);
            stopWatch2.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts2 = stopWatch2.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            ShowList("SortedList 2", sortedList2);
            Console.WriteLine("RunTime " + elapsedTime2);
            Console.WriteLine();
            Console.WriteLine("Is this list sorted?");
            //IsThisSorted(sortedList2, Comparer<double>.Default);
            IsThisSorted(sortedList2);
                
        }

        public static List<int> GetRandomIntegers(int n)
        {
            var list = new List<int>(n);
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(-99, 99));
            }

            return list;
        }
        public static List<double> GetRandomDoubles(int n)
        {
            var list = new List<double>(n);
            Random rand = new();
            for(int i = 0; i < n; i++)
            {
                list.Add((rand.NextDouble() * 200) - 100);
            }
            return list;
        }

        /*public static List<T> GetRandomNumbers<T>(int n)
        {
            var list = new List<T>(n);
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(-99, 99));
            }
            return list;
        }*/

        //public static void IsThisSorted<T>(List<T> ints, IComparer<T> comparer)
        public static void IsThisSorted(List<double> ints)
        {
            for(int i = 0; i < ints.Count -1; i++)
            {
                if (ints[i] > ints[i + 1]) { Console.WriteLine("No"); return; }
                //if (comparer.Compare(ints[i], ints[i+1]) > 0) { Console.WriteLine("No"); return; }
            }
            Console.WriteLine("Yes");
        }


        /* Example of a static function */

        /// <summary>
        /// Show the list in lines of 20 numbers each
        /// </summary>
        /// <param name="label">The label for this list</param>
        /// <param name="theList">The list to show</param>
        public static void ShowList<T>(string label, List<T> theList)
        {
            int count = theList.Count;
            if (count > 100)
            {
                count = 300; // Do not show more than 300 numbers
            }
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 10 == 0) // when index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,6:0.00}; ", theList[index]));  // Show each number right aligned within 3 characters, with a comma and a space
            }
            Console.WriteLine();
        }
    }
}
