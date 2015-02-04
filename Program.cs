using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinghuangXu.PostingList.PositionalPosting;
using XinghuangXu.PostingList.PostingList;

namespace XinghuangXu.PostingList
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPostingList();
            TestPostionalPostingList();
            Console.ReadLine();
        }

        private static void TestPostionalPostingList()
        {
            //Build dictionary
            String fileName="PositionalIndex.txt";
            int counter = 0;
            string line;
            SearchDictionary sd = new SearchDictionary();
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                sd.Add(line);
                counter++;
            }
            file.Close();
            String word = "angels fear to tread";//"fools rush in";
            PList docList = PositionalQuery.FindDocsWithPhrase(sd, word);
            
        }

        private static void TestPostingList()
        {
            int[] data = { 3, 5, 9, 15, 24, 39, 60, 68, 75, 81, 84, 89, 92, 96, 97, 100, 115 };
            PList pl = new PList(data, true);
            Console.WriteLine(pl.ToString());

            //get the second posting list 
            String pl2String = "3 5 89 95 97 99 100 101";
            int[] pl2Data = Array.ConvertAll(pl2String.Split(' '), int.Parse);
            PList pl2 = new PList(pl2Data, false);
            Console.WriteLine(pl2.ToString());

            Console.WriteLine("Intersect:");
            QueryProcessor qp = new QueryProcessor();
            Console.WriteLine(qp.intersect(pl, pl2).ToString());

            Console.WriteLine("Skip Count:" + qp.SkipCount);
            Console.WriteLine("Comparison Count:" + qp.ComparisonCount);

            pl = new PList(data, false);
            qp.ComparisonCount = 0;
            Console.WriteLine(qp.intersect(pl, pl2).ToString());
            Console.WriteLine("Comparison Without Skip:" + qp.ComparisonCount);
        }


    }
}
