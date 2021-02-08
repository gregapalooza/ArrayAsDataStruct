using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Name: Greg Vaggalis
/// Date: 2/7/2021
/// </summary>
namespace ArraysDataStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int[] arry = new int[1000];
            // Fills original array with numbers
            for(int i = 0; i< arry.Length; i++)
            {
                arry[i] = rand.Next(1000);
            }

            DisplayArray(arry); // Displays unsorted
            Console.WriteLine();
            SortArray(arry); // Displays sorted
            AddToArray(arry);


            Console.ReadLine();
        }

        /// <summary>
        /// Method displays the contents of an array
        /// </summary>
        /// <param name="arry"></param>
        static void DisplayArray(int[] arry)
        {
            foreach (int i in arry)
            {
                Console.Write("{0, -6}", i);
            }
        }

        /// <summary>
        /// Ask user to supply numbers to add to array
        /// </summary>
        /// <param name="a"></param>
        static void AddToArray(int[] a)
        {
            char input = 'Y';
            
            do
            {
                Console.WriteLine("Please add a number.");
                int n = (int)Convert.ToInt64(Console.ReadLine());
                int m = CheckNumber(n, a, 0, (a.Length - 1)); // checks to see if number is in array

                if (m == -1)
                {
                    // if number not found it is added
                    Console.WriteLine("Not in here, adding...");

                    a = WriteNewArray(a, n); // creates new array of incresed size
                }
                else
                {
                    // if number found its index is noted
                    Console.WriteLine("Index " + m);
                }

                Console.WriteLine("\nWould you like to add another number?");
                input = Convert.ToChar(Console.ReadLine());

            } while (input == 'Y' || input == 'y');
        }

        /// <summary>
        /// Adds users number to exist array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static int[] WriteNewArray(int[] a, int k)
        {
            int[] b = new int[a.Length + 1];

            // add contents of old array to new one
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            // add user's number 
            b[b.Length - 1] = k;
            // A sort and display
            SortArray(b);

            return b;
        }

        /// <summary>
        /// Method uses a binary search to find if number is located in the array
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static int CheckNumber(int n, int[] a, int min, int max)
        {
            if(max >= min)
            {
                int mid = (int) Math.Ceiling((double)(min + (max - 1)) / 2); // Important that the mid rounds to a whole number

                if(a[mid] == n)
                {
                    return mid; // If found immediatley
                }
                // recursive methods used to keep widdling down guesses till number is found
                // or results in the outside if loop is broken
                if(a[mid] > n)
                {
                    return CheckNumber(n, a, min, mid - 1);
                }
                else
                {
                    return CheckNumber(n, a, mid + 1, max);
                }
            }

            return -1;  // If no match is found
            
        }

        /// <summary>
        /// Using the counting method this sorts an array from smallest to largest
        /// </summary>
        /// <param name="arry"></param>
        static void SortArray(int[] arry)
        {
            int k = arry.Length;

            // Array for the sort
            int[] output = new int[k];
            // Array to count instance of each specific numbers 
            int[] count = new int[k];

            // Make each element in count array 0
            for (int i = 0; i < k; ++i)
            {
                count[i] = 0;
            }
            
            // Take count index and add number of instances to 
            // it from original arry array
            for (int i = 0; i < k; ++i)
            {
                ++count[arry[i]];
            }

            // Starting at index 1, add element from previous index 
            // to index of loop interation
            for (int i = 1; i <= k - 1; ++i)
            {
                count[i] += count[i - 1];
            }    

            // Starting at the end of original array,
            // count[arry[i]]-1] corresponds to the index of output
            // that equals the index of arry[i]
            for (int i = k - 1; i >= 0; i--)
            {
                // Console.WriteLine(count[arry[i]] - 1); // use this to see how output corresponds to arry
                output[count[arry[i]] - 1] = arry[i];
                --count[arry[i]];
            }

            // Combination of sorted array back to original passed array
            for (int i = 0; i < k; ++i)
            {
                arry[i] = output[i];
            }

            DisplayArray(arry);
        }
    }
}
