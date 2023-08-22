using System;
using System.Collections.Generic;

namespace Organizer
{
    public class RotateSort
    {

        private List<int> array = new();
        //private IComparer<T> Comparer { get; set; }

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        //public List<T> Sort(List<T> input, IComparer<T> comparer)
        public List<int> Sort(List<int> input)
        {
            this.array = new List<int>(input);
            //Comparer = comparer;
            SortFunction(0, array.Count - 1);

            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            if (high <= low) return;
            //if(Comparer.Compare(low, high) >= 0) { return; }

            int pivot = Partitioning(low, high);

            SortFunction(low, pivot - 1);
            SortFunction(pivot + 1, high);

            // throw new NotImplementedException();
        }

        /// 
        /// Partition the array in a group 'low' digits (e.a. lower than a choosen pivot) and a group 'high' digits
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        /// <returns>The index in the array of the first of the 'high' digits</returns>
        private int Partitioning(int low, int high)
        {
            int pivot = new Random().Next(low, high + 1);//array[high];
            //int pivot = high;
            (array[pivot], array[high]) = (array[high], array[pivot]);
            pivot = high;
            int i = low - 1;

            for(int j = low; j <= high - 1; j++)
            {
                if (array[j] < array[pivot])
                //if (Comparer.Compare(array[j], array[pivot]) < 0)
                {
                    i++;
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }

            i++;
            (array[pivot], array[i]) = (array[i], array[pivot]);
            return i;

            //throw new NotImplementedException();
        }
    }
}
