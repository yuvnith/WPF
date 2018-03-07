using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class CusomizedCollection :Collection<String>
    {
        protected override void InsertItem(int index, string item)
        {
            if (String.IsNullOrEmpty(item))
                throw new Exception("cannot add blank string ");
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            if (String.IsNullOrEmpty(item))
                throw new Exception("cannot add blank string ");
            base.SetItem(index, item);
        }
    }
}
