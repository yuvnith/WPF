using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    public interface IPhone
    {
        int id { get; set; }
        string releasedate { get; set; }
    }

    public interface ISmartPhone : IPhone
    {
       int version { get; set; }
    }


    public interface IBasicPhone : IPhone
    {
        int simslots { get; set; }
    }
}
