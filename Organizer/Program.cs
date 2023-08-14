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
            //List<int> theList = new List<int>() { -33, 3, 2, 2, 3, 34, 34, 32, 1, 3, 5, 3, -22, -99, 33, -22, 11, 3, 33, 12, -2, -21, 4, 34, 22, 15, 34, -22 };
#if DEBUG
            try
            {
                List<int> randomList = GetRandomIntegers(2000);

                ShowList("RandomList", randomList);

                ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
                RotateSort rotateSort = new RotateSort();

                Stopwatch stopWatch = new Stopwatch();
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

                if (isThisSorted(sortedList1)) Console.WriteLine("SortedList 1 is Sorted");

                Stopwatch stopWatch2 = new Stopwatch();
                stopWatch2.Start();
                List<int> sortedList2 = rotateSort.Sort(randomList);
                stopWatch2.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts2 = stopWatch2.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts2.Hours, ts2.Minutes, ts2.Seconds,
                    ts2.Milliseconds / 10);
                ShowList("SortedList 2", sortedList2);
                Console.WriteLine("RunTime " + elapsedTime2);
                if (isThisSorted(sortedList2)) Console.WriteLine("SortedList 2 is Sorted");
            }
            finally
            {
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
#endif

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

        public static bool isThisSorted(List<int> ints)
        {
            for(int i = 0; i < ints.Count -1; i++)
            {
                if (ints[i] > ints[i + 1]) return false;
            }
            return true;
        }


        /* Example of a static function */

        /// <summary>
        /// Show the list in lines of 20 numbers each
        /// </summary>
        /// <param name="label">The label for this list</param>
        /// <param name="theList">The list to show</param>
        public static void ShowList(string label, List<int> theList)
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
                if (index % 20 == 0) // when index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,3}, ", theList[index]));  // Show each number right aligned within 3 characters, with a comma and a space
            }
            Console.WriteLine();
        }
    }
}
