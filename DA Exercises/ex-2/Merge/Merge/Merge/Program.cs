using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    internal class Program
    {
        static int[] MergeSort(int[] array, int k)
        {
            if (array.Length <= 1)
                return array;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, left, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            int[] sortedLeft = MergeSort(left, k);
            int[] sortedRight = MergeSort(right, k);

            return Merge(sortedLeft, sortedRight, k);
        }

        static int[] Merge(int[] left, int[] right, int k)
        {
            int i = 0;
            int j = 0;
            int[] result = new int[left.Length + right.Length];

            for (int r = 0; r < result.Length; r++)
            {
                if (i >= left.Length)
                {
                    result[r] = right[j];
                    j++;
                }
                else if (j >= right.Length)
                {
                    result[r] = left[i];
                    i++;
                }
                else if (left[i] < right[j])
                {
                    result[r] = left[i];
                    i++;
                }
                else
                {
                    result[r] = right[j];
                    j++;
                }
            }

            // اضافه کردن زمان ادغام به زمان اجرای الگوریتم
            k += result.Length;

            // نوشتن طول قسمت جدید بر روی کاغذ
            Console.WriteLine(result.Length);

            return result;
        }

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
                array[i] = int.Parse(Console.ReadLine());

            MergeSort(array, k);

            // چاپ زمان کل اجرای الگوریتم
            Console.WriteLine(k);
            Console.ReadLine();
        }
    }
}
