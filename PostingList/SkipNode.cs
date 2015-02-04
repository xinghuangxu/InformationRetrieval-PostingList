using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinghuangXu.PostingList.PostingList
{
    class SkipNode : INode
    {
        private INode node;
        private INode skip;
        public SkipNode(INode node)
        {
            this.node = node;
        }
        public bool HasSkip()
        {
            return true;
        }

        public INode GetSkip()
        {
            return skip;
        }
        public void SetSkip(INode skip)
        {
            this.skip = skip;
        }

        public int GetData()
        {
            return this.node.GetData();
        }
        
        public override String ToString()
        {
            return this.GetData() + "(->" + this.GetSkip().GetData() + ") ";
        }


        public INode Next()
        {
            return this.node.Next();
        }

        public void SetNext(INode next)
        {
            this.node.SetNext(next);
        }
    }
}
