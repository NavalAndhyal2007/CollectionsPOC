using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPOC
{
    class Program
    {

        public delegate int SampleDelegate(int num1, int num2);

        public delegate string ShowMessageDelegate(string msg);

        public static int AddNums(int num1,int num2)
        {
            return num1 + num2;
        }

        public static CustomDictionary<int, string> AddSampleValuesToDictionary(CustomDictionary<int, string> sampleKeyValuePairs)
        {
            sampleKeyValuePairs.Add(10, "st1");
            sampleKeyValuePairs.Add(20, "st2");
            sampleKeyValuePairs.Add(40, "st4");
            sampleKeyValuePairs.Add(50, "st5");
            sampleKeyValuePairs[25] = "abc";
            sampleKeyValuePairs.Add(new KeyValuePair<int, string>(100, "Str100"));
            return sampleKeyValuePairs;
        }

        public static void PrintDictionary(CustomDictionary<int, string> sampleKeyValuePairs)
        {
            sampleKeyValuePairs.PrintKeys();
            sampleKeyValuePairs.PrintValues();
        }

        public static CustomDictionary<int, string> RemoveSampleValuesToDictionary(CustomDictionary<int, string> sampleKeyValuePairs)
        {
            sampleKeyValuePairs.Remove(20);
            return sampleKeyValuePairs;
        }

        public static void TryGetValueDictionary(CustomDictionary<int, string> sampleKeyValuePairs)
        {

            string value = "";
            sampleKeyValuePairs.TryGetValue(10, out value);

            Console.WriteLine("Key with 10 and Value : " + value);
        }

        public static void SampleContainsKeyDictionary(CustomDictionary<int, string> sampleKeyValuePairs)
        {
            if (sampleKeyValuePairs.ContainsKey(100))
            {
                Console.WriteLine("Key Found");
            }
            else
                Console.WriteLine("Key Not Found");
        }

        public static CustomArraylist AddSampleCustomArraylist(CustomArraylist customArraylist)
        {
            customArraylist.Add(10);
            customArraylist.Add("Abc");
            customArraylist.Add(10.34);
            customArraylist.Add(100);
            customArraylist.Add(102);
            customArraylist.Add(103);
            return customArraylist;
        }

        public static CustomArraylist InsertSampleCustomArraylist(CustomArraylist customArraylist)
        {
            customArraylist.Insert(2, 34.45);
            customArraylist.Insert(3, "NAVAL");
            customArraylist.Insert(4, 34);
            return customArraylist;

        }
        public static CustomArraylist RemoveAtSampleCustomArraylist(CustomArraylist customArraylist)
        {
            customArraylist.RemoveAt(7);
            customArraylist.RemoveAt(2);
            return customArraylist;
        }

        public static CustomArraylist RemoveSampleCustomArraylist(CustomArraylist customArraylist)
        {
            customArraylist.Remove("Abc");
            customArraylist.Remove("NAVAL");
            return customArraylist;
        }

        public static string AddNums(int num1, int num2,ShowMessageDelegate showMessageDelegate)
        {
            return showMessageDelegate("Addition is " + (num1 + num2));
        }

        static void Main(string[] args)
        {
            try
            {

                //SampleDelegate sampleDelegate = AddNums;
                //Console.WriteLine("Value : " + sampleDelegate(10, 20));

                CustomDictionary<int, string> keyValuePairs = new CustomDictionary<int, string>();

                keyValuePairs = AddSampleValuesToDictionary(keyValuePairs);

                PrintDictionary(keyValuePairs);

                keyValuePairs = RemoveSampleValuesToDictionary(keyValuePairs);

                SampleContainsKeyDictionary(keyValuePairs);

                TryGetValueDictionary(keyValuePairs);

                PrintDictionary(keyValuePairs);

                foreach (var item in keyValuePairs)
                {
                    Console.WriteLine("Key : " + item.Key + " Value = " + item.Value);
                }

                CustomArraylist customArraylist = new CustomArraylist();

                customArraylist = AddSampleCustomArraylist(customArraylist);

                customArraylist = InsertSampleCustomArraylist(customArraylist);

                foreach (var item in customArraylist)
                {
                    Console.WriteLine(item.ToString());
                }

                customArraylist = RemoveSampleCustomArraylist(customArraylist);

                customArraylist = RemoveAtSampleCustomArraylist(customArraylist);

                foreach (var item in customArraylist)
                {
                    Console.WriteLine(item.ToString());
                }



                List<int> listNum = new List<int>() { 1, 3, 4, 5, 6, 33, 11 };
                listNum.Add(32);
                listNum.AddRange(new List<int> { 44, 55, 66 });


                Dictionary<int, string> employeesNames =
                                new Dictionary<int, string>();

                employeesNames.Add(2, "Naval");
                employeesNames.Add(1, "Suresh");
                employeesNames.Add(3, "Adam");
                employeesNames.Add(4, "Brock");
                employeesNames.Add(5, "Roman");

                //to Update the value
                employeesNames[3] = "Naresh";
                try
                {

                    employeesNames.Add(2, "NewName");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Key Already Exists");
                }
                string str1 = "";
                if (!employeesNames.TryGetValue(3, out str1))
                    Console.WriteLine("Element Not present");

                //foreach (var item in employeesNames.Keys)
                //{
                //    Console.WriteLine("Key = " + item + " Value = " + employeesNames.GetVa(item));
                //}



                SortedList<int, string> employeesNamesSorted =
                               new SortedList<int, string>(6);

                employeesNames.Add(2, "Naval");
                employeesNames.Add(1, "Suresh");
                employeesNames.Add(3, "Adam");
                employeesNames.Add(4, "Brock");
                employeesNames.Add(5, "Roman");

                //to Update the value
                employeesNames[3] = "Naresh";
                try
                {

                    employeesNames.Add(2, "NewName");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Key Already Exists");
                }
                string str = "";
                if (!employeesNames.TryGetValue(3, out str))
                    Console.WriteLine("Element Not present");

                Console.WriteLine("Valur of Key {0} is {1}", 3, str);

                //foreach (var item in employeesNames.Keys)
                //{
                //    Console.WriteLine("Key = " + item + " Value = " + employeesNames.GetValueOrDefault(item));
                //}


                Console.ReadLine();


            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.ReadLine();
            }



            //Console.ReadLine();
        }
    }
}
