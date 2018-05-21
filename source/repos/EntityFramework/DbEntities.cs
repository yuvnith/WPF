using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class DbEntities :DbContext
    {
        public DbSet<EMPLOYEE> Empl { get; set; }
        public DbSet<DEPARTMENT> Dept { get; set; }
    }
}
