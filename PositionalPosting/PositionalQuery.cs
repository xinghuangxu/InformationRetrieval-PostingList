using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinghuangXu.PostingList.PostingList;

namespace XinghuangXu.PostingList.PositionalPosting
{
    class PositionalQuery
    {
        public static PList FindDocsWithPhrase(SearchDictionary sd, String phrase)
        {
            PList result = new PList();
            String[] terms = phrase.Split(' ');
            PositionalPostingList[] pplArray = new PositionalPostingList[terms.Length];
            for (int i = 0; i < terms.Length;i++ )
            {
                pplArray[i] = sd.GetPostingList(terms[i]);
            }
            for (int i = 0; i < terms.Length-1; i++)
            {
                for (int j = i+1; j < terms.Length; j++)
                {
                    Tuple<PositionalPostingList, PositionalPostingList> tppList = PositionalPostingList.PositionalIntersect(pplArray[i], pplArray[j],j-i);
                    pplArray[i] = tppList.Item1;
                    pplArray[j] = tppList.Item2;
                }
            }
            return pplArray[0].GetDocPList();
        }
    }
}
