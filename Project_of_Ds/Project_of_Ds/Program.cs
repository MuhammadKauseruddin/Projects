using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_of_Ds
{
    class Program
    {
     public static void Main(string[] args)
        {
            int[] myarray = Program.randIntarray(20);
            introsort.sort(myarray);
            Console.WriteLine("Sorted array Elements\n");
         // print sorted array
            foreach (int var in myarray)
                Console.WriteLine("{0}",var);
            Console.ReadLine();        
        }
        //Method to generate random numbers
     public static int[] randIntarray(int n)
     {
         Random rand = new Random();
         int[] newintarray = new int[n];
         for (int i = 0; i < newintarray.Length; i++)
         {
             newintarray[i] = rand.Next(20);
         }
         return newintarray;
     }
    }

    // function to perform introsort
    public class introsort
    {
        private static int quick = 0;
        private static int heap = 0;

        public static void sort(int[] arraytosort)
        {  // Maximum depth calulate by 2*log(n)
            int depth = ((int)Math.Log(arraytosort.Length) * 2);
            introsort.sort(arraytosort, depth, 0, (arraytosort.Length - 1));
            
        }

        private static void sort(int[] arraytosort, int depth, int start, int end)
        {
            int length = arraytosort.Length;
            // Base case
            if (length <= 1)
            {
                return;
            }
            else if(depth==0)
            {
                heap++;
                introsort.heapsort(arraytosort, start, end);

            }
            else
            {
                if (start >= end)
                {
                    return;
                }
                quick++;
                int pivot = arraytosort[((start + end) / 2)];
                int index =introsort.Partition(arraytosort, start, end, pivot);
               introsort.sort(arraytosort, (depth - 1), start, index - 1);
               introsort.sort(arraytosort, (depth - 1), index, end);
            }
        }
        // Function to perform heapsort
        public static void heapsort(int[] arraytosort, int start, int end)
        {
            int heapsize = arraytosort.Length;
            for(int i=(heapsize-1)/2;i>=0;--i)
            {
                introsort.heapify(arraytosort, heapsize, i);
            }
            for(int j=arraytosort.Length-1;j>0;--j)
            {
                int temp = arraytosort[j];
                arraytosort[j] = arraytosort[0];
                arraytosort[0] = temp;
                --heapsize;
                introsort.heapify(arraytosort, heapsize, 0);
            }


        }
        private static void heapify(int[] arraytosort, int heapsize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if(left < heapsize && arraytosort[left] > arraytosort[index])
               
                largest=left;
            else
               
                largest =index;

            if (right < heapsize && arraytosort[right] > arraytosort[largest])
                largest = right;

            if(largest!=index)
            {
                int temp = arraytosort[index];
                arraytosort[index] = arraytosort[largest];
                arraytosort[largest] = temp;
                introsort.heapify(arraytosort, heapsize, largest);
            }
           

        }

        private static int Partition(int[] arraytosort, int start, int end, int pivot)
        {
            while ((start <= end))
            {
                while ((arraytosort[start]) < pivot)
                {
                    start++;
                }

                while ((arraytosort[end]) > pivot)
                {
                    end--;
                }

                if ((start <= end))
                {
                    int temp = arraytosort[start];
                    arraytosort[start] = arraytosort[end];
                    arraytosort[end] = temp;
                    start++;
                    end--;
                }

            }
            return start;
        }
    }
}
