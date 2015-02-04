using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinghuangXu.PostingList.PostingList;

namespace XinghuangXu.PostingList.PositionalPosting
{
    class PositionalPostingList
    {
        public String Word { get; set; }
        public List<DocWordPositionList> DocWordPositions { get; set; }

        public PositionalPostingList(string word)
        {
            Word = word;
            DocWordPositions = new List<DocWordPositionList>();
        }

        public PositionalPostingList(string word,string data):this(word)
        {
            
            String[] docs = data.Trim().Split(';');
            
            foreach (String list in docs)
            {
                
                if (list != "")
                {
                    DocWordPositions.Add(new DocWordPositionList(list));
                }
            }
        }

        public void AddDoc(DocWordPositionList doc)
        {
            DocWordPositions.Add(doc);
        }

        internal static Tuple<PositionalPostingList,PositionalPostingList> PositionalIntersect(PositionalPostingList ppList1, PositionalPostingList ppList2,int k)
        {
            PositionalPostingList nPPList1 = new PositionalPostingList(ppList1.Word);
            PositionalPostingList nPPList2 = new PositionalPostingList(ppList2.Word);
            List<DocWordPositionList> p1 = ppList1.DocWordPositions;
            List<DocWordPositionList> p2 = ppList2.DocWordPositions;
            int i = 0, j = 0;
            while(i<p1.Count&&j<p2.Count){
                if (p1.ElementAt(i).DocId == p2.ElementAt(i).DocId)
                {
                    Tuple <DocWordPositionList,DocWordPositionList> result=DocWordPositionList.PositionalIntersect(p1.ElementAt(i), p2.ElementAt(i), k);
                    nPPList1.AddDoc(result.Item1);
                    nPPList2.AddDoc(result.Item2);
                    i++;
                    j++;
                }
                else if (p1.ElementAt(i).DocId < p2.ElementAt(i).DocId)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return new Tuple<PositionalPostingList, PositionalPostingList>(nPPList1, nPPList2);
        }


        internal PList GetDocPList()
        {
            PList result=new PList();
            foreach (DocWordPositionList doc in DocWordPositions)
            {
                result.add(new Node(doc.DocId));
            }
            return result;
        }
    }
}
