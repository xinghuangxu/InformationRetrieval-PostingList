using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinghuangXu.PostingList.PostingList;

namespace XinghuangXu.PostingList
{
    class QueryProcessor
    {
        public int SkipCount { get; set; }
        public int ComparisonCount { get; set; }

        public QueryProcessor()
        {

        }

        public PList intersect(PList p1, PList p2)
        {
            PList result = new PList(new int[0], false);
            INode pp1 = p1.GetHead();
            INode pp2 = p2.GetHead();
            while (pp1 != null && pp2 != null)
            {
                ComparisonCount++;
                if (pp1.GetData() == pp2.GetData())
                {
                    result.add(new Node(pp1.GetData()));
                    pp1 = pp1.Next();
                    pp2 = pp2.Next();
                }
                else if (pp1.GetData() < pp2.GetData())
                {
                    if (pp1.HasSkip())
                    {
                        ComparisonCount++;
                    }
                    if (pp1.HasSkip() && pp1.GetSkip().GetData() <= pp2.GetData()) //use skip
                    {
                        SkipCount++;
                        pp1 = pp1.GetSkip();
                    }
                    else//normal next
                    {
                        pp1 = pp1.Next();
                    }
                    
                }
                else
                {
                    if (pp2.HasSkip())
                    {
                        ComparisonCount++;
                    }
                    if (pp2.HasSkip() && pp2.GetSkip().GetData() <= pp1.GetData()) //use skip
                    {
                        SkipCount++;
                        pp2 = pp2.GetSkip();
                    }
                    else//normal next
                    {
                        pp2 = pp2.Next();
                    }
                }
            }
            return result;
        }
    }
}
