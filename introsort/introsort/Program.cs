using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introsort
{
    //  A Program to sort the given array using Introsort.
    class Program
    {
        //  Driver Program to test Introsort
        static void Main(string[] args)
        {
           
            Console.WriteLine("enter array size or total numbers to be sorted : ");

                int n = Convert.ToInt16(Console.ReadLine());
                int[] a = new int[n];
          
            Console.WriteLine("======================");
            Console.WriteLine(" UNSORTED ARRAY ");
            Console.WriteLine("======================");

            // generating random numbers in array then print the unsorted array elements
            Random obj = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = obj.Next(100);
                Console.WriteLine(a[i]);
            }

            // get maximum depth
            int maximumdepth = Convert.ToInt16(2 * Math.Log(a.Length));

            int start = 0, end = a.Length - 1;

            // Pass the reference array , starting index , ending index and maximum depth to Introsort Function.
            Program.introsort(ref a, start, end, maximumdepth);

            Console.WriteLine("=====================");
            Console.WriteLine(" SORTED ARRAY ");
            Console.WriteLine("=====================");

            // printing sorted array
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(a[j]);
            }

        }

        // Function to perform Introsort on unsorted array elements.
        static void introsort(ref int[] array, int start, int end, int maxdepth)
        {
            // calculating length of array through length method while passing refernece of array , start index and end index
            int leng = length(ref array, start, end);

            if (leng <= 1)
            {
                // base case
                // array is sorted so return the sorted array
                return;
            }

            else if (maxdepth == 0)
            {
                //use heapsort if maximumdepth equals to zero by passing reference of unsorted array.
                heapsort(ref array);

            }

            else
            {
                //perform Quick sort
                int partitionpos = partition(array, start, array.Length - 1);

                introsort(ref array, 0, partitionpos - 1, maxdepth - 1);

                introsort(ref array, partitionpos + 1, leng, maxdepth - 1);

            }

        }

        static int length(ref int[] array2, int beginning, int ending)
        {
            int len = 0;

            if ( beginning <= ending ) 
            {
                for ( int i = beginning ; i <= ending ; i++ )
                {
                    len++;
                }

            }

            return len;
        }

        //  A function to partition the given array and to return the partition position
        static int partition(int[] a, int start, int end)
        {
            int tem;
            int left = start; int right = end;
            int pivot = a[start];  // Pivot

            // find pivot position until left index is less than right index.
            while (left < right)
            {
                // until current left index value is less than pivot value increment left index by 1. 
                while ( a[left] < pivot )
                { 
                    left++;
                }

                // until current right index value is greater than pivot value decrement right index by 1.
                while ( a[right] > pivot )
                {
                    right--;
                }

                if ( left < right )
                {
                    //swap left index value and right index value
                    tem = a[left];
                    a[left] = a[right];
                    a[right] = tem;

                    //if left index value and right index value is same then increment left index by 1.
                    if (a[left] == a[right])
                        left++;

                }
                else
                {
                    return right;
                }

            }

            //returning correct position of pivot
            return right;
        }

        // Implementing Heapsort
        static void heapsort(ref int[] array1)
        {
            int heapsize = array1.Length; // array length is the heapsize for creating heap

            // Build heap ( Rearrange array )
            for ( int m = (heapsize / 2) - 1; m >= 0; m-- )
            {
                heapify(ref array1, heapsize, m);
            }

            // remove an element from heap
            // one by one
            for ( int n = array1.Length - 1; n >= 0; n-- )
            {
                int temp = array1[n];
                array1[n] = array1[0];
                array1[0] = temp;

                --heapsize;
                // creates maximum heap on the reduced heap by calling heapify function.
                heapify( ref array1 , heapsize , 0 );
            }

        }

        // creates heap of subtree
        static void heapify(ref int[] array3, int x, int y)
        {
            int max = 0;
            int r = (y + 1) * 2; // right child 
            int l = ((y + 1) * 2) - 1; // left child

            if ( l < x && array3[l] > array3[y] )
            {
                max = l;
            }
            else
            {
                max = y;
            }
            if ( r < x && array3[r] > array3[max] )
            {
                max = r;
            }
            if ( max != y )
            {
                int temp;
                temp = array3[y];
                array3[y] = array3[max];
                array3[max] = temp;

                // recursively heapify the affected sub-tree
                heapify( ref array3 , x , max );
            }
        }

    }
}