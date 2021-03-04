using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Models
{
    public class TransientDependency
    {
        public Guid guid { get; set; } = Guid.NewGuid();
    }

    public class ScopDependency
    {
        public Guid guid { get; set; } = Guid.NewGuid();
    }


    public class SingletonDependency
    {
        public Guid guid { get; set; } = Guid.NewGuid();
    }
}
