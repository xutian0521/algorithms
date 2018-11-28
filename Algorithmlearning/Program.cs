using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithmlearning
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ss=new int[4];
            ss[0]=8;
            ss[1]=7;
            ss[2]=6;
            ss[3]=5;
            sort(ss);
            int[] array = { 49, 38, 65, 97, 76, 13, 27 };
            sort(array, 0, array.Length - 1);
            Console.ReadLine();

        }
        /// <summary>
        /// 选择排序法 1
        /// </summary>
        /// <param name="group"></param>
        static void sort(int[] group)
        {
            int temp;
            int pos=0;
            for(int i=0;i< group.Length-1;i++)
            {
                pos=i;
                for(int j= i+1; j < group.Length; j++)
                {
                    if(group[j] < group[pos])
                    {
                        pos = j;
                    }
                }//第i个数与最小的数group[pos]交换
                temp=group[i];
                group[i]=group[pos];
                group[pos]=temp;
            }
        }

        /// <summary>
        ///  快速排序 -1
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int sortUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                    --high; 
                /*比key小的放左边*/
                array[low] = array[high];   
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                    ++low; 
                /*比key大的放右边*/
                array[high] = array[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;
            foreach (int i in array)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
            return high;
        }
        /// <summary>
        /// 快速排序 -2
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void sort(int[] array, int low, int high)
        {
            if (low >= high)
                return; 
            /*完成一次单元排序*/
            int index = sortUnit(array, low, high); 
            /*对左边单元进行排序*/
            sort(array, low, index - 1);
            /*对右边单元进行排序*/
            sort(array, index + 1, high);
        }   
        
    }


    
}
