using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinghuangXu.PostingList.PostingList
{
    interface INode
    {
         int GetData();
         Boolean HasSkip();
         INode GetSkip();
         INode Next();
         void SetNext(INode next);
         void SetSkip(INode skip);
    }
}
