using System;
using System.Collections.Generic;

namespace Organizer
{
    public class ShiftHighestSort
    {
        private List<int> array = new List<int>();
        private int count = 0;

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public List<int> Sort(List<int> input)
        {
            array = new List<int>(input);

            SortFunction(0, array.Count - 1);
            return array;
        }

        /// <summary>
        /// Sort the array from low to high
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            for (int i = low; i < high; i++)
            {
                int x = array[i];
                int y = array[i + 1];
                if (x > y)
                {
                    array[i] = y; array[i + 1] = x;
                }
            }
            count++;
            if (count < array.Count - 1)
            {
                SortFunction(low, high - 1);
            }
            ///throw new NotImplementedException();
        }
    }
}
