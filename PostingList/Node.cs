using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinghuangXu.PostingList.PostingList
{
    class Node:INode
    {
        protected int data;
        protected INode next;

        public int GetData(){
            return data;
        }

        public Node(int val)
        {
            this.data = val;
        }

        public bool HasSkip()
        {
            return false;
        }

        public INode GetSkip()
        {
            return null;
        }

        public INode Next()
        {
            return this.next;
        }

        public void SetSkip(INode skip)
        {
            throw new NotImplementedException();
        }


        public void SetNext(INode next)
        {
            this.next = next;
        }

        public override String ToString()
        {
            return this.data + " ";
        }
    }
}
