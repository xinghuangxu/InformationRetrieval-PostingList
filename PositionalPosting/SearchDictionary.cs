using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinghuangXu.PostingList.PositionalPosting
{
    class SearchDictionary
    {
        private Dictionary<String, PositionalPostingList> dic;

        public SearchDictionary()
        {
            dic = new Dictionary<string, PositionalPostingList>();

        }

        public PositionalPostingList GetPostingList(String key){
            return dic[key];
        }

        internal void Add(string line)
        {
            String key = line.Substring(0, line.IndexOf(':'));
            PositionalPostingList ppl = new PositionalPostingList(key,line.Substring(line.IndexOf(':')));
            dic.Add(key, ppl);
        }
    }
}
