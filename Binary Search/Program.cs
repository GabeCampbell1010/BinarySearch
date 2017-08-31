using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

//this includes the selection sorting algorithm

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder csv = new StringBuilder();
            Random num = new Random();
            //int number = 0;//del

            for (int i = 1000; i <= 100000; i += 1000)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    list.Add(j);//just add a value matching each index

                    //number = num.Next(number + 1, number + 2);//del
                    //list.Add(number);//still sorted but random numbers going up to a value as high as //del
                }
                foreach(int numb in list)
                {
                    //Console.Write(numb + " ");
                }

                System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();//start stopwatch
                for (int j = 0; j < 1000000; j++)//just one binary search per list, or a million like last week?
                {
                    int value = num.Next(0, list.Count);//get a random value from the list list (indexes and values are equal here, so this works, but is this what the prof wants?)
                    //int value = num.Next(0, number);//del
                    int selection = BinarySearch.Search(list, value);
                    
                }
                watch.Stop();//end stopwatch

                long timeElapsedInMilliseconds = watch.ElapsedMilliseconds;//time elapses for a million searches on list of size i

                Console.WriteLine("A list of size: {0} took {1} milliseconds to binary search", list.Count, timeElapsedInMilliseconds);
                //Console.WriteLine($"{list.Count},{timeElapsedInMilliseconds}");
                string newLine = $"{list.Count},{timeElapsedInMilliseconds}";
                csv.AppendLine(newLine);
            }
            string filePath = @"C:\Users\Gabe\Documents\BinarySearch.ods";//this was the file path local to my computer of course
            string csvString = csv.ToString();
            File.WriteAllText(filePath, csvString);
            Console.ReadKey();
        }
    }

    public static class BinarySearch
    {
        public static int Search(List<int> list, int value)
        {
            //int valueIndex = 0;
            int startIndex = 0;
            int endIndex = list.Count - 1;
            int midIndex = (endIndex + startIndex)/2;

            while (true)
            {
                try
                {
                    midIndex = (endIndex + startIndex) / 2;
                    if (list[midIndex] == value)
                        break;
                    else if (value > list[midIndex])
                    {
                        startIndex = midIndex + 1;
                        
                    }
                    else if (value < list[midIndex])
                    {
                        endIndex = midIndex - 1;
                        
                    }
                    if (startIndex > endIndex)
                    {
                        break;
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.Message);
                    throw new System.ArgumentOutOfRangeException("the midIndex is out of range of the list.", e);
                }
                catch(Exception e)
                {
                    throw new System.Exception("unknown exception", e);
                }
            }
            //Debug.Assert(list[midIndex] == value);
            return midIndex;
        }
    }

    
}
