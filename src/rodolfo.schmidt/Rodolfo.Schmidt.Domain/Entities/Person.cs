using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
