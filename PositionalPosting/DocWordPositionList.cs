using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinghuangXu.PostingList.PostingList;

namespace XinghuangXu.PostingList.PositionalPosting
{
    class DocWordPositionList
    {

        public int DocId { get; set; }
        public PList PostingList { get; set; }

        public DocWordPositionList(int docId,PList plist)
        {
            this.DocId = docId;
            this.PostingList = plist;
        }

        public DocWordPositionList(string list)
        {
            String[] splits = list.Split(':');
            if (splits.Length == 3)
            {
                splits[0] = splits[1]; //docid
                splits[1] = splits[2]; //list of positions
            }
            this.DocId = int.Parse(splits[0]);
            int[] data = Array.ConvertAll(splits[1].Substring(2, splits[1].Length - 3).Split(','), int.Parse);
            this.PostingList = new PList(data, false);

        }

        internal static Tuple<DocWordPositionList, DocWordPositionList> PositionalIntersect(DocWordPositionList dwp1, DocWordPositionList dwp2, int k)
        {
            Tuple<PList,PList> result = PList.PositionalIntersect(dwp1.PostingList,dwp2.PostingList,k);
            return new Tuple<DocWordPositionList, DocWordPositionList>(new DocWordPositionList(dwp1.DocId,result.Item1),new DocWordPositionList(dwp2.DocId,result.Item2));
        }
    }
}