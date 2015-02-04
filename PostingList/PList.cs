using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinghuangXu.PostingList.PostingList
{
    class PList
    {
        private INode head;
        private INode tail;
        private const int SKIPPED_SIZE = 4;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            INode temp = head.Next();
            while (temp != null)
            {
                sb.Append(temp.ToString());
                temp = temp.Next();
            }
            return sb.ToString();
        }

        private void init()
        {

            this.head = new Node(0);
            head.SetNext(this.tail);
            this.tail = null;
        }

        public PList()
        {
            this.init();
        }

        public PList(int[] data, Boolean skip)
        {
            this.init();
            InitializeList(data, skip);
        }

        private void InitializeList(int[] data, bool skip)
        {
            INode temp;
            INode[] array = new INode[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                temp = new Node(data[i]);
                if (skip && (i % SKIPPED_SIZE == 0) && (i + SKIPPED_SIZE < data.Length))
                {

                    temp = new SkipNode(temp);
                }
                array[i] = temp;
                this.add(temp);
            }
            if (skip) //set the skip pointers
            {
                for (int i = 0; i < data.Length; i = i + SKIPPED_SIZE)
                {
                    if (array[i].HasSkip())
                    {
                        array[i].SetSkip(array[i + SKIPPED_SIZE]);
                    }
                }
            }

        }

        public void add(INode temp)
        {
            if (this.tail == null)
            {
                this.head.SetNext(temp);
                this.tail = temp;
            }
            else
            {
                this.tail.SetNext(temp);
                this.tail = temp;
            }
        }

        internal INode GetHead()
        {
            return this.head.Next();
        }

        internal static Tuple<PList,PList> PositionalIntersect(PList p1, PList p2, int k)
        {
            PList result1 = new PList(new int[0], false);
            PList result2 = new PList(new int[0], false);
            INode pp1 = p1.GetHead();
            INode pp2 = p2.GetHead();
            while (pp1 != null && pp2 != null)
            {
                if ((pp2.GetData()-pp1.GetData())==k)
                {
                    result1.add(new Node(pp1.GetData()));
                    result2.add(new Node(pp2.GetData()));
                    pp1 = pp1.Next();
                    pp2 = pp2.Next();
                }
                else if (( pp2.GetData()-pp1.GetData()) < k)
                {
                    pp2 = pp2.Next();
                }
                else
                {
                    pp1 = pp1.Next();
                }
            }
            return new Tuple<PList,PList>(result1,result2);
        }
    }
}
